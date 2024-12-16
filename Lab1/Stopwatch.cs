using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Stopwatch
    {
        public delegate void StopwatchEventHandler(string message);

        public event StopwatchEventHandler OnStarted;
        public event StopwatchEventHandler OnStopped;
        public event StopwatchEventHandler OnReset;

        private int _timeElapsed;
        public bool IsRunning { get; private set; }

        public int TimeElapsed
        {
            get { return _timeElapsed; }
        }

        public void Start()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                OnStarted?.Invoke("Stopwatch Started!");
            }
        }

        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                OnStopped?.Invoke("Stopwatch Stopped!");
            }
        }

        public void Reset()
        {
            IsRunning = false;
            _timeElapsed = 0;
            OnReset?.Invoke("Stopwatch Reset!");
        }

        public void Tick()
        {
            if (IsRunning)
            {
                _timeElapsed++;
            }
        }
    }
}
