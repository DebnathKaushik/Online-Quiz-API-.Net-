using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class QuestionService
    {
        // AutoMapper config for Question <-> QuestionDTO <-> QuestionDetailDTO
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionDTO>().ReverseMap();
                cfg.CreateMap<Question, QuestionDetailDTO>().ReverseMap();
                cfg.CreateMap<Quiz, QuizDTO>().ReverseMap(); // For details
            });
            return new Mapper(config);
        }


        // Get all questions
        public static List<QuestionDTO> GetAll()
        {
            var data = DataAccessFactory.QuestionData().GetAll();
            return GetMapper().Map<List<QuestionDTO>>(data);
        }

        // Get questions by Quiz ID
        public static List<QuestionDTO> GetByQuiz(int quizId)
        {
            var data = DataAccessFactory.QuestionData().GetByQuiz(quizId);
            return GetMapper().Map<List<QuestionDTO>>(data);
        }

        // Add new question
        public static QuestionDTO Add(QuestionDTO dto)
        {
            var entity = GetMapper().Map<Question>(dto);
            var added = DataAccessFactory.QuestionData().Add(entity);
            return GetMapper().Map<QuestionDTO>(added);
        }

        // Update existing question
        public static QuestionDTO Update(QuestionDTO dto)
        {
            var entity = GetMapper().Map<Question>(dto);
            var updated = DataAccessFactory.QuestionData().Update(entity);
            return GetMapper().Map<QuestionDTO>(updated);
        }

        // Delete question
        public static bool Delete(int id)
        {
            return DataAccessFactory.QuestionData().Delete(id);
        }
    }
}
