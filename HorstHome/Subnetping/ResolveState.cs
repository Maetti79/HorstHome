using System.Net;

namespace SubnetPing
{

    public class ResolveState
    {
        string hostName;
        IPHostEntry resolvedIPs;

        public ResolveState(string host)
        {
            hostName = host;
        }

        public IPHostEntry IPs
        {
            get { return resolvedIPs; }
            set { resolvedIPs = value; }
        }
        public string host
        {
            get { return hostName; }
            set { hostName = value; }
        }

        public ResolveType Result { get; set; } = ResolveType.Pending;

    }

}