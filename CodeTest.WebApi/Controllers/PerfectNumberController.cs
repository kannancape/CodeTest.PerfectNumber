using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeTest.BL;
using System.Collections.Generic;
using CodeTest.Model.Response;
using Microsoft.Extensions.Logging;
using System.Runtime.Serialization;
using CodeTest.Excepetion;
using CodeTest.BL.Interface;

namespace CodeTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfectNumberController : ControllerBase
    {

        private ILogger<PerfectNumberController> _logger;
        private IModelService _modelService;
        public PerfectNumberController(ILogger<PerfectNumberController> logger, IModelService modelService)
        {
            this._logger = logger;
            this._modelService = modelService ?? throw new ArgumentNullException(nameof(modelService)); 
        }
        [HttpGet(Name = "GetPerfectNumber")]
        [ProducesResponseType(typeof(PerfectNumberOutput), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PerfectNumberOutput), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(PerfectNumberOutput), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(PerfectNumberOutput), StatusCodes.Status503ServiceUnavailable)]
        public IActionResult Get(int startNo, int endNo)
        {

            if (startNo <= 0 || endNo <= 0)
            {
                return BadRequest();
            }
            List<PerfectNumberOutput> perfectNoList = new List<PerfectNumberOutput>();
            try
            {
                perfectNoList = _modelService.GetPerfectNumber(startNo, endNo);
                if (perfectNoList.Any())
                { 
                    return Ok(perfectNoList);
                } 
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw (new ExceptionMessage("Zero found"));

            }
        }
    }


}
