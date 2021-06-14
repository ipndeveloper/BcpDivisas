using Bcp.Divisas.BaseModels;
using Bcp.Divisas.Core.BaseModels;
using Bcp.Divisas.Core.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bcp.Divisas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly ConvertManager<InfoResult<CurrencyExchange>, ConvertResponse, Convertion , CurrencyExchange> _convertManager;
        public ConvertController(ConvertManager<InfoResult<CurrencyExchange>, ConvertResponse, Convertion, CurrencyExchange> convertManager)
        {
            _convertManager = convertManager;
        }
       
        [HttpPost("ConvertMoney")]
        public Task<ConvertResponse> ConvertMoney(Convertion convertion)
        {
            return _convertManager.ConvertMoney(convertion);
        }
    }
}
