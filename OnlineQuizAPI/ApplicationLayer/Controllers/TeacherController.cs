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
    // Common route for teacher
    [RoutePrefix("api/teacher")]
    public class TeacherController : ApiController
    {
        // api/teacher/all
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = TeacherService.GetAll();
            if(data == null || !data.Any()) // Check for empty list !data.any() 
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,"No Teacher Found!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // api/teacher/12
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetById(int id)
        {
            var data = TeacherService.Get(id);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Teacher not found by this ID");
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // api/teacher/add
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add([FromBody] TeacherDTO dto)
        {
            var data = TeacherService.Add(dto);
            if(data == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Teacher Not Created");
            }
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }


        // api/teacher/update/55
        [HttpPatch]
        [Route("update/{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody] TeacherDTO dto)
        {
            
            dto.TeacherId = id;  // store url(id) in Teacher Obj Id
            var data = TeacherService.Update(dto);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Teacher not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        // api/teacher/delete/14
        [HttpDelete]
        [Route("delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = TeacherService.Delete(id);
            if (!result)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Teacher not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
        }

    }
}
