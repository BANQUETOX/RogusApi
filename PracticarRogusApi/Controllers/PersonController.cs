using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticarRogusApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetPersonDataLinq(string id)
        {
            try
            {
                var result = DataAccess.requestLinq(id);
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
                var result = DataAccess.requestSqlCommand(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
