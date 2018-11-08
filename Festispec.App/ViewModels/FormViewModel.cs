using Festispec.Database.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.App.ViewModels
{
    class FormViewModel : ViewModelBase
    {
        private Form _form;
        public FormViewModel(Form form)
        {
            _form = form;
        }
        public int Id {
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
        public ICollection<Question> Question
        {
            get => _form.Question;
            set
            {
                _form.Question = value;
                RaisePropertyChanged();
            }
        }
    }
}
