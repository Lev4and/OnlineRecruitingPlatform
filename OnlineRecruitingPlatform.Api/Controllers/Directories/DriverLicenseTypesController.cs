using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Api.Controllers.Directories
{
    [ApiController]
    [Route("api/directories/driverLicenseTypes/")]
    [Produces("application/json")]
    public class DriverLicenseTypesController : Controller
    {
        private readonly DataManager _dataManager;

        public DriverLicenseTypesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetDriverLicenseTypes()
        {
            try
            {
                return Ok(await Task.Run<IQueryable<DriverLicenseType>>(() =>
                {
                    return _dataManager.DriverLicenseTypes.GetDriverLicenseTypes();
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDriverLicenseType(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<DriverLicenseType>(() =>
                {
                    return _dataManager.DriverLicenseTypes.GetDriverLicenseType(id);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDriverLicenseType([FromBody] DriverLicenseType driverLicenseType)
        {
            try
            {
                if(driverLicenseType == null ? true : driverLicenseType.Id != default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    return _dataManager.DriverLicenseTypes.SaveDriverLicenseType(driverLicenseType);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDriverLicenseType([FromBody] DriverLicenseType driverLicenseType)
        {
            try
            {
                if(driverLicenseType == null ? true : driverLicenseType.Id == default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    return _dataManager.DriverLicenseTypes.SaveDriverLicenseType(driverLicenseType);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDriverLicenseType(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    _dataManager.DriverLicenseTypes.DeleteDriverLicenseType(id);

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
