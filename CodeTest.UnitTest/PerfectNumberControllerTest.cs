using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeTest.WebApi.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;
using CodeTest.Model.Response;
using Microsoft.AspNetCore.Http;

namespace CodeTestService.UnitTest
{
    [TestClass]
    public class PerfectNumberControllerTest
    {

        private PerfectNumberController _controller;
        private ILogger<PerfectNumberController> logger = new NullLogger<PerfectNumberController>();
        [TestMethod]
        public void TestSetUp()
        { 
            _controller = new PerfectNumberController(logger);
        }

        [TestMethod]
        public void GetCustomerInfoMethod()
        { 
            int startNo = 1;
            int endNo = 30;
            var result = _controller.Get(startNo, endNo);
            var tocheck = result as ObjectResult;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, tocheck.StatusCode);
        }
        
    }
}
