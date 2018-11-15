using System;
using System.ComponentModel;
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
        ///Festispec.App;component/Views/QuestionListHome.xaml
        private string _CurrentPage;
        public string CurrentPage { get => _CurrentPage;  private set { _CurrentPage = value; RaisePropertyChanged(); } }
        public ICommand TemplatePageBtn { get; set; }
        public ICommand AddQuestion { get; set; }
        public ICommand QuestionPageBtn { get; set; }
        public Uri DisplayPage { get; set; }

        public MainViewModel()
        {
            QuestionPageBtn = new RelayCommand(GoToQuestionsPage);
            TemplatePageBtn = new RelayCommand(GoToTemplatesPage);
            AddQuestion = new RelayCommand(ViewCreateQuestion);
            GoToQuestionsPage();
        }

        public void GoToTemplatesPage()
        {
            ChangePage("TemplateList");
        }

        public void GoToQuestionsPage()
        {
            ChangePage("FormList");
        }

        public void GoToEditFormPage()
        {
            ChangePage("EditForm");
        }

        //TODO Temporary page system change to a navigation service 
        public void ChangePage(string page)
        {
            switch (page)
            {
                case "FormList":
                    CurrentPage = "/Views/FormList.xaml";
                    break;
                case "TemplateList":
                    CurrentPage = "/Views/TemplateList.xaml";
                    break;
                case "EditForm":
                    CurrentPage = "/Views/EditForm.xaml";
                    break;
            }
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