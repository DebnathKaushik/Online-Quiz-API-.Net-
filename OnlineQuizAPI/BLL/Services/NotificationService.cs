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
    public class NotificationService
    {
        // Automappper config
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Notification, NotificationDTO>().ReverseMap();
            });
            return new Mapper(config);
        }


        // Add Notification
        public static NotificationDTO Add(NotificationDTO dto)
        {
            var entity = GetMapper().Map<Notification>(dto);
            var addnotifiaction = DataAccessFactory.NotificationData().Add(entity);
            return GetMapper().Map<NotificationDTO>(addnotifiaction);
        }

        // Get all Notification
        public static List<NotificationDTO> GetAll() 
        {
            var data = DataAccessFactory.NotificationData().GetAll();
            return GetMapper().Map<List<NotificationDTO>>(data);
        }

    }


}
