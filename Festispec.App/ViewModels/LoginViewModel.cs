using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Festispec.App.Repositories;
using Festispec.Domain;
using Festispec.App.Views;
using System.Windows;

namespace Festispec.App.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public MainViewModel MainView;
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
        public ICommand Login { get; set; }
        private UserTestRepository _users;

        public LoginViewModel()
        {
            _users = new UserTestRepository();
            Login = new RelayCommand<Window>(LoginCommand);
        }

        public void LoginCommand(Window loginWindow)
        {
            if(fieldsAreEmpty())
            {
                return;
            }
            if(isPasswordUsernameCombinationCorrect())
            {
                //TODO geef user door aan de mainviewmodel
                var window = new MainWindow();
                loginWindow.Close();
                window.ShowDialog();
            }
            else
            {
                ErrorMessage = "Gebruikersnaam of wachtwoord is incorrect";
                RaisePropertyChanged("ErrorMessage");
            }
        }

        public bool fieldsAreEmpty()
        {
            if (_username == null)
            {
                ErrorMessage = "Gebruikersnaam is leeg, vul een gebruikersnaam in";
                RaisePropertyChanged("ErrorMessage");
                return true ;
            }
            if(_password == null)
            {
                ErrorMessage = "Wachtwoord is leeg, vul een wachtwoord in";
                RaisePropertyChanged("ErrorMessage");
                return true;
            }
            return false;
        }

        public bool isPasswordUsernameCombinationCorrect()
        {
            User InputUser = _users.GetAll().FirstOrDefault(u => u.Username.Equals(_username));
            if (InputUser == null)
            {
                return false;
            }
            if(InputUser.Password.Equals(_password))
            {
                return true;
            }
            return false;
        }
    }
}
