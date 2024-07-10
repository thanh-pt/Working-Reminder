using System.Collections.Generic;

namespace Working_Reminder
{
    public class DataInfo
    {
        public int PCTime { get; set; }
        public int WorkTime { get; set; }
        public Dictionary<string, int> ListUsedApp;
        public Dictionary<int, int>    ListWorkBlock;
        public Dictionary<int, int>    ListRelaxBlock;
    }
}
