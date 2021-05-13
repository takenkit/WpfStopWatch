using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfStopWatch
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DispatcherTimer _dispatcherTimer;
        private Stopwatch _stopwatch;
        private TimeSpan _elapsed;
        private string _clearOrCheck;
        private ObservableCollection<string> _lapTimes;
        private ICommand _startCommand;
        private ICommand _stopCommand;
        private ICommand _clearCommand;


        public TimeSpan Elapsed
        {
            get
            {
                return _elapsed;
            }
            set
            {
                _elapsed = value;
                NotifyPropertyChanged();
            }
        }
        
        public string ClearOrCheck
        {
            get
            {
                return _clearOrCheck;
            }
            set
            {
                if (string.IsNullOrEmpty(_clearOrCheck))
                {
                    _clearOrCheck = _stopwatch.IsRunning ? "CHECK" : "CLEAR";
                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand StartCommand 
        {
            get
            {
                if (_startCommand == null)
                {
                    _startCommand = new RelayCommand(param => Start(), null);
                }
                return _startCommand;
            }
        }

        public ICommand StopCommand 
        {
            get
            {
                if (_stopCommand == null)
                {
                    _stopCommand = new RelayCommand(param => Stop(), null);
                }
                return _stopCommand;
            }
        }

        public ICommand ClearOrCheckCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new RelayCommand(param => Reset(), null);
                }
                return _clearCommand;
            }
        }
        public ObservableCollection<string> LapTimes { get; set; }

        public MainWindowViewModel()
        {
            _stopwatch = new Stopwatch();
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            _elapsed = new TimeSpan();
            _clearOrCheck = "CLEAR";
            _lapTimes = new ObservableCollection<string>();
            _lapTimes.CollectionChanged += new NotifyCollectionChangedEventHandler(LapTimes_CollectionChanged);
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (_stopwatch.IsRunning)
            {
                Elapsed = _stopwatch.Elapsed;
            }
        }

        private void Start()
        {
            _stopwatch.Start();
            _dispatcherTimer.Start();
        }

        private void Stop()
        {
            if (_stopwatch.IsRunning)
            {
                _stopwatch.Stop();
            }
        }

        private void Reset()
        {
            if (_stopwatch.IsRunning == false)
            {
                _stopwatch.Reset();
            }
        }

        private void Check()
        {
            if (_stopwatch.IsRunning)
            {

            }
        }

        private void LapTimes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged();
        }

    }
}
