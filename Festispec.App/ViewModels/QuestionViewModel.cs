﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Festispec.App.Repositories;
using Festispec.Database.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

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
        public RelayCommand SaveQuestionCommand { get; private set; }

        private IFormsRepository formsRepository;
        public QuestionViewModel(Question question)
        {
            formsRepository = new FormsTestRepository();
            _question = question;

            QuestionItems = new ObservableCollection<QuestionItemViewModel>(question.QuestionItem.Select(o => new QuestionItemViewModel(o)));
            SaveQuestionCommand = new RelayCommand(SaveQuestion);
        }

        private void SaveQuestion()
        {

        }

        public Question ToModel()
        {
            return _question;
        }
    }
}
