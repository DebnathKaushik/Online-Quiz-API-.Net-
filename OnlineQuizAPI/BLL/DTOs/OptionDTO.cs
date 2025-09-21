using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OptionDTO
    {
        public int OptionId { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
    }
}
