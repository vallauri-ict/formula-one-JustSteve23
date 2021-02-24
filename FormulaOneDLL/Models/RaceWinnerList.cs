using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class RaceWinnerList
    {
        public RaceWinnerList(string gpId,string gpName,int lapNumber,string winnerName,string winnerSurname,string winnerCar)
        {
            this.gpId = gpId;
            this.gpName = gpName;
            this.lapNumber = lapNumber;
            this.winnerName = winnerName;
            this.winnerSurname = winnerSurname;
            this.winnerCar = winnerCar;
        }
        public string gpId { get; set; }
        public string gpName { get; set; }
        public int lapNumber { get; set; }
        public string winnerName { get; set; }
        public string winnerSurname { get; set; }
        public string winnerCar { get; set; }
    }
}
