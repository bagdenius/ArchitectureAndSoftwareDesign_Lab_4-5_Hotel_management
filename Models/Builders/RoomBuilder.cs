using Models.enums;
using System.ComponentModel;

namespace Models.Builders
{
    public static class RoomBuilder
    {
        private static readonly EnumConverter _converter = new(typeof(RoomModel));
        public static void SetRoomCategory(this RoomModel room, RoomCategory roomCategory)
        {
            room.RoomCategory = roomCategory.ToString().Replace('_', ' ').Replace('0', '-');
        }

        public static RoomCategory GetRoomCategory(this RoomModel room)
        {
            return (RoomCategory)_converter.ConvertFromString(room.RoomCategory.Replace(' ', ' ').Replace('-', '0'));
        }

        public static void SetWindowsView(this RoomModel room, WindowsView windowsView)
        {
            room.WindowsView = windowsView.ToString().Replace('_', ' ').Replace('0', '-');
        }

        public static WindowsView GetWindowsView(this RoomModel room)
        {
            return (WindowsView)_converter.ConvertFromString(room.WindowsView.Replace(' ', ' ').Replace('-', '0'));
        }

        public static void SetServicesAndAmenities(this RoomModel room, List<ServicesAndAmenities> services)
        {
            room.ServicesAndAmenities = string.Empty;
            foreach (var service in services)
            {
                if (room.ServicesAndAmenities != string.Empty)
                {
                    room.ServicesAndAmenities += ", ";
                    room.ServicesAndAmenities += service.ToString().Replace('_', ' ').Replace('0', '-').ToLower();
                }
                else room.ServicesAndAmenities += service.ToString().Replace('_', ' ').Replace('0', '-');
            }
        }

        public static List<ServicesAndAmenities> GetServicesAndAmenities(this RoomModel room)
        {
            List<ServicesAndAmenities> result = new();
            foreach (ServicesAndAmenities service in Enum.GetValues(typeof(ServicesAndAmenities)))
            {
                if (room.ServicesAndAmenities.Contains(service.ToString()))
                {
                    result.Add(service);
                }
            }
            return result;
        }

        public static void SetBookingState(this RoomModel room, BookingState bookingState)
        {
            room.BookingState = bookingState.ToString().Replace(' ', ' ').Replace('-', '0');
        }

        public static BookingState GetBookingState(this RoomModel room)
        {
            return (BookingState)_converter.ConvertFromString(room.BookingState.Replace(' ', ' ').Replace('-', '0'));
        }
    }
}
