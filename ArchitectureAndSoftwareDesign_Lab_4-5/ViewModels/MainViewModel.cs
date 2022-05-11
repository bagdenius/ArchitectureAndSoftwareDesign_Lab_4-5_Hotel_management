using Models.ObservableModifications;
using System.Windows;
using System.Windows.Input;
using UI.Commands;

namespace UI.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private object _currentView;
        public HotelsViewModel HotelsVM { get; set; }
        public RoomsViewModel RoomsVM { get; set; }
        public BookingViewModel BookingVM { get; set; }
        public RelayCommand HotelsViewCommand { get; set; }
        public RelayCommand RoomsViewCommand { get; set; }
        public RelayCommand BookingViewCommand { get; set; }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(HotelsViewModel hotelsVM, RoomsViewModel roomsVM, BookingViewModel bookingVM)
        {
            HotelsVM = hotelsVM;
            RoomsVM = roomsVM;
            BookingVM = bookingVM;
            CurrentView = HotelsVM;

            HotelsViewCommand = new RelayCommand(o => CurrentView = HotelsVM);
            RoomsViewCommand = new RelayCommand(o => CurrentView = RoomsVM);
            BookingViewCommand = new RelayCommand(o => CurrentView = BookingVM);
        }
    }
}
