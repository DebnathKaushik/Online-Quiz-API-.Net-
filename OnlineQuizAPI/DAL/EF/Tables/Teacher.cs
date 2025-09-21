using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        // Relation with Quiz (One to Many)
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
