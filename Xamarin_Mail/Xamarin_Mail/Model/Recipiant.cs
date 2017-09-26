using System.Runtime.Serialization;

namespace Xamarin_Mail.Model
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
