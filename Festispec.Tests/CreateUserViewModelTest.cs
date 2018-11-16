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
        public void CreateUserTest()
        {
            CreateUserViewModel vm = new CreateUserViewModel();
            IEmployeeRepository employeeRepo = new EmployeeTestRepository();
            IUsersRepository userRepo = new UserTestRepository();
            IRoleRepository roleRepo = new RoleTestRepository();

            EmployeeViewModel employee = new EmployeeViewModel(new Employee()
            {
                User = new User() {
                    Username = "TestUsername",
                    Password = "TestPassword",
                    Role = roleRepo.GetAll().ElementAt(0)
                },
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                DateOfBirth = DateTime.Now,
                Email = "test@example.com",
                Phone = "0612345678",
                Country = "Nederland",
                City = "TestCity",
                Street = "TestStreet",
                HouseNumber = 1
            });
            vm.Username = "TestUsername";
            vm.Password = "TestPassword";
            vm.Role = new RoleViewModel(roleRepo.GetAll().ElementAt(0));
            vm.FirstName = "TestFirstName";
            vm.LastName = "TestLastName";
            vm.DateOfBirth = DateTime.Now;
            vm.Email = "test@example.com";
            vm.Phone = "0612345678";
            vm.Country = "Nederland";
            vm.City = "TestCity";
            vm.Street = "TestStreet";
            vm.HouseNumber = 1;

            Assert.IsTrue(vm.CanRegister());
            vm.Register();
            Assert.IsTrue(userRepo.GetAll().Any(u => u.Id == employee.User));
            Assert.IsTrue(employeeRepo.GetAll().Contains(employee.ToModel()));

        }
    }
}
