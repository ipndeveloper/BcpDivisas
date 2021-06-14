using Bcp.Divisas.Core.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Bcp.Divisas.Managers;

namespace Bcp.Divisas
{


    public class PreLoadData
    {
      
        public static async Task LoadAsync(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var dependency = provider.GetRequiredService<IForeignExchangeManager<InfoResult<CurrencyExchange>, CurrencyExchange>>();
            List<Task> registers = new List<Task>();
            foreach(var item  in GetExchanges())
            {
                registers.Add(dependency.CreateAsync(item));
            }
            await Task.WhenAll(registers);
        }
        private static IList<Currency> GetCurrencys()
        {

            return new List<Currency> { new Currency { Id = "15cdd09b", Country = 1, Name = "Nuevo Sol" },
                                        new Currency { Id = "aa9803ad", Country = 2, Name = "Dolar Americano" },
                                        new Currency { Id = "0da25f76", Country = 3, Name = "Euro" }

                                      };
        }

        private static IList<CurrencyExchange> GetExchanges ()
        {
            return new List<CurrencyExchange>
            {
                 new CurrencyExchange {IdCurrencySource ="15cdd09b" , IdCurrencyTarget = "aa9803ad" , UnitPrice = 3.85M , State= true , EffectiveDate = DateTime.Now },
                 new CurrencyExchange {IdCurrencySource ="15cdd09b" , IdCurrencyTarget = "0da25f76" , UnitPrice = 4.85M , State= true , EffectiveDate = DateTime.Now }
            };
        }
    }
}
