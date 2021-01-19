using System;

namespace SubnetPing
{

    public class PacketLoss : IComparable
    {
        public long trys_total = 0;
        public long succsess_total = 0;
        public decimal loss = 0;
        public decimal loss_total = 0;

        public PacketLoss(decimal s, long t, long l)
        {
            trys_total = t;
            succsess_total = l;
            loss = s;
            loss_total = decimal.Parse(Math.Round((decimal)100 - (((decimal)succsess_total / (decimal)trys_total) * 100), 0).ToString());
        }

        public override string ToString()
        {
            return loss.ToString() + "% " + loss_total.ToString() + "% (" + succsess_total + "/" + trys_total + ")";
        }

        public int CompareTo(PacketLoss other)
        {
            return this.loss.CompareTo(other.loss);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return (1);
            return (CompareTo((PacketLoss)obj));
        }
    }

}
