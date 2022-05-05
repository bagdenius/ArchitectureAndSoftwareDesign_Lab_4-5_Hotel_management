using Entities.Abstract;
using Entities.enums;

namespace Entities
{
    public class RoomEntity : IRoomEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }
        public double Cost { get; set; }
        public double Area { get; set; }
        public RoomCategory RoomCategory { get; set; }
        public List<ServicesAndAmenities> ServicesAndAmenities { get; set; }
        public WindowsView WindowsView { get; set; }
        public BookingState BookingState { get; set; }
        public DateTime? BookingStartDate { get; set; }
        public DateTime? BookingEndDate { get; set; }
    }
}
