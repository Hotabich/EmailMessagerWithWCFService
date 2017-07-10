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
        List<string> GetRecipientsList(int id);
        void DeleteRecipiantsList(int id);

        void AddRecipiant(int id, int idList, string email);
        void UpdateRecipiant(int id, int idList, string email);
        void DeleteRecipiant(int id);


        


    }
}
