using System.Collections.ObjectModel;

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
