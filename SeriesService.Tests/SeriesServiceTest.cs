using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeriesService.Controllers;
using SeriesService.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Web.Http.Hosting;

namespace SeriesServiceParser.Tests
{
    [TestClass]
    public class SeriesServiceTest
    {
        // These Setup Controller setting are required in case of HttpResponseMessage
        private void SetupController(ApiController controller) {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:49420/"); // Post at this local endpoint
            var route = config.Routes.MapHttpRoute("DefaultApi", "{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "SeriesService" } });

            controller.ControllerContext = new System.Web.Http.Controllers.HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }

        [TestMethod]
        public void PostTest()
        {
            SeriesServiceRootRequest prRequest = new SeriesServiceRootRequest();
            prRequest.SeriesService = new List<SeriesServiceRequest>();
            SeriesServiceRequest pRequest = new SeriesServiceRequest();
            pRequest.drm = true;
            pRequest.episodeCount = 2;
            pRequest.slug = "Testing Slug";
            pRequest.title = "Testing Title";
            pRequest.image = new Image();
            pRequest.image.showImage = "http://www.somewebsite.com/testing.gif";
            prRequest.SeriesService.Add(pRequest);

            var pc = new SeriesServiceController();
            SetupController(pc); // Required in case of using HttpResponseMessage
            var iResult = pc.Post(prRequest);

            //var createdResult = iResult as System.Web.Http.Results.OkNegotiatedContentResult<SeriesServiceRootResponse>; // i was using IHttpResponseMessage
            dynamic dObject = iResult.Content.ReadAsAsync<object>();

            Assert.IsNotNull(dObject);
            Assert.AreEqual(true, !string.IsNullOrEmpty(dObject.Result.response[0].title));
        }
    }
}
