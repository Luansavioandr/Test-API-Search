using Microsoft.AspNetCore.Mvc;
using Test_API_Search.Business;
using Test_API_Search.Models;

namespace Test_API_Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchApi
    {
        [HttpGet]
        public JsonResult RequestSearch(String search)
        {
            var result = new SearchBusiness().SearchRequest(search);
            return new JsonResult(result);
        }
    }
}
