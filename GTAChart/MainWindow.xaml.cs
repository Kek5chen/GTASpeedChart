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

		private readonly ProcessMemory _gtaProcess;

		private float Speed => _gtaProcess.Read<float>(_gtaProcess.BaseAddress + 0x254A754);

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
				_gtaProcess = new ProcessMemory("GTA5", ProcessAccessRights.All);
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
		
		public void UpdateSpeedGraph(object o, ElapsedEventArgs args)
		{
			SpeedSeries[0].Values.Add(Speed);
		}

		private void StartStop_Click(object sender, RoutedEventArgs e)
		{
			_timer.Enabled = !_timer.Enabled;
		}
	}
}
