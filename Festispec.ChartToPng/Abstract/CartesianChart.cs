using Festispec.ChartToPng.Helpers;
using LiveCharts.Wpf;

namespace Festispec.ChartToPng.Abstract
{
    public abstract class CartesianChart<S, V> : BaseChart<CartesianChart, S, V> where S : Series
    {
        public AxisFactory XAxis
        {
            set
            {
                Chart.AxisX.Clear();
                Chart.AxisX.Add(value.Create());
            }
        }
        public AxisFactory YAxis
        {
            set
            {
                Chart.AxisY.Clear();
                Chart.AxisY.Add(value.Create());
            }
        }

        public CartesianChart(string title) : base(title)
        {
        }

        protected override abstract S CreateSeries();
    }
}
