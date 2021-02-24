using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class RaceResults
    {
        public RaceResults(int driverNumber, string teamCode,string gpID,string place, string fastestLap, string gridPosition)
        {
            this.driverNumber = driverNumber;
            this.teamCode = teamCode;
            this.gpID = gpID;
            this.place = place;
            this.fastestLap = fastestLap;
            this.gridPosition = gridPosition;
        }
        public int driverNumber { get; set; }
        public string teamCode { get; set; }
        public string gpID { get; set; }
        public string place { get; set; }
        public string fastestLap { get; set; }
        public string gridPosition { get; set; }
    }
}
