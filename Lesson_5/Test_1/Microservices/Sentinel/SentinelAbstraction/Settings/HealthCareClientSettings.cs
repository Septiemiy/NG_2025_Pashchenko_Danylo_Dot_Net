using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelAbstraction.Settings
{
    public class HealthCareClientSettings
    {
        public const string SectionName = "HealthCareClient";
        public string BaseAddress { get; set; } = string.Empty;
    }
}
