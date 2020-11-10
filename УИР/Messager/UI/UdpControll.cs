using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace UI
{
    public class UdpControll
    {
        private bool m_IsActive { get; set; }
        private UdpClient Sender { get; set; }
        private UdpClient Reciever { get; set; }

        public UdpControll()
        {
            Sender = new UdpClient();
        }

        public void Connect(string ip, int localPort, int remotePort)
        {
            m_IsActive = true;
            Sender.Connect(ip, remotePort);
            Reciever = new UdpClient(localPort);
        }

        public void Disconnect()
        {
            m_IsActive = false;
            Sender.Close();
            Reciever.Close();
            Reciever = null;
        }

        public void Send(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            Sender.Send(data, data.Length);
        }

        public string Recieve()
        {
            if (!m_IsActive)
                throw new Exception();
            IPEndPoint ip = null;
            byte[] data = Reciever.Receive(ref ip);
            string message = Encoding.UTF8.GetString(data);
            return message;
        }
    }
}
