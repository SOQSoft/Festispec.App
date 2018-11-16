using Festispec.App.Repositories;
using Festispec.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Festispec.App.ViewModels
{
	public class CreateUserViewModel : ViewModelBase
	{
		private readonly Random _random;

		private string _username, _password;
		public string Username
		{
			get => _username;
			set
			{
				_username = value;
				RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
			}
		}
		public string Password
		{
			get => _password;
			set
			{
				_password = value;
				RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
		}

		private RoleViewModel _role;
		public RoleViewModel Role
		{
			get => _role;
			set
			{
				_role = value;
				RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
		}

		public ObservableCollection<RoleViewModel> Roles { get; }


		private string _firstName, _lastName;
		public string FirstName
		{
			get => _firstName;
			set
			{
				_firstName = value;
				RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
		}
		public string LastName
		{
			get => _lastName;
			set
			{
				_lastName = value;
				RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
		}

        private DateTime _dateOfBirth;
		public DateTime DateOfBirth {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
        }

		private string _email, _phone;
		public string Email
		{
			get => _email;
			set
			{
				_email = value;
				RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
		}
		public string Phone
		{
			get => _phone;
			set
			{
				_phone = value;
				RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
		}

		private string _country, _city, _street;
		private int _houseNumber;
		public string Country
		{
			get => _country; set
			{
				_country = value;
				RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
		}
		public string City
		{
			get => _city;
			set
			{
				_city = value;
				RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
		}
		public string Street
		{
			get => _street;
			set
			{
				_street = value;
				RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
		}

		public int HouseNumber {
			get => _houseNumber;
			set {
				_houseNumber = value;
				RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
        }

		private char? _houseNumberSuffix;
		public char? HouseNumberSuffix
		{
            get => _houseNumberSuffix;
			set
			{
                _houseNumberSuffix = value;
                RaisePropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
		}

		private IRoleRepository _roleRepo;
		private IEmployeeRepository _employeeRepo;
		private IUsersRepository _userRepo;

		public RelayCommand RegisterCommand { get; private set; }
		public RelayCommand GeneratePasswordCommand { get; private set; }

		public CreateUserViewModel()
		{
			_random = new Random();
			_roleRepo = new RoleTestRepository();
			_employeeRepo = new EmployeeTestRepository();
			_userRepo = new UserTestRepository();
			Roles = new ObservableCollection<RoleViewModel>(_roleRepo.GetAll().Select(r => new RoleViewModel(r)));
			RegisterCommand = new RelayCommand(Register, CanRegister);
			GeneratePasswordCommand = new RelayCommand(GeneratePassword);
            Role = Roles[0];
            DateOfBirth = DateTime.Now;
		}

		public bool CanRegister()
		{
			return !string.IsNullOrWhiteSpace(Username)
				&& !string.IsNullOrWhiteSpace(Password)
				&& Role != null
				&& !string.IsNullOrWhiteSpace(FirstName)
				&& !string.IsNullOrWhiteSpace(LastName)
				&& DateOfBirth != null
				&& !string.IsNullOrWhiteSpace(Email)
				&& Email.Count(c => c == '@') == 1
				&& !string.IsNullOrWhiteSpace(Phone)
				&& !string.IsNullOrWhiteSpace(City)
				&& !string.IsNullOrWhiteSpace(Street)
				&& HouseNumber != 0;
		}

		public void Register()
		{
			User user = new User()
			{
				Username = Username,
				Password = Password,
				Role = Role.ToModel()
			};
            Employee employee = new Employee()
            {
                User = user,
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                Phone = Phone,
                Country = Country,
                City = City,
                Street = Street,
                HouseNumber = HouseNumber,
                IllnessReports = new List<IllnessReport>()
			};
			if (_houseNumberSuffix != null) { employee.HouseNumberSuffix = (char) _houseNumberSuffix; }
            user.Employee = employee;
            _userRepo.Add(user);
			_employeeRepo.AddEmployee(employee);
            //TODO: Change to some page
		}

		private void GeneratePassword()
		{
			int amountOfChars = _random.Next(8, 16);
			char[] chars = new char[amountOfChars];
			for (int i = 0; i < amountOfChars; i++)
				chars[i] = RandomChar;
			Password = new string(chars);
		}

		private char RandomChar
		{
			get
			{
				int charNumber = _random.Next(62);
				char c;
				if (charNumber < 10)
					c = char.Parse(charNumber.ToString());
				else if (charNumber < 36)
					c = (char)('a' + (charNumber - 10));
				else
					c = (char)('A' + (charNumber - 36));
				return c;
			}
		}
	}
}
