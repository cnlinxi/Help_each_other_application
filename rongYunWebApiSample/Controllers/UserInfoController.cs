using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rongYunWebApiSample.Controllers
{
    public class UserInfoController : ApiController
    {
        private readonly Models.UserDetails.UserInfoRepository repository;

        public UserInfoController()
        {
            repository = new Models.UserDetails.UserInfoRepository();
        }

        [HttpGet]
        public HttpResponseMessage GetUser(string userName)
        {
            Models.UserDetails.UserModel model = repository.GetModel(userName);
            if (model != null)
                return Request.CreateResponse(HttpStatusCode.OK, model);
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpPost]
        public HttpResponseMessage CreateUser(Models.UserDetails.UserModel model)
        {
            if(ModelState.IsValid&&model!=null)
            {
                string token = repository.CreateUser(model);
                if (token == "Repeat UserName")
                    return Request.CreateResponse(HttpStatusCode.Conflict);
                if (token!=string.Empty)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, token);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
