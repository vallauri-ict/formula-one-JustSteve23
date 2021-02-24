using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class TeamList
    {
        public TeamList(string teamName, string logo,string img,string colHEX,string colRGB,string pl1, string pl2, string imgpl1, string imgpl2)
        {
            this.teamName = teamName;
            this.logo = logo;
            this.img = img;
            this.teamColourHEX = colHEX;
            this.teamColourRGB = colRGB;
            this.pilot1Name = pl1.Split('-')[0];
            this.pilot1Surname = pl1.Split('-')[1];
            this.pilot1Number = pl1.Split('-')[2];
            this.pilot1img = imgpl1;
            this.pilot2Name = pl2.Split('-')[0];
            this.pilot2Surname = pl2.Split('-')[1];
            this.pilot2Number = pl2.Split('-')[2];
            this.pilot2img = imgpl2;
        }
        public string teamName { get; set; }
        public string logo { get; set; }
        public string img { get; set; }
        public string teamColourHEX { get; set; }
        public string teamColourRGB { get; set; }
        public string pilot1Name { get; set; }
        public string pilot1Surname { get; set; }
        public string pilot1Number { get; set; }
        public string pilot2Name { get; set; }
        public string pilot2Surname { get; set; }
        public string pilot2Number { get; set; }
        public string pilot1img { get; set; }
        public string pilot2img { get; set; }
    }
}
