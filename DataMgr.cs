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
            if (mData.LstUsedApp == null) mData.LstUsedApp = new Dictionary<string, int>();
        }

        public void storeData()
        {
            string jsonData = JsonConvert.SerializeObject(mAllData, Formatting.Indented);
            File.WriteAllText("WorkData.json", jsonData);
        }
    }
}
