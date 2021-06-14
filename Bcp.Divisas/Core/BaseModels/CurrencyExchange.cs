using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bcp.Divisas.Core.BaseModels
{
    public class CurrencyExchange
    {
        public string Id { get; set; }
        public string IdCurrencySource { get; set; }
        public string IdCurrencyTarget { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime EffectiveDate { get; set; }

        public bool State { get; set; }
    }
}
