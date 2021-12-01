
using HospitalMS.Data;
using HospitalMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDemo.Seeders
{
    public class PhysicianSeeder
    {
        private readonly HospitalContext _context;
        public PhysicianSeeder(HospitalContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            AddNewPhysician(new Physician { 
                PhysicianId = 1, 
                Firstname="Kindson", 
                Lastname = "Munonye", 
                Specialties = new List<Specialty>(),
                DateOfHire = DateTime.Today
            });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we avoid adding duplicates, so check first, then add
        private void AddNewPhysician(Physician physician)
        {
            var existingType = _context.Physicians.FirstOrDefault(s => s.PhysicianId == physician.PhysicianId);
            if (existingType == null)
            {
                _context.Physicians.Add(physician);
            }
        }
    }
}
