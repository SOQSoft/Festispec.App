using Festispec.App.Repositories;
using Festispec.Database.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Festispec.App.ViewModels
{
    public class FormOverviewViewModel : ViewModelBase, IFormOverviewViewModelBase
    {
        private readonly IFormsRepository _formRepository;

        public ObservableCollection<FormViewModel> Forms { get; }
        public ObservableCollection<FormViewModel> Templates { get; }
        private string _NewFormTitle;
        public string NewFormTitle
        {
            get => _NewFormTitle; set
            {
                _NewFormTitle = value;
                RaisePropertyChanged();
            }
        }
        public FormViewModel SelectedForm { get; set; }
        public FormViewModel SelectedTemplate { get; set; }
        public RelayCommand EditCommand { get; private set; }
        public RelayCommand RemoveCommand { get; private set; }
        public RelayCommand CreateCommand { get; private set; }
        public RelayCommand CreateBasedOnTemplateCommand { get; private set; }

        private ViewModelLocator _viewModelLocator;

        public FormOverviewViewModel()
        {
            _formRepository = new FormsTestRepository();
            Forms = new ObservableCollection<FormViewModel>(_formRepository.GetAll().Where(o => !o.IsTemplate).Select(o => new FormViewModel(o)));
            Templates = new ObservableCollection<FormViewModel>(_formRepository.GetAll().Where(o => o.IsTemplate).Select(o => new FormViewModel(o)));
            EditCommand = new RelayCommand(Edit, CanEditOrRemove);
            RemoveCommand = new RelayCommand(Remove, CanEditOrRemove);
            CreateCommand = new RelayCommand(Create);
            CreateBasedOnTemplateCommand = new RelayCommand(CreateBasedOnTemplate, CanCreateBasedOnTemplate);
            _viewModelLocator = new ViewModelLocator();
        }

        public bool CanEditOrRemove()
        {
            return SelectedForm != null && Forms.Contains(SelectedForm);
        }

        private bool CanCreateBasedOnTemplate()
        {
            return SelectedTemplate != null;
        }

        public void Create()
        {
            Form f = new Form()
            {
                IsTemplate = false,
                Name = NewFormTitle,
                Question = new List<Question>() { new Question() }

            };
            NewFormTitle = null;
            _formRepository.Add(f);
            Forms.Add(new FormViewModel(f));
        }

        private void CreateBasedOnTemplate()
        {
            if (SelectedTemplate == null) { return; }
            Form f = new Form()
            {
                IsTemplate = false,
                Name = NewFormTitle
            };
            foreach (QuestionViewModel q in SelectedTemplate.Questions) f.Question.Add(q.ToModel());
            NewFormTitle = string.Empty;
            _formRepository.Add(f);
            Forms.Add(new FormViewModel(f));
        }

        public void Edit()
        {
            _viewModelLocator.Main.ChangePage("EditForm");
        }

        public void Remove()
        {
            _formRepository.Delete(SelectedForm.ToModel());
            Forms.Remove(SelectedForm);
        }
    }
}
