using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_Mail.Model.Util
{
  public static  class Converter
    {
        public static ObservableCollection<string> RecipiantToString(ObservableCollection<Recipiant> recipiantList)
        {
            ObservableCollection<string> result = new ObservableCollection<string>();

            foreach (Recipiant item in recipiantList)
            {
                result.Add(item.Mail.ToString());
            }
            return result;
        }
    }
}
