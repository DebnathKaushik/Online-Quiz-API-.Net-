using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISubjectRepo
    {
        // CRUD operations
        Subject Add(Subject subject);
        Subject Update(Subject subject);
        bool Delete(int id);
        List<Subject> GetAll();

    
        //  get subject by Quiz Id
        Subject GetByQuiz(int quizId);

    }
}
