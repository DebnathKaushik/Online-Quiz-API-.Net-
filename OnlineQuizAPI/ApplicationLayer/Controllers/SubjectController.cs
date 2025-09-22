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
    // Common route for all subject 
    [RoutePrefix("api/subject")]
    public class SubjectController : ApiController
    {
        // GET: api/subject/all
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = SubjectService.GetAll();
            if(data == null || !data.Any()) // Check for empty list !data.any() 
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,"No Subjects Found!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        // GET: api/subject/byquizId/5
        [HttpGet]
        [Route("byquizId/{quizId:int}")]
        public HttpResponseMessage GetByQuiz(int quizId)
        {
            var data = SubjectService.GetByQuiz(quizId);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Subject not found for this quiz ID");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        // POST: api/subject/add
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add([FromBody] SubjectDTO dto)
        {
            var data = SubjectService.Add(dto);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        // PATCH: api/subject/update/5
        [HttpPatch]
        [Route("update/{id:int}")]
        public HttpResponseMessage Update(int id , [FromBody] SubjectDTO dto)
        {
            //map id(url id) = dto.id(Subject obj id)
            dto.SubjectId = id;
            var data = SubjectService.Update(dto);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Subject not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // DELETE: api/subject/delete/5
        [HttpDelete]
        [Route("delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = SubjectService.Delete(id);
            if (!result)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Subject not found");

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
        }



    }
}
