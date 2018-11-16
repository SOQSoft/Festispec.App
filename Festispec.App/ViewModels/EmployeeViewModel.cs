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

        public int Id {
            get => _employee.Id;
            set
            {
                _employee.Id = value;
                RaisePropertyChanged();
            }
        }

        public User User {
            get

            {
                return _employee.User;
            }
            set
            {
                _employee.User = value;
                RaisePropertyChanged();
            }
        }

        public string FirstName {
            get => _employee.FirstName;
            set
            {
                _employee.FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string LastName {
            get => _employee.LastName;
            set
            {
                _employee.LastName = value;
                RaisePropertyChanged();
            }
        }

        public DateTime DateOfBirth {
            get => _employee.DateOfBirth;
            set
            {
                _employee.DateOfBirth = value;
                RaisePropertyChanged();
            }
        }

        public string Email {
            get => _employee.Email;
            set
            {
                _employee.Email = value;
                RaisePropertyChanged();
            }
        }

        public string Phone {
            get => _employee.Phone;
            set
            {
                _employee.Phone = value;
                RaisePropertyChanged();
            }
        }

        public string Country {
            get => _employee.Country;
            set
            {
                _employee.Country = value;
                RaisePropertyChanged();
            }
        }

        public string City {
            get => _employee.City;
            set
            {
                _employee.City = value;
                RaisePropertyChanged();
            }
        }

        public string Street {
            get => _employee.Street;
            set
            {
                _employee.Street = value;
                RaisePropertyChanged();
            }
        }

        public int HouseNumber {
            get => _employee.HouseNumber;
            set
            {
                _employee.HouseNumber = value;
                RaisePropertyChanged();
            }
        }
        
        public char HouseNumberSuffix {
            get => _employee.HouseNumberSuffix;
            set
            {
                _employee.HouseNumberSuffix = value;
                RaisePropertyChanged();
            }
        }
        
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
