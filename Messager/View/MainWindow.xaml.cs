using Controller;
using System.Windows;
using System.Drawing;
using System.Threading.Tasks;
using WebEye.Controls.Wpf;

namespace View
{
    public partial class MainWindow : Window
    {
        private ControllerFacade Controller { get; }

        public MainWindow()
        {
            InitializeComponent();
            Controller = new ControllerFacade();
            ConnectButton.Click += ConnectButtonClick;
            SendButton.Click += SendButtonClick;
            WebCameraControl camera = new WebCameraControl();
            Bitmap image = camera.GetCurrentImage();
        }

        private void ConnectButtonClick(object sender, RoutedEventArgs e)
        {
            string ip = IPAddressBox.Text;
            int.TryParse(LocalPortBox.Text, out int localPort);
            int.TryParse(RemotePortBox.Text, out int remotePort);
            Controller.Connect(ip, localPort, remotePort);
            Recieve();
        }

        private void SendButtonClick(object sender, RoutedEventArgs e)
        {
            string message = YourMessageBox.Text;
            Controller.Send(message);
        }

        private async void Recieve()
        {
            while (true)
            {
                string message = await Task.Run(() => Controller.Recieve());
                MessageStory.Text += "\n" + message;
            }
        }
    }
}
