using Bcp.Divisas.Core.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bcp.Divisas.Core.Stores
{
    public interface IExchange<TResponse,TRequest>
    {
        Task<TResponse> CreateAsync(TRequest exchange);
        Task<TResponse> UpdateAsync(TRequest exchange);
        Task<TResponse> GetByIdAsync(TRequest exchange);
    }
}
