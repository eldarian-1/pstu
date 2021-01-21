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

        public new MainWindow Parent { get; set; }

        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.SetUseCase(UseCasesBox.SelectedItem as string);
        }
    }
}
