using Controllers.Abstract;
using Models;
using Models.enums;
using Models.ObservableModifications;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UI.Commands;

namespace UI.ViewModels
{
    public class RoomsViewModel : ObservableObject
    {
        private readonly IController<RoomModel> _roomsController;
        private readonly IController<HotelModel> _hotelsController;
        private List<HotelModel> _hotels;
        private List<RoomModel> _rooms;
        private HotelModel _hotel;
        private List<int> _floorsValues;

        public RoomsViewModel(IController<RoomModel> roomsController, IController<HotelModel> hotelsController)
        {
            _roomsController = roomsController;
            _hotelsController = hotelsController;
            AddRoomCommand = new RelayCommand(o => AddRoom());
            UpdateRoomCommand = new RelayCommand(o => UpdateRoom());
            RemoveRoomCommand = new RelayCommand(o => RemoveRoom());
            Room = new RoomModel();
            _hotelsController = hotelsController;
            UpdateHotelsComboBox();
        }
        public int? SelectedId { get; set; }
        public RelayCommand AddRoomCommand { get; }
        public RelayCommand UpdateRoomCommand { get; }
        public RelayCommand RemoveRoomCommand { get; }
        public string SearchValue { get; set; }
        public RoomModel Room 
        { 
            get; 
            set; 
        }
        public RoomModel SelectedRoom { get; set; }

        public List<HotelModel> Hotels
        {
            get => _hotelsController.GetAll();
            set { _hotels = value; OnPropertyChanged(); }
        }

        public List<RoomModel> Rooms
        {
            get => _rooms;
            set { _rooms = value; OnPropertyChanged(); }
        }

        public HotelModel SelectedHotel
        {
            get => _hotel;
            set
            {
                _hotel = value; OnPropertyChanged();
                FloorValues = GetFloorsValues();
                UpdateDataGrid();
            }
        }

        public List<int> FloorValues
        {
            get => _floorsValues;
            set { _floorsValues = value; OnPropertyChanged(); }
        }

        public bool CanAddOrUpdateRoom
        {
            get
            {
                return (!string.IsNullOrWhiteSpace(Room.Number) && Room.Floor != null &&
                    Room.Cost != null && Room.Area != null && !string.IsNullOrWhiteSpace(Room.RoomCategory) &&
                    !string.IsNullOrWhiteSpace(Room.ServicesAndAmenities) && !string.IsNullOrWhiteSpace(Room.WindowsView));
            }
        }

        public void AddRoom()
        {
            if (CanAddOrUpdateRoom)
            {
                Room.BookingState = "Вільний";

                Room.HotelId = SelectedHotel.Id;
                _roomsController.Add(Room);

                UpdateDataGrid();
            }
            else MessageBox.Show("Заповніть всі поля коректно!", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void UpdateRoom()
        {
            if (CanAddOrUpdateRoom && SelectedId != null)
            {
                var room = _roomsController.GetById((int)SelectedId);
                room.Number = Room.Number;
                room.Floor = Room.Floor;
                room.Cost = Room.Cost;
                room.Area = Room.Area;
                room.RoomCategory = Room.RoomCategory;
                room.ServicesAndAmenities = Room.ServicesAndAmenities;
                room.WindowsView = Room.WindowsView;
                _roomsController.Update(room);
                UpdateDataGrid();
            }
            else MessageBox.Show("Заповніть всі поля коректно!", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void RemoveRoom()
        {
            if (SelectedId != null)
            {
                _roomsController.Remove((int)SelectedId);
                UpdateDataGrid();
            }
        }

        public List<string> ServicesAndAmenitiesValues
        {
            get => GetEnumValues<ServicesAndAmenities>();
        }

        public List<string> RoomCategoryValues
        {
            get => GetEnumValues<RoomCategory>();
        }

        public List<string> WindowsViewValues
        {
            get => GetEnumValues<WindowsView>();
        }

        public List<string> GetEnumValues<TValue>()
        {
            List<string> term = new List<string>();
            foreach (var item in Enum.GetValues(typeof(TValue)))
            {
                term.Add(item.ToString().Replace('_', ' ').Replace('0', '-'));
            }
            return term;
        }

        private void UpdateDataGrid()
        {
            if (SelectedHotel != null)
            {
                if (string.IsNullOrWhiteSpace(SearchValue))

                    Rooms = _roomsController.GetAll().
                        FindAll(x => x.HotelId == SelectedHotel.Id);
            }
        }

        private void UpdateHotelsComboBox()
        {
            Hotels = _hotelsController.GetAll();
        }

        private List<int> GetFloorsValues()
        {
            var temp = new List<int>();
            if (SelectedHotel != null)
                for (int i = 1; i <= SelectedHotel.NumberOfFloors; i++)
                    temp.Add(i);
            return temp;
        }
    }
}
