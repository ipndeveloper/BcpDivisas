using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bcp.Divisas.Core.BaseModels
{
    public class Convertion
    {
        public string Id { get; set; }
        public string IdCurrencySource { get; set; }
        public string IdCurrencyTarget { get; set; }

        public int Cantidad { get; set; }
    }
}
