using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    [RoutePrefix("api/notification")]
    public class NotificationController : ApiController
    {
        // api/notification/all
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = NotificationService.GetAll();
            if(data == null || !data.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Notification's Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { 
                Message="Here is all Notification",
                data });
        }


        //  api/notification/add
       /* 
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add([FromBody] NotificationDTO dto)
        {
            var data = NotificationService.Add(dto);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Notification not created");
            }
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }
       */

    }
}
