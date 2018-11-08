using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;ge
using Festispec.App.Annotations;
using Festispec.Database.Models;
using GalaSoft.MvvmLight;

namespace Festispec.App.ViewModels
{
    public class QuestionViewModel : ViewModelBase
    {
        public int Id
        {
            get => _question.Id;
            set
            {
                _question.Id = value;
                base.RaisePropertyChanged();
            }
        }
        public string Text
        {
            get => _question.Text;
            set
            {
                _question.Text = value;
                base.RaisePropertyChanged();
            }
        }
        public string Description
        {
            get => _question.Description;
            set
            {
                _question.Description = value;
                base.RaisePropertyChanged();
            }
        }
        public int QuestionType
        {
            get => _question.QuestionType;
            set
            {
                _question.QuestionType = value;
                base.RaisePropertyChanged();
            }
        }
        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }

        private readonly Question _question;
        public event PropertyChangedEventHandler PropertyChanged;
        public QuestionViewModel(Question question)
        {
            _question = question;

            QuestionItems = new ObservableCollection<QuestionItemViewModel>(question.QuestionItem.Select(o => new QuestionItemViewModel(o)));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Question ToModel()
        {
            return _question;
        }
    }
}
