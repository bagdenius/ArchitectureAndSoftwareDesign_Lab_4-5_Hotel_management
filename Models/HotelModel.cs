using Models.Abstract;
using Models.ObservableModifications;

namespace Models
{
    public class HotelModel : ObservableObject, IHotelModel
    {
        // fields
        private string name;
        private int stars;
        private int numberOfRooms;
        private int numberOfFoors;
        private string address;
        private string phone;

        // mapped properties
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
