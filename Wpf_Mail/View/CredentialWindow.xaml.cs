using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf_Mail.ViewModel;
using Wpf_Mail.View;
using Wpf_Mail.Model;
using System.Net.Mail;
namespace Wpf_Mail
{
    /// <summary>
    /// Interaction logic for CredentialWindow.xaml
    /// </summary>
    public partial class CredentialWindow : Window
    {
        #region Fields
        private MessageInformation _info;
        #endregion

        #region propertys
        public bool CanDoWork { get; set; }
        public MailAddress Login { get; set; }
        public string Password { get; set; }
        #endregion

        public CredentialWindow()
        {                      
            InitializeComponent();
            _info = new Model.MessageInformation();
            this.WindowStyle = WindowStyle.None;
        }

        #region Method
        private void Okbutton_Click(object sender, RoutedEventArgs e)
        {
           
            if ((String.IsNullOrEmpty(LogintextBox.Text)) || (String.IsNullOrEmpty(PasswordBox.Password)))
            {
                            
                _info.Show("Error", "Login or Password don't be Empty!!!");
            }
            else
            {
                try
                {
                    Login = new MailAddress(LogintextBox.Text);
                    Password = PasswordBox.Password;
                    CanDoWork = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    _info.Show("Error", ex.Message);
                    
                }
                
            }
           
            
        }

        private void Cancelbutton_Click(object sender, RoutedEventArgs e)
        {
            CanDoWork = false;
            this.Close();
        }
        #endregion
    }
}
