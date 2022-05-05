using Domains;
using Domains.enums;
using Services.Abstract;
using System.Windows;

namespace UI
{
    public partial class MainWindow : Window
    {
        private readonly IService<Room> _service;
        public MainWindow(IService<Room> service)
        {
            InitializeComponent();
            _service = service;
            Update();
        }

        public void Update()
        {
            RoomsDataGrid.ItemsSource = _service.GetAll();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _service.Add(new Room()
            {
                Number = "101",
                Floor = 1,
                Cost= 1000,
                Area= 50,
                RoomCategory = RoomCategory.Апартаменти,
                ServicesAndAmenities = { ServicesAndAmenities.Безкоштовні_туалетно0косметичні_засоби, 
                    ServicesAndAmenities.Wi0Fi, ServicesAndAmenities.Кондиціонер,
                ServicesAndAmenities.Рушники, ServicesAndAmenities.Капці, ServicesAndAmenities.Фен},
                WindowsView = WindowsView.На_місто,
                BookingState = BookingState.Вільний
            });
            Update();
        }
    }
}
