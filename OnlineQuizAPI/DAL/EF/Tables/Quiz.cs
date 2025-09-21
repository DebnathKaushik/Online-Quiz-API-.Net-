using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Quiz
    {

        [Key]
        public int QuizId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Title { get; set; }


        // Relation With Subject (Many to one)
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        // Relation With Teacher (Many to one)
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public int DurationMin { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; } = true;


        // Relation With Question (One to Many)
        public virtual ICollection<Question> Questions { get; set; }

        // Relation With StudentQuizAttempt (One to Many)
        public virtual ICollection<StudentQuizAttempt> QuizAttempts { get; set; }
    }
}
