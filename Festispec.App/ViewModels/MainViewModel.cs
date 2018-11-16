using System;
using System.ComponentModel;
using System.Windows.Input;
using Festispec.App.Views;
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
            QuestionPageBtn = new RelayCommand(() => ChangePage(Pages.FormList));
            TemplatePageBtn = new RelayCommand(() => ChangePage(Pages.TemplateList));
            AddQuestion = new RelayCommand(ViewCreateQuestion);
            ChangePage(Pages.CreateUser);
        }

        //TODO Temporary page system change to a navigation service 
        public void ChangePage(Pages page)
        {
            switch (page)
            {
                case Pages.FormList:
                    CurrentPage = "/Views/FormList.xaml";
                    break;
                case Pages.TemplateList:
                    CurrentPage = "/Views/TemplateList.xaml";
                    break;
                case Pages.EditForm:
                    CurrentPage = "/Views/EditForm.xaml";
                    break;
                case Pages.CreateUser:
                    CurrentPage = "/Views/CreateUser.xaml";
                    //TODO: Make a decision, one or the other.
                    DisplayPage = new Uri("CreateUser.xaml", UriKind.Relative);
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