using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeTest.BL;
using System.Collections.Generic;
using CodeTest.Model.Response;
using Microsoft.Extensions.Logging;
using System.Runtime.Serialization;
using CodeTest.Excepetion;

namespace CodeTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfectNumberController : ControllerBase
    {

        private ILogger<PerfectNumberController> _logger; 
        public PerfectNumberController(ILogger<PerfectNumberController> logger)
        {
            this._logger = logger;
        } 
        [HttpGet(Name = "GetPerfectNumber")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult Get(int startNo, int endNo)
        {
            var objPerfectNo = new ModelService();
            List<PerfectNumberOutput> perfectNoList = new List<PerfectNumberOutput>();
            try
            {
                perfectNoList = objPerfectNo.GetPerfectNumber(startNo, endNo);
                if (perfectNoList.Count > 0)
                {
                    if (perfectNoList != null)
                    {
                        return Ok(perfectNoList);
                    }
                }

                return Ok("No Perfect number");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw (new ExceptionMessage("Zero found"));
                
            }
        }
    }

    
}
