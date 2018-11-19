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

        public int Id {
            get => _illnessReport.Id;
            set
            {
                _illnessReport.Id = value;
                RaisePropertyChanged();
            }
        }
        public DateTime IllDateTime {
            get => _illnessReport.IllDateTime;
            set
            {
                _illnessReport.IllDateTime = value;
                RaisePropertyChanged();
            }
        }
        public DateTime BetterDateTime {
            get => _illnessReport.BetterDateTime;
            set
            {
                _illnessReport.BetterDateTime = value;
                RaisePropertyChanged();
            }
        }
        public Employee Employee {
            get => _illnessReport.Employee;
            set
            {
                _illnessReport.Employee = value;
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
