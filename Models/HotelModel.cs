using Models.Abstract;
using Models.ObservableModifications;

namespace Models
{
    public class HotelModel : ObservableObject, IHotelModel
    {
        // fields
        private string name;
        private string stars;
        private int numberOfRooms;
        private int numberOfFloors;
        private string address;
        private string phone;

        // mapped properties
        public int Id { get; set; }
        public List<RoomModel> Rooms { get; set; }

        public string Name
        {
            get;
            set;
        }

        public string Stars
        {
            get => stars;
            set { if (stars == value) return; stars = value; OnPropertyChanged(); }
        }

        public int NumberOfRooms
        {
            get;
            set;
        }

        public int NumberOfFloors
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

    }
}
