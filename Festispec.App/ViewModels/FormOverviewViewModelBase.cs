using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace Festispec.App.ViewModels
{
    public interface IFormOverviewViewModelBase
    {
        ObservableCollection<FormViewModel> Forms { get; }

        FormViewModel SelectedForm { get; set; }
        string NewFormTitle { get; set; }
        RelayCommand EditCommand { get; }
        RelayCommand RemoveCommand { get; }
        RelayCommand CreateCommand { get; }

        void Edit();

        void Remove();

        void Create();
    }
}
