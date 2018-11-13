using Festispec.Database.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using System.Collections.ObjectModel;
using Festispec.App.Repositories;

namespace Festispec.App.ViewModels
{
	public class TemplateOverviewViewModel : FormOverviewViewModelBase
	{
		private readonly IFormsRepository _formRepository;

		public ObservableCollection<FormViewModel> Forms { get; private set; }
		public FormViewModel SelectedForm { get; set; }
		public RelayCommand EditCommand { get; private set; }
		public RelayCommand RemoveCommand { get; private set; }
		public RelayCommand CreateCommand { get; private set; }
		public string NewFormText { get; set; }

		public TemplateOverviewViewModel()
		{
			_formRepository = new FormsTestRepository();
			Forms = new ObservableCollection<FormViewModel>(_formRepository.GetAll().Where(c => c.IsTemplate).Select(o => new FormViewModel(o)));
			EditCommand = new RelayCommand(Edit, CanEditOrRemove);
			RemoveCommand = new RelayCommand(Remove, CanEditOrRemove);
			CreateCommand = new RelayCommand(Create, CanCreate);
		}

		internal override bool CanEditOrRemove()
		{
			return SelectedForm != null;
		}

		internal override bool CanCreate()
		{
			return !string.IsNullOrEmpty(NewFormText);
		}

		internal override void Create()
		{
			Form form = new Form
			{
				IsTemplate = true,
				Name = NewFormText
			};
			_formRepository.Add(form);
			FormViewModel formViewModel = new FormViewModel(form);
			Forms.Add(formViewModel);
			NewFormText = string.Empty;
		}

		internal override void Edit()
		{
			throw new System.NotImplementedException();
		}

		internal override void Remove()
		{
			_formRepository.Delete(SelectedForm.ToModel());
			Forms.Remove(SelectedForm);
		}
	}
}
