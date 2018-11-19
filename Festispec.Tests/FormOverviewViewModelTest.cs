using Festispec.App.Repositories;
using Festispec.App.ViewModels;
using Festispec.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.Tests
{
    [TestFixture]
    public class FormOverviewViewModelTest
    {
        [Test]
        [TestCase(true), TestCase(false)]
        public void ViewModelSetupTest(bool isTemplate)
        {
            FormOverviewViewModel model = new FormOverviewViewModel();
            IFormRepository repo = new FormsTestRepository();

            List<FormViewModel> list1 = repo.GetAll().Where(f => f.IsTemplate == isTemplate).Select(f => new FormViewModel(f)).ToList();
            List<FormViewModel> list2 = isTemplate ? model.Templates.ToList() : model.Forms.ToList();
            bool same = true;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].Id != list2[i].Id)
                {
                    same = false;
                }
            }
            Assert.IsTrue(same);
        }

        [Test]
        [TestCase(true), TestCase(false)]
        public void CRUDTest(bool isTemplate)
        {
            FormOverviewViewModel model = new FormOverviewViewModel();
            var formList = isTemplate ? model.Templates : model.Forms;
            IFormRepository repo = new FormsTestRepository();

            string name = "TestForm";
            FormViewModel newForm = new FormViewModel(new Form() { Name = name, IsTemplate = isTemplate });

            //Create
            model.NewFormTitle = name;
            model.Create(isTemplate);
            Assert.IsTrue(formList.Any(f => f.Id == newForm.Id));
            Assert.IsTrue(repo.GetAll().Any(f => f.Id == newForm.Id));

            //Select
            Assert.IsFalse(model.CanEditOrRemove(isTemplate));
            model.SelectedForm = formList.FirstOrDefault(f => f.Id == newForm.Id);
            Assert.IsTrue(model.CanEditOrRemove(isTemplate));

            //Remove
            model.Remove(isTemplate);
            Assert.IsFalse(formList.Any(f => f.Id == newForm.Id));
            Assert.IsFalse(repo.GetAll().Any(f => f.Id == newForm.Id));
        }
    }
}