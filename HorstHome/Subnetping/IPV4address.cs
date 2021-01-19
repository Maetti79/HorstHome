using System;

namespace SubnetPing
{

    public class IPV4address : IComparable
    {
        public String IPv4;

        public IPV4address(String IP)
        {
            IPv4 = IP;
        }

        public override string ToString()
        {
            return IPv4;
        }

        public int CompareTo(IPV4address other)
        {
            Int32 ip1 = Int32.Parse(this.IPv4.Substring(this.IPv4.LastIndexOf(".") + 1));
            Int32 ip2 = Int32.Parse(other.IPv4.Substring(other.IPv4.LastIndexOf(".") + 1));
            return ip1.CompareTo(ip2);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return (1);
            return (CompareTo((IPV4address)obj));
        }
    }

}
