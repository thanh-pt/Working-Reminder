using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Working_Reminder
{
    public class DataMgr
    {
        public Dictionary<string, DataInfo> mAllData = new Dictionary<string, DataInfo>();
        public DataInfo mData;
        public string mTodayStr;
        public void loadData()
        {
            try
            {
                string jsonData = File.ReadAllText("WorkData.json");
                mAllData = JsonConvert.DeserializeObject<Dictionary<string, DataInfo>>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading data: {ex.Message}");
                mAllData = new Dictionary<string, DataInfo>();
            }
            mTodayStr = DateTime.Now.ToString("dd/MM/yyyy");
            if (mAllData.ContainsKey(mTodayStr) == false)
            {
                mAllData.Add(mTodayStr, new DataInfo());
            }
            mData = mAllData[mTodayStr];
            if (mData.ListUsedApp == null) mData.ListUsedApp = new Dictionary<string, int>();
            if (mData.ListWorkBlock == null)
            {
                mData.ListWorkBlock = new Dictionary<int, int>();
                mData.ListWorkBlock.Add(7 , 0);
                mData.ListWorkBlock.Add(8 , 0);
                mData.ListWorkBlock.Add(9 , 0);
                mData.ListWorkBlock.Add(10, 0);
                mData.ListWorkBlock.Add(11, 0);
                mData.ListWorkBlock.Add(12, 0);
                mData.ListWorkBlock.Add(13, 0);
                mData.ListWorkBlock.Add(14, 0);
                mData.ListWorkBlock.Add(15, 0);
                mData.ListWorkBlock.Add(16, 0);
                mData.ListWorkBlock.Add(17, 0);
                mData.ListWorkBlock.Add(18, 0);
                mData.ListWorkBlock.Add(19, 0);
                mData.ListWorkBlock.Add(20, 0);
                mData.ListWorkBlock.Add(21, 0);
                mData.ListWorkBlock.Add(22, 0);
            }
            if (mData.ListRelaxBlock == null)
            {
                mData.ListRelaxBlock = new Dictionary<int, int>();
                mData.ListRelaxBlock.Add(7, 0);
                mData.ListRelaxBlock.Add(8, 0);
                mData.ListRelaxBlock.Add(9, 0);
                mData.ListRelaxBlock.Add(10, 0);
                mData.ListRelaxBlock.Add(11, 0);
                mData.ListRelaxBlock.Add(12, 0);
                mData.ListRelaxBlock.Add(13, 0);
                mData.ListRelaxBlock.Add(14, 0);
                mData.ListRelaxBlock.Add(15, 0);
                mData.ListRelaxBlock.Add(16, 0);
                mData.ListRelaxBlock.Add(17, 0);
                mData.ListRelaxBlock.Add(18, 0);
                mData.ListRelaxBlock.Add(19, 0);
                mData.ListRelaxBlock.Add(20, 0);
                mData.ListRelaxBlock.Add(21, 0);
                mData.ListRelaxBlock.Add(22, 0);
            }
        }

        public void storeData()
        {
            string jsonData = JsonConvert.SerializeObject(mAllData, Formatting.Indented);
            File.WriteAllText("WorkData.json", jsonData);
        }
    }
}
