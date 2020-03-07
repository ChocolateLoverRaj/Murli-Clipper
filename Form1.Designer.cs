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
            this.step2 = new System.Windows.Forms.TabPage();
            this.step3 = new System.Windows.Forms.TabPage();
            this.step4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.srcPath = new System.Windows.Forms.TextBox();
            this.srcButton = new System.Windows.Forms.Button();
            this.srcValidity = new System.Windows.Forms.Label();
            this.step1Next = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.step1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.step1);
            this.tabControl1.Controls.Add(this.step2);
            this.tabControl1.Controls.Add(this.step3);
            this.tabControl1.Controls.Add(this.step4);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(547, 254);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabChanged);
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
            this.step1.Size = new System.Drawing.Size(539, 225);
            this.step1.TabIndex = 0;
            this.step1.Text = "Select PDF";
            this.step1.UseVisualStyleBackColor = true;
            // 
            // step2
            // 
            this.step2.Location = new System.Drawing.Point(4, 25);
            this.step2.Name = "step2";
            this.step2.Size = new System.Drawing.Size(517, 279);
            this.step2.TabIndex = 1;
            this.step2.Text = "Select Date";
            this.step2.UseVisualStyleBackColor = true;
            // 
            // step3
            // 
            this.step3.Location = new System.Drawing.Point(4, 25);
            this.step3.Name = "step3";
            this.step3.Size = new System.Drawing.Size(517, 279);
            this.step3.TabIndex = 2;
            this.step3.Text = "Crop PDF";
            this.step3.UseVisualStyleBackColor = true;
            // 
            // step4
            // 
            this.step4.Location = new System.Drawing.Point(4, 25);
            this.step4.Name = "step4";
            this.step4.Size = new System.Drawing.Size(311, 279);
            this.step4.TabIndex = 3;
            this.step4.Text = "Create PDF";
            this.step4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 91);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select A PDF";
            // 
            // srcPath
            // 
            this.srcPath.Location = new System.Drawing.Point(124, 133);
            this.srcPath.Name = "srcPath";
            this.srcPath.Size = new System.Drawing.Size(393, 22);
            this.srcPath.TabIndex = 1;
            this.srcPath.TextChanged += new System.EventHandler(this.srcPathChanged);
            // 
            // srcButton
            // 
            this.srcButton.Location = new System.Drawing.Point(19, 132);
            this.srcButton.Name = "srcButton";
            this.srcButton.Size = new System.Drawing.Size(99, 23);
            this.srcButton.TabIndex = 2;
            this.srcButton.Text = "Choose Path";
            this.srcButton.UseVisualStyleBackColor = true;
            this.srcButton.Click += new System.EventHandler(this.srcDialogClicked);
            // 
            // srcValidity
            // 
            this.srcValidity.AutoSize = true;
            this.srcValidity.ForeColor = System.Drawing.Color.Red;
            this.srcValidity.Location = new System.Drawing.Point(121, 158);
            this.srcValidity.Name = "srcValidity";
            this.srcValidity.Size = new System.Drawing.Size(110, 17);
            this.srcValidity.TabIndex = 3;
            this.srcValidity.Text = "Not a Valid Path";
            // 
            // step1Next
            // 
            this.step1Next.Enabled = false;
            this.step1Next.Location = new System.Drawing.Point(442, 158);
            this.step1Next.Name = "step1Next";
            this.step1Next.Size = new System.Drawing.Size(75, 23);
            this.step1Next.TabIndex = 4;
            this.step1Next.Text = "Next";
            this.step1Next.UseVisualStyleBackColor = true;
            this.step1Next.Click += new System.EventHandler(this.step1Done);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 450);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Murli Clipper";
            this.tabControl1.ResumeLayout(false);
            this.step1.ResumeLayout(false);
            this.step1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage step1;
        private System.Windows.Forms.TabPage step2;
        private System.Windows.Forms.TabPage step3;
        private System.Windows.Forms.TabPage step4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox srcPath;
        private System.Windows.Forms.Button srcButton;
        private System.Windows.Forms.Label srcValidity;
        private System.Windows.Forms.Button step1Next;
    }
}

