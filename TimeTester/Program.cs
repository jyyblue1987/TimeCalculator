using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimeCalculator;
// using TimeInternal;

// c) Use the console application from Fig 10.6 to create a console project that will use the class library 
// (will need to create a reference to the class library dll) created in a). and modify the test program to show 
// that time is added correctly. What should your classes do when adding time takes the time over the 23:59;59 max time in a day?
namespace TimeTester
{
    class Program
    {
        public static void Main(string[] args)
        {
            Time2 t1 = new Time2(); // 00:00:00
            Time2 t2 = new Time2(2); // 02:00:00
            Time2 t3 = new Time2(21, 34); // 21:34:00
            Time2 t4 = new Time2(12, 25, 42); // 12:25:42
            Time2 t5 = new Time2(t4); // 12:25:42
            Time2 t6; // initialized later in the program

            Console.WriteLine("Constructed with:\n");
            Console.WriteLine("t1: all arguments defaulted");
            Console.WriteLine(" {0}", t1.ToUniversalString()); // 00:00:00
            Console.WriteLine(" {0}\n", t1.ToString()); // 12:00:00 AM

            Console.WriteLine(
            "t2: hour specified; minute and second defaulted");
            Console.WriteLine(" {0}", t2.ToUniversalString()); // 02:00:00
            Console.WriteLine(" {0}\n", t2.ToString()); // 2:00:00 AM

            Console.WriteLine(
            "t3: hour and minute specified; second defaulted");
            Console.WriteLine(" {0}", t3.ToUniversalString()); // 21:34:00
            Console.WriteLine(" {0}\n", t3.ToString()); // 9:34:00 PM

            Console.WriteLine("t4: hour, minute and second specified");
            Console.WriteLine(" {0}", t4.ToUniversalString()); // 12:25:42
            Console.WriteLine(" {0}\n", t4.ToString()); // 12:25:42 PM

            Console.WriteLine("t5: Time2 object t4 specified");
            Console.WriteLine(" {0}", t5.ToUniversalString()); // 12:25:42
            Console.WriteLine(" {0}", t5.ToString()); // 12:25:42 PM

            // attempt to initialize t6 with invalid values
            try
            {

            } // end try
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("\nException while initializing t6:");
                Console.WriteLine(ex.Message);
            } // end catch

            // addtime(4, 10, 10)
            try
            {
                Time2 t7 = new Time2(7); // 07:00:00
                t7.addtime(4, 10, 10);

                Console.WriteLine(
                "t7: time is added");
                Console.WriteLine(" {0}", t7.ToUniversalString()); // 11:10:10
                Console.WriteLine(" {0}\n", t7.ToString()); // 11:10:10 AM
            }// end try
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("\nException while add time t2:");
                Console.WriteLine(ex.Message);
            } // end catch

            // addtime(Time2)
            try
            {
                Time2 t8 = new Time2(7); // 07:00:00
                Time2 t9 = new Time2(3, 10, 10); // 03:10:10
                t8.addtime(t9);

                Console.WriteLine(
                "t8: time is added");
                Console.WriteLine(" {0}", t8.ToUniversalString()); // 10:10:10
                Console.WriteLine(" {0}\n", t8.ToString()); // 10:10:10 AM
            }// end try
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("\nException while add time t2:");
                Console.WriteLine(ex.Message);
            } // end catch

            // Part C
            time2sw t10 = new time2sw(10, 10, 10, 200); // 10:10:10 200
            Console.WriteLine("Constructed with:\n");
            Console.WriteLine("t10: all arguments provided");
            Console.WriteLine(" {0}", t10.ToUniversalString()); // 10:10:10 200
            Console.WriteLine(" {0}\n", t10.ToString()); // 10:10:10 AM 200

            time2sw t11 = new time2sw(19, 10, 10); // 19:10:10 000
            Console.WriteLine("Constructed with:\n");
            Console.WriteLine("t10: 3 arguments provided");
            Console.WriteLine(" {0}", t11.ToUniversalString()); // 19:10:10 000
            Console.WriteLine(" {0}\n", t11.ToString()); // 7:10:10 PM 000

            time2sw t12 = new time2sw(t10); // 10:10:10 200
            Console.WriteLine("Constructed with:\n");
            Console.WriteLine("t10:  a time2sw object arguments provided");
            Console.WriteLine(" {0}", t12.ToUniversalString()); // 10:10:10 200
            Console.WriteLine(" {0}\n", t12.ToString()); // 10:10:10 AM 200



        } // end Main
    }
}
