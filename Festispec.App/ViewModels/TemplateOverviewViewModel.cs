using Festispec.Database.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using System.Collections.ObjectModel;
using Festispec.App.Repositories;

namespace Festispec.App.ViewModels
{
	class TemplateOverviewViewModel : ViewModelBase, IFormOverviewViewModel
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
			Forms = new ObservableCollection<FormViewModel>(_formRepository.GetAll().Where(c => c.IsTemplate).Select(o => new FormViewModel(o)));
		}

		public bool CanEditOrRemove()
		{
			return SelectedForm != null;
		}

		public void Create()
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
