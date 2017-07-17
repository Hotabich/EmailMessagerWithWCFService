using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MainService.Model.DbModels
{
    [DataContract]
   public class Recipiant
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdList { get; set; }
        [DataMember]
        public string Mail { get; set; }
       
        
        public Recipiant(int id, int idList, string mail)
        {
            this.Id = id;
            this.IdList = idList;
            this.Mail = mail;
        }
    }
}
