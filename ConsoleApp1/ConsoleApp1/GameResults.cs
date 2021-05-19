using System;

namespace ConsoleApp1
{
    class GameResults
    {
        public string Name;
        public string Time;
        public DateTime Date;
        public int UsedBobms;

        public GameResults(string name, string time, DateTime date, int usedBombs)
        {
            Name = name;
            Time = time;
            Date = date;
            UsedBobms = usedBombs;
        }
    }
}
