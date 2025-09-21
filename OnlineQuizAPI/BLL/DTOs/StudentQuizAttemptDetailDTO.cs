using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentQuizAttemptDetailDTO: StudentQuizAttemptDTO
    {
        public StudentDTO Student { get; set; }
        public QuizDTO Quiz { get; set; }
    }
}
