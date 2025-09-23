using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IQuizRepo
    {
        // CRUD
        Quiz Add(Quiz quiz);
        Quiz Update(Quiz quiz);
        bool Delete(int id);
        List<Quiz> GetAll();

        Quiz Get(int id);

        // Quiz-specific
        List<Quiz> GetByTeacher(int teacherId);
        List<Quiz> GetBySubjectName(string subjectName);


    }
}
