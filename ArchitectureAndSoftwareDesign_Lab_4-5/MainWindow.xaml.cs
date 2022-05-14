using Controllers.Abstract;
using Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Views;

namespace UI
{
    public partial class MainWindow : Window
    {
        private readonly HotelsView _hotelsView;
        private readonly RoomsView _roomsView;
        private readonly BookingView _bookingView;
        public MainWindow(HotelsView hotelsView, RoomsView roomsView, BookingView bookingView)
        {
            InitializeComponent();
            // views init
            _hotelsView = hotelsView;
            _roomsView = roomsView;
            _bookingView = bookingView;
            // on start view
            ViewsContentControl.Content = hotelsView;
        }

        // Window controlling events
        private void ButtonMinimizeWindow_Click(object sender, RoutedEventArgs e)
           => WindowState = WindowState.Minimized;

        private void ButtonMaximizeWindow_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal) WindowState = WindowState.Maximized;
            else WindowState = WindowState.Normal;
        }

        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
            => App.Current.Shutdown();

        private void MainHeaderGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        // Setting view events
        private void ButtonSetHotelsView_Click(object sender, RoutedEventArgs e)
            => ViewsContentControl.Content = _hotelsView;

        private void ButtonSetRoomsView_Click(object sender, RoutedEventArgs e)
            => ViewsContentControl.Content = _roomsView;

        private void ButtonSetBookingsView_Click(object sender, RoutedEventArgs e)
            => ViewsContentControl.Content = _bookingView;
    }
}
