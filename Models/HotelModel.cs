using Models.ObservableModifications;
using System.Text.RegularExpressions;

namespace Models
{
    public class HotelModel : ObservableObject
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
            get => name;
            set
            {
                if (name != value)
                {
                    name = value; OnPropertyChanged();
                }
            }
        }

        public string Stars
        {
            get => stars;
            set { if (stars == value) return; stars = value; OnPropertyChanged(); }
        }

        public int NumberOfRooms { get; set; }

        public int NumberOfFloors
        {
            get => numberOfFloors;
            set
            {
                if (!int.TryParse(value.ToString(), out numberOfFloors) && value != 0)
                    throw new ArgumentException("Введіть у числовому вигляді!");
                OnPropertyChanged(ref numberOfFloors, value);
            }
        }

        public string Address
        {
            get;
            set;
        }

        public string Phone
        {
            get => phone;
            set
            {
                if (!new Regex(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$").IsMatch(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Неправильний формат номера телефону!");
                OnPropertyChanged(ref phone, value);
            }
        }

    }
}
