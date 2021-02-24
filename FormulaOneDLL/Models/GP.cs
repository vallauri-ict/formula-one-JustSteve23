using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class GP
    {
        public GP(string gpId,string gpName, int lapNumber, string circuitId)
        {
            this.gpId = gpId;
            this.gpName = gpName;
            this.lapNumber = lapNumber;
            this.circuitId = circuitId;
        }

        public string gpId { get; set; }
        public string gpName { get; set; }
        public int lapNumber { get; set; }
        public string circuitId { get; set; }

    }
}
