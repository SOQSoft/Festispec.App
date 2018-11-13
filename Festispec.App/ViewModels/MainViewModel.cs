using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Festispec.App.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ICommand TemplatePageBtn { get; set; }
        public ICommand AddQuestion { get; set; }
        public ICommand QuestionPageBtn { get; set; }
        public Uri DisplayPage { get; set; }

        public MainViewModel()
        {
            TemplatePageBtn = new RelayCommand(ShowTemplatePage);
            AddQuestion = new RelayCommand(ViewCreateQuestion);
            QuestionPageBtn = new RelayCommand(ViewQuestions);
            DisplayPage = new Uri("QuestionListHome.xaml", UriKind.Relative);
        }

        public void ShowTemplatePage()
        {
            DisplayPage = new Uri("TemplateList.xaml", UriKind.Relative);
            RaisePropertyChanged("DisplayPage");
        }

        public void ViewCreateQuestion()
        {
            DisplayPage = new Uri("CreateQuestion.xaml", UriKind.Relative);
            RaisePropertyChanged("DisplayPage");
        }
        public void ViewQuestions()
        {
            DisplayPage = new Uri("QuestionListHome.xaml", UriKind.Relative);
            RaisePropertyChanged("DisplayPage");
        }
    }
}