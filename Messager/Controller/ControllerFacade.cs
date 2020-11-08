using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Controller
{
    public class ControllerFacade
    {
        private UdpClient Sender { get; }
        private UdpClient Reciever { get; set; }

        public ControllerFacade()
        {
            Sender = new UdpClient();
        }

        public void Connect(string ip, int localPort, int remotePort)
        {
            Sender.Connect(ip, remotePort);
            Reciever = new UdpClient(localPort);
        }

        public void Send(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            Sender.Send(data, data.Length);
        }

        public string Recieve()
        {
            IPEndPoint ip = null;
            byte[] data = Reciever.Receive(ref ip);
            string message = Encoding.UTF8.GetString(data);
            return message;
        }
    }
}
