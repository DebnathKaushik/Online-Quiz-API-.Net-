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
    public class SubjectService
    {
        // AutoMapper config for Subject <-> SubjectDTO <-> SubjectDetailDTO
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Subject, SubjectDTO>().ReverseMap();
                cfg.CreateMap<Subject, SubjectDetailDTO>().ReverseMap();
            });
            return new Mapper(config);
        }


        // Get all Subjects
        public static List<SubjectDTO> GetAll()
        {
            var data = DataAccessFactory.SubjectData().GetAll();
            return GetMapper().Map<List<SubjectDTO>>(data);
        }

       

        // Get Subject by Quiz ID
        public static SubjectDTO GetByQuiz(int quizId)
        {
            var data = DataAccessFactory.SubjectData().GetByQuiz(quizId);
            return GetMapper().Map<SubjectDTO>(data);
        }

        // Add Subject
        public static SubjectDTO Add(SubjectDTO dto)
        {
            var entity = GetMapper().Map<Subject>(dto);
            var added = DataAccessFactory.SubjectData().Add(entity);
            return GetMapper().Map<SubjectDTO>(added);
        }

        // Update Subject
        public static SubjectDTO Update(SubjectDTO dto)
        {
            var entity = GetMapper().Map<Subject>(dto);
            var updated = DataAccessFactory.SubjectData().Update(entity);
            return GetMapper().Map<SubjectDTO>(updated);
        }

        // Delete Subject
        public static bool Delete(int id)
        {
            return DataAccessFactory.SubjectData().Delete(id);
        }



    }
}
