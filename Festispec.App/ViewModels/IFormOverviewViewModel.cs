using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace Festispec.App.ViewModels
{
	public interface IFormOverviewViewModel
	{
		ObservableCollection<FormViewModel> Forms { get;}

		FormViewModel SelectedForm { get; set; }

        string NewFormText { get; set; }

		RelayCommand EditCommand { get; }
		RelayCommand RemoveCommand { get; }
		RelayCommand CreateCommand { get; }

		bool CanEditOrRemove();

		void Edit();

		void Remove();

		void Create();
	}
}
