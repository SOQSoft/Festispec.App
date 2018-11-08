using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;

namespace Festispec.App.ViewModels
{
	class TemplateOverviewViewModel : ViewModelBase, IFormOverviewViewModel
	{
		public ObservableCollection<FormViewModel> Forms { get;}
		public FormViewModel SelectedForm { get; set; }
		public RelayCommand EditCommand { get; private set; }
		public RelayCommand RemoveCommand { get; private set; }
		public RelayCommand CreateCommand { get; private set; }

		public void CanEditOrRemove()
		{
		}

		public void Create()
		{
		}

		public void Edit()
		{
		}

		public void Remove()
		{
		}
	}
}
