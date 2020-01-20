using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using SlimDX.DirectInput;

namespace Joystick
{
    public partial class Form1 : Form
    {
        private SlimDX.DirectInput.Joystick _stick;
        private JoystickState _jState;

        private readonly Random _random = new Random();
        private static System.Timers.Timer _secTimer;

        private Rectangle _targetRectangle, _playerRectangle;
        private int _timeToEnd;
        private int _score;

        public Form1()
        {
            InitializeComponent();

            InitializeJoystick();
            new Task(PollStickTask).Start();

            GameInit();
            new Task(GameLoopTask).Start();
        }
        
        private void InitializeJoystick()
        {
            DirectInput input = new DirectInput();
            //List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>(); // Creates the list of joysticks connected to the computer via USB.

            foreach (DeviceInstance device in input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                // Creates a joystick for each game device
                try
                {
                    _stick = new SlimDX.DirectInput.Joystick(input, device.InstanceGuid);
                    _stick.Acquire();

                    foreach (DeviceObjectInstance deviceObject in _stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                            _stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                    }

                    // Adds how ever many joysticks are connected to the computer into the sticks list.
                    //sticks.Add(stick);
                }
                catch (DirectInputException)
                {
                    throw;
                }
            }
            //Console.WriteLine(sticks.Count);
            //return sticks.ToArray();
        }

        private void PollStickTask()
        {
            while (true)
            {
                _stick.Poll();
                _jState = _stick.GetCurrentState();
                Console.WriteLine($"Pressed buttons: b1:{_jState.GetButtons()[0]}, b2:{_jState.GetButtons()[1]}, xAxis = {_jState.X}, yAxis = {_jState.Y}");
                Thread.Sleep(1);
            }
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            _secTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            _secTimer.Elapsed += OnTimedEvent;
            _secTimer.AutoReset = true;
            _secTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            --_timeToEnd;
        }

        private void GameInit()
        {
            _targetRectangle.X = _random.Next(panel1.Width);
            _targetRectangle.Y = _random.Next(panel1.Height);
            _targetRectangle.Width = 50;
            _targetRectangle.Height = 50;

            _playerRectangle.X = _random.Next(panel1.Width);
            _playerRectangle.Y = _random.Next(panel1.Height);
            _playerRectangle.Width = 25;
            _playerRectangle.Height = 25;

            _timeToEnd = 30;
            timeLabel.Text = _timeToEnd.ToString();
            SetTimer();

            _score = 0;
            scoreLabel.Text = _score.ToString();
        }

        private void GameLoopTask()
        {
            Thread.Sleep(1000);
            while (true)
            {
                UpdateRects();
                timeLabel.Invoke(new Action(() => timeLabel.Text = _timeToEnd.ToString()));
                timeLabel.Invoke(new Action(() => scoreLabel.Text = _score.ToString()));

                if (_playerRectangle.Location == _targetRectangle.Location && _jState.GetButtons()[0])
                {
                    _score += 1;
                    ResetRectangles();
                }
                if (_timeToEnd < 1)
                {
                    break;
                }

                panel1.Invalidate();
                Thread.Sleep(33);
            }

        }

        private void ResetRectangles()
        {
            _targetRectangle.X = _random.Next(panel1.Width);
            _targetRectangle.Y = _random.Next(panel1.Height);

            _playerRectangle.X = _random.Next(panel1.Width);
            _playerRectangle.Y = _random.Next(panel1.Height);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush solidBrush = new SolidBrush(Color.Black);

            pen.Color = Color.Red;
            solidBrush.Color = Color.Green;
            e.Graphics.DrawRectangle(pen, _targetRectangle);
            e.Graphics.FillRectangle(solidBrush, _targetRectangle);

            pen.Color = Color.Red;
            solidBrush.Color = Color.Blue;
            e.Graphics.DrawRectangle(pen, _playerRectangle);
            e.Graphics.FillRectangle(solidBrush, _playerRectangle);
        }

        private void UpdateRects()
        {
            _playerRectangle.X += Convert.ToInt32(_jState.X / 100.0 * 5);
            _playerRectangle.Y += Convert.ToInt32(_jState.Y / 100.0 * 5);
        }
    }
}
