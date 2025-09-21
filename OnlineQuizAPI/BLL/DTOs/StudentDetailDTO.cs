using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentDetailDTO : StudentDTO
    {
        public List<StudentQuizAttemptDTO> QuizAttempts { get; set; }
    }

}
