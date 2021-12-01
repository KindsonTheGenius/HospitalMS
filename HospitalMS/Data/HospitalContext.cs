using HospitalMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
: base(options)
        {
        }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Admission> Admissions { get; set; }
        public virtual DbSet<Discharge> Discharges { get; set; }
        public virtual DbSet<Physician> Physicians { get; set; }
        public virtual DbSet<Specialty> Specialties { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
    }
}
