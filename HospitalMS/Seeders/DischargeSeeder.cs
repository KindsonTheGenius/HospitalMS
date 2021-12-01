
using HospitalMS.Data;
using HospitalMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDemo.Seeders
{
    public class DischargeSeeder
    {
        private readonly HospitalContext _context;
        public DischargeSeeder(HospitalContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            AddNewDischarge(new Discharge
            {
                DischargeId = 1,
                PatientId = 1,
                DischargeDate = DateTime.Today,
                DischargeTime = DateTime.Now,
                Details = "The patient recovered"
            }); 
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we avoid adding duplicates, so check first, then add
        private void AddNewDischarge(Discharge discharge)
        {
            var existingType = _context.Discharges.FirstOrDefault(s => s.DischargeId == discharge.DischargeId);
            if (existingType == null)
            {
                _context.Discharges.Add(discharge);
            }
        }

    }
}
