﻿namespace Murli_Clipper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.step1 = new System.Windows.Forms.TabPage();
            this.step1Next = new System.Windows.Forms.Button();
            this.srcValidity = new System.Windows.Forms.Label();
            this.srcButton = new System.Windows.Forms.Button();
            this.srcPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.step2 = new System.Windows.Forms.TabPage();
            this.step2Next = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.step3 = new System.Windows.Forms.TabPage();
            this.step3Label = new System.Windows.Forms.Label();
            this.step3ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.step4 = new System.Windows.Forms.TabPage();
            this.step4Next = new System.Windows.Forms.Button();
            this.marginPicture = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.step5 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.step1.SuspendLayout();
            this.step2.SuspendLayout();
            this.step3.SuspendLayout();
            this.step4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marginPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.step1);
            this.tabControl1.Controls.Add(this.step2);
            this.tabControl1.Controls.Add(this.step3);
            this.tabControl1.Controls.Add(this.step4);
            this.tabControl1.Controls.Add(this.step5);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 731);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabChangeAttempted);
            // 
            // step1
            // 
            this.step1.Controls.Add(this.step1Next);
            this.step1.Controls.Add(this.srcValidity);
            this.step1.Controls.Add(this.srcButton);
            this.step1.Controls.Add(this.srcPath);
            this.step1.Controls.Add(this.label1);
            this.step1.Location = new System.Drawing.Point(4, 25);
            this.step1.Name = "step1";
            this.step1.Size = new System.Drawing.Size(1152, 702);
            this.step1.TabIndex = 0;
            this.step1.Text = "Select PDF";
            this.step1.UseVisualStyleBackColor = true;
            // 
            // step1Next
            // 
            this.step1Next.Enabled = false;
            this.step1Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 199.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step1Next.Location = new System.Drawing.Point(34, 268);
            this.step1Next.Name = "step1Next";
            this.step1Next.Size = new System.Drawing.Size(1006, 431);
            this.step1Next.TabIndex = 4;
            this.step1Next.Text = "Next";
            this.step1Next.UseVisualStyleBackColor = true;
            this.step1Next.Click += new System.EventHandler(this.step1Done);
            // 
            // srcValidity
            // 
            this.srcValidity.AutoSize = true;
            this.srcValidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcValidity.ForeColor = System.Drawing.Color.Red;
            this.srcValidity.Location = new System.Drawing.Point(241, 229);
            this.srcValidity.Name = "srcValidity";
            this.srcValidity.Size = new System.Drawing.Size(231, 36);
            this.srcValidity.TabIndex = 3;
            this.srcValidity.Text = "Not a Valid Path";
            // 
            // srcButton
            // 
            this.srcButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcButton.Location = new System.Drawing.Point(34, 184);
            this.srcButton.Name = "srcButton";
            this.srcButton.Size = new System.Drawing.Size(197, 42);
            this.srcButton.TabIndex = 2;
            this.srcButton.Text = "Choose Path";
            this.srcButton.UseVisualStyleBackColor = true;
            this.srcButton.Click += new System.EventHandler(this.srcDialogClicked);
            // 
            // srcPath
            // 
            this.srcPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcPath.Location = new System.Drawing.Point(237, 185);
            this.srcPath.Name = "srcPath";
            this.srcPath.Size = new System.Drawing.Size(803, 41);
            this.srcPath.TabIndex = 1;
            this.srcPath.TextChanged += new System.EventHandler(this.srcPathChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 96F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1037, 181);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select A PDF";
            // 
            // step2
            // 
            this.step2.Controls.Add(this.step2Next);
            this.step2.Controls.Add(this.label2);
            this.step2.Controls.Add(this.dateTimePicker1);
            this.step2.Location = new System.Drawing.Point(4, 25);
            this.step2.Name = "step2";
            this.step2.Size = new System.Drawing.Size(1152, 702);
            this.step2.TabIndex = 1;
            this.step2.Text = "Select Date";
            this.step2.UseVisualStyleBackColor = true;
            // 
            // step2Next
            // 
            this.step2Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step2Next.Location = new System.Drawing.Point(27, 170);
            this.step2Next.Name = "step2Next";
            this.step2Next.Size = new System.Drawing.Size(834, 529);
            this.step2Next.TabIndex = 2;
            this.step2Next.Text = "Next";
            this.step2Next.UseVisualStyleBackColor = true;
            this.step2Next.Click += new System.EventHandler(this.step2Done);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(857, 135);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose a Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "MMMM dd,  yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(27, 142);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(834, 22);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2020, 3, 7, 12, 14, 25, 0);
            // 
            // step3
            // 
            this.step3.Controls.Add(this.step3Label);
            this.step3.Controls.Add(this.step3ProgressBar);
            this.step3.Controls.Add(this.label3);
            this.step3.Location = new System.Drawing.Point(4, 25);
            this.step3.Name = "step3";
            this.step3.Size = new System.Drawing.Size(1152, 702);
            this.step3.TabIndex = 4;
            this.step3.Text = "Generate Images";
            this.step3.UseVisualStyleBackColor = true;
            // 
            // step3Label
            // 
            this.step3Label.AutoSize = true;
            this.step3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step3Label.ForeColor = System.Drawing.Color.Green;
            this.step3Label.Location = new System.Drawing.Point(3, 623);
            this.step3Label.Name = "step3Label";
            this.step3Label.Size = new System.Drawing.Size(820, 69);
            this.step3Label.TabIndex = 2;
            this.step3Label.Text = "0 out of 14 images generated.";
            // 
            // step3ProgressBar
            // 
            this.step3ProgressBar.Location = new System.Drawing.Point(3, 153);
            this.step3ProgressBar.Maximum = 14;
            this.step3ProgressBar.Name = "step3ProgressBar";
            this.step3ProgressBar.Size = new System.Drawing.Size(1079, 467);
            this.step3ProgressBar.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1078, 135);
            this.label3.TabIndex = 0;
            this.label3.Text = "Generating Images";
            // 
            // step4
            // 
            this.step4.Controls.Add(this.step4Next);
            this.step4.Controls.Add(this.marginPicture);
            this.step4.Controls.Add(this.label4);
            this.step4.Location = new System.Drawing.Point(4, 25);
            this.step4.Name = "step4";
            this.step4.Size = new System.Drawing.Size(1152, 702);
            this.step4.TabIndex = 2;
            this.step4.Text = "Crop Sides";
            this.step4.UseVisualStyleBackColor = true;
            // 
            // step4Next
            // 
            this.step4Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step4Next.Location = new System.Drawing.Point(10, 44);
            this.step4Next.Name = "step4Next";
            this.step4Next.Size = new System.Drawing.Size(488, 655);
            this.step4Next.TabIndex = 2;
            this.step4Next.Text = "Next";
            this.step4Next.UseVisualStyleBackColor = true;
            this.step4Next.Click += new System.EventHandler(this.step4Done);
            // 
            // marginPicture
            // 
            this.marginPicture.BackColor = System.Drawing.Color.DarkRed;
            this.marginPicture.Image = ((System.Drawing.Image)(resources.GetObject("marginPicture.Image")));
            this.marginPicture.Location = new System.Drawing.Point(504, 4);
            this.marginPicture.Name = "marginPicture";
            this.marginPicture.Size = new System.Drawing.Size(636, 695);
            this.marginPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.marginPicture.TabIndex = 1;
            this.marginPicture.TabStop = false;
            this.marginPicture.WaitOnLoad = true;
            this.marginPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.marginPaint);
            this.marginPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.marginMouseDown);
            this.marginPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.marginMouseMoved);
            this.marginPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.marginMouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 36);
            this.label4.TabIndex = 0;
            this.label4.Text = "Choose Margin Cut-off";
            // 
            // step5
            // 
            this.step5.Location = new System.Drawing.Point(4, 25);
            this.step5.Name = "step5";
            this.step5.Size = new System.Drawing.Size(1152, 702);
            this.step5.TabIndex = 3;
            this.step5.Text = "Create PDF";
            this.step5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 755);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Murli Clipper";
            this.tabControl1.ResumeLayout(false);
            this.step1.ResumeLayout(false);
            this.step1.PerformLayout();
            this.step2.ResumeLayout(false);
            this.step2.PerformLayout();
            this.step3.ResumeLayout(false);
            this.step3.PerformLayout();
            this.step4.ResumeLayout(false);
            this.step4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marginPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage step1;
        private System.Windows.Forms.TabPage step2;
        private System.Windows.Forms.TabPage step4;
        private System.Windows.Forms.TabPage step5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox srcPath;
        private System.Windows.Forms.Button srcButton;
        private System.Windows.Forms.Label srcValidity;
        private System.Windows.Forms.Button step1Next;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button step2Next;
        private System.Windows.Forms.TabPage step3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar step3ProgressBar;
        private System.Windows.Forms.Label step3Label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox marginPicture;
        private System.Windows.Forms.Button step4Next;
    }
}

