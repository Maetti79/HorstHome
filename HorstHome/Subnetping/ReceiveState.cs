using System.Net;
using System.Net.Sockets;

namespace SubnetPing
{

    public class ReceiveState
    {
        public Socket client;
        public byte[] buffer;

        public ReceiveState(Socket c, byte[] b)
        {
            buffer = b;
            client = c;
        }
    }

}
