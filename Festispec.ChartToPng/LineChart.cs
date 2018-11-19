using Festispec.ChartToPng.Abstract;
using LiveCharts.Wpf;

namespace Festispec.ChartToPng
{
    public class LineChart<V> : CartesianChart<LineSeries, V>
    {
        public LineChart(string title) : base(title)
        {

        }

        protected override LineSeries CreateSeries()
        {
            return new LineSeries();
        }
    }
}
