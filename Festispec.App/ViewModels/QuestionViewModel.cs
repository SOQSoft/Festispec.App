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
using GalaSoft.MvvmLight.Ioc;

namespace Festispec.App.ViewModels
{
    public class QuestionViewModel : ViewModelBase
    {
        public string Header { get { return $"Vraag {OrderNr + 1}"; } }
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
        public int OrderNr
        {
            get => _question.OrderNr;
            set
            {
                _question.OrderNr = value;
                base.RaisePropertyChanged("Header");
            }
        }

        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }

        private readonly Question _question;
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand SaveQuestionCommand { get; private set; }
        public RelayCommand AddQuestionItemCommand { get; private set; }
        public RelayCommand RemoveQuestionItemCommand { get; private set; }
        public QuestionItemViewModel SelectedQuestionItem { get; set; }
        //AddQuestionItem

        private IFormsRepository formsRepository;
        public QuestionViewModel(Question question, int orderNr = 0)
        {
            formsRepository = SimpleIoc.Default.GetInstance<IFormsRepository>();
            _question = question;
            OrderNr = orderNr;
            QuestionItems = new ObservableCollection<QuestionItemViewModel>(question.QuestionItem.Select(o => new QuestionItemViewModel(o)));
            SaveQuestionCommand = new RelayCommand(SaveQuestion);
            AddQuestionItemCommand = new RelayCommand(AddQuestionItem);
            RemoveQuestionItemCommand = new RelayCommand(RemoveQuestionItem);
        }

        private void RemoveQuestionItem()
        {
            if (SelectedQuestionItem != null)
                QuestionItems.Remove(SelectedQuestionItem);
        }

        public void AddQuestionItem()
        {
            QuestionItems.Add(new QuestionItemViewModel(new QuestionItem()));
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
            _question.QuestionItem = QuestionItems.Select(o => o.ToModel()).ToList();
            return _question;
        }
    }
}
