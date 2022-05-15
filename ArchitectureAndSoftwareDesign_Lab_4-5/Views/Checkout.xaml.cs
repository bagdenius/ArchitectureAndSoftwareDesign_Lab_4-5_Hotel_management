using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI.Views
{
    public partial class Checkout : Window
    {
        public Checkout()
        {
            InitializeComponent();
        }
        static MessageBoxResult result;
        public static MessageBoxResult Show(string HotelInfo, string RoomInfo, string CustomerInfo, string BookingInfo)
        {
            Checkout Checkout = new Checkout();
            Checkout.TextBlockCheckout.Text = $"ІНФОРМАЦІЯ ПРО БРОНЮВАННЯ" +
                $"\n{HotelInfo}" +
                $"\n{RoomInfo}" +
                $"\n\nБРОНЮВАННЯ НА ІМ'Я {CustomerInfo}" +
                $"\n\n{BookingInfo}";
            Checkout.ShowDialog();
            return result;
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBoxResult.Yes;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBoxResult.Cancel;
            Close();
        }
    }
}
