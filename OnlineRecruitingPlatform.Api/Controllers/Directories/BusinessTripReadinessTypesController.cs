using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Api.Controllers.Directories
{
    [ApiController]
    [Route("api/directories/businessTripReadinessTypes/")]
    [Produces("apllication/json")]
    public class BusinessTripReadinessTypesController : Controller
    {
        private readonly DataManager _dataManager;

        public BusinessTripReadinessTypesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinessTripReadinessTypes()
        {
            try
            {
                return Ok(await Task.Run<IQueryable<BusinessTripReadiness>>(() =>
                {
                    return _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadinessTypes();
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBusinessTripReadiness(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<BusinessTripReadiness>(() =>
                {
                    return _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadiness(id, true);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBusinessTripReadiness([FromBody] BusinessTripReadiness businessTripReadiness)
        {
            try
            {
                if(businessTripReadiness == null ? true : businessTripReadiness.Id != default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    return _dataManager.BusinessTripReadinessTypes.SaveBusinessTripReadiness(businessTripReadiness);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBusinessTripReadiness([FromBody] BusinessTripReadiness businessTripReadiness)
        {
            try
            {
                if(businessTripReadiness == null ? true : businessTripReadiness.Id == default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    return _dataManager.BusinessTripReadinessTypes.SaveBusinessTripReadiness(businessTripReadiness);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBusinessTripReadiness(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    _dataManager.BusinessTripReadinessTypes.DeleteBusinessTripReadiness(id);

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
