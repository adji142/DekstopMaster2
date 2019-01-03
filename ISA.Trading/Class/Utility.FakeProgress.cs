using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

/*
 * Programming by GearIntellix
 */
namespace ISA.Utility
{
    class FakeProgress
    {
        Timer _time;
        double _inc;
        double _val;
        int _long;
        int _flag;
        ProgressBar _progb;
        BackgroundWorker _bgw;
        bool _useBgw = false;
        public FakeProgress()
        {
            _long = 2500;
            _bgw = new BackgroundWorker();
            _bgw.DoWork += (a, b) =>
            {
                if (!_useBgw) return;

                int _ci;
                while (_time.Enabled && _flag != 0)
                {
                    _ci = 0;
                    _inc += _time.Interval;
                    _val = 1 - Math.Exp(-1 * _inc / _long);
                    if (OnProgressChanged != null) OnProgressChanged((float)_val);
                    while (_time.Enabled && _ci <= _time.Interval && _flag != 0)
                    {
                        System.Threading.Thread.Sleep(1);
                        _ci += 1;
                    }
                }
            };

            _time = new Timer();
            _time.Interval = 50;
            _time.Tick += (a, b) =>
            {
                if (_useBgw) return;

                _inc += _time.Interval;
                _val = 1 - Math.Exp(-1 * _inc / _long);
                if (OnProgressChanged != null) OnProgressChanged((float)_val);
            };
        }
        public FakeProgress(ProgressBar elm)
        {
            if (elm != null) _progb = elm;
            
            _long = 2500;
            _time = new Timer();
            _time.Interval = 50;

            _bgw = new BackgroundWorker();
            _bgw.DoWork += (a, b) =>
            {
                if (!_useBgw) return;

                int _ci;
                while (_time.Enabled && _flag != 0)
                {
                    _ci = 0;
                    _inc += _time.Interval;
                    _val = 1 - Math.Exp(-1 * _inc / _long);

                    if (_progb != null)
                    {
                        if (_progb.InvokeRequired) _progb.Invoke(new Action(() => _progb.Value = (int)GetValue(_progb.Maximum)));
                        else _progb.Value = (int)GetValue(_progb.Maximum);
                    }

                    if (OnProgressChanged != null) OnProgressChanged((float)_val);
                    while (_time.Enabled && _ci <= _time.Interval && _flag != 0)
                    {
                        System.Threading.Thread.Sleep(1);
                        _ci += 1;
                    }
                }
            };
            _time.Tick += (a, b) =>
            {
                if (_useBgw) return;

                _inc += _time.Interval;
                _val = 1 - Math.Exp(-1 * _inc / _long);

                if (_progb != null)
                {
                    if (_progb.InvokeRequired) _progb.Invoke(new Action(() => _progb.Value = (int)GetValue(_progb.Maximum)));
                    else _progb.Value = (int)GetValue(_progb.Maximum);
                }

                if (OnProgressChanged != null) OnProgressChanged((float)_val);
            };
        }

        public bool UseBackgroundWorker
        {
            get { return _useBgw; }
            set { _useBgw = value; }
        }

        public bool IsEnabled
        {
            get { return _flag != 0; }
        }
        public bool IsPaused
        {
            get { return _flag == 2; }
        }

        public double Value
        {
            get { return _val; }
        }

        public double GetValue(double max)
        {
            return _val * max;
        }

        public Action<float> OnProgressChanged;

        public void Start()
        {
            this.Start(2500);
        }
        public void Start(int tlong)
        {
            if (_progb.InvokeRequired) _progb.Invoke(new Action(() => _progb.Value = 0));
            else _progb.Value = 0;
            _val = _inc = 0;
            _long = tlong;
            _time.Start();
            _flag = 1;

            if (!_bgw.IsBusy && _useBgw) _bgw.RunWorkerAsync();
        }

        public void Stop()
        {
            _inc = _flag = 0;
            _time.Stop();
        }

        public void Done() {
            this.Stop();
            _flag = 0;
            _val = 1;
            if (_progb != null)
            {
                if (_progb.InvokeRequired) _progb.Invoke(new Action(() => _progb.Value = _progb.Maximum));
                else _progb.Value = _progb.Maximum;
            }
            if (OnProgressChanged != null) OnProgressChanged(1);
        }

        public void Pause() {
            _flag = 2;
            _time.Stop();
        }

        public void Resume() {
            if (_flag == 2) return;
            _flag = 1;
            _time.Start();
        }
    }
}
