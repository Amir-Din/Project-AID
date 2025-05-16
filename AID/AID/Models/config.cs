using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AID.Models
{
    public class config
    {
        public int Id { get; set; }
        public string CloseWeekDays { get; set; }
        public string CloseYearDays { get; set; }
        public string OfficeStartTime { get; set; }
        public string VisitPeriod { get; set; }
        public string VisitCount { get; set; }
    }
}
