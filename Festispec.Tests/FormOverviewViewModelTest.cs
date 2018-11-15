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
    public class FormOverviewViewModelTest
    {
        [Test]
        public void ViewModelSetupTest()
        {
            FormOverviewViewModel model = new FormOverviewViewModel();
            IFormsRepository repo = new FormsTestRepository();
            Assert.AreEqual(repo.GetAll().Where(f => f.IsTemplate).Select(f => new FormViewModel(f)), model.Templates);
            Assert.AreEqual(repo.GetAll().Where(f => !f.IsTemplate).Select(f => new FormViewModel(f)), model.Forms);
        }

        [Test]
        public void CreateTest()
        {
            FormOverviewViewModel model = new FormOverviewViewModel();
            IFormsRepository repo = new FormsTestRepository();
            FormViewModel form = new FormViewModel(new Form() { });
        }
    }
}
