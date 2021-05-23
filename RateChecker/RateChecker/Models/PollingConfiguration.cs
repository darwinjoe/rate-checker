using System;
using System.Collections.Generic;
using System.Text;

namespace RateChecker.Models{
    public class PollingConfiguration{
        public Currency Source { get; set; }
        public Currency Target { get; set; }
        public RateThreshold Threshold { get; set; }
        public Frequency Frequency { get; set; }
    }
}