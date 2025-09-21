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
    internal class StudentRepo : IRepo<Student, int>
    {

        // Initialize the Database
        OnlineQuizContext db;
        public StudentRepo()
        {
            db = new OnlineQuizContext();
        }

        // ADD Student
        public Student Add(Student s)
        {
           db.Students.Add(s);
           db.SaveChanges();
           return s;
        }

        // Delete Student
        public bool Delete(int id)
        {
            var student = db.Students.Find(id);
            if(student != null)
            {
                db.Students.Remove(student);
                return db.SaveChanges() > 0;
            }
            return false;
            
        }

        // Get All Students
        public List<Student> GetAll()
        { 
            return db.Students.ToList();
        }

        // Get Students By ID
        public Student GetByID(int id)
        {
            try
            {
                return db.Students.Find(id);
            }
            catch
            {
                return null;
            }
        }

        // Student Update
        public Student Update(Student s)
        {
            var exist_Student = GetByID(s.StudentId);
            if(exist_Student == null) 
            {
                return null;
            }
            db.Entry(exist_Student).CurrentValues.SetValues(s);
            db.SaveChanges();
            return exist_Student;
        }
    }
}
