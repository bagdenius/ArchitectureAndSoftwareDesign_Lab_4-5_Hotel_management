using Controllers.Abstract;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace UI.Views
{
    public partial class HotelsView : UserControl, INotifyPropertyChanged
    {
        private readonly IController<HotelModel> _hotelsController;
        private readonly IController<RoomModel> _roomsController;
        private readonly IController<CustomerModel> _customersController;
        private string searchValue;
        public HotelsView(IController<HotelModel> hotelsController, IController<RoomModel> roomsController,
            IController<CustomerModel> customersController)
        {
            InitializeComponent();
            // controllers init
            _hotelsController = hotelsController;
            _roomsController = roomsController;
            _customersController = customersController;
            Hotel = new HotelModel();
            DataContext = this;
        }
        public int? SelectedId { get; set; }
        public string SearchValue
        {
            get => searchValue;
            set { if (searchValue != value) searchValue = value; OnPropertyChanged(); UpdateDataGrid(); }
        }
        public HotelModel Hotel { get; set; }
        public List<Value> StarsValues { get; set; } = new List<Value>() { new Value("1-зірковий", "1★"),
            new Value("2-зірковий", "2★"), new Value("3-зірковий", "3★"), new Value("4-зірковий", "4★"), new Value("5-зірковий", "5★") };

        private void HotelsView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBoxFloorsNumber.Text = "1";
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            if (string.IsNullOrWhiteSpace(SearchValue))
                HotelsDataGrid.ItemsSource = _hotelsController.GetAll();
            else HotelsDataGrid.ItemsSource = _hotelsController.GetAll().FindAll(x => x.Name.Contains(SearchValue) |
            x.Address.Contains(SearchValue) | x.Stars.Contains(SearchValue) |
            x.Address.Contains(SearchValue) | x.Phone.Contains(SearchValue));
        }

        private void ClearFields()
        {
            TextBoxHotelName.Clear();
            ComboBoxStars.SelectedItem = null;
            TextBoxFloorsNumber.Text = "1";
            TextBoxAddress.Clear();
            TextBoxPhone.Clear();
        }

        private bool CanAddOrUpdate()
        {
            if (Hotel != null && !string.IsNullOrWhiteSpace(Hotel.Name) &&
                !string.IsNullOrWhiteSpace(Hotel.Stars) && !string.IsNullOrWhiteSpace(Hotel.Address) &&
                !string.IsNullOrWhiteSpace(Hotel.Phone) && Hotel.NumberOfFloors != 0)
                return true;
            return false;
        }

        // CRUD events
        private void ButtonAddHotel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CanAddOrUpdate())
            {
                _hotelsController.Add(Hotel);
                UpdateDataGrid(); ClearFields();
            }
        }

        private void ButtonUpdateHotel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CanAddOrUpdate() && SelectedId != null)
            {
                var temp = _hotelsController.GetById((int)SelectedId);
                temp.Name = Hotel.Name;
                temp.Stars = Hotel.Stars;
                temp.NumberOfFloors = Hotel.NumberOfFloors;
                temp.Address = Hotel.Address;
                temp.Phone = Hotel.Phone;
                _hotelsController.Update(temp);
                UpdateDataGrid(); ClearFields();
            }
        }

        private void ButtonRemoveHotel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (SelectedId != null)
                _hotelsController.Remove((int)SelectedId);
            UpdateDataGrid();
        }

        //public void SearchBox_TextChanged(object sender, TextChangedEventArgs e) => UpdateDataGrid();
        private void TextBoxFloorsNumber_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            string inputSymbol = e.Text.ToString();
            if (!Char.IsDigit(e.Text, 0) || TextBoxFloorsNumber.Text.Length >= 2)
                e.Handled = true;
        }

        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HotelModel temp = (HotelModel)HotelsDataGrid.SelectedItem;
            TextBoxHotelName.Text = temp.Name;
            ComboBoxStars.SelectedItem = temp.Stars;
            TextBoxFloorsNumber.Text = temp.NumberOfFloors.ToString();
            TextBoxAddress.Text = temp.Address;
            TextBoxPhone.Text = temp.Phone;
        }

        private void ButtonClearFields_Click(object sender, System.Windows.RoutedEventArgs e) => ClearFields();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        public class Value
        {
            public Value(string selected, string display)
            {
                Display = display;
                Selected = selected;
            }
            public string Display { get; set; }
            public string Selected { get; set; }
        }
    }
}
