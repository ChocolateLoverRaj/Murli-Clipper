namespace Murli_Clipper
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.step1 = new System.Windows.Forms.TabPage();
            this.step1Next = new System.Windows.Forms.Button();
            this.srcValidity = new System.Windows.Forms.Label();
            this.srcButton = new System.Windows.Forms.Button();
            this.srcPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.step2 = new System.Windows.Forms.TabPage();
            this.step2BackButton = new System.Windows.Forms.Button();
            this.step2Next = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.step3 = new System.Windows.Forms.TabPage();
            this.step3Label = new System.Windows.Forms.Label();
            this.step3ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.step4 = new System.Windows.Forms.TabPage();
            this.step4Next = new System.Windows.Forms.Button();
            this.cropPicture = new System.Windows.Forms.PictureBox();
            this.cropLabel = new System.Windows.Forms.Label();
            this.step5 = new System.Windows.Forms.TabPage();
            this.step4BackButton = new System.Windows.Forms.Button();
            this.destValidity = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.destPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.step1.SuspendLayout();
            this.step2.SuspendLayout();
            this.step3.SuspendLayout();
            this.step4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cropPicture)).BeginInit();
            this.step5.SuspendLayout();
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
            this.step2.Controls.Add(this.step2BackButton);
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
            // step2BackButton
            // 
            this.step2BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step2BackButton.Location = new System.Drawing.Point(27, 433);
            this.step2BackButton.Name = "step2BackButton";
            this.step2BackButton.Size = new System.Drawing.Size(834, 232);
            this.step2BackButton.TabIndex = 3;
            this.step2BackButton.Text = "Back";
            this.step2BackButton.UseVisualStyleBackColor = true;
            this.step2BackButton.Click += new System.EventHandler(this.step2Back);
            // 
            // step2Next
            // 
            this.step2Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step2Next.Location = new System.Drawing.Point(27, 170);
            this.step2Next.Name = "step2Next";
            this.step2Next.Size = new System.Drawing.Size(834, 232);
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
            this.step4.Controls.Add(this.step4BackButton);
            this.step4.Controls.Add(this.step4Next);
            this.step4.Controls.Add(this.cropPicture);
            this.step4.Controls.Add(this.cropLabel);
            this.step4.Location = new System.Drawing.Point(4, 25);
            this.step4.Name = "step4";
            this.step4.Size = new System.Drawing.Size(1152, 702);
            this.step4.TabIndex = 2;
            this.step4.Text = "Crop Pages";
            this.step4.UseVisualStyleBackColor = true;
            // 
            // step4Next
            // 
            this.step4Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step4Next.Location = new System.Drawing.Point(10, 43);
            this.step4Next.Name = "step4Next";
            this.step4Next.Size = new System.Drawing.Size(488, 175);
            this.step4Next.TabIndex = 2;
            this.step4Next.Text = "Next";
            this.step4Next.UseVisualStyleBackColor = true;
            this.step4Next.Click += new System.EventHandler(this.nextImage);
            // 
            // cropPicture
            // 
            this.cropPicture.BackColor = System.Drawing.Color.DarkRed;
            this.cropPicture.Location = new System.Drawing.Point(504, 4);
            this.cropPicture.Name = "cropPicture";
            this.cropPicture.Size = new System.Drawing.Size(636, 695);
            this.cropPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cropPicture.TabIndex = 1;
            this.cropPicture.TabStop = false;
            this.cropPicture.WaitOnLoad = true;
            this.cropPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.cropPaint);
            this.cropPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cropMouseDown);
            this.cropPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cropMouseMoved);
            this.cropPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cropMouseUp);
            // 
            // cropLabel
            // 
            this.cropLabel.AutoSize = true;
            this.cropLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cropLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cropLabel.Location = new System.Drawing.Point(4, 4);
            this.cropLabel.Name = "cropLabel";
            this.cropLabel.Size = new System.Drawing.Size(376, 36);
            this.cropLabel.TabIndex = 0;
            this.cropLabel.Text = "Choose Horizontal Margins";
            // 
            // step5
            // 
            this.step5.Controls.Add(this.closeButton);
            this.step5.Controls.Add(this.openButton);
            this.step5.Controls.Add(this.createButton);
            this.step5.Controls.Add(this.button2);
            this.step5.Controls.Add(this.destValidity);
            this.step5.Controls.Add(this.button1);
            this.step5.Controls.Add(this.destPath);
            this.step5.Controls.Add(this.label5);
            this.step5.Location = new System.Drawing.Point(4, 25);
            this.step5.Name = "step5";
            this.step5.Size = new System.Drawing.Size(1152, 702);
            this.step5.TabIndex = 3;
            this.step5.Text = "Create PDF";
            this.step5.UseVisualStyleBackColor = true;
            // 
            // step4BackButton
            // 
            this.step4BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step4BackButton.Location = new System.Drawing.Point(10, 224);
            this.step4BackButton.Name = "step4BackButton";
            this.step4BackButton.Size = new System.Drawing.Size(488, 175);
            this.step4BackButton.TabIndex = 3;
            this.step4BackButton.Text = "Back";
            this.step4BackButton.UseVisualStyleBackColor = true;
            this.step4BackButton.Click += new System.EventHandler(this.step4Back);
            // 
            // destValidity
            // 
            this.destValidity.AutoSize = true;
            this.destValidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destValidity.ForeColor = System.Drawing.Color.Red;
            this.destValidity.Location = new System.Drawing.Point(200, 139);
            this.destValidity.Name = "destValidity";
            this.destValidity.Size = new System.Drawing.Size(281, 36);
            this.destValidity.TabIndex = 7;
            this.destValidity.Text = "Folder Doesn\'t Exist";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Choose Path";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.destDialogClicked);
            // 
            // destPath
            // 
            this.destPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destPath.Location = new System.Drawing.Point(206, 95);
            this.destPath.Name = "destPath";
            this.destPath.Size = new System.Drawing.Size(803, 41);
            this.destPath.TabIndex = 5;
            this.destPath.TextChanged += new System.EventHandler(this.destPathChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(936, 91);
            this.label5.TabIndex = 4;
            this.label5.Text = "Choose An Output Folder";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(3, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(555, 256);
            this.button2.TabIndex = 8;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.step5Back);
            // 
            // createButton
            // 
            this.createButton.Enabled = false;
            this.createButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(564, 178);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(555, 256);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createClicked);
            // 
            // openButton
            // 
            this.openButton.Enabled = false;
            this.openButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openButton.Location = new System.Drawing.Point(3, 440);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(555, 256);
            this.openButton.TabIndex = 10;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openClicked);
            // 
            // closeButton
            // 
            this.closeButton.Enabled = false;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(564, 440);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(555, 256);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeClicked);
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
            ((System.ComponentModel.ISupportInitialize)(this.cropPicture)).EndInit();
            this.step5.ResumeLayout(false);
            this.step5.PerformLayout();
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
        private System.Windows.Forms.Label cropLabel;
        private System.Windows.Forms.PictureBox cropPicture;
        private System.Windows.Forms.Button step4Next;
        private System.Windows.Forms.Button step2BackButton;
        private System.Windows.Forms.Button step4BackButton;
        private System.Windows.Forms.Label destValidity;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox destPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button closeButton;
    }
}

