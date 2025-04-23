using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelAbstraction.Settings
{
    public class PetClientSettings
    {
        public const string SectionName = "PetClient";

        public string BaseAddress { get; set; } = string.Empty;
    }
}
