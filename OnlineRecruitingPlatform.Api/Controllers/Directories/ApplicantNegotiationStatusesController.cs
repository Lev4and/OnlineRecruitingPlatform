using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Api.Controllers.Directories
{
    [ApiController]
    [Route("api/directories/applicantNegotiationStatuses/")]
    [Produces("apllication/json")]
    public class ApplicantNegotiationStatusesController : Controller
    {
        private readonly DataManager _dataManager;

        public ApplicantNegotiationStatusesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicantNegotiationStatuses()
        {
            try
            {
                return Ok(await Task.Run<IQueryable<ApplicantNegotiationStatus>>(() =>
                {
                    return _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatuses();
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApplicantNegotiationStatus(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<ApplicantNegotiationStatus>(() =>
                {
                    return _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatus(id);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddApplicantNegotiationStatus([FromBody] ApplicantNegotiationStatus applicantNegotiationStatus)
        {
            try
            {
                if(applicantNegotiationStatus == null ? true : applicantNegotiationStatus.Id != default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    return _dataManager.ApplicantNegotiationStatuses.SaveApplicantNegotiationStatus(applicantNegotiationStatus);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplicantNegotiationStatus([FromBody] ApplicantNegotiationStatus applicantNegotiationStatus)
        {
            try
            {
                if(applicantNegotiationStatus == null ? true : applicantNegotiationStatus.Id == default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    return _dataManager.ApplicantNegotiationStatuses.SaveApplicantNegotiationStatus(applicantNegotiationStatus);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteApplicantNegotiationStatus(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    _dataManager.ApplicantNegotiationStatuses.DeleteApplicantNegotiationStatus(id);

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
