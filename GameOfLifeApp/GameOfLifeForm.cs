using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GameOfLifeLib;

namespace GameOfLifeApp
{
    public partial class GameOfLifeForm : Form
    {
        private Timer _timer;
        private Universe _universe;
        private int _offsetX;
        private int _offsetY;

        public GameOfLifeForm()
        {
            InitializeComponent();
            InitUniverseSelection();
            LoadUniverse();
            CreateTimer();
        }

        private void InitUniverseSelection()
        {
            var values = UniverseHelper.GetListOfUniverses();
            selectStartUniverse.DataSource = values;
            selectStartUniverse.SelectedItem = values[0];
        }

        private void CreateTimer()
        {
            _timer = new Timer {Interval = (int) inpFrequency.Value};
            _timer.Tick += TickHandler;
        }

        private void LoadUniverse()
        {
            var selectedUniverse = selectStartUniverse.SelectedItem.ToString();
            _universe = UniverseHelper.GetFromFile(selectedUniverse);
            _offsetX = 100;
            _offsetY = 100;
        }

        private void TickHandler(object sender, EventArgs e)
        {
            ExecActionAndRedraw(CalculateNextGeneration);
        }

        private void CalculateNextGeneration()
        {
            _universe = GameOfLife.CalculateStep(_universe);
            if(_universe.IsEmpty)
                ToggleTimer();
        }

        private void DrawUniverse(Graphics graphics)
        {
            var rectangles = _universe.Cells.Select(CellToRectangle).ToArray();
            graphics.Clear(Color.White);
            if(rectangles.Any())
                graphics.FillRectangles(new SolidBrush(Color.Black), rectangles);
        }

        private int _pixelWidth = 6;

        private Rectangle CellToRectangle((long x, long y) cell)
        {
            const int space = 1;
            return new Rectangle(
                (int)cell.x * (_pixelWidth + space) + _offsetX,
                (int)cell.y * (_pixelWidth + space) + _offsetY,
                _pixelWidth,
                _pixelWidth);
        }

        private void ExecActionAndRedraw(Action action)
        {
            action();
            pictureBox.Invalidate();
        }

        private void ToggleTimer()
        {
            selectStartUniverse.Enabled = _timer.Enabled;
            if (_timer.Enabled)
            {
                _timer.Stop();
                btnStartStop.Text = @"Start";
            }
            else
            {
                if(_universe.IsEmpty)
                    ExecActionAndRedraw(LoadUniverse);
                _timer.Start();
                btnStartStop.Text = @"Stop";
            }
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            ToggleTimer();
        }
        
        private void InpFrequency_ValueChanged(object sender, EventArgs e)
        {
            if (inpFrequency.Value >= 10)
            {
                _timer.Interval = (int)inpFrequency.Value;
            }
            else
            {
                inpFrequency.Value = _timer.Interval;
            }
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            DrawUniverse(e.Graphics);
        }

        private void SelectStartUniverse_SelectedValueChanged(object sender, EventArgs e)
        {
            ExecActionAndRedraw(LoadUniverse);
        }

        private bool _mouseIsMoving;
        private int _mouseStartX;
        private int _mouseStartY;
        private int _offsetStartX;
        private int _offsetStartY;

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            _mouseIsMoving = true;
            _mouseStartX = e.X;
            _mouseStartY = e.Y;
            _offsetStartX = _offsetX;
            _offsetStartY = _offsetY;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            _mouseIsMoving = false;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseIsMoving) return;

            ExecActionAndRedraw(() =>
            {
                _offsetX = _offsetStartX + (e.X - _mouseStartX);
                _offsetY = _offsetStartY + (e.Y - _mouseStartY);
            });
        }

        private void NumPixelSize_ValueChanged(object sender, EventArgs e)
        {
            ExecActionAndRedraw(() => _pixelWidth = (int) numPixelSize.Value);
        }
    }
}
