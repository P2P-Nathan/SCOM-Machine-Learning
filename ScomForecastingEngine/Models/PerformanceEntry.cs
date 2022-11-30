using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScomForecastingEngine.Models
{
    public class PerformanceEntry
    {
        public float Value { get; private set; }
        public DateTime Timestamp { get; private set; }
        public long RelativeAgeSeconds { get; set; }

        public PerformanceEntry() { }
        public PerformanceEntry(float value, DateTime timestamp, long relativeAgeSeconds)
        {
            Value = value;
            Timestamp = timestamp;
            RelativeAgeSeconds = relativeAgeSeconds;
        }
    }
}
