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
                cfg.CreateMap<Option, OptionDTO>().ReverseMap();
                cfg.CreateMap<Quiz, QuizDTO>().ReverseMap(); 
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

        // Add New Question with Options
        public static QuestionDetailDTO AddwithOption(QuestionDetailDTO dto)
        {
            var question = GetMapper().Map<Question>(dto);

            // Save the question first
            var addedQuestion = DataAccessFactory.QuestionData().Add(question);

            // Save options if provided
            if (dto.Options != null && dto.Options.Any())
            {
                foreach (var optDto in dto.Options)
                {
                    optDto.QuestionId = addedQuestion.QuestionId;
                    var option = GetMapper().Map<Option>(optDto);
                    DataAccessFactory.OptionData().Add(option);
                }
            }

            // Reload question with options from DB to get OptionIds and prevent duplication
            var savedQuestion = DataAccessFactory.QuestionData()
                                    .GetAll()
                                    .FirstOrDefault(q => q.QuestionId == addedQuestion.QuestionId);

            return GetMapper().Map<QuestionDetailDTO>(savedQuestion);
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
