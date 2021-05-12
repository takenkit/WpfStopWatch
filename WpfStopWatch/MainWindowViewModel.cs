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
        public MainWindowViewModel()
        {
            Stopwatch = new Stopwatch();   
            LapTimes = new ObservableCollection<string>();
        }

        public Stopwatch Stopwatch { get; set; }

        public ICommand StartCommand { get; set; }

        public ICommand StopCommand { get; set; }

        public ICommand ClearCommand { get; set; }

        private void LapTimes_CollectionChanged(object sender, NotifyCollectionChangedEventHandler e)
        {

        }

        public ObservableCollection<string> LapTimes { get; set; }

    }
}
