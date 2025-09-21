using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class QuizDTO
    {
        public int QuizId { get; set; }
        public string Title { get; set; }
        public int DurationMin { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
    }
}
