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

namespace Festispec.App.ViewModels
{
    public class LoginViewModel
    {
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
        public ICommand LoginCommand;
        private UserTestRepository _users;

        public LoginViewModel()
        {
            _users = new UserTestRepository();
            LoginCommand = new RelayCommand(Login);
        }

        public void Login()
        {
            if(isValid())
            {
                //TODO initialise mainview

            }
            else
            {
                //TODO show message regarding wrongful login
            }
        }

        public bool isValid()
        {
            User InputUser = _users.GetAll().First(u => u.Username == _username);
            if (InputUser == null)
            {
                return false;
            }
            if(InputUser.Password == _password)
            {
                return true;
            }
            return false;
        }
    }
}
