
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
            this.label4 = new System.Windows.Forms.Label();
            this.lblLivingCells = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGenerations = new System.Windows.Forms.Label();
            this.lblReload = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnHistoryBack = new System.Windows.Forms.Button();
            this.btnHistoryForward = new System.Windows.Forms.Button();
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
            this.pictureBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 59);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(975, 576);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(454, 28);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(61, 23);
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
            this.inpFrequency.Location = new System.Drawing.Point(285, 30);
            this.inpFrequency.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.inpFrequency.Minimum = new decimal(new int[] {
            10,
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
            this.label1.Location = new System.Drawing.Point(285, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Speed (ms)";
            // 
            // selectStartUniverse
            // 
            this.selectStartUniverse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectStartUniverse.FormattingEnabled = true;
            this.selectStartUniverse.Location = new System.Drawing.Point(12, 30);
            this.selectStartUniverse.Name = "selectStartUniverse";
            this.selectStartUniverse.Size = new System.Drawing.Size(143, 23);
            this.selectStartUniverse.TabIndex = 5;
            this.selectStartUniverse.SelectedValueChanged += new System.EventHandler(this.SelectStartUniverse_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Start Configuration";
            // 
            // numPixelSize
            // 
            this.numPixelSize.Location = new System.Drawing.Point(379, 30);
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
            this.numPixelSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.label3.Location = new System.Drawing.Point(379, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Size (px)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Population: ";
            // 
            // lblLivingCells
            // 
            this.lblLivingCells.Location = new System.Drawing.Point(629, 36);
            this.lblLivingCells.Name = "lblLivingCells";
            this.lblLivingCells.Size = new System.Drawing.Size(45, 15);
            this.lblLivingCells.TabIndex = 10;
            this.lblLivingCells.Text = "0";
            this.lblLivingCells.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(550, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Generations:";
            // 
            // lblGenerations
            // 
            this.lblGenerations.Location = new System.Drawing.Point(629, 21);
            this.lblGenerations.Name = "lblGenerations";
            this.lblGenerations.Size = new System.Drawing.Size(45, 15);
            this.lblGenerations.TabIndex = 12;
            this.lblGenerations.Text = "0";
            this.lblGenerations.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblReload
            // 
            this.lblReload.AutoSize = true;
            this.lblReload.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReload.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblReload.Location = new System.Drawing.Point(161, 24);
            this.lblReload.Name = "lblReload";
            this.lblReload.Size = new System.Drawing.Size(34, 34);
            this.lblReload.TabIndex = 13;
            this.lblReload.Text = "⭯";
            this.lblReload.Click += new System.EventHandler(this.LblReload_Click);
            this.lblReload.MouseEnter += new System.EventHandler(this.LblReload_MouseEnter);
            this.lblReload.MouseLeave += new System.EventHandler(this.LblReload_MouseLeave);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(727, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "History";
            // 
            // btnHistoryBack
            // 
            this.btnHistoryBack.Location = new System.Drawing.Point(210, 30);
            this.btnHistoryBack.Name = "btnHistoryBack";
            this.btnHistoryBack.Size = new System.Drawing.Size(22, 23);
            this.btnHistoryBack.TabIndex = 16;
            this.btnHistoryBack.Text = "<";
            this.btnHistoryBack.UseVisualStyleBackColor = true;
            this.btnHistoryBack.Click += new System.EventHandler(this.btnHistoryBack_Click);
            // 
            // btnHistoryForward
            // 
            this.btnHistoryForward.Location = new System.Drawing.Point(238, 30);
            this.btnHistoryForward.Name = "btnHistoryForward";
            this.btnHistoryForward.Size = new System.Drawing.Size(23, 23);
            this.btnHistoryForward.TabIndex = 17;
            this.btnHistoryForward.Text = ">";
            this.btnHistoryForward.UseVisualStyleBackColor = true;
            this.btnHistoryForward.Click += new System.EventHandler(this.btnHistoryForward_Click);
            // 
            // GameOfLifeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 647);
            this.Controls.Add(this.btnHistoryForward);
            this.Controls.Add(this.btnHistoryBack);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblReload);
            this.Controls.Add(this.lblGenerations);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLivingCells);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPixelSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectStartUniverse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inpFrequency);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.pictureBox);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(777, 406);
            this.Name = "GameOfLifeForm";
            this.Text = "Game of Life";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameOfLifeForm_KeyUpDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameOfLifeForm_KeyUpDown);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLivingCells;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGenerations;
        private System.Windows.Forms.Label lblReload;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnHistoryBack;
        private System.Windows.Forms.Button btnHistoryForward;
    }
}

