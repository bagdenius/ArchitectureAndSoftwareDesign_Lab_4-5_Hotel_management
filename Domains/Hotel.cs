using Domains.Abstract;

namespace Domains
{
    public class Hotel
    {
        public int Id { get; set; }
        public List<Room> Rooms { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloors { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
