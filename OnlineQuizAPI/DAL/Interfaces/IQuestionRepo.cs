using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IQuestionRepo
    {
        // CRUD operations
        Question Add(Question question);
        Question Update(Question question);
        bool Delete(int id);
        List<Question> GetAll();

        // Quiz-specific
        List<Question> GetByQuiz(int quizId);
    }
}
