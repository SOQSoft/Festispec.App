using Festispec.Domain;
using GalaSoft.MvvmLight.Command;
using System;

namespace Festispec.App.ViewModels
{
	public class CreateUserViewModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public Role Role { get; set; }


		public string FirstName { get; set; }
		public string LastName { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Email { get; set; }
		public string Phone { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public int HouseNumber { get; set; }
		private char _houseNumberFix;
		public string HouseNumberSuffix
		{
			get => Convert.ToString(_houseNumberFix);
			set
			{
				try
				{
					_houseNumberFix = Convert.ToChar(value);
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

		public RelayCommand RegisterCommand { get; set; }

		private void Register()
		{
			User user = new User()
			{
				Username = Username,
				Password = Password,
				Role = Role
			};
			Employee employee = new Employee()
			{
				User = user,
			};
		}
	}
}
