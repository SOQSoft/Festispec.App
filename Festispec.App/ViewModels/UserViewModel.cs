using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Festispec.Domain;
using GalaSoft.MvvmLight.Ioc;

namespace Festispec.App.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private User _user;
        public UserViewModel(User User)
        {
            _user = User;
        }

        [PreferredConstructor]
        public UserViewModel()
        {

        }

        public string UserName
        {
            get => _user.Username;
            set
            {
                _user.Username = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            //TODO encrypt!!
            get => _user.Password;
            set
            {
                _user.Password = value;
            }
        }

        public Roles Role
        {
            get => _user.Role.Roles;
            set
            {
                _user.Role = value.ToRole();
                RaisePropertyChanged();
            }
        }
        public Employee Employee
        {
            get => _user.Employee;
            set
            {
                _user.Employee = value;
                RaisePropertyChanged();
            }
        }

        public void Login(User user)
        {
            _user = user;
            LoggedIn = true;
        }

        public bool LoggedIn { get; set; } = false;
    }
}
