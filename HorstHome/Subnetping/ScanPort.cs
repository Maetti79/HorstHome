namespace SubnetPing
{
    public class ScanPort
    {
        public string Name;
        public int Port;
        public bool Open = false;

        public ScanPort()
        {
 
        }

        public ScanPort(string n, int p)
        {
            Name = n;
            Port = p;
            Open = false;
        }

        ~ScanPort()
        {
    
        }
    }
}
