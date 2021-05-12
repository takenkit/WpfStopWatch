using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace WpfStopWatch
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Timer = new Timer();
            LapTimes = new List<string>();
        }

        public Timer Timer { get; set; }

        public ICommand StartCommand { get; set; }

        public ICommand StopCommand { get; set; }

        public ICommand ClearCommand { get; set; }

        public List<string> LapTimes { get; set; }

    }
}
