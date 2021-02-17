using System;
using System.Collections.Generic;
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
        private int _generations;
        private int _pixelsPerCell = 6;
        private const string RandomUniverse = "** Random **";
        private const string EmptyUniverse = "** Empty **";
        private const string OpenFile = "** Open File... **";
        private const int CellSpacing = 1;
        
        public GameOfLifeForm()
        {
            InitializeComponent();
            InitUniverseSelection();
            CreateTimer();
        }

        private void InitUniverseSelection()
        {
            var values = new List<string> { EmptyUniverse, RandomUniverse, OpenFile };
            values.AddRange(UniverseHelper.GetListOfUniverses());
            selectStartUniverse.DataSource = values;
            selectStartUniverse.SelectedItem = values[1];
        }

        private void CreateTimer()
        {
            _timer = new Timer {Interval = (int) inpFrequency.Value};
            _timer.Tick += TickHandler;
        }

        private void LoadUniverse()
        {
            var selectedUniverse = selectStartUniverse.SelectedItem.ToString();
            _universe = selectedUniverse switch
            {
                EmptyUniverse => new Universe(),
                RandomUniverse => UniverseFactory.GetRandom(),
                OpenFile => LoadUniverseFromUserSelectedFile(),
                _ => UniverseHelper.GetFromFile(selectedUniverse)
            };
            CenterUniverse();
            _generations = 0;
            UpdateCounters();
        }

        private Universe LoadUniverseFromUserSelectedFile()
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"txt files (*.txt)|*.txt|RLE files (*.rle)|*.rle|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            return openFileDialog.ShowDialog() == DialogResult.OK 
                ? UniverseHelper.GetFromFile(openFileDialog.FileName, true) 
                : _universe;
        }

        private int RasterStepSize => _pixelsPerCell + CellSpacing;

        private int GetCenter(int overall, int min, int max)
            => (overall - (max - min + 1) * RasterStepSize) / 2 - min;

        private void CenterUniverse()
        {
            var (minX, maxX, minY, maxY) = _universe.GetDimensions();
            _offsetX = GetCenter(pictureBox.Size.Width, minX, maxX);
            _offsetY = GetCenter(pictureBox.Size.Height, minY, maxY);
        }

        private void TickHandler(object sender, EventArgs e)
        {
            ExecActionAndRedraw(CalculateNextGeneration);
        }

        private void CalculateNextGeneration()
        {
            _universe = GameOfLife.CalculateStep(_universe);
            _generations++;
            UpdateCounters();
            if (_universe.IsEmpty)
                ToggleTimer();
        }

        private void UpdateCounters()
        {
            lblLivingCells.Text = _universe.LivingCellsCount.ToString();
            lblGenerations.Text = _generations.ToString();
        }

        private void DrawUniverse(Graphics graphics)
        {
            var rectangles = _universe.Cells.Select(CellToRectangle).ToArray();
            graphics.Clear(Color.WhiteSmoke);
            if(rectangles.Any())
                graphics.FillRectangles(new SolidBrush(Color.Black), rectangles);
        }

        private Rectangle CellToRectangle((int x, int y) cell)
        {
            return new Rectangle(
                cell.x * RasterStepSize + _offsetX,
                cell.y * RasterStepSize + _offsetY,
                _pixelsPerCell,
                _pixelsPerCell);
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
            ExecActionAndRedraw(() =>
            {
                _pixelsPerCell = (int) numPixelSize.Value;
                CenterUniverse();
            });
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_timer.Enabled && e.Button == MouseButtons.Left && _shiftPressed)
            {
                ExecActionAndRedraw(() =>
                {
                    var cellX = GetUniverseCoordinate(e.X, _offsetX);
                    var cellY = GetUniverseCoordinate(e.Y, _offsetY);
                    _universe.ToggleCell(cellX, cellY);
                });
            }
        }

        private int GetUniverseCoordinate(int mouseValue, int offsetValue)
        {
            var diff = mouseValue - offsetValue;
            var sign = Math.Sign(diff);
            var add = sign < 0 ? 1 : 0;
            var absDiff = Math.Abs(diff) / RasterStepSize;
            return (absDiff + add) * sign;
        }

        private bool _shiftPressed;

        private void GameOfLifeForm_KeyUpDown(object sender, KeyEventArgs e)
        {
            _shiftPressed = e.Shift;
        }
    }
}
