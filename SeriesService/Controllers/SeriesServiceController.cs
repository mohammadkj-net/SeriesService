using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SeriesService.Models;

namespace SeriesService.Controllers
{
    public class SeriesServiceController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(SeriesServiceRootRequest SeriesServiceRequest)
        {
            SeriesServiceRootResponse prr = new SeriesServiceRootResponse();
            prr.response = new List<SeriesServiceResponse>();
            if (SeriesServiceRequest != null && SeriesServiceRequest.SeriesService != null && SeriesServiceRequest.SeriesService.Count > 0)
            {
                foreach (SeriesServiceRequest pr in SeriesServiceRequest.SeriesService)
                {
                    if (pr.drm == true && pr.episodeCount > 0)
                    {
                        SeriesServiceResponse pResponse = new SeriesServiceResponse();
                        pResponse.image = pr.image.showImage;
                        pResponse.slug = pr.slug;
                        pResponse.title = pr.title;
                        prr.response.Add(pResponse);
                    }
                }
                var response = Request.CreateResponse(HttpStatusCode.OK, prr);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Could not decode request: JSON parsing failed" });
            }
        }
    }
}


