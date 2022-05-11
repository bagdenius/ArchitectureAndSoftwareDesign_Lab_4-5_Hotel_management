using System.Windows.Controls;

namespace UI.Views
{
    public partial class RoomsView : UserControl
    {
        public RoomsView()
        {
            InitializeComponent();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var binding = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }

        private void ListBox_ServicesAndAmenities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
