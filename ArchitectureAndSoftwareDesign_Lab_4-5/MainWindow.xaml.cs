using Controllers.Abstract;
using Models;
using Models.enums;
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

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _roomsController.Add(new RoomModel()
            {
                Number = "101",
                Floor = 1,
                Cost = 1000,
                Area = 50,
                roomCategory = RoomCategory.Апартаменти,
                servicesAndAmenities = {},
                bookingState = BookingState.Вільний
            });
            Update();
        }
    }
}
