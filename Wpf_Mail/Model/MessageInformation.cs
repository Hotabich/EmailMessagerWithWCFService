using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Mail.View;

namespace Wpf_Mail.Model
{
   public class MessageInformation
    {
       
        public MessageInformation()
        {
           
        }

        public void Show(string title, string message)
        {
            InformationWindow _info = new InformationWindow();            
            _info.Title = title;
            _info.MessageTextBlock.Text = message;
            _info.Show();
        }

        public void Show(string title, string[] message)
        {
            InformationWindow _info = new InformationWindow();
            List<string> error = new List<string>();
            _info.Title = title;
            _info.ErrorListView.Visibility = System.Windows.Visibility.Visible;

            foreach (string  item in message)
            {
                error.Add(item);
            }
            _info.ErrorListView.ItemsSource = error;
            _info.Show();
        }
    }
}
