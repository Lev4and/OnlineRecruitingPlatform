using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Api.Controllers.Directories
{
    [ApiController]
    [Route("api/directories/applicantCommentAccessTypes/")]
    [Produces("application/json")]
    public class ApplicantCommentAccessTypesController : Controller
    {
        private readonly DataManager _dataManager;

        public ApplicantCommentAccessTypesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicantCommentAccessTypes()
        {
            try
            {
                return Ok(await Task.Run<IQueryable<ApplicantCommentAccessType>>(() =>
                {
                    return _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessTypes();
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApplicantCommentAccessType(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<ApplicantCommentAccessType>(() =>
                {
                    return _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessType(id, true);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddApplicantCommentAccessType([FromBody]ApplicantCommentAccessType applicantCommentAccessType)
        {
            try
            {
                if(applicantCommentAccessType == null ? true : applicantCommentAccessType.Id != default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() =>
                {
                    return _dataManager.ApplicantCommentAccessTypes.SaveApplicantCommentAccessType(applicantCommentAccessType);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplicantCommentAccessType([FromBody]ApplicantCommentAccessType applicantCommentAccessType)
        {
            try
            {
                if (applicantCommentAccessType == null ? true : applicantCommentAccessType.Id == default)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() => 
                {
                    return _dataManager.ApplicantCommentAccessTypes.SaveApplicantCommentAccessType(applicantCommentAccessType);
                }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplicantCommentAccessType(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest();
                }

                return Ok(await Task.Run<bool>(() => 
                {
                    _dataManager.ApplicantCommentAccessTypes.DeleteApplicantCommentAccessType(id);

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
