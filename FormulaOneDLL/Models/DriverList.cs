using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class DriverList
    {
        public DriverList(int number,string name, string surname, string col1, string col2, string flag,string team,string driverImg)
        {
            this.driverNumber = number;
            this.driverName = name;
            this.driverSurname = surname;
            this.teamColourHEX = col1;
            this.teamColourRGB = col2;
            this.driverFlag = flag;
            this.driverTeam = team;
            this.driverImg = driverImg;
        }
        public int driverNumber { get;set; }
        public string driverName { get; set; }
        public string driverSurname{ get; set; }
        public string teamColourHEX { get; set; }
        public string teamColourRGB { get; set; }
        public string driverFlag { get; set; }
        public string driverTeam { get; set; }
        public string driverImg { get; set; }
    }
}
