using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using BenchCommonLib;

namespace BenchNativeApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly Benchmarker bench;
        private const string FilterDefault = "Filter ...";
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancelToken;
        private bool isRunning;
        private DispatcherTimer dispatcherTimer;
        private int tickCount = 0;

        public MainPage()
        {
            this.InitializeComponent();
            bench = new Benchmarker();
            dispatcherTimer = new DispatcherTimer();
            bench.Writer = new MyWriter(LogTextBox);
            FilterTextBox.Text = FilterDefault;
            RunStatusTextBlock.Text = string.Format("Press Run to start the benchmark ({0})... ", Benchmarker.Platform);

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning)
            {
                cancellationTokenSource.Cancel();
                LogTextBox.Text += "\nAborted\n";
                return;
            }

            tickCount = 0;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();

            RunButton.Content = "Stop";
            LogTextBox.Text = string.Empty;

            cancellationTokenSource = new CancellationTokenSource();
            cancelToken = cancellationTokenSource.Token;
            isRunning = true;

            bench.Filter = null;
            if (FilterTextBox.Text != FilterDefault && !string.IsNullOrWhiteSpace(FilterTextBox.Text))
            {
                bench.Filter = FilterTextBox.Text;
            }

            await ThreadPool.RunAsync(operation => bench.RunAllBenchmarkstoWriter(new Benchmarks(bench), cancelToken));

            dispatcherTimer.Tick -= dispatcherTimer_Tick;
            dispatcherTimer.Stop();

            LogTextBox.Text += "\nEnd\n";
            RunButton.Content = "Start";
            isRunning = false; 
            RunStatusTextBlock.Text = string.Format("Press Run to start the benchmark ({0})... ", Benchmarker.Platform);
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            RunStatusTextBlock.Text = string.Format("Running ({1}){0} ", string.Join(string.Empty, Enumerable.Repeat('.', (tickCount & 3))), Benchmarker.Platform);
            tickCount++;
        }

        private class MyWriter : TextWriter
        {
            private readonly StringBuilder buffer = new StringBuilder();
            private readonly CoreDispatcher dispatcher;
            private readonly TextBox LogTextbox;

            public MyWriter(TextBox logTextbox)
            {
                LogTextbox = logTextbox;
                dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
            }

            public override void Write(char value)
            {
                buffer.Append(value);
                if (value == '\n')
                {
                    var text = buffer.ToString();
                    buffer.Clear();
                    var textBox = LogTextbox;
                    dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        textBox.Text += text;
                    });
                }
            }

            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }

        private void FilterTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (FilterTextBox.Text == FilterDefault)
            {
                FilterTextBox.Text = string.Empty;
            }
        }

        private void FilterTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FilterTextBox.Text))
            {
                FilterTextBox.Text = FilterDefault;
            }
        }
    }
}
