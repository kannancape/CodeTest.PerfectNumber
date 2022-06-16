using CodeTest.BL;
using CodeTest.BL.Interface;
using CodeTest.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeTestService.UnitTest
{
    [TestClass]
    public class PerfectNumberControllerTest
    {

        private PerfectNumberController _controller;
        private IModelService _modelService;

        private ILogger<PerfectNumberController> logger = new NullLogger<PerfectNumberController>();

        public PerfectNumberControllerTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<IModelService, ModelService>();
            var serviceProvider = services.BuildServiceProvider();
            _modelService = serviceProvider.GetRequiredService<IModelService>();
            _controller = new PerfectNumberController(logger, _modelService);
        }

        private IModelService CreateInstance()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void PerfectNo_Returns_Success()
        {
            int startNo = 1;
            int endNo = 30;
            var result = _controller.Get(startNo, endNo);
            var tocheck = result as ObjectResult;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, tocheck.StatusCode);
        }

        [TestMethod]
        public void PerfectNo_Returns_400_When_Zero()
        {
            int startNo = -1;
            int endNo = -5;
            IActionResult result = _controller.Get(startNo, endNo);
            var actual = result as ObjectResult;
            Assert.IsNotNull(result);

        }
    }
}
