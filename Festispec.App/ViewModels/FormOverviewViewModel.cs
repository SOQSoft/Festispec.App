using Festispec.App.Repositories;
using Festispec.Database.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Festispec.App.ViewModels
{
	public class FormOverviewViewModel : ViewModelBase, IFormOverviewViewModel
	{
        private readonly IFormsRepository _formRepository;

        public ObservableCollection<FormViewModel> Forms { get;}
		public ObservableCollection<FormViewModel> Templates { get; }
        public string NewFormText { get; set; }
        public FormViewModel SelectedForm { get; set; }
		public FormViewModel SelectedTemplate { get; set; }
		public RelayCommand EditCommand { get; private set; }
		public RelayCommand RemoveCommand { get; private set; }
		public RelayCommand CreateCommand { get; private set; }


        public FormOverviewViewModel()
        {
            _formRepository = new FormsTestRepository();
            Forms = new ObservableCollection<FormViewModel>(_formRepository.GetAll().Where(o => !o.IsTemplate).Select(o => new FormViewModel(o)));
            Templates = new ObservableCollection<FormViewModel>(_formRepository.GetAll().Where(o => o.IsTemplate).Select(o => new FormViewModel(o)));
        }
		public bool CanEditOrRemove()
		{
            return SelectedForm != null && Forms.Contains(SelectedForm);
		}

		public void Create()
		{
            Form f = new Form()
            {
                IsTemplate = false,
                Name = NewFormText
            };
            NewFormText = null;
            _formRepository.Add(f);
            Forms.Add(new FormViewModel(f));
		}

        public void CreateBasedOnTemplate()
        {
            if (SelectedTemplate == null) { return; }
            Form f = new Form()
            {
                IsTemplate = false,
                Name = NewFormText
            };
            foreach (QuestionViewModel q in SelectedTemplate.Questions) f.Question.Add(q.ToModel());
            NewFormText = null;
            _formRepository.Add(f);
            Forms.Add(new FormViewModel(f));
        }

		public void Edit()
		{
            throw new NotImplementedException();
		}

		public void Remove()
		{
            Forms.Remove(SelectedForm);
            _formRepository.Delete(SelectedForm.ToModel());
		}
	}
}
