namespace GPA_Calculator
{
    partial class GPA_Cal_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GPA_Cal_Form));
            this.btn_cal = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Btn_clear = new Guna.UI2.WinForms.Guna2Button();
            this.txt_gpa = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_addbatches = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_cal
            // 
            this.btn_cal.Animated = true;
            this.btn_cal.BorderColor = System.Drawing.Color.White;
            this.btn_cal.BorderRadius = 5;
            this.btn_cal.BorderThickness = 1;
            this.btn_cal.CheckedState.Parent = this.btn_cal;
            this.btn_cal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cal.CustomImages.Parent = this.btn_cal;
            this.btn_cal.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(77)))), ((int)(((byte)(116)))));
            this.btn_cal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btn_cal.ForeColor = System.Drawing.Color.White;
            this.btn_cal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(178)))));
            this.btn_cal.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(66)))), ((int)(((byte)(235)))));
            this.btn_cal.HoverState.Parent = this.btn_cal;
            this.btn_cal.Location = new System.Drawing.Point(72, 674);
            this.btn_cal.Name = "btn_cal";
            this.btn_cal.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(77)))), ((int)(((byte)(116)))));
            this.btn_cal.ShadowDecoration.Parent = this.btn_cal;
            this.btn_cal.Size = new System.Drawing.Size(115, 39);
            this.btn_cal.TabIndex = 107;
            this.btn_cal.Text = "Calculate";
            this.btn_cal.Click += new System.EventHandler(this.Btn_cal_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(189)))));
            this.linkLabel1.Location = new System.Drawing.Point(86, 574);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(165, 20);
            this.linkLabel1.TabIndex = 126;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "+ Add More Subjects";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.Location = new System.Drawing.Point(622, 7);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(33, 29);
            this.guna2ControlBox1.TabIndex = 127;
            this.guna2ControlBox1.Click += new System.EventHandler(this.Guna2ControlBox1_Click);
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox2.Location = new System.Drawing.Point(583, 6);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.Size = new System.Drawing.Size(35, 29);
            this.guna2ControlBox2.TabIndex = 128;
            // 
            // Btn_clear
            // 
            this.Btn_clear.Animated = true;
            this.Btn_clear.BorderColor = System.Drawing.Color.White;
            this.Btn_clear.BorderRadius = 5;
            this.Btn_clear.BorderThickness = 1;
            this.Btn_clear.CheckedState.Parent = this.Btn_clear;
            this.Btn_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_clear.CustomImages.Parent = this.Btn_clear;
            this.Btn_clear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(77)))), ((int)(((byte)(116)))));
            this.Btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Btn_clear.ForeColor = System.Drawing.Color.White;
            this.Btn_clear.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(178)))));
            this.Btn_clear.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(66)))), ((int)(((byte)(235)))));
            this.Btn_clear.HoverState.Parent = this.Btn_clear;
            this.Btn_clear.Location = new System.Drawing.Point(193, 674);
            this.Btn_clear.Name = "Btn_clear";
            this.Btn_clear.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(77)))), ((int)(((byte)(116)))));
            this.Btn_clear.ShadowDecoration.Parent = this.Btn_clear;
            this.Btn_clear.Size = new System.Drawing.Size(70, 39);
            this.Btn_clear.TabIndex = 129;
            this.Btn_clear.Text = "Clear";
            this.Btn_clear.Click += new System.EventHandler(this.Btn_clear_Click);
            // 
            // txt_gpa
            // 
            this.txt_gpa.BorderColor = System.Drawing.Color.Black;
            this.txt_gpa.BorderRadius = 5;
            this.txt_gpa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_gpa.DefaultText = "";
            this.txt_gpa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_gpa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_gpa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_gpa.DisabledState.Parent = this.txt_gpa;
            this.txt_gpa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_gpa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_gpa.FocusedState.Parent = this.txt_gpa;
            this.txt_gpa.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txt_gpa.ForeColor = System.Drawing.Color.Black;
            this.txt_gpa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_gpa.HoverState.Parent = this.txt_gpa;
            this.txt_gpa.Location = new System.Drawing.Point(72, 620);
            this.txt_gpa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_gpa.Name = "txt_gpa";
            this.txt_gpa.PasswordChar = '\0';
            this.txt_gpa.PlaceholderText = "";
            this.txt_gpa.ReadOnly = true;
            this.txt_gpa.SelectedText = "";
            this.txt_gpa.ShadowDecoration.Parent = this.txt_gpa;
            this.txt_gpa.Size = new System.Drawing.Size(191, 37);
            this.txt_gpa.TabIndex = 144;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 627);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 145;
            this.label1.Text = "GPA";
            // 
            // Btn_addbatches
            // 
            this.Btn_addbatches.Animated = true;
            this.Btn_addbatches.BorderColor = System.Drawing.Color.White;
            this.Btn_addbatches.BorderRadius = 5;
            this.Btn_addbatches.BorderThickness = 1;
            this.Btn_addbatches.CheckedState.Parent = this.Btn_addbatches;
            this.Btn_addbatches.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_addbatches.CustomImages.Parent = this.Btn_addbatches;
            this.Btn_addbatches.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(77)))), ((int)(((byte)(116)))));
            this.Btn_addbatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Btn_addbatches.ForeColor = System.Drawing.Color.White;
            this.Btn_addbatches.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(178)))));
            this.Btn_addbatches.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(66)))), ((int)(((byte)(235)))));
            this.Btn_addbatches.HoverState.Parent = this.Btn_addbatches;
            this.Btn_addbatches.Location = new System.Drawing.Point(493, 674);
            this.Btn_addbatches.Name = "Btn_addbatches";
            this.Btn_addbatches.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(77)))), ((int)(((byte)(116)))));
            this.Btn_addbatches.ShadowDecoration.Parent = this.Btn_addbatches;
            this.Btn_addbatches.Size = new System.Drawing.Size(103, 39);
            this.Btn_addbatches.TabIndex = 146;
            this.Btn_addbatches.Text = "Add Batches";
            this.Btn_addbatches.Click += new System.EventHandler(this.Btn_addbatches_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 37);
            this.label2.TabIndex = 147;
            this.label2.Text = "Note : For Grades ( Select \"-\" if you fail a Subject )";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(77)))), ((int)(((byte)(116)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.Teal;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(295, 619);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(335, 40);
            this.guna2GradientPanel1.TabIndex = 148;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 20;
            this.guna2Elipse2.TargetControl = this.guna2GradientPanel1;
            // 
            // GPA_Cal_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(660, 748);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.Btn_addbatches);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_gpa);
            this.Controls.Add(this.Btn_clear);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.btn_cal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GPA_Cal_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_cal;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2Button Btn_clear;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_gpa;
        private Guna.UI2.WinForms.Guna2Button Btn_addbatches;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
    }
}

