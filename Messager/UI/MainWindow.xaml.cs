using Controller;
using System.Windows;
using System.Drawing;
using System.Threading.Tasks;
using WebEye.Controls.Wpf;
using System.Collections.Generic;
using System.Windows.Interop;
using System;
using System.Windows.Media.Imaging;
using System.Threading;

namespace View { }

namespace UI
{
    public partial class MainWindow : Window
    {
        private ControllerFacade Controller { get; }
        private WebCameraControl CameraControl { get; }
        private Task UpdateImageTask { get; }

        public MainWindow()
        {
            InitializeComponent();
            Controller = new ControllerFacade();
            ConnectButton.Click += ConnectButtonClick;
            SendButton.Click += SendButtonClick;
            CameraControl = new WebCameraControl();
            IEnumerator<WebCameraId> cameraEnumerator = CameraControl.GetVideoCaptureDevices().GetEnumerator();
            cameraEnumerator.MoveNext();
            WebCameraId camera = cameraEnumerator.Current;
            CameraControl.StartCapture(camera);
            UpdateImage();
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

        private async void UpdateImage()
        {
            while (true)
            {
                Bitmap bitmap = CameraControl.GetCurrentImage();
                CameraImage.Source = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                await Task.Delay(1000 / 60);
            }
        }
    }
}
