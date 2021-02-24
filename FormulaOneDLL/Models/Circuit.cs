using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class Circuit
    {
        public Circuit(string id, string gpName,string flag,int turnN,int circuitLen,string firstGpYear,string fastestLap,string thumbIMG,string fullIMG)
        {
            this.id = id;
            this.circuitName = gpName;
            this.flag = flag;
            this.turnNumber = turnN;
            this.circuitLen = circuitLen;
            this.firstGpYear = firstGpYear;
            this.fastestLapTime = fastestLap.Split('-')[0];
            this.fastestLapPilot = fastestLap.Split('-')[1];
            this.fastestLapYear = fastestLap.Split('-')[2];
            this.thumbIMG = thumbIMG;
            this.fullIMG = fullIMG;
        }
        public string id { get; set; }
        public string circuitName { get; set; }
        public string flag { get; set; }
        public int turnNumber { get; set; }
        public int circuitLen { get; set; }
        public string firstGpYear { get; set; }
        public string fastestLapTime { get; set; }
        public string fastestLapPilot { get; set; }
        public string fastestLapYear { get; set; }
        public string thumbIMG { get; set; }
        public string fullIMG { get; set; }
    }
}
