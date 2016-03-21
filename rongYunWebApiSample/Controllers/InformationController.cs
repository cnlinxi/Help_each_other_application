using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rongYunWebApiSample.Controllers
{
    public class InformationController : ApiController
    {
        private readonly Models.InformationDetails.InformationRepository repository;
        public InformationController()
        {
            repository = new Models.InformationDetails.InformationRepository();
        }

        [HttpGet]
        public HttpResponseMessage GetInformationByUserName(string userName)
        {
            IList<Models.InformationDetails.InformationModel> lstModel
                = repository.GetModelsByUserName(userName);
            if(lstModel.Count>0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lstModel);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpGet]
        public HttpResponseMessage GetInformationById(string id)
        {
            Models.InformationDetails.InformationModel model=
                repository.GetModelById(id);
            if(model!=null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage CreateInformation(Models.InformationDetails.InformationModel model)
        {
            if (ModelState.IsValid&&model!=null)
            {
                if (repository.CreateInformation(model) > 0)
                    return Request.CreateResponse(HttpStatusCode.Created);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
