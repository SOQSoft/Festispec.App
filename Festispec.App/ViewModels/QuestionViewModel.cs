using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Festispec.App.Repositories;
using Festispec.Database.Models;
using Festispec.Domain.src;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Festispec.App.ViewModels
{
    public class QuestionViewModel : ViewModelBase
    {
        public string Header { get { return $"Vraag {_count + 1}"; } }
        public QuestionType[] QuestionTypes => (QuestionType[])Enum.GetValues(typeof(QuestionType));
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
        public QuestionType QuestionType
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
        private readonly int _count;

        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand SaveQuestionCommand { get; private set; }

        private IFormsRepository formsRepository;
        public QuestionViewModel(Question question,int count = 0)
        {
            formsRepository = new FormsTestRepository();
            _question = question;
            _count = count;
            QuestionItems = new ObservableCollection<QuestionItemViewModel>(question.QuestionItem.Select(o => new QuestionItemViewModel(o)));
            SaveQuestionCommand = new RelayCommand(SaveQuestion);
        }

        private void SaveQuestion()
        {

        }

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
