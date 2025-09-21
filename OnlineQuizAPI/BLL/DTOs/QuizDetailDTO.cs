using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class QuizDetailDTO: QuizDTO
    {
        public SubjectDTO Subject { get; set; }
        public TeacherDTO Teacher { get; set; }
        public List<QuestionDTO> Questions { get; set; }
        public List<StudentQuizAttemptDTO> Attempts { get; set; }
    }
}
