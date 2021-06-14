using Bcp.Divisas.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bcp.Divisas.Core.Stores;
using Bcp.Divisas.Core.BaseModels;

namespace Bcp.Divisas.Managers
{
    public class ForeignExchangeManager<TResponse,TRequest>  :  IForeignExchangeManager<TResponse, TRequest> 
        where TResponse : InfoResult<TRequest> 
        where TRequest : CurrencyExchange
    {
        protected internal IExchange<TResponse,TRequest> Store { get; set; }
        public ForeignExchangeManager(IExchange<TResponse, TRequest> store)
        {
            if (store == null)
            {
                throw new ArgumentNullException(nameof(store));
            }
            Store = store;
        }

        public virtual async Task<TResponse> GetByIdAsync(TRequest request)
        {
            return await Store.GetByIdAsync(request);
        }
        public virtual async Task<TResponse> CreateAsync(TRequest request)
        {
            return await Store.CreateAsync(request);
        }
        public virtual async Task<TResponse> UpdateAsync(TRequest request)
        {
            return await Store.UpdateAsync(request);
        }
    }
}
