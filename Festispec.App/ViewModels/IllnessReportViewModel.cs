using Festispec.Domain;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.App.ViewModels
{
    public class IllnessReportViewModel : ViewModelBase
    {
        private IllnessReport _illnessReport;

        private int _id;
        public int Id {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }
        private DateTime _illDateTime;
        public DateTime IllDateTime {
            get => _illDateTime;
            set
            {
                _illDateTime = value;
                RaisePropertyChanged();
            }
        }
        private DateTime _betterDateTime;
        public DateTime BetterDateTime {
            get => _betterDateTime;
            set
            {
                _betterDateTime = value;
                RaisePropertyChanged();
            }
        }
        private Employee _employee;
        public Employee Employee {
            get => _employee;
            set
            {
                _employee = value;
                RaisePropertyChanged();
            }
        }

        public IllnessReportViewModel(IllnessReport report)
        {
            _illnessReport = report;
        }

        public IllnessReport ToModel()
        {
            return _illnessReport;
        }
    }
}
