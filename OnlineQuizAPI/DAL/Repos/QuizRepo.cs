using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repos
{
    internal class QuizRepo : IQuizRepo
    {

        // DataBase initialization
        OnlineQuizContext db;
        public QuizRepo()
        {
            db = new OnlineQuizContext();
        }

        // Add Quiz
        public Quiz Add(Quiz q)
        {
            db.Quizzes.Add(q);
            db.SaveChanges();
            return q;
        }

        // Delete Quiz
        public bool Delete(int id)
        {
            var quiz = db.Quizzes.Find(id);
            if (quiz != null)
            {
                db.Quizzes.Remove(quiz);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        // Update Quiz
        public Quiz Update(Quiz quiz)
        {
            var exist = db.Quizzes.Find(quiz.QuizId);
            if (exist == null)
            {
                return null;
            }

            db.Entry(exist).CurrentValues.SetValues(quiz);
            db.SaveChanges();
            return exist;
        }


        // Get All Quizes
        public List<Quiz> GetAll()
        {
            return db.Quizzes.ToList();
        }

        // Get quiz by Quiz Id
        public Quiz Get(int id)
        {
            return db.Quizzes.Find(id);
        }


        // Get all Quizzes by Subject Name
        public List<Quiz> GetBySubjectName(string subjectName)
        {
            return db.Quizzes
                     .Where(q => q.Subject != null && q.Subject.Name == subjectName)
                     .ToList();
        }


        // Get all quizzes created by a specific teacher
        public List<Quiz> GetByTeacher(int teacherId)
        {
            return db.Quizzes.Where(q => q.TeacherId == teacherId).ToList();
        }

        
    }
}
