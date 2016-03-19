using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rongYunWebApiSample.Controllers
{
    public class InformationListController : ApiController
    {
        private readonly Models.InformationListDetails.InformationListRepository repository;
        public InformationListController()
        {
            repository = new Models.InformationListDetails.InformationListRepository();
        }

        public HttpResponseMessage GetInformationListByAddress(int pageIndex,int pageSize,string address="")
        {
            IList<Models.InformationListDetails.InformationListModel> lstModel=
                repository.GetInformationListByAddress(pageIndex, pageSize, address);
            if(lstModel.Count>0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lstModel);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
