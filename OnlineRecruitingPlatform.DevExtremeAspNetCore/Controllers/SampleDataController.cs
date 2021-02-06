using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using OnlineRecruitingPlatform_DevExtremeAspNetCore.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace OnlineRecruitingPlatform_DevExtremeAspNetCore.Controllers {

    [Route("api/[controller]")]
    public class SampleDataController : Controller {

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions) {
            return DataSourceLoader.Load(SampleData.Orders, loadOptions);
        }

    }
}