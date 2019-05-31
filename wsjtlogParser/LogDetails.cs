using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsjtlogParser
{
    public class LogDetails
    {
        public string startDate { get; set; }
        public string startTime { get; set; }
        public string endDate { get; set; }
        public string endTime { get; set; }
        public string callsign { get; set; }
        public string gridSquare { get; set; }
        public double freq { get; set; }
        public string mode { get; set; }
        public int rstSent { get; set; }
        public int rstRcvd { get; set; }
        public string txPower { get; set; }
        public string comment { get; set; }
    }
}
