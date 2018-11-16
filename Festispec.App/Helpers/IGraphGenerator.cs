using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Festispec.App.Helpers
{
	public abstract class GraphGeneratorBase
	{
		public void CreateGraph()
		{
			
		}

		protected abstract MarshalByRefObject.Component.Control.Chart GenerateChart();

		private void GraphToPNG
	}
}
