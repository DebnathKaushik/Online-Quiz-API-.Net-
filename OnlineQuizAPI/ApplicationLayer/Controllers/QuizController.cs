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
    // Common route for all Quiz
    [RoutePrefix("api/quiz")]
    public class QuizController : ApiController
    {
        // GET: api/quiz/all
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = QuizService.GetAll();
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Quiz found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // GET: api/quiz/by-teacher/3
        [HttpGet]
        [Route("by-teacher/{teacherId:int}")]
        public HttpResponseMessage GetByTeacher(int teacherId)
        {
            var data = QuizService.GetByTeacher(teacherId);
            if (data == null || !data.Any()) // Check for empty list !data.any() 
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Quiz not found for this Teacher ID");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // GET: api/quiz/by-subject-name/Math
        [HttpGet]
        [Route("by-subject-name/{subjectName}")]
        public HttpResponseMessage GetBySubject(string subjectName)
        {
            var data = QuizService.GetBySubject(subjectName);
            if (data == null || !data.Any()) // Check for empty list !data.any() 
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Quiz not found for this Subject Name");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        // POST: api/quiz/add
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add([FromBody] QuizDTO dto)
        {
            var data = QuizService.Add(dto);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Quiz Not Created");
            }
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }


        // PATCH: api/quiz/update/6
        [HttpPatch]
        [Route("update/{id:int}")]
        public HttpResponseMessage Update(int id ,[FromBody] QuizDTO dto)
        {
            //map id(url id) = dto.id(Quiz obj id)
            dto.QuizId = id;

            var data = QuizService.Update(dto);
            if (data == null )
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Quiz not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        // DELETE: api/quiz/delete/5
        [HttpDelete]
        [Route("delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = QuizService.Delete(id);
            if (!result)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Quiz not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
        }
    }
}
