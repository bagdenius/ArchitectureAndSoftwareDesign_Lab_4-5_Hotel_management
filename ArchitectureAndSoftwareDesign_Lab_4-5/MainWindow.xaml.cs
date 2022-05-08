using Controllers.Abstract;
using Models;
using System.Windows;

namespace UI
{
    public partial class MainWindow : Window
    {
        private readonly IController<HotelModel> _hotelsController;
        private readonly IController<RoomModel> _roomsController;
        private readonly IController<CustomerModel> _customersController;
        public MainWindow(IController<HotelModel> hotelsController, IController<RoomModel> roomsController,
            IController<CustomerModel> customersController)
        {
            InitializeComponent();

            _hotelsController = hotelsController;
            _roomsController = roomsController;
            _customersController = customersController;

            Update();
        }

        public void Update()
        {
            //RoomsDataGrid.ItemsSource = _roomsController.GetAll();
        }

        private void ButtonHotelsMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRoomsMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBookingMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMinimizeWindow_Click(object sender, RoutedEventArgs e)
           => WindowState = WindowState.Minimized;

        private void ButtonMaximizeWindow_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal) WindowState = WindowState.Maximized;
            else WindowState = WindowState.Normal;
        }

        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
            => App.Current.Shutdown();
    }
}
