using Controllers.Abstract;
using Models;
using System.Windows.Controls;

namespace UI.Views
{
    public partial class BookingView : UserControl
    {
        private readonly IController<HotelModel> _hotelsController;
        private readonly IController<RoomModel> _roomsController;
        private readonly IController<CustomerModel> _customersController;
        public BookingView(IController<HotelModel> hotelsController, IController<RoomModel> roomsController,
            IController<CustomerModel> customersController)
        {
            InitializeComponent();
            // controllers init
            _hotelsController = hotelsController;
            _roomsController = roomsController;
            _customersController = customersController;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
