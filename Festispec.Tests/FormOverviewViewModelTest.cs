﻿using Festispec.App.Repositories;
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
            IFormsRepository repo = new FormsTestRepository();
            FormOverviewViewModel model = new FormOverviewViewModel(repo, new ViewModelLocator());
            Assert.AreEqual(repo.GetAll().Where(f => f.IsTemplate).Select(f => new FormViewModel(f)), model.Templates);
            Assert.AreEqual(repo.GetAll().Where(f => !f.IsTemplate).Select(f => new FormViewModel(f)), model.Forms);
        }

        [Test]
        [TestCase(true), TestCase(false)]
        public void CRUDTest(bool isTemplate)
        {
            IFormsRepository repo = new FormsTestRepository();
            FormOverviewViewModel model = new FormOverviewViewModel(repo, new ViewModelLocator());
            var formList = isTemplate ? model.Templates : model.Forms;

            string name = "TestForm";
            FormViewModel newForm = new FormViewModel(new Form() { Name = name, IsTemplate = isTemplate });

            //Create
            model.NewFormTitle = name;
            model.Create(isTemplate);
            Assert.IsTrue(formList.Contains(newForm));
            Assert.IsTrue(repo.GetAll().Any(f => f.Id == newForm.Id));

            //Select
            Assert.IsFalse(model.CanEditOrRemove(isTemplate));
            model.SelectedForm = newForm;
            Assert.IsTrue(model.CanEditOrRemove(isTemplate));

            //Remove
            model.Remove(isTemplate);
            Assert.IsFalse(formList.Contains(newForm));
            Assert.IsFalse(repo.GetAll().Any(f => f.Id == newForm.Id));
        }
    }
}