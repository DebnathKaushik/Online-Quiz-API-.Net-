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
    public class StudentService
    {
        // Configure AutoMapper for Student <-> StudentDTO <-> StudentDetailDTO mappings(ReverseMap)
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDetailDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        // Get all students
        public static List<StudentDTO> GetAll()
        {
            var data = DataAccessFactory.StudentData().GetAll();
            return GetMapper().Map<List<StudentDTO>>(data);
        }

        // Get student by ID
        public static StudentDTO Get(int id)
        {
            var data = DataAccessFactory.StudentData().GetByID(id);
            return GetMapper().Map<StudentDTO>(data);
        }

        // Add student
        public static StudentDTO Add(StudentDTO dto)
        {
            var entity = GetMapper().Map<Student>(dto);
            var added = DataAccessFactory.StudentData().Add(entity);
            return GetMapper().Map<StudentDTO>(added);
        }

        // Update student
        public static StudentDTO Update(StudentDTO dto)
        {
            var entity = GetMapper().Map<Student>(dto);
            var updated = DataAccessFactory.StudentData().Update(entity);
            return GetMapper().Map<StudentDTO>(updated);
        }

        // Delete student
        public static bool Delete(int id)
        {
            return DataAccessFactory.StudentData().Delete(id);
        }
    }
}
