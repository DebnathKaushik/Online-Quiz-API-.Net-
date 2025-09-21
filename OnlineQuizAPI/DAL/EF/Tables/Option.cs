using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Option
    {
        [Key]
        public int OptionId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Text { get; set; }


        // Here Relation with Question (Many to one)
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
