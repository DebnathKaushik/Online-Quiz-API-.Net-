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
        // api/quiz/all
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = QuizService.GetAll();
            if (data == null || !data.Any()) // Check for empty list !data.any() 
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Quiz found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // api/quiz/by-teacher/3
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

        // api/quiz/by-subject-name/Math
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


        // api/quiz/add
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


        // api/quiz/update/6
        [HttpPatch]
        [Route("update/{id:int}")]
        public HttpResponseMessage Update(int id ,[FromBody] QuizDTO dto)
        {
            
            dto.QuizId = id;

            var data = QuizService.Update(dto);
            if (data == null )
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Quiz not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        // api/quiz/delete/5
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



        // ----------------------------(Search/filter)-------------------------------
        [HttpGet]
        [Route("search")]
        public HttpResponseMessage Search(string title = null, int? teacherId = null)
        {
            var data = QuizService.GetAll();

            // now filter title 
            if (!string.IsNullOrEmpty(title))
            {
                data = data.Where(q => q.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            // now filter teacher id
            if (teacherId.HasValue)
            {
                data = data.Where(q => q.TeacherId ==  teacherId.Value).ToList();
            }

            // if No data found in db
            if (!data.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No quizzes found based on this Parameter");
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        // ----------------------------(Recommondation Quiz)-------------------------------

        [HttpGet]
        [Route("popular")]
        public HttpResponseMessage GetPopularQuizzes(int top) // here top is quesy param(that i pass from url)
        {
            var data = QuizService.GetPopularQuizzes(top);
            if(data == null || !data.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Recommodation found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // ------------------(Quiz status change)--------------------------------------------
        [HttpPatch]
        [Route("status/{quizId:int}/{teacherId:int}/{newStatus:bool}")]
        public HttpResponseMessage ChangeStatus(int quizId, int teacherId, bool newStatus)
        {
            var success = QuizService.changeQuizStatus(quizId, teacherId, newStatus);

            if (!success)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Quiz not found or teacher not found!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Quiz status updated to {(newStatus ? "Active" : "Inactive")}");
        }






    }
}
