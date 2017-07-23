using System.Collections.Generic;
using System.Net.Mail;
using Web_Mail.ServiceReference1;

namespace Wpf_Mail.Converters
{
    public static class Converter
    {
       public static List<RecipiantList> ConvertToRecipiantList(RecipiantList[] massive)
        {
            List<RecipiantList> allRecipiantList = new List<RecipiantList>();
            foreach(RecipiantList item in massive)
            {
                allRecipiantList.Add(item);
            }
            return allRecipiantList;

        }

        public static List<MailAddress> ConvertToReceiversMailList(List<Recipiant> recipiants)
        {
            List<MailAddress> recipiantList = new List<MailAddress>();

            foreach (Recipiant item in recipiants)
            {
                recipiantList.Add(new MailAddress(item.Mail));
            }
            return recipiantList;
        }
        

    }
}
