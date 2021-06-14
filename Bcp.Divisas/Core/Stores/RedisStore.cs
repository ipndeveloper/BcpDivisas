using Bcp.Divisas.Core.BaseModels;
using Bcp.Divisas.Core.Utility;
using Newtonsoft.Json;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bcp.Divisas.Core.Stores
{
    public class RedisStore<TResponse,TRequest> :  IExchange<TResponse, TRequest>
        where TResponse : InfoResult<TRequest>, new()  
        where TRequest : CurrencyExchange 
    {

        private readonly IRedisCacheClient _cache;
        private string _redisPattern = "Exchange";
        public RedisStore(IRedisCacheClient cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> GetByIdAsync(TRequest exchange)
        {
            TResponse responseResult = new TResponse();
            if (exchange == null)
            {
                throw new ArgumentNullException(nameof(exchange));
            }
            string identifier = $"{exchange.IdCurrencySource}_{exchange.IdCurrencyTarget}";
            var response = await _cache.Db0.HashGetAllAsync<string>($"{_redisPattern}:{identifier}");
            if (response.Values.Any())
            {
                string exchangeHashValue = response.Values.FirstOrDefault() ?? string.Empty;
                TRequest exchangeDeserialize = JsonConvert.DeserializeObject<TRequest>(exchangeHashValue);
                responseResult.Success = true;
                responseResult.Entity = exchangeDeserialize;
            }
            else
            {
                responseResult.Success = false;
                responseResult.Message = "el registro no existe.";
            }
            return responseResult;

        }
        public async  Task<TResponse> CreateAsync(TRequest exchange)
        {
            await RegisterAsync(exchange);
            return new TResponse { Success = true , Message = "el registro se creo correctamente." };

        }

        public async Task<TResponse> UpdateAsync(TRequest exchange)
        {

            TResponse responseResult = new TResponse ();
            if (exchange == null)
            {
                throw new ArgumentNullException(nameof(exchange));
            }
            string identifier = $"{exchange.IdCurrencySource}_{exchange.IdCurrencyTarget}";
            var response = await _cache.Db0.HashGetAllAsync<string>($"{_redisPattern}:{identifier}");

            if (response.Values.Any())
            {
                string exchangeHashValue = response.Values.FirstOrDefault() ?? string.Empty;
                TRequest exchangeDeserialize = JsonConvert.DeserializeObject<TRequest>(exchangeHashValue);
                exchangeDeserialize.State = false;
                Task TaskEdit =     EditAsync(exchangeDeserialize);
                Task TaskRegister = RegisterAsync(exchange);
                await Task.WhenAll(TaskEdit, TaskRegister);
                responseResult.Success = true;
                responseResult.Message = "el registro se actualizo correctamente.";
            }
            else
            {
                responseResult.Success = false;
                responseResult.Message = "el registro no existe , no se puede actualizar.";
            }
            return responseResult;
        }
        private   async Task RegisterAsync(TRequest exchange)
        {
            if (exchange == null)
            {
                throw new ArgumentNullException(nameof(exchange));
            }
            string Id =Serial.GetId();
            exchange.Id = Id;
            string identifier = $"{exchange.IdCurrencySource}_{exchange.IdCurrencyTarget}_{Id}";
            await _cache.Db0.HashSetAsync($"{_redisPattern}:{identifier}", identifier, JsonConvert.SerializeObject(exchange));
            
        }
        private async Task EditAsync(TRequest exchange)
        {
            if (exchange == null)
            {
                throw new ArgumentNullException(nameof(exchange));
            }
           
            string identifier = $"{exchange.IdCurrencySource}_{exchange.IdCurrencyTarget}_{exchange.Id}";
            await _cache.Db0.HashSetAsync($"{_redisPattern}:{identifier}", identifier, JsonConvert.SerializeObject(exchange));

        }
    }
}
