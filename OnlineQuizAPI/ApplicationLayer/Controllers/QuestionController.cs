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
    // Common route for the Question 
    [RoutePrefix("api/question")]
    public class QuestionController : ApiController
    {
        // api/question/all
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = QuestionService.GetAll();
            if (data == null || !data.Any()) // for check (if)empty list [!data.Any()]
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No questions found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // api/question/by-quiz/3
        [HttpGet]
        [Route("by-quiz/{quizId:int}")]
        public HttpResponseMessage GetByQuiz(int quizId)
        {
            var data = QuestionService.GetByQuiz(quizId);
            if (data == null || !data.Any()) // for check (if)empty list [!data.Any()]
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No questions found for this Quiz");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // api/question/add
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add([FromBody] QuestionDTO dto)
        {
            var data = QuestionService.Add(dto);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Question not created");
            }

            return Request.CreateResponse(HttpStatusCode.Created, data);
        }


        // api/question/add-with-options
        [HttpPost]
        [Route("add-with-options")]
        public HttpResponseMessage AddWithOptions([FromBody] QuestionDetailDTO dto)
        {
            var data = QuestionService.AddwithOption(dto);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }


        // api/question/update/7
        [HttpPatch]
        [Route("update/{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody] QuestionDTO dto)
        {
            
            dto.QuestionId = id; // store url(id) in Question Obj Id

            var data = QuestionService.Update(dto);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Question not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        // api/question/delete/5
        [HttpDelete]
        [Route("delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = QuestionService.Delete(id);
            if (!result)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Question not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
        }
    }
}
