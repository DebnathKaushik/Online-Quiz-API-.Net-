using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        // Student
        public static IRepo<Student, int> StudentData()
        {
            return new StudentRepo();
        }

        // Teacher
        public static IRepo<Teacher, int> TeacherData()
        {
            return new TeacherRepo();
        }

        // Quiz
        public static IQuizRepo QuizData()
        {
            return new QuizRepo();
        }

        // Question
        public static IQuestionRepo QuestionData()
        {
            return new QuestionRepo();
        }

        // Option
        public static IOptionRepo OptionData()
        {
            return new OptionRepo();
        }

        // StudentQuizAttempt
        public static IStudentQuizAttemptRepo StudentQuizAttemptData()
        {
            return new StudentQuizAttemptRepo();
        }

        // Subject
        public static ISubjectRepo SubjectData()
        {
            return new SubjectRepo();
        }
    }
}
