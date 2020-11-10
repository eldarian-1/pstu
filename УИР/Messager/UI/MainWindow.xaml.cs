using System.Windows;
using WebEye.Controls.Wpf;
using System.Threading.Tasks;
using System;

namespace View { }

namespace UI
{
    public partial class MainWindow : Window
    {
        private UdpControll m_UdpControll { get; }
        private CameraControll m_CameraControll { get; }

        public MainWindow()
        {
            InitializeComponent();
            m_UdpControll = new UdpControll();
            m_CameraControll = new CameraControll();
            ConnectButton.Click += ConnectButtonClick;
            CameraList.ItemsSource = m_CameraControll.Devices;
            CameraList.SelectedIndex = 0;
        }

        private void ConnectButtonClick(object sender, RoutedEventArgs e)
        {
            ConnectButton.Click -= ConnectButtonClick;
            DisconnectButton.Click += DisconnectButtonClick;
            SendButton.Click += SendButtonClick;
            string ip = IPAddressBox.Text;
            int.TryParse(LocalPortBox.Text, out int localPort);
            int.TryParse(RemotePortBox.Text, out int remotePort);
            m_UdpControll.Connect(ip, localPort, remotePort);
            m_CameraControll.UsedCamera = (WebCameraId)CameraList.SelectedItem;
            m_CameraControll.Start();
            UpdateImage();
            Recieve();
        }

        private void DisconnectButtonClick(object sender, RoutedEventArgs e)
        {
            ConnectButton.Click += ConnectButtonClick;
            DisconnectButton.Click -= DisconnectButtonClick;
            SendButton.Click -= SendButtonClick;
            m_CameraControll.Stop();
            //m_Controller.Disconnect();
        }

        private void SendButtonClick(object sender, RoutedEventArgs e)
        {
            string message = YourMessageBox.Text;
            m_UdpControll.Send(message);
        }

        private async void Recieve()
        {
            while (true)
            {
                try
                {
                    string message = await Task.Run(() => m_UdpControll.Recieve());
                    MessageStory.Text += "\n" + message;
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        private async void UpdateImage()
        {
            while (true)
            {
                try
                {
                    CameraImage.Source = m_CameraControll.CurrentImage;
                    await Task.Delay(1000 / 120);
                }
                catch(Exception)
                {
                    break;
                }
            }
        }
    }
}
