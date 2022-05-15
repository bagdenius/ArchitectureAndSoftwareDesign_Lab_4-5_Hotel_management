using Controllers.Abstract;
using Models;
using Models.enums;
using System;
using System.Windows;
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
            Customer = new CustomerModel();
            DataContext = this;
            foreach (var gender in Enum.GetValues(typeof(Gender)))
                ComboBoxGender.Items.Add(gender.ToString());
        }

        public CustomerModel Customer { get; set; }

        private void BookingView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            ComboBoxHotelSelecting.ItemsSource = _hotelsController.GetAll();
            ComboBoxHotelSelecting.SelectedIndex = 0;
        }

        private bool CanAddOrUpdate()
        {
            return ComboBoxHotelSelecting.SelectedItem != null &&
                ComboBoxRoomSelecting.SelectedItem != null &&
                Customer.BirthDate != null &&
                !string.IsNullOrWhiteSpace(Customer.Name) &&
                !string.IsNullOrWhiteSpace(Customer.Surname) &&
                !string.IsNullOrWhiteSpace(Customer.Patronymic) &&
                !string.IsNullOrWhiteSpace(Customer.Gender) &&
                !string.IsNullOrWhiteSpace(Customer.Passport) &&
                !string.IsNullOrWhiteSpace(Customer.Phone) &&
                !string.IsNullOrWhiteSpace(Customer.Email);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e) => UpdateDataGrid();

        private void ButtonAddBooking_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CanAddOrUpdate())
            {
                RoomModel Room = _roomsController.GetById((int)ComboBoxRoomSelecting.SelectedValue);
                Room.BookingStartDate = DatePickerStartBookingDate.SelectedDate;
                Room.BookingEndDate = DatePickerEndBookingDate.SelectedDate;
                if (Room.BookingState == BookingState.Вільний.ToString())
                {
                    MessageBoxResult result = Checkout.Show(Room.Hotel.Stars + " готель " +
                        Room.Hotel.Name, Room.ToString(), Customer.ToString(),
                        $"ДАТА БРОНЮВАННЯ: {Room.BookingDates}" +
                        $"\nСУМА ЗАМОВЛЕННЯ: {Room.Cost * ((Room.BookingEndDate - Room.BookingStartDate).Value.Days + 1)} гривень");
                    if (result == MessageBoxResult.Yes)
                    {
                        Room.BookingState = BookingState.Заброньований.ToString();
                        Customer.Id = 0;
                        Customer.RoomId = Room.Id;
                        _customersController.Add(Customer);
                        _roomsController.Update(Room);
                        UpdateDataGrid(); ClearFields();
                    }
                }
                else MessageBox.Show("Обрана кімната вже заброньована або здається!", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        private void ButtonUpdateBooking_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CanAddOrUpdate())
            {
                RoomModel Room = _roomsController.GetById((int)ComboBoxRoomSelecting.SelectedValue);
                Room.BookingStartDate = DatePickerStartBookingDate.SelectedDate;
                Room.BookingEndDate = DatePickerEndBookingDate.SelectedDate;
                if (Room.BookingState == BookingState.Заброньований.ToString())
                {
                    MessageBoxResult result = Checkout.Show(Room.Hotel.Stars + " готель " +
                        Room.Hotel.Name, Room.ToString(), Customer.ToString(),
                        $"ДАТА БРОНЮВАННЯ: {Room.BookingDates}" +
                        $"\nСУМА ЗАМОВЛЕННЯ: {Room.Cost * ((Room.BookingEndDate - Room.BookingStartDate).Value.Days + 1)} гривень");
                    if (result == MessageBoxResult.Yes)
                    {
                        Room.BookingState = BookingState.Заброньований.ToString();
                        _roomsController.Update(Room);
                        Customer.Id = (BookingsDataGrid.SelectedItem as RoomModel).Customer.Id;
                        if (Customer.Id == 0)
                            Customer.Id = _roomsController.GetById(Room.Id).Customer.Id;
                        Customer.RoomId = Room.Id;
                        _customersController.Update(Customer);
                        UpdateDataGrid(); ClearFields();
                    }  
                }
            }
        }

        private void ButtonRemoveBooking_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (BookingsDataGrid.SelectedItem != null)
            {
                var Room = _roomsController.GetById((int)BookingsDataGrid.SelectedValue);
                Room.BookingStartDate = null;
                Room.BookingEndDate = null;
                Room.BookingState = BookingState.Вільний.ToString();
                _customersController.Remove(Room.Customer.Id);
                Room.Customer = null;
                _roomsController.Update(Room);
                UpdateDataGrid();
            }
        }

        private void ButtonClearFields_Click(object sender, System.Windows.RoutedEventArgs e) => ClearFields();

        private void ClearFields()
        {
            DatePickerStartBookingDate.SelectedDate = null;
            DatePickerEndBookingDate.SelectedDate = null;
            TextBoxName.Clear();
            TextBoxSurname.Clear();
            TextBoxPatronymic.Clear();
            ComboBoxGender.SelectedItem = null;
            DatePickerBirthDate.SelectedDate = null;
            TextBoxPassport.Clear();
            TextBoxPhone.Clear();
            TextBoxEmail.Clear();
        }

        private void UpdateDataGrid()
        {
            BookingsDataGrid.ItemsSource = _roomsController.GetAll()
            .FindAll(x => x.BookingStartDate != null & x.Customer != null &
            x.BookingState == BookingState.Заброньований.ToString());
        }

        private void ComboBoxHotelSelecting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxHotelSelecting.SelectedValue != null)
            {
                ComboBoxRoomSelecting.ItemsSource = _roomsController.GetAll()
                .FindAll(x => x.HotelId == (int)ComboBoxHotelSelecting.SelectedValue);
                ComboBoxRoomSelecting.SelectedIndex = 0;
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RoomModel Room = BookingsDataGrid.SelectedItem as RoomModel;
            ComboBoxHotelSelecting.SelectedValue = Room.HotelId;
            ComboBoxRoomSelecting.SelectedValue = Room.Id;
            DatePickerStartBookingDate.SelectedDate = Room.BookingStartDate;
            DatePickerEndBookingDate.SelectedDate = Room.BookingEndDate;
            TextBoxName.Text = Room.Customer.Name;
            TextBoxSurname.Text = Room.Customer.Surname;
            TextBoxPatronymic.Text = Room.Customer.Patronymic;
            ComboBoxGender.SelectedItem = Room.Customer.Gender;
            DatePickerBirthDate.SelectedDate = Room.Customer.BirthDate;
            TextBoxPassport.Text = Room.Customer.Passport;
            TextBoxPhone.Text = Room.Customer.Phone;
            TextBoxEmail.Text = Room.Customer.Email;
        }
    }
}


