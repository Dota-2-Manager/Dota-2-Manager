using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.TimeStuff
{
    public class TimePeriod
    {
        DateTime _start;
        public DateTime Start
        { get { return _start; } }

        DateTime _end;
        public DateTime End
        { get { return _end; } }

        DateTime _current;
        public DateTime CurrentDate
        { get { return _current; } }

        public TimePeriod(DateTime start, DateTime end)
        {
            _start = start;
            _end = end;
            _current = new DateTime(start.Year, start.Month, start.Day);
        }
    }
}
