using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class QuestionDetailDTO: QuestionDTO
    {
        public List<OptionDTO> Options { get; set; }
    }
}
