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
    // Common for all Student who give quiz(QuizAttempt)
    [RoutePrefix("api/attempt")]
    public class StudentQuizAttemptController : ApiController
    {
        // api/attempt/by-student/3
        [HttpGet]
        [Route("by-student/{studentId:int}")]
        public HttpResponseMessage GetByStudent(int studentId)
        {
            var data = StudentQuizAttemptService.GetByStudent(studentId);
            if (data == null || !data.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Student attempt Quiz by this Student ID");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // api/attempt/by-quiz/2
        [HttpGet]
        [Route("by-quiz/{quizId:int}")]
        public HttpResponseMessage GetByQuiz(int quizId)
        {
            var data = StudentQuizAttemptService.GetByQuiz(quizId);
            if (data == null || !data.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Student attempt Quiz by this Quiz ID");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        // api/attempt/add
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add([FromBody] StudentQuizAttemptDTO dto)
        {
            var data = StudentQuizAttemptService.Add(dto);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Student Attempt Quiz  not created");
            }
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }


        // api/attempt/update/5
        [HttpPatch]
        [Route("update/{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody] StudentQuizAttemptDTO dto)
        {
            dto.AttemptId = id; 
            var data = StudentQuizAttemptService.Update(dto);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student Attempt not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        // api/attempt/delete/5
        [HttpDelete]
        [Route("delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = StudentQuizAttemptService.Delete(id);
            if (!result)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Attempt not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
        }
    }
}
