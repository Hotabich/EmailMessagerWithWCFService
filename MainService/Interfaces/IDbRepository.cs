using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainService.Model.Interfaces
{
    interface IDbRepository
    {
        List<string> GetAllRecipiantsList();
        List<string> GetRecipientsList(string name);
        void DeleteRecipiantsList(string name);

        void AddRecipiant(int id, string nameList, string email);
        void UpdateRecipiant(int id, string nameList);
        void DeleteRecipiant(int id);


        


    }
}
