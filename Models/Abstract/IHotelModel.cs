namespace Models.Abstract
{
    public interface IHotelModel
    {
        public int Id { get; set; }
        public List<RoomModel> Rooms { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloors { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
