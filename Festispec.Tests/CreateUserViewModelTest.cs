using Festispec.App.Repositories;
using Festispec.App.ViewModels;
using Festispec.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.Tests
{
    [TestFixture]
    public class CreateUserViewModelTest
    {
        [Test]
        public void CreateUserTest()
        {
            CreateUserViewModel vm = new CreateUserViewModel();
            IEmployeeRepository employeeRepo = new EmployeeTestRepository();
            IUsersRepository userRepo = new UserTestRepository();
            IRoleRepository roleRepo = new RoleTestRepository();

            User user = new User()
            {
                Username = "TestUsername",
                Password = "TestPassword",
                Role = roleRepo.GetAll().ElementAt(0)
            };
            EmployeeViewModel employee = new EmployeeViewModel(new Employee()
            {
                User = user,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                DateOfBirth = DateTime.Now,
                Email = "test@example.com",
                Phone = "0612345678",
                Country = "Nederland",
                City = "TestCity",
                Street = "TestStreet",
                HouseNumber = 1,
                IllnessReports = new List<IllnessReport>()
            });
            employee.User.Employee = employee.ToModel();
            vm.Username = employee.User.Username;
            vm.Password = employee.User.Password;
            vm.Role = new RoleViewModel(employee.User.Role);
            vm.FirstName = employee.FirstName;
            vm.LastName = employee.LastName;
            vm.DateOfBirth = DateTime.Now;
            vm.Email = employee.Email;
            vm.Phone = employee.Phone;
            vm.Country = employee.Country;
            vm.City = employee.City;
            vm.Street = employee.Street;
            vm.HouseNumber = employee.HouseNumber;

            Assert.IsTrue(vm.CanRegister());
            vm.Register();
            Assert.IsTrue(userRepo.GetAll().Any(u => u.Username == user.Username));
            Assert.IsTrue(employeeRepo.GetAll().Any(e => e.Id == employee.Id));
            userRepo.Delete(userRepo.GetAll().FirstOrDefault(u => u.Username == user.Username));
            employeeRepo.RemoveEmployee(employeeRepo.GetAll().FirstOrDefault(e => e.Id == employee.Id));
            Assert.IsFalse(userRepo.GetAll().Any(u => u.Username == user.Username));
            Assert.IsFalse(employeeRepo.GetAll().Any(e => e.Id == employee.Id));
        }
    }
}
