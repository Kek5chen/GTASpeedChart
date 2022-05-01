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
		
		public float Speed => _gtaProcess.Read<float>(_gtaProcess.BaseAddress + 0x254A754);
		
		public void UpdateSpeedGraph(object o, ElapsedEventArgs args)
		{
			SpeedSeries[0].Values.Add(Speed);
		}

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
				Timer timer = new Timer();
				timer.Interval = 100;
				timer.AutoReset = true;
				timer.Elapsed += UpdateSpeedGraph;
				timer.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Close();
			}
		}
	}
}
