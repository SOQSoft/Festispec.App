using Festispec.App.Repositories;
using Festispec.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Festispec.App.ViewModels
{
	public class CreateUserViewModel : ViewModelBase
	{
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
		private char _houseNumberSuffix;
		public string HouseNumberSuffix
		{
			get => Convert.ToString(_houseNumberSuffix);
			set
			{
				try
				{
					_houseNumberSuffix = Convert.ToChar(value);
				}
				catch (ArgumentNullException e)
				{
					Console.WriteLine(e.ToString());
				}
				catch (FormatException e)
				{
					Console.WriteLine(e.ToString());
				}
			}
		}

        private IRoleRepository _roleRepo;
        private IEmployeeRepository _employeeRepo;
        private IUsersRepository _userRepo;

		public RelayCommand RegisterCommand { get; set; }

        public CreateUserViewModel()
        {
            _roleRepo = new RoleTestRepository();
            _employeeRepo = new EmployeeTestRepository();
            _userRepo = new UserTestRepository();
            Roles = new ObservableCollection<RoleViewModel>(_roleRepo.GetAll().Select(r => new RoleViewModel(r)));
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
				HouseNumberSuffix = _houseNumberSuffix,
			};
            _userRepo.Add(user);
            _employeeRepo.AddEmployee(employee);
		}
	}
}
