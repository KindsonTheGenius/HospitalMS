using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models
{
    public class Discharge
    {
        public int DischargeId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public DateTime DischargeDate { get; set; }
        public DateTime DischargeTime { get; set; }
        public string Details { get; set; }
    }
}
