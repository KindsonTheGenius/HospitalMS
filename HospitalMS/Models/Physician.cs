using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models
{
    public class Physician
    {
        public int PhysicianId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Specialty> Specialties { get; set; }
        public DateTime DateOfHire { get; set; }
    }
}
