using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Working_Reminder
{
    enum WorkState{
        None,
        Relax,
        Work,
        OtherWork,
    };
    public partial class MainForm : Form
    {
        int mPreMousePos = 0;

        WorkState mWorkState = WorkState.Work;
        Dictionary<string, int> mListAppTime = new Dictionary<string, int>();

        int mRelaxCount = 0;
        int mCheckinCount = 0;

        int mPauseTime = 0;
        int mTempWork = 0;
        int mOtherAppTime = 0;
        int mWorkingTime = 0;
        int mPCTime = 0;
        int mTimer25m = 0;
        int _1MIN = 60;
        int _5MIN = 300;
        int _25MIN = 1500;

        Point mOldLocation = new Point();
        public MainForm()
        {
            InitializeComponent();
            Width = 0;
            Height = 0;
#if DEBUG
            _1MIN = 5;
            _5MIN = 10;
            _25MIN = 15;
#endif
        }
        private void btnCheckin_Click(object sender, EventArgs e)
        {
            mCheckinCount++;
            btnCheckin.Text = "I'm Working (" + mCheckinCount.ToString() + ")";
            mTimer25m = _25MIN;
            mWorkState = WorkState.OtherWork;
            btnCheckin.Visible = false;
            btnRelax.Visible = false;
        }
        private void btnRelax_Click(object sender, EventArgs e)
        {
            mRelaxCount++;
            btnRelax.Text = "Relax(" + mRelaxCount.ToString() + ")";
            mTimer25m = _25MIN;
            mWorkState = WorkState.Relax;
            btnCheckin.Visible = false;
            btnRelax.Visible = false;
        }
        private void btnCheckinMask_Click(object sender, EventArgs e)
        {
            btnCheckin.Visible = true;
            btnRelax.Visible = true;
        }

        private bool isWorkingApp(string appName)
        {
            if (appName.Contains("terminal")) return true;
            if (appName.Contains("Forex Simulator")) return true;
            return false;
        }
        private void CreateMask()
        {
            foreach (var screen in Screen.AllScreens)
            {
                Form maskForm = new Form();
                maskForm.FormBorderStyle = FormBorderStyle.None;
                maskForm.WindowState = FormWindowState.Maximized;
                maskForm.TopMost = true;
                maskForm.BackColor = Color.Black;
                maskForm.Opacity = 0.8; // Độ trong suốt
                maskForm.ShowInTaskbar = false;
                maskForm.StartPosition = FormStartPosition.Manual;
                maskForm.Location = screen.Bounds.Location;
                maskForm.Size = screen.Bounds.Size;
                maskForm.MouseClick += (sender, e) => this.BringToFront();
                maskForm.Show();
            }

            // Đảm bảo main form luôn ở trên tất cả các mask form
            this.TopMost = true;
            this.BringToFront();
        }

        private void RemoveMasks()
        {
            var masksToRemove = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                if (form != this && form.Opacity == 0.8 && form.BackColor == Color.Black)
                {
                    masksToRemove.Add(form);
                }
            }
            foreach (Form mask in masksToRemove)
            {
                mask.Close();
            }
        }

        private void updateHMI()
        {
            if (mWorkState != WorkState.None)
            {
                if (ShowInTaskbar == true)
                {
                    ShowInTaskbar = false;
                    WindowState = FormWindowState.Normal;
                    Width = 0;
                    Height = 0;
                    Location = mOldLocation;
                    RemoveMasks();
                }
                if (mWorkState == WorkState.Relax)
                {
                    Text = "Relax(" + mRelaxCount.ToString() + ")  "
                           + TimeSpan.FromSeconds(mTimer25m).ToString(@"mm\:ss");
                    return;
                }
                if (mWorkState == WorkState.OtherWork)
                {
                    Text = "🍅 " + TimeSpan.FromSeconds(mTimer25m).ToString(@"mm\:ss") + "/"
                                 + TimeSpan.FromSeconds(mWorkingTime).ToString(@"hh\:mm\:ss");
                    return;
                }
                if (mWorkState == WorkState.Work || mWorkState == WorkState.OtherWork)
                {
                    Text = "💲💲💲 " + TimeSpan.FromSeconds(mWorkingTime).ToString(@"hh\:mm\:ss");
                }
            }
            else
            {
                // Create Notification
                if (ShowInTaskbar == false)
                {
                    ShowInTaskbar = true;
                    mOldLocation = Location;
                    Width = 500;
                    Height = 350;
                    txtHistory.Text  = "PC Time: "  + TimeSpan.FromSeconds(mPCTime).ToString(@"hh\:mm") + "\r\n";
                    txtHistory.Text += "Work   : "  + TimeSpan.FromSeconds(mWorkingTime).ToString(@"hh\:mm") + "\r\n";
                    txtHistory.Text += "Percent:  " + (mWorkingTime*100/mPCTime).ToString() + "%\r\n";
                    txtHistory.Text += "----------------------------------------\r\n";
                    var orderedList = mListAppTime.OrderByDescending(kv => kv.Value);
                    foreach (var kv in orderedList)
                    {
                        txtHistory.Text += "- " + TimeSpan.FromSeconds(kv.Value).ToString(@"hh\:mm\:ss") + "\t" + kv.Key + "\r\n";
                    }
                    CreateMask();
                }
                Screen screen = Screen.FromPoint(Cursor.Position);
                int x = (screen.WorkingArea.Width - Width) / 2 + screen.WorkingArea.Left;
                int y = (screen.WorkingArea.Height - Height) / 2 + screen.WorkingArea.Top;
                Location = new Point(x, y);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mWorkState == WorkState.None)
            {
                mOtherAppTime = 0;
                updateHMI();
                return;
            }
            string curApp = User32Tool.GetActiveWindowProcess();

            bool bWorkingAppFg = isWorkingApp(curApp);
            if (mPauseTime < _5MIN)
            {
                if (mListAppTime.ContainsKey(curApp) == false) mListAppTime.Add(curApp, 0);
                mListAppTime[curApp]++;
                mPCTime++;
            }
            if (mPreMousePos == Cursor.Position.X) mPauseTime++;
            else
            {
                mPreMousePos = Cursor.Position.X;
                mPauseTime = 0;
            }

            if (bWorkingAppFg == false) mOtherAppTime++;
            else mOtherAppTime = 0;

            if (mWorkState == WorkState.Relax || mWorkState == WorkState.OtherWork) mTimer25m--;

            if (mWorkState == WorkState.Relax)
            {
                // Check timer 25
                if (mTimer25m < 0) mWorkState = WorkState.None;
                // Check work in relax timer 1
                if (bWorkingAppFg) mTempWork++;
                else mTempWork = 0;
                if (mTempWork > _1MIN) mWorkState = WorkState.Work;
            }
            else if (mWorkState == WorkState.OtherWork)
            {
                mWorkingTime++;
                // Check timer 25
                if (mTimer25m < 0) mWorkState = WorkState.None;
                if (bWorkingAppFg) mWorkState = WorkState.Work;
            }
            else if (mWorkState == WorkState.Work)
            {
                // Check pause timer
                mWorkingTime++;
                if (mOtherAppTime > _25MIN) mWorkState = WorkState.None;
                if (mPauseTime > _5MIN) mWorkState = WorkState.None;
            }

            updateHMI();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
