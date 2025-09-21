using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStudentQuizAttemptRepo
    {
        // CRUD operations
        StudentQuizAttempt Add(StudentQuizAttempt attempt);
        StudentQuizAttempt Update(StudentQuizAttempt attempt);
        bool Delete(int id);

        // Student-specific
        List<StudentQuizAttempt> GetByStudent(int studentId);

        // Quiz-specific
        List<StudentQuizAttempt> GetByQuiz(int quizId);
    }
}
