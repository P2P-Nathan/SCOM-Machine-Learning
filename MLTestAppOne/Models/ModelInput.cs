using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLTestAppOne.Models
{
    public class ModelInput
    {
        [LoadColumn(0)]
        public float ReadingValue { get; set; }

        [LoadColumn(1)]
        public DateTime ReadingDateTime { get; set; }
        
    }
}
