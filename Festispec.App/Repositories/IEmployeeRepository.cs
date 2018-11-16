using Festispec.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.App.Repositories
{
	public interface IEmployeeRepository
	{
		void AddEmployee(Employee employee);

		void RemoveEmployee(Employee employee);

		ICollection<Employee> GetAll();
	}
}
