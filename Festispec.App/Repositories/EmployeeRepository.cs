﻿using Festispec.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Festispec.App.Repositories
{
	public class EmployeeRepository
	{
		private readonly static List<Employee> _employees = new List<Employee>();

		public void AddEmployee(Employee employee)
		{
			_employees.Add(employee);
		}

		public void RemoveEmployee(Employee employee)
		{
			_employees.Remove(employee);
		}

		public ICollection<Employee> GetAll { get { return _employees; } }
	}
}
