
using HospitalMS.Data;
using HospitalMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDemo.Seeders
{
    public class PatientSeeder
    {
        private readonly HospitalContext _context;
        public PatientSeeder(HospitalContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            AddNewPatient(new Patient
            {
                PatientId = 1,
                Firstname = "Jonyy",
                Lastname = "Doe",
                Email = "jonny.doe@gmail.com",
                Address = "Budapest 45 e street",
                CountryId = 1
            });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we avoid adding duplicates, so check first, then add
        private void AddNewPatient(Patient patient)
        {
            var existingType = _context.Patients.FirstOrDefault(s => s.PatientId == patient.PatientId);
            if (existingType == null)
            {
                _context.Patients.Add(patient);
            }
        }
    }
}
