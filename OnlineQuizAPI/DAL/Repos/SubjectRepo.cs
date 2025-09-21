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
    internal class SubjectRepo : ISubjectRepo
    {
        // Initialize the Database
        OnlineQuizContext db;
        public SubjectRepo()
        {
            db = new OnlineQuizContext();
        }


        // Add Subject
        public Subject Add(Subject subject)
        {
            db.Subjects.Add(subject);
            db.SaveChanges();
            return subject;
        }

        // Delete Subject
        public bool Delete(int id)
        {
            var subject = db.Subjects.Find(id);
            if (subject != null)
            {
                db.Subjects.Remove(subject);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        // Update Subject
        public Subject Update(Subject subject)
        {
            var existSubject = db.Subjects.Find(subject.SubjectId);
            if (existSubject == null)
            {
                return null;
            }
            db.Entry(existSubject).CurrentValues.SetValues(subject);
            db.SaveChanges();
            return existSubject;
        }

        // Get all Subjects
        public List<Subject> GetAll()
        {
            return db.Subjects.ToList();
        }


        // Get all Subjects by Quiz Id
        public Subject GetByQuiz(int quizId)
        {
            var quiz = db.Quizzes.Find(quizId);
            if (quiz == null) return null;

            return db.Subjects.Find(quiz.SubjectId);
        }

    }
}
