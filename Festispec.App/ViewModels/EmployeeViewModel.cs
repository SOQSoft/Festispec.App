using Festispec.Domain;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Festispec.App.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private Employee _employee;

        private int _id;
        public int Id {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        private User _user;
        public User User {
            get => _user;
            set
            {
                _user = value;
                RaisePropertyChanged();
            }
        }
        private string _firstName;
        public string FirstName {
            get => _firstName;
            set
            {
                _firstName = value;
                RaisePropertyChanged();
            }
        }
        private string _lastName;
        public string LastName {
            get => _lastName;
            set
            {
                _lastName = value;
                RaisePropertyChanged();
            }
        }
        private DateTime _dateOfBirth;
        public DateTime DateOfBirth {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                RaisePropertyChanged();
            }
        }
        private string _email;
        public string Email {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged();
            }
        }
        private string _phone;
        public string Phone {
            get => _phone;
            set
            {
                _phone = value;
                RaisePropertyChanged();
            }
        }
        private string _country;
        public string Country {
            get => _country;
            set
            {
                _country = value;
                RaisePropertyChanged();
            }
        }
        private string _city;
        public string City {
            get => _city;
            set
            {
                _city = value;
                RaisePropertyChanged();
            }
        }
        private string _street;
        public string Street {
            get => _street;
            set
            {
                _street = value;
                RaisePropertyChanged();
            }
        }
        private int _housenumber;
        public int HouseNumber { get; set; }
        private char _housenumbersuffix;
        public char HouseNumberSuffix { get; set; }
        
        public ObservableCollection<IllnessReportViewModel> IllnessReports { get; set; }


        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
            IllnessReports = new ObservableCollection<IllnessReportViewModel>(employee.IllnessReports.Select(i => new IllnessReportViewModel(i)));
        }

        public Employee ToModel()
        {
            return _employee;
        }
    }
}
