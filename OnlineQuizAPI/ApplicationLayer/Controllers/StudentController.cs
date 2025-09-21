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
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        // GET: api/student/all
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = StudentService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // GET: api/student/5
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetById(int id)
        {
            var data = StudentService.Get(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // POST: api/student
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add([FromBody] StudentDTO dto)
        {
          
            var data = StudentService.Add(dto);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // PUT: api/student
        [HttpPatch]
        [Route("update/{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody]  StudentDTO dto)
        {
           
            //map id(url id) = dto.id(student obj id)
            dto.StudentId = id;

            var data = StudentService.Update(dto);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // DELETE: api/student/5
        [HttpDelete]
        [Route("delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = StudentService.Delete(id);
            if (!result)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
        }
    }
}
