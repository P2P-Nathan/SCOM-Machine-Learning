using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScomForecastingEngine.Models
{
    public class ForecastRecord
    {
        public DateTime ForecastDate { get; set; }
        public float PredictedValue { get; set; }
        public float LowerBound { get; set; }
        public float UpperBound { get; set; }

        public static List<ForecastRecord> CreateForecastRecords(ModelOutput results, double averageAge)
        {
            DateTime forcastedDate = DateTime.Now;
            List<ForecastRecord> records = new List<ForecastRecord>();

            for (int i = 0; i < results.ForecastedValues.Length; i++)
            {
                forcastedDate = forcastedDate.AddSeconds(averageAge);
                records.Add(new ForecastRecord
                {
                    ForecastDate = forcastedDate,
                    PredictedValue = results.ForecastedValues[i],
                    LowerBound = results.LowerBoundValues[i],
                    UpperBound = results.UpperBoundValues[i]
                });
            }

            return records;
        }
    }
}
