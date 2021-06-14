using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bcp.Divisas.Core.BaseModels
{
    public class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int Country { get; set; }
    }
}
