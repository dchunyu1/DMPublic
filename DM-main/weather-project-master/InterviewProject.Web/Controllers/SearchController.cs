using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewProject.Data;
using InterviewProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        // GET: api/<SearchController>
        [HttpGet]
        public async Task<List<Location>> GetAsync(string search)
        {
            var searchBylocation = new SearchByLocation();
            List<Location> result = await searchBylocation.SearchAsync(search);
            return result;
        }


    }
}
