using Festispec.Domain;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.App.ViewModels
{
    public class RoleViewModel : ViewModelBase
    {
        private Role _role;
        public string Name
        {
            get => _role.Name;
            set
            {
                _role.Name = value;
                RaisePropertyChanged();
            }
        }

        public RoleViewModel(Role role)
        {
            _role = role;
        }

        public Role ToModel()
        {
            return _role;
        }
    }
}
