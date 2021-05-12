using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace WpfStopWatch
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Stopwatch _stopwatch;
        private ObservableCollection<string> _lapTimes;
        private ICommand _startCommand;
        private ICommand _stopCommand;
        private ICommand _clearCommand;

        public Stopwatch Stopwatch { get; set; }

        public ICommand StartCommand { get; set; }

        public ICommand StopCommand { get; set; }

        public ICommand ClearCommand { get; set; }
        public ObservableCollection<string> LapTimes { get; set; }

        private void LapTimes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged();
        }
        public MainWindowViewModel()
        {
            Stopwatch = new Stopwatch();
            LapTimes = new ObservableCollection<string>();
            LapTimes.CollectionChanged += new NotifyCollectionChangedEventHandler(LapTimes_CollectionChanged);
        }

    }
}
