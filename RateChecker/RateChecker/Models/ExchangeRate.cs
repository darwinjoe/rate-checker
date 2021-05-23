using System;
using System.Collections.Generic;
using System.Text;

namespace RateChecker.Models {
    public class ExchangeRate { 
        public DateTime Date { get; set; }
        public double Rate { get; set; }
        public Currency Source { get; set; }
        public Currency Target { get; set; }

        public override string ToString(){
            var template = "At {0}, 1 {1} equals {2} {3}.";
            var dateFormat = "yyyy-MM-dd HH:mm:ss";

            return String.Format(template, Date.ToString(dateFormat), Source.Code, Rate, Target.Code);
        }
    }
}