
namespace WinFormsApp3
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
            this.comboBoxday = new System.Windows.Forms.ComboBox();
            this.comboBoxyear = new System.Windows.Forms.ComboBox();
            this.comboBoxmonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxday
            // 
            this.comboBoxday.FormattingEnabled = true;
            this.comboBoxday.Location = new System.Drawing.Point(45, 120);
            this.comboBoxday.Name = "comboBoxday";
            this.comboBoxday.Size = new System.Drawing.Size(151, 28);
            this.comboBoxday.TabIndex = 0;
            this.comboBoxday.SelectedIndexChanged += new System.EventHandler(this.comboBoxday_SelectedIndexChanged);
            // 
            // comboBoxyear
            // 
            this.comboBoxyear.FormattingEnabled = true;
            this.comboBoxyear.Location = new System.Drawing.Point(415, 120);
            this.comboBoxyear.Name = "comboBoxyear";
            this.comboBoxyear.Size = new System.Drawing.Size(151, 28);
            this.comboBoxyear.TabIndex = 1;
            this.comboBoxyear.SelectedIndexChanged += new System.EventHandler(this.comboBoxyear_SelectedIndexChanged);
            // 
            // comboBoxmonth
            // 
            this.comboBoxmonth.FormattingEnabled = true;
            this.comboBoxmonth.Location = new System.Drawing.Point(238, 120);
            this.comboBoxmonth.Name = "comboBoxmonth";
            this.comboBoxmonth.Size = new System.Drawing.Size(151, 28);
            this.comboBoxmonth.TabIndex = 2;
            this.comboBoxmonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxmonth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(45, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(596, 74);
            this.label1.TabIndex = 3;
            this.label1.Text = "la";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 52);
            this.button1.TabIndex = 4;
            this.button1.Text = "Show Message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 566);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxmonth);
            this.Controls.Add(this.comboBoxyear);
            this.Controls.Add(this.comboBoxday);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxday;
        private System.Windows.Forms.ComboBox comboBoxyear;
        private System.Windows.Forms.ComboBox comboBoxmonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

