using System;

namespace SubnetPing
{

    public class Trace
    {
        public String Ipv6;
        public Int32 Hops;
        public long ms;

        public Trace(String ip, Int32 h, long m)
        {
            Ipv6 = ip;
            Hops = h;
            ms = m;
        }

        ~Trace() {

        }
    }

}
