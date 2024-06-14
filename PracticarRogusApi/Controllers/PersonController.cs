using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticarRogusApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly string _connectionString;
        DataAccess dataAccess;

        public PersonController(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:Main"];
            dataAccess =  new DataAccess(_connectionString);
        }
        [HttpGet]
        public ActionResult GetPersonDataLinq(string id)
        {
            try
            {
                var result = dataAccess.requestLinq(id);
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
                var result = dataAccess.requestSqlCommand(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
