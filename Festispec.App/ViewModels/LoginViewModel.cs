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
        public string Username { get; set; }
        public string Password { get; set; }
        private string _errorMessage;
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; RaisePropertyChanged(); } }

        public ICommand Login { get; set; }
        private UserViewModel _userViewModel;
        private UserTestRepository _userRepository;

        public LoginViewModel(UserViewModel userViewModel)
        {
            _userViewModel = userViewModel;
            _userRepository = new UserTestRepository();
            Login = new RelayCommand<Window>(LoginCommand);
        }

        public void LoginCommand(Window loginWindow)
        {
            if (!fieldsAreEmpty() && _userRepository.GetUser(Username, Password) is User user && user != null)
            {
                _userViewModel.Login(user);
                var window = new MainWindow();
                loginWindow.Close();
                window.ShowDialog();
            }
            else
            {
                ErrorMessage = "Gebruikersnaam of wachtwoord is incorrect";
            }
        }

        public bool fieldsAreEmpty()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                ErrorMessage = "Gebruikersnaam is leeg, vul een gebruikersnaam in";
                return true;
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Wachtwoord is leeg, vul een wachtwoord in";
                return true;
            }
            return false;
        }
    }
}
