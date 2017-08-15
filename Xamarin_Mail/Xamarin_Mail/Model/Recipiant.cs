using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_Mail.Model
{
    public class Recipiant
    {
        public int Id { get; set; }
       
        public int IdList { get; set; }
       
        public string Mail { get; set; }


        public Recipiant(int id, int idList, string mail)
        {
            this.Id = id;
            this.IdList = idList;
            this.Mail = mail;
        }
    }
}
