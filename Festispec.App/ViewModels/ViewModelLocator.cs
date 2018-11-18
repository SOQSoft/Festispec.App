using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Festispec.App.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<FormOverviewViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CreateUserViewModel>();
            SimpleIoc.Default.Register<UserViewModel>();
            if (!SimpleIoc.Default.IsRegistered<ViewModelLocator>("ViewModelLocator"))
            {
                SimpleIoc.Default.Register(() => this);
            }
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public FormOverviewViewModel FormOverview => ServiceLocator.Current.GetInstance<FormOverviewViewModel>();
        public FormViewModel FormViewModel => FormOverview.SelectedForm;
        public QuestionViewModel QuestionViewmodel => FormViewModel.SelectedQuestion;
        public CreateUserViewModel CreateUserViewModel => new CreateUserViewModel();
        public LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public static void Cleanup()
        {

        }
    }
}