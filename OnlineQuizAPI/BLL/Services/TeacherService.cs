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
    public class TeacherService
    {
        // Configure AutoMapper for Teacher <-> TeacherDTO <-> TeacherDetailDTO mappings
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Teacher, TeacherDTO>().ReverseMap();
                cfg.CreateMap<Teacher, TeacherDetailDTO>().ReverseMap();
            });
            return new Mapper(config);
        }


        // Get all Teachers
        public static List<TeacherDTO> GetAll()
        {
            var data = DataAccessFactory.TeacherData().GetAll();
            return GetMapper().Map<List<TeacherDTO>>(data);
        }

        // Get Teacher by ID
        public static TeacherDTO Get(int id)
        {
            var data = DataAccessFactory.TeacherData().GetByID(id);
            return GetMapper().Map<TeacherDTO>(data);
        }

        // Add Teacher
        public static TeacherDTO Add(TeacherDTO dto)
        {
            var entity = GetMapper().Map<Teacher>(dto);
            var added = DataAccessFactory.TeacherData().Add(entity);
            // after Teacher added then notification trigger
            NotificationService.Add(
                new NotificationDTO
                {
                    Message = $"Welcome {added.Name} your account has been created successfully!",
                    CreatedAt = DateTime.Now
                });
            return GetMapper().Map<TeacherDTO>(added);
        }

        // Update Teacher
        public static TeacherDTO Update(TeacherDTO dto)
        {
            var entity = GetMapper().Map<Teacher>(dto);
            var updated = DataAccessFactory.TeacherData().Update(entity);
            return GetMapper().Map<TeacherDTO>(updated);
        }

        // Delete Teacher
        public static bool Delete(int id)
        {
            return DataAccessFactory.TeacherData().Delete(id);
        }
    }
}
