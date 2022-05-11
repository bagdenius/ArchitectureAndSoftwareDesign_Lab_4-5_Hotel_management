﻿using Domains.Abstract;

namespace Domains
{
    public class Hotel : IHotel
    {
        // Mapped properties
        public int Id { get; set; }
        public List<Room> Rooms { get; set; }
        public string Name { get; set; }
        public string Stars { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloors { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
