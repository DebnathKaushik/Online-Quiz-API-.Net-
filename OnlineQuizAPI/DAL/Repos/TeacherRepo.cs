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
    internal class TeacherRepo : IRepo<Teacher, int>
    {
        // Initialize the Database
        OnlineQuizContext db;
        public TeacherRepo()
        {
            db = new OnlineQuizContext();
        }

        // ADD Teacher
        public Teacher Add(Teacher t)
        {
            db.Teachers.Add(t);
            db.SaveChanges();
            return t; 
        }

        // Teacher Delete
        public bool Delete(int id)
        {
            var teacher = db.Teachers.Find(id);
            if (teacher != null)
            {
                db.Teachers.Remove(teacher);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        // Get All Teacher
        public List<Teacher> GetAll()
        {
            return db.Teachers.ToList();   
        }

        // Get Teacher by id
        public Teacher GetByID(int id)
        {
            try 
            {
                return db.Teachers.Find(id);
            }
            catch 
            { 
                return null; 
            }
        }

        // Update Teacher
        public Teacher Update(Teacher t)
        {
            var existTeacher = GetByID(t.TeacherId);
            if (existTeacher == null)
            {
                return null;
            }

            // update all properties
            db.Entry(existTeacher).CurrentValues.SetValues(t);
            db.SaveChanges();
            return existTeacher;
        }
    }
}
