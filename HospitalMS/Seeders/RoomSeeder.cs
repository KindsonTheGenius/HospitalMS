
using HospitalMS.Data;
using HospitalMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDemo.Seeders
{
    public class RoomSeeder
    {
        private readonly HospitalContext _context;
        public RoomSeeder(HospitalContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            AddNewRoom(new Room { RoomId = 1, Description = "VIP", Number=101 });
            AddNewRoom(new Room { RoomId = 2, Description = "General room", Number=100 });
            AddNewRoom(new Room { RoomId = 3, Description = "Covid room", Number=501 });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we avoid adding duplicates, so check first, then add
        private void AddNewRoom(Room room)
        {
            var existingType = _context.Rooms.FirstOrDefault(s => s.RoomId == room.RoomId);
            if (existingType == null)
            {
                _context.Rooms.Add(room);
            }
        }
    }
}
