using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MainService.Model;
using System.Net;
using System.IO;
using System.Net.Mail;
using MainService.Model.DbModels;


namespace MainService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMainService" in both code and config file together.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IMainService
    {
        [OperationContract]
        List<string> Send(Message _message);

        [OperationContract]
        List<RecipiantList> GetAllRecipiantsList();
        [OperationContract]
        List<Recipiant> GetRecipientsList(int id);
        [OperationContract]
        void AddRecipiantList(string listName);
        [OperationContract]
        void AddRecipiant(int idList, string email);
        [OperationContract]
        void UpdateRecipiant(int id, int idList, string email);
        [OperationContract]
        void DeleteRecipiantsList(int id);
        [OperationContract]
        void DeleteRecipiant(int id);
    }


}
