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
    // Common route to Student
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        // api/student/all
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = StudentService.GetAll();
            if(data == null || !data.Any()) // Check for empty list !data.any() 
            {
                return  Request.CreateResponse(HttpStatusCode.NotFound , "No Student found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // api/student/5
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetById(int id)
        {
            var data = StudentService.Get(id);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found by this ID");
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // api/student/add
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add([FromBody] StudentDTO dto)
        {
          
            var data = StudentService.Add(dto);
            if(data == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Student Not Created");
            }
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        // api/student/update/5
        [HttpPatch]
        [Route("update/{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody]  StudentDTO dto)
        {
           
            
            dto.StudentId = id;

            var data = StudentService.Update(dto);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");
            }
                
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // api/student/5
        [HttpDelete]
        [Route("delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = StudentService.Delete(id);
            if (!result)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
        }
    }
}
