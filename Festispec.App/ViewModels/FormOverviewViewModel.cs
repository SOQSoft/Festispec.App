using Festispec.App.Repositories;
using Festispec.App.Views;
using Festispec.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Festispec.App.ViewModels
{
    public class FormOverviewViewModel : ViewModelBase
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
        public ICommand EditCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand CreateCommand { get; private set; }
        private ViewModelLocator _viewModelLocator;

        public FormOverviewViewModel()
        {
            _formRepository = new FormsTestRepository();
            Forms = new ObservableCollection<FormViewModel>(_formRepository.GetAll().Where(o => !o.IsTemplate).Select(o => new FormViewModel(o)));
            Templates = new ObservableCollection<FormViewModel>(_formRepository.GetAll().Where(o => o.IsTemplate).Select(o => new FormViewModel(o)));
            EditCommand = new RelayCommand<bool>(Edit, CanEditOrRemove);
            RemoveCommand = new RelayCommand<bool>(Remove, CanEditOrRemove);
            CreateCommand = new RelayCommand<bool>(Create);
            _viewModelLocator = new ViewModelLocator();
        }

        public bool CanEditOrRemove(bool isTemplate)
        {
            return SelectedForm != null && ((SelectedForm.IsTemplate && Templates.Contains(SelectedForm)) || (!SelectedForm.IsTemplate && Forms.Contains(SelectedForm)));
        }

        public void Create(bool isTemplate)
        {
            Form f = new Form()
            {
                IsTemplate = isTemplate,
                Name = NewFormTitle,
            };

            if (SelectedTemplate != null)
            {
                foreach (QuestionViewModel q in SelectedTemplate.Questions) f.Question.Add(q.ToModel());
            }
            else
            {
                f.Question.Add(new Question());
            }
            NewFormTitle = null;
            _formRepository.Add(f);
            if (!isTemplate)
            {
                Forms.Add(new FormViewModel(f));
            }
            else
            {
                Templates.Add(new FormViewModel(f));
            }
        }
        public void Edit(bool isTemplate)
        {
            _viewModelLocator.Main.ChangePage(Pages.EditForm);
        }

        public void Remove(bool isTemplate)
        {
            _formRepository.Delete(SelectedForm.ToModel());
            if (isTemplate)
            {
                Templates.Remove(SelectedForm);
            }
            else
            {
                Forms.Remove(SelectedForm);
            }
        }
    }
}
