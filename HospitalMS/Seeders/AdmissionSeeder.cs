
using HospitalMS.Data;
using HospitalMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDemo.Seeders
{
    public class AdmissionSeeder
    {
        private readonly HospitalContext _context;
        public AdmissionSeeder(HospitalContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            AddNewAdmission(new Admission
            {
                AdmissionId = 1,
                Complaint = "A bit of headaches and fever",
                PatientId = 1,
                RoomId = 1,
                AdmissionDate = DateTime.Today,
                AdmissionTime = DateTime.Now,
            });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we avoid adding duplicates, so check first, then add
        private void AddNewAdmission(Admission admission)
        {
            var existingType = _context.Admissions.FirstOrDefault(s => s.AdmissionId == admission.AdmissionId);
            if (existingType == null)
            {
                _context.Admissions.Add(admission);
            }
        }
    }
}
