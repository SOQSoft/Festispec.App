using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Festispec.App.Repositories;
using Festispec.Domain;
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
        public string ColumnName1
        {
            get => QuestionItems.Count >= 1 ? QuestionItems[0].Body : "";
            set
            {
                if (QuestionItems.Count < 1)
                {
                    QuestionItems.Add(new QuestionItemViewModel(new QuestionItem() { Body = value }));
                }
                else
                {
                    QuestionItems[0].Body = value;
                }
            }
        }
        public string ColumnName2
        {
            get => QuestionItems.Count >= 2 ? QuestionItems[1].Body : "";
            set
            {
                if (QuestionItems.Count < 2)
                {
                    if(QuestionItems.Count == 0)
                        QuestionItems.Add(new QuestionItemViewModel(new QuestionItem()));

                    QuestionItems.Add(new QuestionItemViewModel(new QuestionItem() { Body = value }));
                }
                else
                {
                    QuestionItems[1].Body = value;
                }
            }
        }
        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }

        private readonly Question _question;
        private readonly int _count;

        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand SaveQuestionCommand { get; private set; }
        public RelayCommand AddQuestionItemCommand { get; private set; }
        public RelayCommand RemoveQuestionItemCommand { get; private set; }
        public QuestionItemViewModel SelectedQuestionItem { get; set; }
        //AddQuestionItem

        private IFormRepository formsRepository;
        public QuestionViewModel(Question question, int count = 0)
        {
            formsRepository = new FormsTestRepository();
            _question = question;
            _count = count;
            QuestionItems = new ObservableCollection<QuestionItemViewModel>(question.QuestionItem.Select(o => new QuestionItemViewModel(o)));
            SaveQuestionCommand = new RelayCommand(SaveQuestion);
            AddQuestionItemCommand = new RelayCommand(AddQuestionItem);
            RemoveQuestionItemCommand = new RelayCommand(RemoveQuestionItem);
        }

        private void RemoveQuestionItem()
        {
            if (SelectedQuestionItem != null)
            {
                QuestionItems.Remove(SelectedQuestionItem);
                _question.QuestionItem.Remove(SelectedQuestionItem.ToModel());
            }
        }

        public void AddQuestionItem()
        {
            QuestionItem q = new QuestionItem();
            _question.QuestionItem.Add(q);
            QuestionItems.Add(new QuestionItemViewModel(q));
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
