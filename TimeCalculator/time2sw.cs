using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Part C. Write a derived class time2sw (time2-stop watch) based on either one of your time2 classes (the original or the new implementation) a value of time that includes milliseconds (0 to 999). 
namespace TimeCalculator
{
    public class time2sw : Time2
    {
        private int millisecond; // 0 - 999

        // a fully parameterized constructor that expects H, M, S and mS
        public time2sw(int h, int m, int s, int ms) : base(h, m, s)
        {            
            MilliSeconds = ms;
        }

        // one that only expects H, M, S and defaults to 0 mSec;
        public time2sw(int h, int m, int s): this(h, m, s, 0)
        {
        }

        public time2sw(time2sw tm) : this(tm.Hour, tm.Minute, tm.Second, tm.MilliSeconds)
        {
        }

        public int MilliSeconds
        {
            get
            {
                return millisecond;
            } // end get
            set
            {
                if (value >= 0 && value < 1000)
                    millisecond = value;
                else
                    throw new ArgumentOutOfRangeException(
                    "Milliseconds", value, "Milliseconds must be 0-999");
            } // end set
        } // end property Hour

        public override string ToUniversalString()
        {
            return base.ToUniversalString() + string.Format(
            ":{0:D3}", MilliSeconds);
        } // end method ToUniversalString

        // convert to string in standard-time format (H:MM:SS AM or PM)
        public override string ToString()
        {
            return base.ToString() + string.Format(
            ":{0:D3}", MilliSeconds);
        } // end method ToString
    }
}
