using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.TimeStuff
{
    class TimePeriod
    {
        DateTime _start;
        public DateTime Start
        { get { return _start; } }

        DateTime _end;
        public DateTime End
        { get { return _end; } }
    }
}
