
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace Services.pobieranie.models
{
    public class PismoModel
        {
            public long IdPisma { get; set; }
            public Dictionary<long, string> zalacznikiPisma { get; set; }
            public int IdAdresat { get; set; }
            public int IdKoszulki { get; set; }
            public bool ZapisanoNaDysku { get; set; } = false;
            public bool OznaczonoJakoPobrane { get; set; } = false;
            public Dictionary<bool, string> ZapisZalacznikow { get; set; }
        }
    }

