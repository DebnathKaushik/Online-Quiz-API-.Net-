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
    public class QuizService
    {
        // AutoMapper config for Quiz <->QuizDTO<->QuizDetailDTO
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Quiz, QuizDTO>().ReverseMap();
                cfg.CreateMap<Quiz, QuizDetailDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        // Get all quizzes
        public static List<QuizDTO> GetAll()
        {
            var data = DataAccessFactory.QuizData().GetAll();
            return GetMapper().Map<List<QuizDTO>>(data);
        }

        // Get quizzes by Teacher ID
        public static List<QuizDTO> GetByTeacher(int teacherId)
        {
            var data = DataAccessFactory.QuizData().GetByTeacher(teacherId);
            return GetMapper().Map<List<QuizDTO>>(data);
        }

        // Get quizzes by Subject name
        public static List<QuizDTO> GetBySubject(string subjectName)
        {
            var data = DataAccessFactory.QuizData().GetBySubjectName(subjectName);
            return GetMapper().Map<List<QuizDTO>>(data);
        }

        // Add new Quiz
        public static QuizDTO Add(QuizDTO dto)
        {
            // Ensure default times if only date provided
            if (dto.StartTime.TimeOfDay == TimeSpan.Zero)
            {
                dto.StartTime = dto.StartTime.Date.AddHours(10); // default 10AM
            }
            if (dto.EndTime.TimeOfDay == TimeSpan.Zero)
            {
                dto.EndTime = dto.EndTime.Date.AddHours(11); // default 11 AM
            }

            var entity = GetMapper().Map<Quiz>(dto);
            var added = DataAccessFactory.QuizData().Add(entity);
            return GetMapper().Map<QuizDTO>(added);
        }

        // Update existing Quiz
        public static QuizDTO Update(QuizDTO dto)
        {
            var entity = GetMapper().Map<Quiz>(dto);
            var updated = DataAccessFactory.QuizData().Update(entity);
            return GetMapper().Map<QuizDTO>(updated);
        }

        // Delete Quiz
        public static bool Delete(int id)
        {
            return DataAccessFactory.QuizData().Delete(id);
        }


        // ----------------Recommondation of Popular Quiz (by Student attempt)-----------------
        // from  PopularQuizDTO in DTo
        public static List<PopularQuizDTO> GetPopularQuizzes(int top)
        {
            var attempts = DataAccessFactory.StudentQuizAttemptData().GetAll();
            var quizzes = DataAccessFactory.QuizData().GetAll();

            // Count attempts per quiz
            var recommendedQuiz = attempts
                .GroupBy(a => a.QuizId)
                .Select(g => new
                {
                    QuizId = g.Key,
                    Count = g.Count()
                })
                .Join(quizzes, g => g.QuizId, q => q.QuizId, (g, q) => new PopularQuizDTO
                {
                    QuizId = q.QuizId,
                    Title = q.Title,
                    SubjectName = q.Subject.Name,
                    TeacherId = q.TeacherId,
                    AttemptCount = g.Count
                })
                .OrderByDescending(r => r.AttemptCount)
                .Take(top) // that is from url query param , how many recommondation i want to show 
                .ToList();

            return recommendedQuiz;
        }

        // ----------------(Quiz status change by the Teacher )---------------
        public static bool changeQuizStatus(int teacherId, int quizId, bool newStatus)
        {
            var quiz = DataAccessFactory.QuizData().Get(quizId);
            if (quiz == null)
            {
                return false;
            }
            if (quiz.TeacherId != teacherId)
            {
                return false;
            }

            // if all okk then , change status
            quiz.IsActive = newStatus;
            DataAccessFactory.QuizData().Update(quiz);
            return true;
        }
    }
}
