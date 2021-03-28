using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class driverStats
    {
        public driverStats(int driverN,string driverName,string driverSurname,int totalPoints,int poleNumber,int rp1,int rp2,int rp3,int podiumN,int fastestLapN)
        {
            DriverN = driverN;
            DriverName = driverName;
            DriverSurname = driverSurname;
            TotalPoints = totalPoints;
            PoleNumber = poleNumber;
            Rp1 = rp1;
            Rp2 = rp2;
            Rp3 = rp3;
            PodiumN = podiumN;
            FastestLapN = fastestLapN;
        }

        public int DriverN { get; set; }
        public string DriverName { get; set; }
        public string DriverSurname { get; set; }
        public int TotalPoints { get; set; }
        public int PoleNumber { get; set; }
        public int Rp1 { get; set; }
        public int Rp2 { get; set; }
        public int Rp3 { get; set; }
        public int PodiumN { get; set; }
        public int FastestLapN { get; set; }
    }
}
