using HospitalMS.Data;
using HospitalMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Seeders
{
    public class CountrySeeder
    {
        private readonly HospitalContext _context;
        public CountrySeeder(HospitalContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            AddNewCountry(new Country { CountryId = 1, Name = "India", Capital = "New Delhi" });
            AddNewCountry(new Country { CountryId = 2, Name = "Nigeria", Capital = "Abuja" });
            AddNewCountry(new Country { CountryId = 3, Name = "Hungary", Capital = "Budapest" });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we avoid adding duplicates, so check first, then add
        private void AddNewCountry(Country country)
        {
            var existingType = _context.Countries.FirstOrDefault(c => c.CountryId == country.CountryId);
            if (existingType == null)
            {
                _context.Countries.Add(country);
            }
        }
    }
}
