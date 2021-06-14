using Bcp.Divisas.BaseModels;
using Bcp.Divisas.Core.BaseModels;
using System.Threading.Tasks;

namespace Bcp.Divisas.Managers
{
    public interface IForeignExchangeManager<TResponse , TRequest>
        where TResponse : InfoResult<TRequest>
        where TRequest : CurrencyExchange
    {
        Task<TResponse> CreateAsync(TRequest request);
        Task<TResponse> GetByIdAsync(TRequest request);
        Task<TResponse> UpdateAsync(TRequest request);
    }
}