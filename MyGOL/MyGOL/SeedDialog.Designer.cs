
namespace MyGOL
{
    partial class SeedDialog
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
            this.SeedOk = new System.Windows.Forms.Button();
            this.SeedCancel = new System.Windows.Forms.Button();
            this.numericUpDownSeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.RandomButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeed)).BeginInit();
            this.SuspendLayout();
            // 
            // SeedOk
            // 
            this.SeedOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SeedOk.Location = new System.Drawing.Point(111, 100);
            this.SeedOk.Name = "SeedOk";
            this.SeedOk.Size = new System.Drawing.Size(75, 23);
            this.SeedOk.TabIndex = 0;
            this.SeedOk.Text = "Ok";
            this.SeedOk.UseVisualStyleBackColor = true;
            this.SeedOk.Click += new System.EventHandler(this.SeedOk_Click);
            // 
            // SeedCancel
            // 
            this.SeedCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SeedCancel.Location = new System.Drawing.Point(213, 100);
            this.SeedCancel.Name = "SeedCancel";
            this.SeedCancel.Size = new System.Drawing.Size(75, 23);
            this.SeedCancel.TabIndex = 1;
            this.SeedCancel.Text = "Cancel";
            this.SeedCancel.UseVisualStyleBackColor = true;
            // 
            // numericUpDownSeed
            // 
            this.numericUpDownSeed.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSeed.Location = new System.Drawing.Point(79, 52);
            this.numericUpDownSeed.Maximum = new decimal(new int[] {
            1200000,
            0,
            0,
            0});
            this.numericUpDownSeed.Name = "numericUpDownSeed";
            this.numericUpDownSeed.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownSeed.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seed";
            // 
            // RandomButton
            // 
            this.RandomButton.Location = new System.Drawing.Point(236, 52);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.Size = new System.Drawing.Size(123, 23);
            this.RandomButton.TabIndex = 4;
            this.RandomButton.Text = "Randomize";
            this.RandomButton.UseVisualStyleBackColor = true;
            this.RandomButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SeedDialog
            // 
            this.AcceptButton = this.SeedOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.SeedCancel;
            this.ClientSize = new System.Drawing.Size(382, 153);
            this.Controls.Add(this.RandomButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownSeed);
            this.Controls.Add(this.SeedCancel);
            this.Controls.Add(this.SeedOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeedDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seed Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SeedOk;
        private System.Windows.Forms.Button SeedCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownSeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RandomButton;
    }
}