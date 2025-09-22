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

    // Common route for Option
    [RoutePrefix("api/option")]
    public class OptionController : ApiController
    {
        // api/option/by-question/1
        [HttpGet]
        [Route("by-question/{questionId:int}")]
        public HttpResponseMessage GetByQuestion(int questionId)
        {
            var data = OptionService.GetByQuestion(questionId);
            if (data == null || !data.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Options not found for this Question ID");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // api/option/add
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add([FromBody] OptionDTO dto)
        {
            var data = OptionService.Add(dto);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Option not created");
            }
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        // api/option/update/5
        [HttpPatch]
        [Route("update/{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody] OptionDTO dto)
        {
            dto.OptionId = id;  
            var data = OptionService.Update(dto);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Option not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        // api/option/delete/5
        [HttpDelete]
        [Route("delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = OptionService.Delete(id);
            if (!result)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Option not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
        }
    }
}
