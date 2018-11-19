using Festispec.ChartToPng.Abstract;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;

namespace Festispec.ChartToPng
{
    public partial class PieChart : BaseChart<LiveCharts.Wpf.PieChart, PieSeries, ObservableValue>
    {
        private bool _pushOut = true;
        private Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        public PieChart(string title) : base(title)
        {
        }

        protected override PieSeries CreateSeries()
        {
            return new PieSeries();
        }

        protected override void AfterSetupSeries(PieSeries series)
        {
            if (_pushOut)
            {
                series.PushOut = 15;
                _pushOut = false;
            }
            series.LabelPoint = labelPoint;
        }
    }
}