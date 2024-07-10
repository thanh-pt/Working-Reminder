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

        DataMgr dataMgr;
        WorkState mWorkState = WorkState.Work;

        int mRelaxCount = 0;
        int mCheckinCount = 0;

        int mPauseTime = 0;
        int mTempWork = 0;
        int mTimer25m = 0;
        int mDpWkSs = 0;
        int _1MIN = 60;
        int _5MIN = 300;
        int _25MIN = 1500;

        int MAX_WIDTH = 500;
        int MAX_HEIGHT = 315;
        bool mReqClose = false;
        Point mOldLocation = new Point();
        Dictionary<int, Control> mListWorkPanel = new Dictionary<int, Control>();
        Dictionary<int, Control> mListRelaxPanel = new Dictionary<int, Control>();
        public MainForm()
        {
            InitializeComponent();
            Width = 0;
            Height = 0;
            mListWorkPanel.Add(7 , wk7);
            mListWorkPanel.Add(8 , wk8);
            mListWorkPanel.Add(9 , wk9);
            mListWorkPanel.Add(10, wk10);
            mListWorkPanel.Add(11, wk11);
            mListWorkPanel.Add(12, wk12);
            mListWorkPanel.Add(13, wk13);
            mListWorkPanel.Add(14, wk14);
            mListWorkPanel.Add(15, wk15);
            mListWorkPanel.Add(16, wk16);
            mListWorkPanel.Add(17, wk17);
            mListWorkPanel.Add(18, wk18);
            mListWorkPanel.Add(19, wk19);
            mListWorkPanel.Add(20, wk20);
            mListWorkPanel.Add(21, wk21);
            mListWorkPanel.Add(22, wk22);

            mListRelaxPanel.Add(7 , rlx7);
            mListRelaxPanel.Add(8 , rlx8);
            mListRelaxPanel.Add(9 , rlx9);
            mListRelaxPanel.Add(10, rlx10);
            mListRelaxPanel.Add(11, rlx11);
            mListRelaxPanel.Add(12, rlx12);
            mListRelaxPanel.Add(13, rlx13);
            mListRelaxPanel.Add(14, rlx14);
            mListRelaxPanel.Add(15, rlx15);
            mListRelaxPanel.Add(16, rlx16);
            mListRelaxPanel.Add(17, rlx17);
            mListRelaxPanel.Add(18, rlx18);
            mListRelaxPanel.Add(19, rlx19);
            mListRelaxPanel.Add(20, rlx20);
            mListRelaxPanel.Add(21, rlx21);
            mListRelaxPanel.Add(22, rlx22);
#if DEBUG
            _1MIN = 5;
            _5MIN = 10;
            _25MIN = 15;
#endif
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            dataMgr = new DataMgr();
            dataMgr.loadData();
            foreach (var kv in dataMgr.mAllData)
            {
                listDate.Items.Add(kv.Key);
            }
        }
        private void btnCheckin_Click(object sender, EventArgs e)
        {
            mCheckinCount++;
            btnCheckin.Text = "I'm Working (" + mCheckinCount.ToString() + ")";
            mTimer25m = _25MIN;
            mWorkState = WorkState.OtherWork;
        }
        private void btnRelax_Click(object sender, EventArgs e)
        {
            mRelaxCount++;
            btnRelax.Text = "Relax(" + mRelaxCount.ToString() + ")";
            mTimer25m = _25MIN;
            mWorkState = WorkState.Relax;
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

        private void loadHistory(string dateStr)
        {
            if (dataMgr.mAllData[dateStr].PCTime != 0)
            {
                //💻 00:00  ~  ⛏ 00:00  ~  👌 100%
                lbPerformance.Text = "💻 " + TimeSpan.FromSeconds(dataMgr.mAllData[dateStr].PCTime).ToString(@"hh\:mm") + "  ~  ";
                lbPerformance.Text += "⛏ " + TimeSpan.FromSeconds(dataMgr.mAllData[dateStr].WorkTime).ToString(@"hh\:mm") + "  ~  ";
                lbPerformance.Text += "👌 " + (dataMgr.mAllData[dateStr].WorkTime * 100 / dataMgr.mAllData[dateStr].PCTime).ToString() + "%\r\n";
            }
            else
            {
                lbPerformance.Text = "NoData";
            }
            

            if (dataMgr.mAllData[dateStr].ListUsedApp != null)
            {
                txtHistory.Text = "";
                var orderedList = dataMgr.mAllData[dateStr].ListUsedApp.OrderByDescending(kv => kv.Value);
                foreach (var kv in orderedList)
                {
                    txtHistory.Text += "- " + TimeSpan.FromSeconds(kv.Value).ToString(@"hh\:mm\.ss") + "\t" + kv.Key + "\r\n";
                }
            }
            else
            {
                txtHistory.Text = "NoData";
            }

            if (dataMgr.mAllData[dateStr].ListWorkBlock != null)
            {
                lbNoBlockData.Visible = false;
                int blockHeight = panelBg.Height - 2;
                int wrkHeight = 0;
                int rlxHeight = 0;
                foreach (var kv in dataMgr.mAllData[dateStr].ListWorkBlock)
                {
                    wrkHeight = blockHeight * kv.Value / 3600;
                    rlxHeight = blockHeight * dataMgr.mAllData[dateStr].ListRelaxBlock[kv.Key] / 3600;
                    mListWorkPanel[kv.Key].Height = wrkHeight;
                    mListWorkPanel[kv.Key].Location = new Point(mListWorkPanel[kv.Key].Location.X, lb7oclock.Location.Y - wrkHeight - 1);
                    mListRelaxPanel[kv.Key].Height = rlxHeight;
                    mListRelaxPanel[kv.Key].Location = new Point(mListRelaxPanel[kv.Key].Location.X, mListWorkPanel[kv.Key].Location.Y - rlxHeight);
                }
            }
            else
            {
                lbNoBlockData.Visible = true;
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
                    Text = "🎵 " + TimeSpan.FromSeconds(mTimer25m).ToString(@"mm\.ss") + " / "
                                 + TimeSpan.FromSeconds(dataMgr.mData.WorkTime).ToString(@"hh\:mm");
                    return;
                }
                if (mWorkState == WorkState.OtherWork)
                {
                    Text = "🍅 " + TimeSpan.FromSeconds(mTimer25m).ToString(@"mm\.ss") + " / "
                                 + TimeSpan.FromSeconds(dataMgr.mData.WorkTime).ToString(@"hh\:mm");
                    return;
                }
                if (mWorkState == WorkState.Work)
                {
                    Text = "⛏ " + TimeSpan.FromSeconds(mDpWkSs).ToString(@"mm\.ss") + " / "
                                 + TimeSpan.FromSeconds(dataMgr.mData.WorkTime).ToString(@"hh\:mm");
                }
            }
            else
            {
                // Create Notification
                if (ShowInTaskbar == false)
                {
                    ShowInTaskbar = true;
                    mOldLocation = Location;
                    Width = MAX_WIDTH;
                    Height = MAX_HEIGHT;
                    CreateMask();
                    loadHistory(dataMgr.mTodayStr);
                    dataMgr.storeData();
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
                updateHMI();
                return;
            }
            string curApp = User32Tool.GetActiveWindowProcess();

            bool bWorkingAppFg = isWorkingApp(curApp);
            if (mPauseTime < _5MIN)
            {
                if (dataMgr.mData.ListUsedApp.ContainsKey(curApp) == false) dataMgr.mData.ListUsedApp.Add(curApp, 0);
                dataMgr.mData.ListUsedApp[curApp]++;
                dataMgr.mData.PCTime++;
            }
            if (mPreMousePos == Cursor.Position.X) mPauseTime++;
            else
            {
                mPreMousePos = Cursor.Position.X;
                mPauseTime = 0;
            }

            if (mWorkState == WorkState.Relax || mWorkState == WorkState.OtherWork) mTimer25m--;

            if (mWorkState == WorkState.Relax)
            {
                if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 22) dataMgr.mData.ListRelaxBlock[DateTime.Now.Hour]++;
                // Check timer 25
                if (mTimer25m < 0) mWorkState = WorkState.None;
                // Check work in relax timer 1
                if (bWorkingAppFg) mTempWork++;
                else mTempWork = 0;
                if (mTempWork > _1MIN)
                {
                    mDpWkSs = 0;
                    mWorkState = WorkState.Work;
                }
            }
            else if (mWorkState == WorkState.OtherWork)
            {
                dataMgr.mData.WorkTime++;
                if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 22)  dataMgr.mData.ListWorkBlock[DateTime.Now.Hour]++;
                // Check timer 25
                if (mTimer25m < 0) mWorkState = WorkState.None;
                if (mPauseTime > _5MIN) mWorkState = WorkState.None;
                if (bWorkingAppFg)
                {
                    mDpWkSs = 0;
                    mWorkState = WorkState.Work;
                }
            }
            else if (mWorkState == WorkState.Work)
            {
                dataMgr.mData.WorkTime++;
                if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 22)  dataMgr.mData.ListWorkBlock[DateTime.Now.Hour]++;
                mDpWkSs++;

                if (bWorkingAppFg == false) mTimer25m++;
                else mTimer25m = 0;
                if (mTimer25m > _25MIN) mWorkState = WorkState.None;
                if (mPauseTime > _5MIN) mWorkState = WorkState.None;
            }

            updateHMI();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mReqClose = true;
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mReqClose == false)
            {
                e.Cancel = true;
                if (Width < MAX_WIDTH)
                {
                    Width = MAX_WIDTH;
                    Height = MAX_HEIGHT;
                    listDate_Click(sender, e);
                }
                else if (mWorkState != WorkState.None)
                {
                    Width = 0;
                    Height = 0;
                }
            }
            dataMgr.storeData();
        }

        private void listDate_Click(object sender, EventArgs e)
        {
            if (listDate.SelectedItem == null)
            {
                loadHistory(dataMgr.mTodayStr);
                return;
            }
            loadHistory(listDate.SelectedItem.ToString());
        }
    }
}
