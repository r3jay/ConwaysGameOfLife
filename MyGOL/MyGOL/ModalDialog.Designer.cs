
namespace MyGOL
{
    partial class ModalDialog
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numericUpDownTime = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(192, 118);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(273, 118);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // numericUpDownTime
            // 
            this.numericUpDownTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTime.Location = new System.Drawing.Point(228, 21);
            this.numericUpDownTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTime.Name = "numericUpDownTime";
            this.numericUpDownTime.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownTime.TabIndex = 2;
            // 
            // numericUpDownCWidth
            // 
            this.numericUpDownCWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCWidth.Location = new System.Drawing.Point(228, 49);
            this.numericUpDownCWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownCWidth.Name = "numericUpDownCWidth";
            this.numericUpDownCWidth.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownCWidth.TabIndex = 3;
            // 
            // numericUpDownCHeight
            // 
            this.numericUpDownCHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCHeight.Location = new System.Drawing.Point(228, 75);
            this.numericUpDownCHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownCHeight.Name = "numericUpDownCHeight";
            this.numericUpDownCHeight.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownCHeight.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Time Interval in Milliseconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Width of Universe in Cells";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Height of Universe in Cells";
            // 
            // ModalDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(382, 153);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownCHeight);
            this.Controls.Add(this.numericUpDownCWidth);
            this.Controls.Add(this.numericUpDownTime);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownTime;
        private System.Windows.Forms.NumericUpDown numericUpDownCWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownCHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}