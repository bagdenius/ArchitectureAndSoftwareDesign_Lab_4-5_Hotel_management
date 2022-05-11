namespace Domains.Abstract
{
    public interface IHotel
    {
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
