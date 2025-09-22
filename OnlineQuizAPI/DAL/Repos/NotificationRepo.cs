using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NotificationRepo: INotificationRepo
    {
        // DataBase initialization
        OnlineQuizContext db;
        public NotificationRepo()
        {
            db = new OnlineQuizContext();
        }


        public Notification Add(Notification notification)
        {
            db.Notifications.Add(notification);
            db.SaveChanges();
            return notification;
        }

        public List<Notification> GetAll()
        {
            return db.Notifications.ToList();
        }
    }
}
