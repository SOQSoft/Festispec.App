using Festispec.App.Repositories;
using Festispec.App.Views;
using Festispec.Database.Models;
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
        private IFormsRepository formsRepository;
        public QuestionViewModel SelectedQuestion { get; set; }
        public ICommand AddQuestion { get; set; }
        private int count = 0;
        public FormViewModel(Form form)
        {
            formsRepository = new FormsTestRepository();
            _form = form;
            Questions = new ObservableCollection<QuestionViewModel>(form.Question.Select(o => new QuestionViewModel(o, count++)));
            SelectedQuestion = Questions.FirstOrDefault();
            AddQuestion = new RelayCommand(addQuestion);
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
        private void addQuestion()
        {
            Questions.Add(new QuestionViewModel(new Question(), count++));
        }

    }
}