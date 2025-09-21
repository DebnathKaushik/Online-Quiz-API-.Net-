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
    internal class QuestionRepo : IQuestionRepo
    {
        // DataBase initialization
        OnlineQuizContext db;
        public QuestionRepo()
        {
            db = new OnlineQuizContext();
        }


        // Add Question
        public Question Add(Question question)
        {
            db.Questions.Add(question);
            db.SaveChanges();
            return question;
        }

        // Delete Question
        public bool Delete(int id)
        {
            var question = db.Questions.Find(id);
            if (question != null)
            {
                db.Questions.Remove(question);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        // Update Question
        public Question Update(Question question)
        {
            var exist_question = db.Questions.Find(question.QuestionId);
            if (exist_question == null) return null;

            db.Entry(exist_question).CurrentValues.SetValues(question);
            db.SaveChanges();
            return exist_question;
        }

        // Get all Questions
        public List<Question> GetAll()
        {
            return db.Questions.ToList();
        }

       
        // Get Questions by Quiz id
        public List<Question> GetByQuiz(int quizId)
        {
            return db.Questions.Where(q => q.QuizId == quizId).ToList();
        }

        
    }
}
