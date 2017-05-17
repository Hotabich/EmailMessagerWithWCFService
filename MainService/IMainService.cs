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

namespace MainService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMainService" in both code and config file together.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IMainService
    {
        [OperationContract]
        List<string> Send(Message _message);

       

        
        
    }

    
}
