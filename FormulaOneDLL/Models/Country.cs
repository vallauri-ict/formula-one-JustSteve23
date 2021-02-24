using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class Country
    {
        public Country(string isoCode,string country)
        {
            this.country = country;
            this.isoCode = isoCode;
        }
        public string isoCode{ get;set; }
        public string country { get; set; }
    }
}
