using System.Runtime.InteropServices;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace GTAChart
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public SeriesCollection SpeedSeries { get; set; }
		
		public MainWindow()
		{
			SpeedSeries = new SeriesCollection
			{
				new LineSeries
				{
					Title="Speeds1",
					Values = new ChartValues<ObservableValue>
					{
						new ObservableValue(1),
						new ObservableValue(2),
						new ObservableValue(3),
						new ObservableValue(2)
					}
				}
			};
			InitializeComponent();
			SpeedSeries[0].Values.Add(new ObservableValue(4));
			
		}
	}
}
