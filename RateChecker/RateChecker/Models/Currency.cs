using System;
using System.Collections.Generic;
using System.Text;

namespace RateChecker.Models{
    public class Currency{
        public String Code { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public override string ToString(){
            return String.Format("Currency Code {0} is {1}", Code, Name);
        }
    }
}