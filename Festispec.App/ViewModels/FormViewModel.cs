using Festispec.App.Repositories;
using Festispec.App.Views;
using Festispec.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;

namespace Festispec.App.ViewModels
{
    public class FormViewModel : ViewModelBase
    {
        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        private Form _form;
        private IFormRepository formsRepository;
        public QuestionViewModel SelectedQuestion { get; set; }
        public ICommand AddQuestionCommand { get; set; }
        public ICommand RemoveQuestionCommand { get; set; }
        public ICommand UpQuestionCommand { get; set; }
        public ICommand DownQuestionCommand { get; set; }

        private int count = 0;
        public FormViewModel(Form form)
        {
            formsRepository = new FormsTestRepository();
            _form = form;
            Questions = new ObservableCollection<QuestionViewModel>(form.Question.OrderBy( o => o.OrderNr).Select(o => new QuestionViewModel(o, count++)));
            SelectedQuestion = Questions.FirstOrDefault();
            AddQuestionCommand = new RelayCommand(AddQuestion);
            RemoveQuestionCommand = new RelayCommand(RemoveQuestion);
            UpQuestionCommand = new RelayCommand(UpQuestion);
            DownQuestionCommand = new RelayCommand(DownQuestion);

        }

        public void UpQuestion()
        {
            if (SelectedQuestion.OrderNr == Questions.Count - 1)
                return;
            var question = Questions.FirstOrDefault(o => o.OrderNr == SelectedQuestion.OrderNr + 1);
            if (question != null)
            {
                question.OrderNr = SelectedQuestion.OrderNr;
            }
            SelectedQuestion.OrderNr += 1;
            ReOrder();
        }

        public void DownQuestion()
        {
            if (SelectedQuestion.OrderNr == 0)
                return;
            var question = Questions.FirstOrDefault(o => o.OrderNr == SelectedQuestion.OrderNr - 1);
            if (question != null)
            {
                question.OrderNr = SelectedQuestion.OrderNr;
            }
            SelectedQuestion.OrderNr -= 1;
            ReOrder();
        }
        public int Id
        {
            get => _form.Id;
            set
            {
                _form.Id = value;
                RaisePropertyChanged();
            }
        }
        public string Name
        {
            get => _form.Name;
            set
            {
                _form.Name = value;
                RaisePropertyChanged();
            }
        }
        public bool IsTemplate
        {
            get => _form.IsTemplate;
            set
            {
                _form.IsTemplate = value;
                RaisePropertyChanged();
            }
        }
        public string Comments
        {
            get => _form.Comments;
            set
            {
                _form.Comments = value;
                RaisePropertyChanged();
            }
        }
        private void AddQuestion()
        {
            Question q = new Question();
            _form.Questions.Add(q);
            Questions.Add(new QuestionViewModel(q, count++));
        }

        private void RemoveQuestion()
        {
            if(Questions.Count != 1)
            {
                Questions.Remove(SelectedQuestion);
                ReOrder();
            }
        }

        public void ReOrder()
        {
            count = 0;
            foreach (var question in Questions.OrderBy(o => o.OrderNr))
            {
                question.OrderNr = count++;
            }
            Questions = new ObservableCollection<QuestionViewModel>(Questions.OrderBy(o => o.OrderNr));
            base.RaisePropertyChanged("Questions");
        }

        public Form ToModel() { return _form; }
    }
}