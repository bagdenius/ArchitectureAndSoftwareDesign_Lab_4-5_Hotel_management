using Controllers.Abstract;
using Models;
using Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace UI.Views
{
    public partial class RoomsView : UserControl
    {
        private readonly IController<HotelModel> _hotelsController;
        private readonly IController<RoomModel> _roomsController;
        private string searchValue;
        public RoomsView(IController<HotelModel> hotelsController, IController<RoomModel> roomsController)
        {
            InitializeComponent();
            // controllers init
            _hotelsController = hotelsController;
            _roomsController = roomsController;
            Room = new RoomModel();
            DataContext = this;
            // comboboxes and listbox init
            foreach (var category in Enum.GetValues(typeof(RoomCategory)))
                ComboBoxRoomCategory.Items.Add(category.ToString().Replace('_', ' ').Replace('0', '-'));
            foreach (var view in Enum.GetValues(typeof(WindowsView)))
                ComboBoxWindowsView.Items.Add(view.ToString().Replace('_', ' ').Replace('0', '-'));
            foreach (var service in Enum.GetValues(typeof(ServicesAndAmenities)))
                ListBox_ServicesAndAmenities.Items.Add(service.ToString().Replace('_', ' ').Replace('0', '-'));
        }

        public int? SelectedId { get; set; }
        public string SearchValue
        {
            get => searchValue;
            set { if (searchValue != value) searchValue = value; OnPropertyChanged(); UpdateDataGrid(); }
        }
        public RoomModel Room { get; set; }

        private void RoomsView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateDataGrid();
            ComboBoxHotelSelecting.ItemsSource = _hotelsController.GetAll();
            ComboBoxHotelSelecting.SelectedIndex = 0;
        }

        private void UpdateDataGrid()
        {
            if (ComboBoxHotelSelecting.SelectedValue != null)
            {
                if (string.IsNullOrWhiteSpace(SearchValue))
                    RoomsDataGrid.ItemsSource = _roomsController.GetAll().
                    FindAll(x => x.HotelId == (int)ComboBoxHotelSelecting.SelectedValue);
                else RoomsDataGrid.ItemsSource = _roomsController.GetAll().
                        FindAll(x => x.Number.ToLower().Contains(SearchValue.ToLower()) |
                x.RoomCategory.ToLower().Contains(SearchValue.ToLower()) |
                x.ServicesAndAmenities.ToLower().Contains(SearchValue.ToLower()) |
                x.WindowsView.ToLower().Contains(SearchValue.ToLower()) |
                x.BookingState.ToLower().Contains(SearchValue.ToLower()) &
                x.HotelId == (int)ComboBoxHotelSelecting.SelectedValue);
            }
            else RoomsDataGrid.ItemsSource = null;
        }

        private void ClearFields()
        {
            //ComboBoxHotelSelecting.SelectedItem = null;
            TextBox_RoomNumber.Text = "1";
            ComboBoxFloor.SelectedItem = null;
            TextBox_Cost.Text = "1";
            TextBox_Area.Text = "1";
            ComboBoxRoomCategory.SelectedItem = null;
            ComboBoxWindowsView.SelectedItem = null;
            ListBox_ServicesAndAmenities.SelectedItems.Clear();
        }

        private bool CanAddOrUpdate()
        {
            if (Room != null && ComboBoxHotelSelecting.SelectedValue != null &&
                !string.IsNullOrWhiteSpace(Room.Number) && Room.Floor > 0 &&
                Room.Cost > 0 && Room.Area > 0 && !string.IsNullOrWhiteSpace(Room.RoomCategory) &&
                !string.IsNullOrWhiteSpace(Room.WindowsView) && !string.IsNullOrWhiteSpace(Room.ServicesAndAmenities))
                return true;
            return false;
        }

        // CRUD events
        private void ButtonAddRoom_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CanAddOrUpdate())
            {
                var Hotel = _hotelsController.GetById((int)ComboBoxHotelSelecting.SelectedValue);
                Room.HotelId = Hotel.Id;
                Room.BookingState = BookingState.Вільний.ToString();
                _roomsController.Add(Room);
                Hotel.NumberOfRooms++;
                _hotelsController.Update(Hotel);
                UpdateDataGrid(); ClearFields();
            }
        }

        private void ButtonUpdateRoom_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CanAddOrUpdate() && SelectedId != null)
            {
                var temp = _roomsController.GetById((int)SelectedId);
                temp.HotelId = (int)ComboBoxHotelSelecting.SelectedValue;
                temp.Number = Room.Number;
                temp.Floor = Room.Floor;
                temp.Cost = Room.Cost;
                temp.Area = Room.Area;
                temp.RoomCategory = Room.RoomCategory;
                temp.ServicesAndAmenities = Room.ServicesAndAmenities;
                temp.WindowsView = Room.WindowsView;
                temp.BookingState = BookingState.Вільний.ToString();
                _roomsController.Update(temp);
                UpdateDataGrid(); ClearFields();
            }
        }

        private void ButtonRemoveRoom_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (SelectedId != null)
            {
                _roomsController.Remove((int)SelectedId);
                var Hotel = _hotelsController.GetById((int)ComboBoxHotelSelecting.SelectedValue);
                Hotel.NumberOfRooms--;
                _hotelsController.Update(Hotel);
                UpdateDataGrid();
            }
                
        }

        private void DigitalTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RoomModel temp = RoomsDataGrid.SelectedItem as RoomModel;
            ComboBoxHotelSelecting.SelectedValue = temp.HotelId;
            TextBox_RoomNumber.Text = temp.Number;
            ComboBoxFloor.SelectedItem = temp.Floor;
            TextBox_Cost.Text = temp.Cost.ToString();
            TextBox_Area.Text = temp.Area.ToString();
            ComboBoxRoomCategory.SelectedItem = temp.RoomCategory;
            ComboBoxWindowsView.SelectedItem = temp.WindowsView;
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

        private void ComboBoxHotelSelecting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxFloor.Items.Clear();
            if (ComboBoxHotelSelecting.SelectedValue != null)
                for (int i = 1; i <= (ComboBoxHotelSelecting.SelectedItem as HotelModel).NumberOfFloors; i++)
                    ComboBoxFloor.Items.Add(i);
            UpdateDataGrid();
        }

        private void ListBox_ServicesAndAmenities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
            {
                Room.ServicesAndAmenities = string.Empty;
                foreach (string item in ListBox_ServicesAndAmenities.SelectedItems)
                {
                    if (string.IsNullOrWhiteSpace(Room.ServicesAndAmenities))
                        Room.ServicesAndAmenities = item;
                    else Room.ServicesAndAmenities += ", " + item.ToLower();
                }
            }

        }
    }
}
