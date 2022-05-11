using System.Collections.Generic;
using System.Windows.Controls;

namespace UI.Views
{
    public partial class HotelsView : UserControl
    {
        public HotelsView()
        {
            InitializeComponent();
        }

        public void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var binding = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }
    }
}
