
namespace GameOfLifeApp
{
    partial class GameOfLifeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.inpFrequency = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.selectStartUniverse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numPixelSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPixelSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 59);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(927, 507);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(512, 24);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(64, 23);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // inpFrequency
            // 
            this.inpFrequency.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.inpFrequency.Location = new System.Drawing.Point(288, 22);
            this.inpFrequency.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.inpFrequency.Name = "inpFrequency";
            this.inpFrequency.Size = new System.Drawing.Size(73, 23);
            this.inpFrequency.TabIndex = 3;
            this.inpFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inpFrequency.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.inpFrequency.ValueChanged += new System.EventHandler(this.InpFrequency_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Speed (ms):";
            // 
            // selectStartUniverse
            // 
            this.selectStartUniverse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectStartUniverse.FormattingEnabled = true;
            this.selectStartUniverse.Location = new System.Drawing.Point(64, 22);
            this.selectStartUniverse.Name = "selectStartUniverse";
            this.selectStartUniverse.Size = new System.Drawing.Size(143, 23);
            this.selectStartUniverse.TabIndex = 5;
            this.selectStartUniverse.SelectedValueChanged += new System.EventHandler(this.SelectStartUniverse_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Layout:";
            // 
            // numPixelSize
            // 
            this.numPixelSize.Location = new System.Drawing.Point(423, 23);
            this.numPixelSize.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numPixelSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPixelSize.Name = "numPixelSize";
            this.numPixelSize.Size = new System.Drawing.Size(44, 23);
            this.numPixelSize.TabIndex = 7;
            this.numPixelSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numPixelSize.ValueChanged += new System.EventHandler(this.NumPixelSize_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Size:";
            // 
            // GameOfLifeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 578);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPixelSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectStartUniverse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inpFrequency);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.pictureBox);
            this.MinimumSize = new System.Drawing.Size(584, 301);
            this.Name = "GameOfLifeForm";
            this.Text = "Game of Life";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPixelSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.NumericUpDown inpFrequency;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox selectStartUniverse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPixelSize;
        private System.Windows.Forms.Label label3;
    }
}

