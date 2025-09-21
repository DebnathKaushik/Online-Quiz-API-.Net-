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
    internal class StudentQuizAttemptRepo : IStudentQuizAttemptRepo
    {

        // DataBase initialization
        OnlineQuizContext db;
        public StudentQuizAttemptRepo()
        {
            db = new OnlineQuizContext();
        }

        // Add StudentQuizAttempt
        public StudentQuizAttempt Add(StudentQuizAttempt attempt)
        {
            db.StudentQuizAttempts.Add(attempt);
            db.SaveChanges();
            return attempt;
        }

        // Delete StudentQuizAttempt
        public bool Delete(int id)
        {
            var attempt = db.StudentQuizAttempts.Find(id);
            if (attempt != null)
            {
                db.StudentQuizAttempts.Remove(attempt);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        // Update StudentQuizAttempt
        public StudentQuizAttempt Update(StudentQuizAttempt attempt)
        {
            var existing = db.StudentQuizAttempts.Find(attempt.AttemptId);
            if (existing == null) return null;

            db.Entry(existing).CurrentValues.SetValues(attempt);
            db.SaveChanges();
            return existing;
        }

        // Get all StudentQuizAttempt By Quiz Id
        public List<StudentQuizAttempt> GetByQuiz(int quizId)
        {
            return db.StudentQuizAttempts.Where(a => a.QuizId == quizId).ToList();
        }

        // Get all StudentQuizAttempt By Student Id
        public List<StudentQuizAttempt> GetByStudent(int studentId)
        {
           return db.StudentQuizAttempts.Where(a => a.StudentId == studentId).ToList();
        }

        
    }
}
