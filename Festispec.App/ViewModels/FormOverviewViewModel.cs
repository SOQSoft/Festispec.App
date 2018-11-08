using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;

namespace Festispec.App.ViewModels
{
	public class FormOverviewViewModel : ViewModelBase, IFormOverviewViewModel
	{
		public ObservableCollection<FormViewModel> Forms { get;}
		public ObservableCollection<FormViewModel> Templates { get; }
		public FormViewModel SelectedForm { get; set; }
		public FormViewModel SelectedTemplate { get; set; }
		public RelayCommand EditCommand { get; private set; }
		public RelayCommand RemoveCommand { get; private set; }
		public RelayCommand CreateCommand { get; private set; }

		public void CanEditOrRemove()
		{
		}

		public void Create()
		{
		}

		public void CreateBasedOnTemplate()
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
