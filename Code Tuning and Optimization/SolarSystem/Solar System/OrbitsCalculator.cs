namespace SolarSystem
{
    using System;
    using System.ComponentModel;
    using System.Windows.Threading;

    internal class OrbitsCalculator : INotifyPropertyChanged
    {
        private const double EarthRotationPeriod = 1.0;
        private const double EarthYear = 365.25;
        private const double SunRotationPeriod = 25.0;
        private const double TwoPi = Math.PI * 2;
        private double _daysPerSecond = 2;
        private double _startDays;
        private DateTime _startTime;
        private DispatcherTimer _timer;

        public OrbitsCalculator()
        {
            EarthOrbitPositionX = EarthOrbitRadius;
            DaysPerSecond = 2;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double Days { get; set; }

        public double DaysPerSecond
        {
            get { return _daysPerSecond; }
            set { _daysPerSecond = value; Update("DaysPerSecond"); }
        }

        public double EarthOrbitPositionX { get; set; }
        public double EarthOrbitPositionY { get; set; }
        public double EarthOrbitPositionZ { get; set; }
        public double EarthOrbitRadius { get { return 40; } set { } }
        public double EarthRotationAngle { get; set; }

        public bool Paused { get; set; }
        public bool ReverseTime { get; set; }
        public double SunRotationAngle { get; set; }

        public void Pause(bool doPause)
        {
            if (doPause)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }

        public void StartTimer()
        {
            _startTime = DateTime.Now;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += new EventHandler(OnTimerTick);
            _timer.Start();
        }

        private void EarthPosition()
        {
            double angle = 2 * Math.PI * Days / EarthYear;
            EarthOrbitPositionX = EarthOrbitRadius * Math.Cos(angle);
            EarthOrbitPositionY = EarthOrbitRadius * Math.Sin(angle);
            Update("EarthOrbitPositionX");
            Update("EarthOrbitPositionY");
        }

        private void EarthRotation()
        {
            for (double step = 0; step <= 360; step += 0.00005)
            {
                EarthRotationAngle = (step * Days) / EarthRotationPeriod;
            }

            Update("EarthRotationAngle");
        }

        private void OnTimeChanged()
        {
            EarthPosition();
            EarthRotation();
            SunRotation();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            Days += (now - _startTime).TotalMilliseconds * DaysPerSecond / 1000.0 * (ReverseTime ? -1 : 1);
            _startTime = now;
            Update("Days");
            OnTimeChanged();
        }

        private void StopTimer()
        {
            _timer.Stop();
            _timer.Tick -= OnTimerTick;
            _timer = null;
        }

        private void SunRotation()
        {
            SunRotationAngle = 360 * Days / SunRotationPeriod;
            Update("SunRotationAngle");
        }

        private void Update(string propertyName)
        {
            if (PropertyChanged != null)
            {
                var args = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, args);
            }
        }
    }
}