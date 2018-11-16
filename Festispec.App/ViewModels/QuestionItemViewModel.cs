using Festispec.Domain;
using GalaSoft.MvvmLight;

namespace Festispec.App.ViewModels
{
    public class QuestionItemViewModel : ViewModelBase
    {
        private QuestionItem _questionItem;
        public QuestionItemViewModel(QuestionItem questionItem)
        {
            _questionItem = questionItem;
        }

        public string Body
        {
            get => _questionItem.Body;
            set
            {
                _questionItem.Body = value;
                base.RaisePropertyChanged();
            }
        }

    }
}
