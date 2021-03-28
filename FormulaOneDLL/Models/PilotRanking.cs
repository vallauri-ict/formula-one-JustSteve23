using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class PilotRanking
    {
        public PilotRanking(string place, string driverName, string driverSurname, string nat, string teamName, int pts)
        {
            this.place = place;
            this.driverName = driverName;
            this.driverSurname = driverSurname;
            this.nat = nat;
            this.teamName = teamName;
            this.pts = pts;
        }

        public string place { get; set; }
        public string driverName { get; set; }
        public string driverSurname { get; set; }
        public string nat { get; set; }
        public string teamName { get; set; }
        public int pts { get; set; }
    }
}
