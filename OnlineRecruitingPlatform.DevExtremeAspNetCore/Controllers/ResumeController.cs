using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Models;
using OnlineRecruitingPlatform.Model.Deserializers;
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
            var resultResumesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.ResumesDirectory>(await _resumesZarplataRuClient.GetResumes(25, 1));

            var viewModel = new BrowseResumesViewModel()
            {
                SearchStringByCityAddressOrZip = "",
                SearchStringByJobTitleSkills = "",
                ResumesZarplataRu = resultResumesZarplataRu.Resumes.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Resume/Browse")]
        public async Task<IActionResult> Browse(BrowseResumesViewModel viewModel)
        {
            var resultResumesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.ResumesDirectory>(await _resumesZarplataRuClient.GetResumes(25, 1, viewModel.SearchStringByJobTitleSkills));

            viewModel.ResumesZarplataRu = resultResumesZarplataRu.Resumes.ToList();

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
