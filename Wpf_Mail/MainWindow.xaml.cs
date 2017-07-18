using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using Wpf_Mail.ViewModel;

namespace Wpf_Mail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _messager;
        private MailAddress _login;
        private string _password;
        public MainWindow()
        {
            InitializeComponent();
            OpenCredential();
            _messager = new MainWindowViewModel();            
            _messager.OwnerLogin = _login;
            _messager.OwnerPassword = _password;
            DataContext = _messager;
            
        }
        public void OpenCredential()
        {
            CredentialWindow _credentialWindow = new CredentialWindow();
            _credentialWindow.ShowDialog();
            _login = _credentialWindow.Login;
            _password = _credentialWindow.Password;
            if (!_credentialWindow.CanDoWork)
            {
                this.Close();
            }
           
        }

        
    }
}
