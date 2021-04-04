using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DatabaseController : Controller
    {
        private readonly DataManager _dataManager;

        private readonly CurrenciesClient _currenciesClient;
        private readonly ApplicantCommentsOrdersClient _applicantCommentsOrdersClient;
        private readonly BusinessTripReadinessTypesClient _businessTripReadinessTypesClient;
        private readonly ApplicantCommentAccessTypesClient _applicantCommentAccessTypesClient;
        private readonly ApplicantNegotiationStatusesClient _applicantNegotiationStatusesClient;

        public DatabaseController(DataManager dataManager, CurrenciesClient currenciesClient, ApplicantCommentsOrdersClient applicantCommentsOrdersClient, BusinessTripReadinessTypesClient businessTripReadinessTypesClient, ApplicantCommentAccessTypesClient applicantCommentAccessTypesClient, ApplicantNegotiationStatusesClient applicantNegotiationStatusesClient)
        {
            _dataManager = dataManager;

            _currenciesClient = currenciesClient;
            _applicantCommentsOrdersClient = applicantCommentsOrdersClient;
            _businessTripReadinessTypesClient = businessTripReadinessTypesClient;
            _applicantCommentAccessTypesClient = applicantCommentAccessTypesClient;
            _applicantNegotiationStatusesClient = applicantNegotiationStatusesClient;
        }

        [Route("Admin/Database/ApplicantCommentAccessTypes/")]
        public async Task<IActionResult> ApplicantCommentAccessTypes()
        {
            var result = await Task.Run<List<ApplicantCommentAccessType>>(() =>
            {
                return _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessTypes().ToList();
            });

            ViewBag.applicantCommentAccessTypes = result;

            return View();
        }
        
        [HttpGet]
        [Route("Admin/Database/SaveOrEditApplicantCommentAccessType/{id?}")]
        public async Task<IActionResult> SaveOrEditApplicantCommentAccessType(Guid? id)
        {
            var result = new ApplicantCommentAccessType();
            
            if (id != null)
            {
                result = await Task.Run<ApplicantCommentAccessType>(() =>
                {
                    return _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessType(id: (Guid) id,
                        true);
                });
            }

            ViewBag.applicantCommentAccessType = result;

            return View();
        }
    }
}