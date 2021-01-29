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

        public Mediator Mediator { get; set; }

        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
            Mediator.SetUseCase(UseCasesBox.SelectedItem as string);
        }
    }
}
