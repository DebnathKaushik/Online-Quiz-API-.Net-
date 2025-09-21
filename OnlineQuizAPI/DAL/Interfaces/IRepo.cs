using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS,ID>
    {
        List<CLASS> GetAll();
        CLASS GetByID(ID id);

        CLASS Add(CLASS obj);
        CLASS Update(CLASS obj);

        bool Delete(ID id);
    }
}
