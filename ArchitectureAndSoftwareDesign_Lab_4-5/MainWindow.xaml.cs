using Models;
using System.Windows;

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Update();
        }

        public void Update()
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //_service.Add(new RoomModel()
            //{
            //    Number = "101",
            //    Floor = 1,
            //    Cost = 1000,
            //    Area = 50,
            //    RoomCategory = RoomCategory.Апартаменти,
            //    ServicesAndAmenities = ServicesAndAmenities.Капці.ToString()
            //});
            Update();
        }
    }
}
