using System;

namespace UI.Static_addons
{
    public static class DateHelper
    {
        public static DateTime BookingStart
        {
            get => DateTime.Today;
        }
        public static DateTime BookingEnd
        {
            get => DateTime.Today.AddDays(365);
        }
    }
}
