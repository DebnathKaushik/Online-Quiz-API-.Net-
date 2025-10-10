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
    public class StudentQuizAttemptService
    {
        // AutoMapper configuration
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Basic DTO mapping
                cfg.CreateMap<StudentQuizAttempt, StudentQuizAttemptDTO>().ReverseMap();

                // Detailed DTO mapping
                cfg.CreateMap<StudentQuizAttempt, StudentQuizAttemptDetailDTO>()
                   .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
                   .ForMember(dest => dest.Quiz, opt => opt.MapFrom(src => src.Quiz))
                   .ReverseMap();

                // Student and Quiz mappings (for details)
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Quiz, QuizDTO>().ReverseMap();
            });

            return new Mapper(config);
        }


        // Add Attempt
        public static StudentQuizAttemptDTO Add(StudentQuizAttemptDTO dto)
        {
            // Ensure default times if only date provided
            if (dto.StartedAt.TimeOfDay == TimeSpan.Zero)
            {
                dto.StartedAt = dto.StartedAt.Date.AddHours(10); // start 10AM
            }
            if (!dto.CompletedAt.HasValue || dto.CompletedAt.Value.TimeOfDay == TimeSpan.Zero)
            {
                dto.CompletedAt = dto.StartedAt.AddHours(1); //  1 hour after start
            }

            var entity = GetMapper().Map<StudentQuizAttempt>(dto);
            var added = DataAccessFactory.StudentQuizAttemptData().Add(entity);
            return GetMapper().Map<StudentQuizAttemptDTO>(added);
        }

        // Update Attempt
        public static StudentQuizAttemptDTO Update(StudentQuizAttemptDTO dto)
        {
            var entity = GetMapper().Map<StudentQuizAttempt>(dto);
            var updated = DataAccessFactory.StudentQuizAttemptData().Update(entity);
            return GetMapper().Map<StudentQuizAttemptDTO>(updated);
        }

        // Delete Attempt
        public static bool Delete(int id)
        {
            return DataAccessFactory.StudentQuizAttemptData().Delete(id);
        }

       
        // Get attempts by Student ID (detailed DTO)
        public static List<StudentQuizAttemptDetailDTO> GetByStudent(int studentId)
        {
            var data = DataAccessFactory.StudentQuizAttemptData().GetByStudent(studentId);
            return GetMapper().Map<List<StudentQuizAttemptDetailDTO>>(data);
        }

        // Get attempts by Quiz ID (detailed DTO)
        public static List<StudentQuizAttemptDetailDTO> GetByQuiz(int quizId)
        {
            var data = DataAccessFactory.StudentQuizAttemptData().GetByQuiz(quizId);
            return GetMapper().Map<List<StudentQuizAttemptDetailDTO>>(data);
        }


    }
}
