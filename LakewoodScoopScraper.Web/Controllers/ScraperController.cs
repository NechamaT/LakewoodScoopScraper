using LakewoodScoopScaper.Scraper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LakewoodScoopScraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<LakewoodScoopElement> Scrape()
        {
            return Scraper.ScrapeResults();
        }
    }
}
