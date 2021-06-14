using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Models;
using OnlineRecruitingPlatform.Model.Deserializers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarplataRu = OnlineRecruitingPlatform.Model.API.ZarplataRu;
using ZarplataRuClients = OnlineRecruitingPlatform.HttpClients.ZarplataRu.Clients;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ZarplataRuClients.Resumes.ResumesClient _resumesZarplataRuClient;

        public ResumeController(ZarplataRuClients.Resumes.ResumesClient resumesZarplataRuClient)
        {
            _resumesZarplataRuClient = resumesZarplataRuClient;
        }

        [Route("~/Resume")]
        [Route("~/Resume/Browse")]
        public async Task<IActionResult> Browse()
        {
            var resultResumesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.ResumesDirectory>(await _resumesZarplataRuClient.GetResumes(25, 0));

            var viewModel = new BrowseResumesViewModel()
            {
                NumberPage = 1,
                SearchStringByCityAddressOrZip = "",
                SearchStringByJobTitleSkills = "",
                ResumesZarplataRu = resultResumesZarplataRu.Resumes.ToList(),
                CountItems = resultResumesZarplataRu.Metadata.Resultset.Count
            };

            viewModel.GeneratePagination();

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Resume/Browse")]
        public async Task<IActionResult> Browse(BrowseResumesViewModel viewModel)
        {
            var resultResumesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.ResumesDirectory>(await _resumesZarplataRuClient.GetResumes(25, viewModel.NumberPage * 25, viewModel.SearchStringByJobTitleSkills));

            if (resultResumesZarplataRu == null)
            {
                resultResumesZarplataRu = new ZarplataRu.ResumesDirectory()
                {
                    Metadata = new ZarplataRu.Metadata()
                    {
                        Resultset = new ZarplataRu.Resultset()
                        {
                            Count = 0
                        }
                    },
                    Resumes = new List<dynamic>().ToArray()
                };
            }

            viewModel.ResumesZarplataRu = resultResumesZarplataRu.Resumes.ToList();
            viewModel.CountItems = resultResumesZarplataRu.Metadata.Resultset.Count;
            viewModel.GeneratePagination();

            return View(viewModel);
        }

        [Route("~/Resume/{type}/{id}")]
        public async Task<IActionResult> Details(string type, int id)
        {
            if (type == "ZarplataRu")
            {
                var result = await GzipDeserializer.Deserialize<dynamic>(await _resumesZarplataRuClient.GetResume(id));

                return View("DetailsResumeZarplataRu", result.resumes[0]);
            }

            return View("DetailsResume");
        }
    }
}
