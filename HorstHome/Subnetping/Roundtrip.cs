using System;

namespace SubnetPing
{

    public class Roundtrip : IComparable
    {
        public String Time;

        public Roundtrip(String t)
        {
            Time = t;
        }

        public override string ToString()
        {
            return Time;
        }

        public int CompareTo(Roundtrip other)
        {

            int n1 = 0;
            int n2 = 0;
            Boolean thisisNumeric = Int32.TryParse(this.Time.ToString(), out n1);
            if (thisisNumeric == false) {
                return 0;
            }
            Boolean otherisNumeric = Int32.TryParse(other.Time.ToString(), out n2);
            if (otherisNumeric == false)
            {
                return 0;
            }
            return n1.CompareTo(n2);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return (1);
            return (CompareTo((Roundtrip)obj));
        }
    }

}
