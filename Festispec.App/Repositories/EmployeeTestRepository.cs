using Festispec.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Festispec.App.Repositories
{
	public class EmployeeTestRepository:IEmployeeRepository
	{
		private readonly static List<Employee> _employees = new List<Employee>();
		private static bool init = false;

		public EmployeeTestRepository()
		{
			InitializeData();
		}

		private void InitializeData()
		{
			if (init)
				return;
			init = true;

			int id = 0;

			User user;

			user = new User()
			{
				Password = "1a2B3c4D5e6F",
				Username = "Banaan",
				Role = new Role() { Name = "Manager" },
				Employee = new Employee()
				{
					Id = id,
					FirstName = "Henk",
					LastName = "Vries",
					City = "New York",
					Country = "Los Angeles",
					Street = "16th Avenue",
					HouseNumber = 20,
					HouseNumberSuffix = 'a',
					Email = "h.devries@festispec.com",
					Phone = "0644608010",
					DateOfBirth = new DateTime(1999, 10, 8),
					IllnessReports = new List<IllnessReport>(),
				}
			};
			user.Employee.User = user;
			AddEmployee(user.Employee);
			id++;

			user = new User()
			{
				Password = "123456ABCDEF",
				Username = "Tafel",
				Role = new Role() { Name = "Inspecteur" },
				Employee = new Employee()
				{
					Id = id,
					FirstName = "Pieter",
					LastName = "Jan",
					City = "Sydney",
					Country = "Australia",
					Street = "St.Petersstreet",
					HouseNumber = 133,
					Email = "p.jan@festispec.com",
					Phone = "0645307001",
					DateOfBirth = new DateTime(1978, 2, 3),
					IllnessReports = new List<IllnessReport>(),
				}
			};
			user.Employee.User = user;
			AddEmployee(user.Employee);
			id++;

			user = new User()
			{
				Password = "ABCDEF123456",
				Username = "Appel",
				Role = new Role() { Name = "Inspecteur" },
				Employee = new Employee()
				{
					Id = id,
					FirstName = "Jan",
					LastName = "Jantjes",
					City = "Amsterdam",
					Country = "Nederland",
					Street = "Kalverstraat",
					HouseNumber = 42,
					Email = "j.jantjes@festispec.com",
					Phone = "0674708996",
					DateOfBirth = new DateTime(2001, 12, 5),
					IllnessReports = new List<IllnessReport>(),
				}
			};
			user.Employee.User = user;
			AddEmployee(user.Employee);
		}

			public void AddEmployee(Employee employee)
		{
			_employees.Add(employee);
		}

		public void RemoveEmployee(Employee employee)
		{
			_employees.Remove(employee);
		}

		public ICollection<Employee> GetAll() { return _employees; }

		public ICollection<Employee> Where(Func<Employee, bool> func)
		{
			return _employees.Where(func).ToList();
		}
	}
}
