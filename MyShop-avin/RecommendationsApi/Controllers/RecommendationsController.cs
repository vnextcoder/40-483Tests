using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RecommendationsApi.Controllers
{
    [Route("api/[controller]")]
    public class RecommendationsController : Controller
    {
        // GET api/Recommendations
        [HttpGet]
        public string Get()
        {
            string RecommendationsApiVersion = "1.4";
            return $"Executing RecommendationsApi version {RecommendationsApiVersion}. Hostname : {Environment.MachineName}";
        }
    }
}
