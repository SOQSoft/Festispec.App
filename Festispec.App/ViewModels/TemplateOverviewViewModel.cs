using Festispec.Database.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using System.Collections.ObjectModel;
using Festispec.App.Repositories;
using System.Collections.Generic;

namespace Festispec.App.ViewModels
{
    public class TemplateOverviewViewModel : ViewModelBase, IFormOverviewViewModelBase
    {
        private readonly IFormsRepository _formRepository;

        public ObservableCollection<FormViewModel> Forms { get; private set; }
        public FormViewModel SelectedForm { get; set; }
        public RelayCommand EditCommand { get; private set; }
        public RelayCommand RemoveCommand { get; private set; }
        public RelayCommand CreateCommand { get; private set; }
        public string NewFormTitle { get; set; }

        public TemplateOverviewViewModel()
        {
            _formRepository = new FormsTestRepository();
            Forms = new ObservableCollection<FormViewModel>(_formRepository.GetAll().Where(c => c.IsTemplate).Select(o => new FormViewModel(o)));
            EditCommand = new RelayCommand(Edit, CanEditOrRemove);
            RemoveCommand = new RelayCommand(Remove, CanEditOrRemove);
            CreateCommand = new RelayCommand(Create, CanCreate);
        }

        public bool CanEditOrRemove()
        {
            return SelectedForm != null;
        }

        public bool CanCreate()
        {
            return !string.IsNullOrEmpty(NewFormTitle);
        }

        public void Create()
        {
            Form form = new Form
            {
                IsTemplate = true,
                Name = NewFormTitle,
                Question = new List<Question>() { new Question() }
            };
            _formRepository.Add(form);
            FormViewModel formViewModel = new FormViewModel(form);
            Forms.Add(formViewModel);
            NewFormTitle = string.Empty;
        }

        public void Edit()
        {
            throw new System.NotImplementedException();
        }

        public void Remove()
        {
            _formRepository.Delete(SelectedForm.ToModel());
            Forms.Remove(SelectedForm);
        }
    }
}
