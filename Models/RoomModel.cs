using Models.Abstract;
using Models.enums;
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
        private DateTime bookingStartDate;
        private DateTime bookingEndDate;

        // mapped properties
        public int Id { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }
        public double Cost { get; set; }
        public double Area { get; set; }        
        public string RoomCategory { get; set; }
        public string ServicesAndAmenities { get; set; }
        public string WindowsWiew { get; set; }
        public string BookingState { get; set; }
        public DateTime? BookingStartDate { get; set; }
        public DateTime? BookingEndDate { get; set; }

        // unmapped properties for setting/getting mapped props
        public RoomCategory roomCategory 
        { 
            get; 
            set; 
        }

        public List<ServicesAndAmenities> servicesAndAmenities 
        { 
            get; 
            set; 
        }

        public WindowsView windowsView 
        { 
            get; 
            set; 
        }

        public BookingState bookingState 
        { 
            get; 
            set; 
        }
        
    }
}
