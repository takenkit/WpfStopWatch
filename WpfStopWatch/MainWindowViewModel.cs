using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
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
        private ICommand _clearOrCheckCommand;

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
                _clearOrCheck = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<string> LapTimes
        {
            get
            {
                return _lapTimes;
            }
            set
            {
                _lapTimes = value;
                NotifyPropertyChanged();
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
                if (_clearOrCheckCommand == null)
                {
                    _clearOrCheckCommand = new RelayCommand(param => ClearDisplayOrAddLapTime(), null);
                }
                return _clearOrCheckCommand;
            }
        }

        public MainWindowViewModel()
        {
            _stopwatch = new Stopwatch();
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            _elapsed = new TimeSpan();
            ClearOrCheck = "CLEAR";
            _lapTimes = new ObservableCollection<string>();
            _lapTimes.CollectionChanged += new NotifyCollectionChangedEventHandler(LapTimes_CollectionChanged);
        }


        private void Start()
        {
            _stopwatch.Start();
            _dispatcherTimer.Start();
            ClearOrCheck = "CHECK";
        }

        private void Stop()
        {
            if (_stopwatch.IsRunning)
            {
                _stopwatch.Stop();
                ClearOrCheck = "CLEAR";
            }
        }

        private void ClearDisplayOrAddLapTime()
        {
            if (_stopwatch.IsRunning)
            {
                var ts = Elapsed;
                var str = string.Format("  LAP{0:00}:              {1:00}:{2:00}:{3:00}.{4:000}",
                LapTimes.Count + 1, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

                LapTimes.Add(str);
                if (LapTimes.Count > 1)
                {
                    LapTimes.Insert(0, LapTimes.ElementAt(LapTimes.Count - 1));
                    LapTimes.RemoveAt(LapTimes.Count - 1);
                }
            }
            else
            {
                _stopwatch.Reset();
                Elapsed = TimeSpan.Zero;
                LapTimes.Clear();
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (_stopwatch.IsRunning)
            {
                Elapsed = _stopwatch.Elapsed;
            }
        }

        private void LapTimes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("LapTimes");
        }

    }
}
