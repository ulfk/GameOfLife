using System;
using System.Windows.Forms;

namespace GameOfLifeApp
{
    public partial class RandomSettingsForm : Form
    {
        private int _density = 40;
        private int _fieldSize = 25;

        public int Density
        {
            get => _density;
            set
            {
                ThrowIfNotInRange(nameof(Density), value, numDensity);
                _density = value;
            }
        }

        public int FieldSize
        {
            get => _fieldSize;
            set
            {
                ThrowIfNotInRange(nameof(FieldSize), value, numSize);
                _fieldSize = value;
            }
        }

        private void ThrowIfNotInRange(string name, int value, NumericUpDown field)
        {
            if (value < (int)field.Minimum || value > (int)field.Value)
                throw new ArgumentOutOfRangeException($"{name}-value {value} not in valid range of {field.Minimum}..{field.Maximum}");
        }

        public RandomSettingsForm()
        {
            InitializeComponent();
        }

        private void NumDensity_ValueChanged(object sender, EventArgs e)
        {
            _density = (int) numDensity.Value;
        }

        private void NumSize_ValueChanged(object sender, EventArgs e)
        {
            _fieldSize = (int) numSize.Value;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RandomSettingsForm_Shown(object sender, EventArgs e)
        {
            numDensity.Value = _density;
            numSize.Value = _fieldSize;
        }
    }
}
