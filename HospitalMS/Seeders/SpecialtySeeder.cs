
using HospitalMS.Data;
using HospitalMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDemo.Seeders
{
    public class SpecialtySeeder
    {
        private readonly HospitalContext _context;
        public SpecialtySeeder(HospitalContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            AddNewSpecialty(new Specialty { SpecialtyId = 1, Description = "Optometry" });
            AddNewSpecialty(new Specialty { SpecialtyId = 2, Description = "Cardiology" });
            AddNewSpecialty(new Specialty { SpecialtyId = 3, Description = "Cardiatry" });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we avoid adding duplicates, so check first, then add
        private void AddNewSpecialty(Specialty specialty)
        {
            var existingType = _context.Specialties.FirstOrDefault(s => s.SpecialtyId == specialty.SpecialtyId);
            if (existingType == null)
            {
                _context.Specialties.Add(specialty);
            }
        }
    }
}
