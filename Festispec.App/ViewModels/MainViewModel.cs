using System;
using System.ComponentModel;
using System.Windows.Input;
using Festispec.App.Views;
using Festispec.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Festispec.App.ViewModels
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _CurrentPage;
        public string CurrentPage { get => _CurrentPage; private set { _CurrentPage = value; RaisePropertyChanged(); } }
        public ICommand TemplatePageBtn { get; set; }
        public ICommand ManageUsersPageBtn { get; }
        public ICommand AddQuestion { get; set; }
        private UserViewModel _user;
        public bool IsAdmin { get => _user.LoggedIn && _user.Role == Roles.Manager; }
        public ICommand QuestionPageBtn { get; set; }
        public Uri DisplayPage { get; set; }

        public MainViewModel(UserViewModel user)
        {
            _user = user;
            QuestionPageBtn = new RelayCommand(() => ChangePage(Pages.FormList));
            TemplatePageBtn = new RelayCommand(() => ChangePage(Pages.TemplateList));
            ManageUsersPageBtn = new RelayCommand(() => ChangePage(Pages.CreateUser));

            ChangePage(Pages.QuestionListHome);
        }

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
                    break;
                case Pages.QuestionListHome:
                    CurrentPage = "/Views/QuestionListHome.xaml";
                    break;
            }
        }
    }
}