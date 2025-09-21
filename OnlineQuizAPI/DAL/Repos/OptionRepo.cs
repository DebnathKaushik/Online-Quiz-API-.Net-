using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OptionRepo : IOptionRepo
    {
        // DataBase initialization
        OnlineQuizContext db;
        public OptionRepo()
        {
            db = new OnlineQuizContext();
        }

        // Add Option
        public Option Add(Option option)
        {
            db.Options.Add(option);
            db.SaveChanges();
            return option;
        }

        // Delete Option
        public bool Delete(int id)
        {
            var option = db.Options.Find(id);
            if (option != null)
            {
                db.Options.Remove(option);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        // Update Option
        public Option Update(Option option)
        {
            var exist_option = db.Options.Find(option.OptionId);
            if (exist_option == null) return null;

            db.Entry(exist_option).CurrentValues.SetValues(option);
            db.SaveChanges();
            return exist_option;
        }

        // Get all Options by Specific QuestionID
        public List<Option> GetByQuestion(int questionId)
        {
            return db.Options.Where(o => o.QuestionId == questionId).ToList();
        }

        
    }
}
