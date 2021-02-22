
namespace GameOfLifeApp
{
    partial class RandomSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numDensity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.numSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).BeginInit();
            this.SuspendLayout();
            // 
            // numDensity
            // 
            this.numDensity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDensity.Location = new System.Drawing.Point(70, 12);
            this.numDensity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDensity.Name = "numDensity";
            this.numDensity.Size = new System.Drawing.Size(46, 23);
            this.numDensity.TabIndex = 1;
            this.numDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDensity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDensity.ValueChanged += new System.EventHandler(this.NumDensity_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Density:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(70, 74);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(46, 23);
            this.btnOk.TabIndex = 99;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // numSize
            // 
            this.numSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSize.Location = new System.Drawing.Point(70, 42);
            this.numSize.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSize.Name = "numSize";
            this.numSize.Size = new System.Drawing.Size(46, 23);
            this.numSize.TabIndex = 2;
            this.numSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSize.ValueChanged += new System.EventHandler(this.NumSize_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Size (px):";
            // 
            // RandomSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(130, 108);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numSize);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numDensity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandomSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.RandomSettingsForm_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RandomSettingsForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.numDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numDensity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.Label label2;
    }
}