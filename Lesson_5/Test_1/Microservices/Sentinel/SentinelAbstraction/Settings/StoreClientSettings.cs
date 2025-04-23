using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelAbstraction.Settings
{
    public class StoreClientSettings
    {
        public const string SectionName = "StoreClient";
        public string BaseAddress { get; set; } = string.Empty;
    }
}
