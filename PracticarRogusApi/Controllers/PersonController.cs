using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticarRogusApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        DataAccess dataAccess;

        public PersonController(IConfiguration configuration, ApplicationDbContext context)
        {
            
            dataAccess =  new DataAccess(configuration["ConnectionStrings:Main"], context);
        }
        [HttpGet]
        public async Task<ActionResult> GetPersonDataLinq(string id)
        {
            try
            {
                var result = await dataAccess.requestLinq(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetPersonDataSqlCommand(string id)
        {
            try
            {
                var result = dataAccess.requestSqlCommand(id)[0];
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
