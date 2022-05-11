using Controllers.Abstract;
using Models;
using Models.ObservableModifications;
using System.Collections.Generic;
using System.Windows;
using UI.Commands;

namespace UI.ViewModels
{
    public class HotelsViewModel : ObservableObject
    {
        private readonly IController<HotelModel> _hotelsController;
        private List<HotelModel> _hotels;
        private string searchvalue;
        public HotelsViewModel(IController<HotelModel> hotelsController)
        {
            _hotelsController = hotelsController;
            Hotel = new HotelModel();
            AddHotelCommand = new RelayCommand(o => AddHotel());
            UpdateHotelCommand = new RelayCommand(o => UpdateHotel());
            RemoveHotelCommand = new RelayCommand(o => RemoveHotel());
            UpdateDataGrid();
        }

        public RelayCommand AddHotelCommand { get; }
        public RelayCommand UpdateHotelCommand { get; }
        public RelayCommand RemoveHotelCommand { get; }

        public HotelModel Hotel { get; set; }
        public List<HotelModel> Hotels
        {
            get => _hotels;
            set { _hotels = value; OnPropertyChanged(); }
        }
        public List<Value> StarsValues { get; set; } = new List<Value>() { new Value("1-зірковий", "1★"),
            new Value("2-зірковий", "2★"), new Value("3-зірковий", "3★"), new Value("4-зірковий", "4★"), new Value("5-зірковий", "5★") };
        public int? SelectedId { get; set; }
        public string SearchValue
        {
            get => searchvalue;
            set
            {
                if (searchvalue != value)
                {
                    searchvalue = value; OnPropertyChanged();
                    UpdateDataGrid();
                }
            }
        }

        public bool CanAddOrUpdateHotel
        {
            get
            {
                return (!string.IsNullOrWhiteSpace(Hotel.Name) && Hotel.NumberOfFloors > 0 &&
                    !string.IsNullOrWhiteSpace(Hotel.Address) && !string.IsNullOrWhiteSpace(Hotel.Phone));
            }
        }

        private void AddHotel()
        {
            if (CanAddOrUpdateHotel)
            {
                _hotelsController.Add(Hotel);
                UpdateDataGrid();
            }
            else MessageBox.Show("Заповніть всі поля коректно!", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void UpdateHotel()
        {
            if (SelectedId != null && CanAddOrUpdateHotel)
            {
                HotelModel hotel = _hotelsController.GetById((int)SelectedId);
                hotel.Name = Hotel.Name;
                hotel.Stars = Hotel.Stars;
                hotel.NumberOfFloors = Hotel.NumberOfFloors;
                hotel.Address = Hotel.Address;
                hotel.Phone = Hotel.Phone;
                _hotelsController.Update(hotel);
                UpdateDataGrid();
            }
        }

        private void RemoveHotel()
        {
            if (SelectedId != null)
            {
                _hotelsController.Remove((int)SelectedId);
                UpdateDataGrid();
            }
        }

        private void UpdateDataGrid()
        {
            if (string.IsNullOrWhiteSpace(SearchValue))
                Hotels = _hotelsController.GetAll();
            else Hotels = _hotelsController.GetAll().FindAll(x => x.Name.Contains(SearchValue) | 
            x.Address.Contains(SearchValue) | x.Stars.Contains(SearchValue) | 
            x.Address.Contains(SearchValue) | x.Phone.Contains(SearchValue));
        }
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
