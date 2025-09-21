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
    public class OptionService
    {
        // AutoMapper configuration
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Option, OptionDTO>().ReverseMap();
                cfg.CreateMap<Option, OptionDetailsDTO>()
                   .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.Text))
                   .ReverseMap();
            });
            return new Mapper(config);
        }


        // Get all options for a specific question
        public static List<OptionDetailsDTO> GetByQuestion(int questionId)
        {
            var data = DataAccessFactory.OptionData().GetByQuestion(questionId);
            return GetMapper().Map<List<OptionDetailsDTO>>(data);
        }

        // Add a new option
        public static OptionDTO Add(OptionDTO dto)
        {
            var entity = GetMapper().Map<Option>(dto);
            var added = DataAccessFactory.OptionData().Add(entity);
            return GetMapper().Map<OptionDTO>(added);
        }

        // Update an option
        public static OptionDTO Update(OptionDTO dto)
        {
            var entity = GetMapper().Map<Option>(dto);
            var updated = DataAccessFactory.OptionData().Update(entity);
            return GetMapper().Map<OptionDTO>(updated);
        }

        // Delete an option
        public static bool Delete(int id)
        {
            return DataAccessFactory.OptionData().Delete(id);
        }
    }
}
