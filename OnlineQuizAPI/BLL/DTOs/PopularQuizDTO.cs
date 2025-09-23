using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PopularQuizDTO
    {
        public int QuizId { get; set; }
        public string Title { get; set; }
        public string SubjectName { get; set; }
        public int TeacherId { get; set; }
        public int AttemptCount { get; set; }
    }
}
