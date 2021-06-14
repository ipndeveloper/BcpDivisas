using Bcp.Divisas.BaseModels;
using Bcp.Divisas.Core.BaseModels;
using Bcp.Divisas.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bcp.Divisas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {

        private readonly ForeignExchangeManager<InfoResult<CurrencyExchange>, CurrencyExchange> _convertManager;
        public ManagerController(ForeignExchangeManager<InfoResult<CurrencyExchange>, CurrencyExchange> convertManager)
        {
            _convertManager = convertManager;
        }
        [HttpPost("UpdateExchange")]
        public async Task<InfoResult<CurrencyExchange>> UpdateExchange(CurrencyExchange convertion)
        {
            return await _convertManager.UpdateAsync(convertion);
        }
    }
}
