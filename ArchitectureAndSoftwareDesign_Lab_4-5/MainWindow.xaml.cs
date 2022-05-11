using System.Windows;
using System.Windows.Input;
using UI.ViewModels;

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }

        private void ButtonMinimizeWindow_Click(object sender, RoutedEventArgs e)
           => WindowState = WindowState.Minimized;

        private void ButtonMaximizeWindow_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal) WindowState = WindowState.Maximized;
            else WindowState = WindowState.Normal;
        }

        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
            => App.Current.Shutdown();

        private void MainHeaderGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
