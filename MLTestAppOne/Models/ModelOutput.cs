using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLTestAppOne.Models
{
    public class ModelOutput
    {
        public float[] ForecastedValues { get; set; }

        public float[] LowerBoundValues { get; set; }

        public float[] UpperBoundValues { get; set; }
    }
}
