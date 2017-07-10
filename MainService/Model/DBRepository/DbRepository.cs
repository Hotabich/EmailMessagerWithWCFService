using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainService.Model.Interfaces;

namespace MainService.Model.DBRepository
{
    public class DbRepository : IDbRepository
    {
        public void AddRecipiant(int id, string nameList, string email)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipiant(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipiantsList(string name)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllRecipiantsList()
        {
            throw new NotImplementedException();
        }

        public List<string> GetRecipientsList(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipiant(int id, string nameList)
        {
            throw new NotImplementedException();
        }
    }
}
