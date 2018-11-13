using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace Festispec.App.ViewModels
{
	public abstract class FormOverviewViewModelBase:ViewModelBase
	{
		ObservableCollection<FormViewModel> Forms { get;}

		FormViewModel SelectedForm { get; set; }
		string NewFormText { get; set; }
		RelayCommand EditCommand { get; }
		RelayCommand RemoveCommand { get; }
		RelayCommand CreateCommand { get; }

		internal abstract bool CanEditOrRemove();

		internal abstract bool CanCreate();

		internal abstract void Edit();

		internal abstract void Remove();

		internal abstract void Create();
	}
}
