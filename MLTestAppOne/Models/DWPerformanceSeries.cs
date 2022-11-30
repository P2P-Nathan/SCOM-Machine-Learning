using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLTestAppOne.Models
{
    internal class DWPerformanceSeries
    {
        const string dwQuery = ";with PerformanceRuleInstances AS ( SELECT [PerformanceRuleInstanceRowId], InstanceName FROM [dbo].[vPerformanceRuleInstance] Where RuleRowId = {0} ), PerformanceResults AS ( SELECT [DateTime], [SampleValue] FROM [Perf].[vPerfRaw] Where PerformanceRuleInstanceRowId in ( Select PerformanceRuleInstanceRowId from PerformanceRuleInstances ) and ManagedEntityRowId = {1} ) SELECT cast(SampleValue as float) [ReadingValue], [DateTime] [ReadingDateTime] FROM PerformanceResults";

        public int ManagedEntityRowId { get; set; }
        public int PerformanceRuleInstanceRowId { get; set; }

        internal string GetQuery()
        {
            return string.Format(dwQuery, PerformanceRuleInstanceRowId, ManagedEntityRowId);
        }

        public List<PerformanceEntry> PerformanceEntries { get; set; }
        public DWPerformanceSeries(int managedEntityRowId, int performanceRuleInstanceRowId)
        {
            ManagedEntityRowId = managedEntityRowId;
            PerformanceRuleInstanceRowId = performanceRuleInstanceRowId;
            PerformanceEntries = new List<PerformanceEntry>();
        }

        public void PopulatePerformanceEntries(SqlConnection connection)
        {
            SqlCommand cm = new SqlCommand(string.Format(dwQuery,PerformanceRuleInstanceRowId,ManagedEntityRowId), connection);
            // Executing the SQL query  
            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                PerformanceEntries.Add(new PerformanceEntry(float.Parse(sdr[0].ToString()), DateTime.Parse(sdr[1].ToString())));
            }
        }
    }
}
