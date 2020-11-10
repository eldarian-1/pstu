using System;
using System.Windows;
using System.Threading;
using WebEye.Controls.Wpf;
using System.Windows.Media;
using System.Windows.Interop;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace UI
{
    class CameraControll
    {
        private Mutex m_Mutex { get; }
        private bool m_IsActive { get; set; }
        private WebCameraControl m_Control { get; }
        public WebCameraId UsedCamera { get; set; }

        public CameraControll()
        {
            m_Mutex = new Mutex();
            m_Control = new WebCameraControl();
        }

        public IEnumerable<WebCameraId> Devices
        {
            get
            {
                m_Mutex.WaitOne();
                IEnumerable<WebCameraId>  temp = m_Control.GetVideoCaptureDevices();
                m_Mutex.ReleaseMutex();
                return temp;
            }
        }

        public void Start()
        {
            m_IsActive = true;
            m_Mutex.WaitOne();
            m_Control.StartCapture(UsedCamera);
            m_Mutex.ReleaseMutex();
        }

        public void Stop()
        {
            m_IsActive = false;
            m_Mutex.WaitOne();
            m_Control.StopCapture();
            m_Mutex.ReleaseMutex();
        }

        public ImageSource CurrentImage
        {
            get
            {
                if (!m_IsActive)
                    throw new Exception();
                return Imaging.CreateBitmapSourceFromHBitmap(
                    m_Control.GetCurrentImage().GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
        }
    }
}
