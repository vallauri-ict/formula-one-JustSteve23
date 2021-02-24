using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class Driver
    {
        public Driver(int driverNumber,string driverName, string driverSurname, string teamCode, string flag, int winNumber, int worldChampionshipsNumber, string img)
        {
            this.driverNumber = driverNumber;
            this.driverName = driverName;
            this.driverSurname = driverSurname;
            this.teamCode = teamCode;
            this.flag = flag;
            this.winNumber = winNumber;
            this.worldChampionshipsNumber = worldChampionshipsNumber;
            this.img = img;
        }

        public int driverNumber { get; set; }
        public string driverName { get; set; }
        public string driverSurname { get; set; }
        public string teamCode { get; set; }
        public string flag { get; set; }
        public int winNumber { get; set; }
        public int worldChampionshipsNumber { get; set; }
        public string img { get; set; }

    }
}
