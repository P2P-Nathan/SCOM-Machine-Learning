using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLTestAppOne.Models
{
    internal class PerformanceEntry
    {
        public float Value { get; private set; }
        public DateTime Timestamp { get; private set; }

        public PerformanceEntry() { }
        public PerformanceEntry(float value, DateTime timestamp)
        {
            Value = value;
            Timestamp = timestamp;
        }
    }
}
