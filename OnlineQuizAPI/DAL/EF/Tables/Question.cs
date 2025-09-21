using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Text { get; set; }

        public int Marks { get; set; }


        // Relation With Quiz(many to one)
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        // Relation with Option (One to many)
        public virtual ICollection<Option> Options { get; set; }
    }
}
