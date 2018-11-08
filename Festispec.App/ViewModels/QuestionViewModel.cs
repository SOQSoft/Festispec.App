using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Festispec.App.Annotations;
using Festispec.Database.Models;
using GalaSoft.MvvmLight;

namespace Festispec.App.ViewModels
{
    public class QuestionViewModel : ViewModelBase
    {
        private readonly Question Question;

        public QuestionViewModel(Question question)
        {
            Question = question;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Question ToModel()
        {
            return Question;
        }
    }
}
