using Bcp.Divisas.BaseModels;
using Bcp.Divisas.Core.BaseModels;
using Bcp.Divisas.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bcp.Divisas.Core.Managers
{
    public class ConvertManager<TResponseForeign, TResponseConvert , TRequestConvert, TRequestForeign>
        where TResponseForeign : InfoResult<TRequestForeign>
        where TRequestForeign : CurrencyExchange, new()
        where TResponseConvert : ConvertResponse, new() 
        where TRequestConvert : Convertion
    {
        private  IForeignExchangeManager<TResponseForeign, TRequestForeign> _exchange;
        public ConvertManager(IForeignExchangeManager<TResponseForeign, TRequestForeign> exchange)
        {
            _exchange = exchange;

        }
        public virtual  async Task<TResponseConvert> ConvertMoney(TRequestConvert convert)
        {

          var response = await _exchange.GetByIdAsync(new TRequestForeign { Id = convert.Id, IdCurrencySource = convert.IdCurrencySource, IdCurrencyTarget = convert.IdCurrencyTarget });
          var total =response.Entity.UnitPrice * convert.Cantidad;

           return new TResponseConvert { };

        }
    }
}
