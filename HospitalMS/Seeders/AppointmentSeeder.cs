
using HospitalMS.Data;
using HospitalMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDemo.Seeders
{
    public class AppointmentSeeder
    {
        private readonly HospitalContext _context;
        public AppointmentSeeder(HospitalContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            AddNewAppointment(new Appointment
            {
                AppointmentId = 1,
                PatientId = 1,
                PhysicianId = 1,
                Description = "The patient recovered",
                AppointmentDate = DateTime.Today,
                AppointmentTime = DateTime.Now,
                AppointmentStatus = Status.New,
                DurationInMinutes = 30
            });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we avoid adding duplicates, so check first, then add
        private void AddNewAppointment(Appointment appointment)
        {
            var existingType = _context.Appointments.FirstOrDefault(s => s.AppointmentId == appointment.AppointmentId);
            if (existingType == null)
            {
                _context.Appointments.Add(appointment);
            }
        }
    }
}
