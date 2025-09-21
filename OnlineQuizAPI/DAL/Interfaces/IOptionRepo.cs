using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOptionRepo
    {
        // CRUD operations
        Option Add(Option option);
        Option Update(Option option);
        bool Delete(int id);

        // Question-specific
        List<Option> GetByQuestion(int questionId);
    }
}   
