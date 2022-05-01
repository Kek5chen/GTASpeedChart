using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Events;
using LiveCharts.Wpf;
using Timer = System.Timers.Timer;

namespace GTAChart
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public SeriesCollection SpeedSeries { get; set; }

		private readonly GTAProcess _gtaProcess;

		private readonly Timer _timer = new Timer();
		
		public MainWindow()
		{
			SpeedSeries = new SeriesCollection
			{
				new LineSeries
				{
					Title = "Speed",
					Values = new ChartValues<float>(),
					PointGeometry = null,
					LineSmoothness = .1d
				}
			};
			InitializeComponent();

			try
			{
				_gtaProcess = new GTAProcess();
				_timer.Interval = 100;
				_timer.AutoReset = true;
				_timer.Elapsed += UpdateSpeedGraph;
				_timer.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Close();
			}
		}

		private void UpdateSpeedGraph(object o, ElapsedEventArgs args)
		{
			SpeedSeries[0].Values.Add(_gtaProcess.CurrentSpeed);
		}

		private void StartStop_Click(object sender, RoutedEventArgs e)
		{
			_timer.Enabled = !_timer.Enabled;
		}
	}
}
