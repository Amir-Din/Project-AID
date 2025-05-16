using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AID.Models
{
    public class visit
    {
        public int id { get; set; }
        public int patientId { get; set; }
        public int charityId { get; set; }
        public string visitTime { get; set; }
        public string discountValue { get; set; }
        public int insurance { get; set; }
        public int status { get; set; }
        public DateTime visitDateTime { get; set; }
    }
}
