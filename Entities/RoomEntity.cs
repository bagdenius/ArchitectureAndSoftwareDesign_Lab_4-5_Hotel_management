using Entities.Abstract;
using Entities.enums;

namespace Entities
{
    internal class RoomEntity : IRoomEntity
    {
        public string Number { get; set; }
        public int Floor { get; set; }
        public double Cost { get; set; }
        public double Area { get; set; }
        public RoomCategory RoomCategory { get; set; }
        public ServicesAndAmenities ServicesAndAmenities { get; set; }
        public WindowsView WindowsView { get; set; }
        public BookingState BookingState { get; set; }
        public DateTime? BookingStartDate { get; set; }
        public DateTime? BookingEndDate { get; set; }
    }
}
