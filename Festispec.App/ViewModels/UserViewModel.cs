using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Festispec.Domain;

namespace Festispec.App.ViewModels
{
    class UserViewModel : ViewModelBase
    {
        private User _user;
        public UserViewModel (User User)
        {
            _user = User;
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

        public Role Role
        {
            get => _user.Role;
            set
            {
                _user.Role = value;
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
    }
}
