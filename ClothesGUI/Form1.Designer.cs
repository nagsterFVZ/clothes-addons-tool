﻿namespace ClothesGUI
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "Execute";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(12, 69);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOut.Size = new System.Drawing.Size(1275, 685);
            this.txtOut.TabIndex = 2;
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(821, 12);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(466, 51);
            this.prgBar.TabIndex = 3;
            this.prgBar.Click += new System.EventHandler(this.prgBar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(280, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 51);
            this.button3.TabIndex = 4;
            this.button3.Text = "Not Copied";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(548, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 51);
            this.button4.TabIndex = 5;
            this.button4.Text = "Fix Models";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(414, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 51);
            this.button5.TabIndex = 6;
            this.button5.Text = "GTA Models";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 766);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

