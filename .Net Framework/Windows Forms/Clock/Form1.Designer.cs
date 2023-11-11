
namespace Clock
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.labelclock = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartorStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelclock
            // 
            this.labelclock.BackColor = System.Drawing.Color.Maroon;
            this.labelclock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelclock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelclock.Location = new System.Drawing.Point(1, 0);
            this.labelclock.Name = "labelclock";
            this.labelclock.Size = new System.Drawing.Size(333, 37);
            this.labelclock.TabIndex = 0;
            this.labelclock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelclock.Click += new System.EventHandler(this.labelclock_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer_tick);
            // 
            // StartorStop
            // 
            this.StartorStop.BackColor = System.Drawing.Color.Red;
            this.StartorStop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartorStop.Location = new System.Drawing.Point(114, 40);
            this.StartorStop.Name = "StartorStop";
            this.StartorStop.Size = new System.Drawing.Size(100, 43);
            this.StartorStop.TabIndex = 1;
            this.StartorStop.Text = "Stop";
            this.StartorStop.UseVisualStyleBackColor = false;
            this.StartorStop.Click += new System.EventHandler(this.StartorStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 92);
            this.Controls.Add(this.StartorStop);
            this.Controls.Add(this.labelclock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelclock;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartorStop;
    }
}

