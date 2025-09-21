using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        // Relation with StudentQuizAttempt (One to Many)
        public virtual ICollection<StudentQuizAttempt> QuizAttempts { get; set; }

    }
}
