﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// a) Use class Time2 from Fig. 10.5 to create a C# class library project that can be used in a console project application (you can cut and paste the code from the book example).
namespace TimeCalculator
{
    // b) Modify the class to include two overloaded methods that can add time to the time objects as follows:
    public class Time2
    {
        private int hour; // 0 - 23
        private int minute; // 0 - 59
        private int second; // 0 - 59
        
        // constructor can be called with zero, one, two or three arguments
        public Time2(int h = 0, int m = 0, int s = 0)
        {
            SetTime(h, m, s); // invoke SetTime to validate time
        } // end Time2 three-argument constructor




        // Time2 constructor: another Time2 object supplied as an argument
        public Time2(Time2 time)
            : this(time.Hour, time.Minute, time.Second) { }


        // set a new time value using universal time; ensure that
        // the data remains consistent by setting invalid values to zero
        public void SetTime(int h, int m, int s)
        {
            Hour = h; // set the Hour property
            Minute = m; // set the Minute property
            Second = s; // set the Second property
        } // end method SetTime

        // property that gets and sets the hour
        public int Hour
        {
            get
            {
                return hour;
            } // end get
            set
            {
                if (value >= 0 && value < 24)
                    hour = value;
                else
                    throw new ArgumentOutOfRangeException(
                    "Hour", value, "Hour must be 0-23");
            } // end set
        } // end property Hour

        // property that gets and sets the minute
        public int Minute
        {
            get
            {
                return minute;
            } // end get
            set
            {
                if (value >= 0 && value < 60)
                    minute = value;
                else
                    throw new ArgumentOutOfRangeException(
                    "Minute", value, "Minute must be 0-59");
            } // end set
        } // end property Minute

        // property that gets and sets the second
        public int Second
        {
            get
            {
                return second;
            } // end get
            set
            {
                if (value >= 0 && value < 60)
                    second = value;
                else
                    throw new ArgumentOutOfRangeException(
                    "Second", value, "Second must be 0-59");
            } // end set
        } // end property Second

        // convert to string in universal-time format (HH:MM:SS)
        public virtual string ToUniversalString()
        {
            return string.Format(
            "{0:D2}:{1:D2}:{2:D2}", Hour, Minute, Second);
        } // end method ToUniversalString

        // convert to string in standard-time format (H:MM:SS AM or PM)
        public override string ToString()
        {
            return string.Format("{0}:{1:D2}:{2:D2} {3}",
            ((Hour == 0 || Hour == 12) ? 12 : Hour % 12),
            Minute, Second, (Hour < 12 ? "AM" : "PM"));
        } // end method ToString

        // i) one method will add a value of time received as three integers representing number of hours, minutes and seconds to be added.
        public void addtime(int h, int m, int s)
        {
            // calculate total seconds
            int sec = Hour * 3600 + Minute * 60 + Second;

            // caculate total second
            int more = h * 3600 + m * 60 + s;

            int total = sec + more;

            int hh = total / 3600;
            int mm = (total - hh * 3600) / 60;
            int ss = total - hh * 3600 - mm * 60;

            SetTime(hh, mm, ss);
        }

        // ii) the other one will add a value of time received as another Time2 object.
        public void addtime(Time2 atime)
        {
            addtime(atime.Hour, atime.Minute, atime.Second);
        }
    } // end class Time2
}
