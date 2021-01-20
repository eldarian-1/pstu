using System.Windows;
using System.Windows.Controls;

namespace WpfUi.Blocks
{
    public partial class Setting : UserControl
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("Hello Eldarian!!!");
        }
    }
}
