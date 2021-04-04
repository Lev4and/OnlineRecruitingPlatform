using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Api.Controllers.Directories
{
    [ApiController]
    [Route("api/directories/currencies/")]
    [Produces("application/json")]
    public class CurrenciesController : Controller
    {
        private readonly DataManager _dataManager;

        public CurrenciesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrencies()
        {
            try
            {
                return Ok(await Task.Run<IQueryable<Currency>>(() =>
                {
                    return _dataManager.Currencies.GetCurrencies();
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCurrency(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<Currency>(() =>
                {
                    return _dataManager.Currencies.GetCurrency(id, true);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCurrency([FromBody] Currency currency)
        {
            try
            {
                if(currency == null ? true : currency.Id != default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    return _dataManager.Currencies.SaveCurrency(currency);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCurrency([FromBody] Currency currency)
        {
            try
            {
                if(currency == null ? true : currency.Id == default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    return _dataManager.Currencies.SaveCurrency(currency);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCurrency(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    _dataManager.Currencies.DeleteCurrency(id);

                    return true;
                }));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
