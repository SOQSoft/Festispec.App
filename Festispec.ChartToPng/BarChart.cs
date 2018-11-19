using Festispec.ChartToPng.Abstract;
using LiveCharts.Wpf;

namespace Festispec.ChartToPng
{
    public class BarChart<V> : CartesianChart<ColumnSeries, V>
	{
		public BarChart(string title) : base(title)
		{
			
		}

        protected override ColumnSeries CreateSeries()
		{
            return new ColumnSeries();
		}
    }
}
