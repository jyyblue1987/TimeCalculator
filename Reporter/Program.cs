using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimeCalculator;

namespace Reporter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Time2> list = new List<Time2>();

            while (true)
            {
                Console.WriteLine("Which type of object you wish to enter?:");
                Console.WriteLine("1 – time2");
                Console.WriteLine("2 – time2sw");
                Console.WriteLine("3 – Stop entering data");

                int num = Convert.ToInt32(Console.ReadLine());

                if (num == 3)
                    break;

                Time2 t = null;
                if (num == 1)
                    t = new Time2();
                else if (num == 2)
                    t = new time2sw(0, 0, 0, 0);

                Console.WriteLine("Enter Hours:");
                t.Hour = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Minutes:");
                t.Minute = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Seconds:");
                t.Second = Convert.ToInt32(Console.ReadLine());

                if (num == 2)
                {
                    Console.WriteLine("Enter milliSeconds:");
                    ((time2sw)t).MilliSeconds = Convert.ToInt32(Console.ReadLine());
                }

                list.Add(t);
            }

            
            while (true)
            {
                Console.WriteLine("What report do you want:");
                Console.WriteLine("1 - All Objects");
                Console.WriteLine("2 - All with AM times");
                Console.WriteLine("3 - All with PM times");
                Console.WriteLine("4 – Stop entering data");

                int num = Convert.ToInt32(Console.ReadLine());

                if (num == 4)
                    break;

                List<Time2> result = new List<Time2>();
                if (num == 1)
                    result = list.OrderBy(t => t.Hour * 3600 + t.Minute * 60 + t.Second).ToList();
                else if (num == 2)
                    result = list.Where(t => t.Hour < 12).OrderBy(t => t.Hour * 3600 + t.Minute * 60 + t.Second).ToList();
                else if( num == 3 )
                    result = list.Where(t => t.Hour >= 12).OrderBy(t => t.Hour * 3600 + t.Minute * 60 + t.Second).ToList();

                result.ForEach(t =>
                {
                    Console.WriteLine(" {0}", t.ToUniversalString());
                    Console.WriteLine(" {0}\n", t.ToString()); 
                });
            }
        }
    }
}
