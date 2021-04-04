using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Api.Controllers.Directories
{
    [ApiController]
    [Route("api/directories/applicantCommentsOrders/")]
    [Produces("application/json")]
    public class ApplicantCommentsOrdersController : Controller
    {
        private readonly DataManager _dataManager;

        public ApplicantCommentsOrdersController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicantCommentsOrders()
        {
            try
            {
                return Ok(await Task.Run<IQueryable<ApplicantCommentsOrder>>(() =>
                {
                    return _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrders();
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApplicantCommentsOrder(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<ApplicantCommentsOrder>(() =>
                {
                    return _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrder(id, true);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddApplicantCommentsOrder([FromBody] ApplicantCommentsOrder applicantCommentsOrder)
        {
            try
            {
                if(applicantCommentsOrder == null ? true : applicantCommentsOrder.Id != default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    return _dataManager.ApplicantCommentsOrders.SaveApplicantCommentsOrder(applicantCommentsOrder);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplicantCommentsOrder([FromBody] ApplicantCommentsOrder applicantCommentsOrder)
        {
            try
            {
                if(applicantCommentsOrder == null ? true : applicantCommentsOrder.Id == default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    return _dataManager.ApplicantCommentsOrders.SaveApplicantCommentsOrder(applicantCommentsOrder);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteApplicantCommentsOrder(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    _dataManager.ApplicantCommentsOrders.DeleteApplicantCommentsOrder(id);

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
