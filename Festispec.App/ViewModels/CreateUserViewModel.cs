using Festispec.App.Repositories;
using Festispec.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Festispec.App.ViewModels
{
	public class CreateUserViewModel : ViewModelBase
	{
		private readonly Random _random;

		public string Username { get; set; }
		public string Password { get; set; }
		public RoleViewModel Role { get; set; }
		public ObservableCollection<RoleViewModel> Roles { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Email { get; set; }
		public string Phone { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public int HouseNumber { get; set; }
		private char? _houseNumberSuffix;

		public char? HouseNumberSuffix
		{
            get => _houseNumberSuffix;
			set
			{
                _houseNumberSuffix = value;
                RaisePropertyChanged();
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
		}

		private bool CanRegister()
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

		private void Register()
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
			};
			if (_houseNumberSuffix != null) { employee.HouseNumberSuffix = (char) _houseNumberSuffix; }
			_userRepo.Add(user);
			_employeeRepo.AddEmployee(employee);
            //TODO: Change to some page

            Trace.WriteLine(user);
            Trace.WriteLine(FirstName);
            Trace.WriteLine(LastName);
            Trace.WriteLine(DateOfBirth);
            Trace.WriteLine(Email);
            Trace.WriteLine(Phone);
            Trace.WriteLine(Country);
            Trace.WriteLine(City);
            Trace.WriteLine(Street);
            Trace.WriteLine(HouseNumber);
            Trace.WriteLine(HouseNumberSuffix);
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
