using Controllers.Abstract;
using Models;
using System.Windows.Controls;

namespace UI.Views
{
    public partial class RoomsView : UserControl
    {
        private readonly IController<HotelModel> _hotelsController;
        private readonly IController<RoomModel> _roomsController;
        private readonly IController<CustomerModel> _customersController;
        public RoomsView(IController<HotelModel> hotelsController, IController<RoomModel> roomsController,
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
            var binding = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }
    }
}
