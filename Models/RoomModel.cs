using Models.Abstract;
using Models.ObservableModifications;

namespace Models
{
    public class RoomModel : ObservableObject, IRoomModel
    {
        // fields
        private string number;
        private int floor;
        private double cost;
        private double area;
        private string roomCategory;
        private string servicesAndAmenities;
        private string windowsView;
        private string bookingState;
        private DateTime bookingStartDate;
        private DateTime bookingEndDate;

        // mapped properties
        public int Id { get; set; }

        public string Number { get; set; }

        public int Floor { get; set; }

        public double Cost { get; set; }

        public double Area { get; set; }

        public string RoomCategory { get; set; }
        public string ServicesAndAmenities 
        {
            get;
            set;
        }

        public string WindowsView { get; set; }

        public string BookingState { get; set; }

        public DateTime? BookingStartDate { get; set; }

        public DateTime? BookingEndDate { get; set; }

        public int? HotelId { get; set; }
        public virtual HotelModel Hotel { get; set; }

    }
}
