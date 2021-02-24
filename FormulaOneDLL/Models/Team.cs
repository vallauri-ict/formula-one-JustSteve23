using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class Team
    {
        public Team(string teamCode, string teamFullName, string teamChief, string teamPowerUnit, int teamFirstEntryYear, string nationCode, string teamHQPlace, string logo, string img, string HEXcolour, string RGBcolour)
        {
            this.teamCode = teamCode;
            this.teamFullName = teamFullName;
            this.teamChief = teamChief;
            this.teamPowerUnit = teamPowerUnit;
            this.teamFirstEntryYear = teamFirstEntryYear;
            this.teamHQPlace = teamHQPlace;
            this.nationCode = nationCode;
            this.logo = logo;
            this.img = img;
            this.HEXcolour = HEXcolour;
            this.RGBcolour = RGBcolour;
        }

        public string teamCode { get; set; }
        public string teamFullName { get; set; }
        public string teamChief { get; set; }
        public string teamPowerUnit { get; set; }
        public int teamFirstEntryYear { get; set; }
        public string nationCode { get; set; }
        public string teamHQPlace { get; set; }
        public string logo { get; set; }
        public string img { get; set; }
        public string HEXcolour { get; set; }
        public string RGBcolour { get; set; }
    }
}
