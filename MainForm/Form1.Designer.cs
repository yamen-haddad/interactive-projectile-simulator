namespace MainForm
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
            this.glControl1 = new OpenTK.GLControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.degreeLabel = new System.Windows.Forms.Label();
            this.msLabel = new System.Windows.Forms.Label();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.maxHeightLabel = new System.Windows.Forms.Label();
            this.horizontalDistanceLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.projectileCheckBox = new System.Windows.Forms.CheckBox();
            this.velocityCheckBox = new System.Windows.Forms.CheckBox();
            this.vxCheckBox = new System.Windows.Forms.CheckBox();
            this.vyCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.angleTrackBar = new System.Windows.Forms.TrackBar();
            this.velocityTrackBar = new System.Windows.Forms.TrackBar();
            this.resultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.angleTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(4, 12);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(627, 443);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(668, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Angel :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(632, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Initial Velocity:";
            // 
            // degreeLabel
            // 
            this.degreeLabel.AutoSize = true;
            this.degreeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.degreeLabel.Location = new System.Drawing.Point(870, 50);
            this.degreeLabel.Name = "degreeLabel";
            this.degreeLabel.Size = new System.Drawing.Size(55, 17);
            this.degreeLabel.TabIndex = 5;
            this.degreeLabel.Text = "Degree";
            // 
            // msLabel
            // 
            this.msLabel.AutoSize = true;
            this.msLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msLabel.Location = new System.Drawing.Point(870, 99);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(32, 17);
            this.msLabel.TabIndex = 6;
            this.msLabel.Text = "M/S";
            // 
            // totalTimeLabel
            // 
            this.totalTimeLabel.AutoSize = true;
            this.totalTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTimeLabel.Location = new System.Drawing.Point(706, 239);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.Size = new System.Drawing.Size(87, 17);
            this.totalTimeLabel.TabIndex = 8;
            this.totalTimeLabel.Text = "Total Time:  ";
            // 
            // maxHeightLabel
            // 
            this.maxHeightLabel.AutoSize = true;
            this.maxHeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxHeightLabel.Location = new System.Drawing.Point(707, 203);
            this.maxHeightLabel.Name = "maxHeightLabel";
            this.maxHeightLabel.Size = new System.Drawing.Size(86, 17);
            this.maxHeightLabel.TabIndex = 7;
            this.maxHeightLabel.Text = "Max Height: ";
            // 
            // horizontalDistanceLabel
            // 
            this.horizontalDistanceLabel.AutoSize = true;
            this.horizontalDistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalDistanceLabel.Location = new System.Drawing.Point(654, 269);
            this.horizontalDistanceLabel.Name = "horizontalDistanceLabel";
            this.horizontalDistanceLabel.Size = new System.Drawing.Size(139, 17);
            this.horizontalDistanceLabel.TabIndex = 9;
            this.horizontalDistanceLabel.Text = "Horizontal Distance: ";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(735, 157);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(91, 30);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // projectileCheckBox
            // 
            this.projectileCheckBox.AutoSize = true;
            this.projectileCheckBox.Location = new System.Drawing.Point(644, 397);
            this.projectileCheckBox.Name = "projectileCheckBox";
            this.projectileCheckBox.Size = new System.Drawing.Size(99, 17);
            this.projectileCheckBox.TabIndex = 11;
            this.projectileCheckBox.Text = "Show Projectile";
            this.projectileCheckBox.UseVisualStyleBackColor = true;
            // 
            // velocityCheckBox
            // 
            this.velocityCheckBox.AutoSize = true;
            this.velocityCheckBox.Location = new System.Drawing.Point(644, 438);
            this.velocityCheckBox.Name = "velocityCheckBox";
            this.velocityCheckBox.Size = new System.Drawing.Size(124, 17);
            this.velocityCheckBox.TabIndex = 12;
            this.velocityCheckBox.Text = "Show Velocity Vecor";
            this.velocityCheckBox.UseVisualStyleBackColor = true;
            // 
            // vxCheckBox
            // 
            this.vxCheckBox.AutoSize = true;
            this.vxCheckBox.Location = new System.Drawing.Point(785, 397);
            this.vxCheckBox.Name = "vxCheckBox";
            this.vxCheckBox.Size = new System.Drawing.Size(102, 17);
            this.vxCheckBox.TabIndex = 13;
            this.vxCheckBox.Text = "Show Vx Vector";
            this.vxCheckBox.UseVisualStyleBackColor = true;
            // 
            // vyCheckBox
            // 
            this.vyCheckBox.AutoSize = true;
            this.vyCheckBox.Location = new System.Drawing.Point(785, 438);
            this.vyCheckBox.Name = "vyCheckBox";
            this.vyCheckBox.Size = new System.Drawing.Size(102, 17);
            this.vyCheckBox.TabIndex = 14;
            this.vyCheckBox.Text = "Show Vy Vector";
            this.vyCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(642, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Advanced Options: ";
            // 
            // angleTrackBar
            // 
            this.angleTrackBar.Location = new System.Drawing.Point(722, 48);
            this.angleTrackBar.Maximum = 90;
            this.angleTrackBar.Name = "angleTrackBar";
            this.angleTrackBar.Size = new System.Drawing.Size(104, 45);
            this.angleTrackBar.TabIndex = 16;
            this.angleTrackBar.Value = 45;
            this.angleTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // velocityTrackBar
            // 
            this.velocityTrackBar.Location = new System.Drawing.Point(722, 99);
            this.velocityTrackBar.Maximum = 50;
            this.velocityTrackBar.Minimum = 10;
            this.velocityTrackBar.Name = "velocityTrackBar";
            this.velocityTrackBar.Size = new System.Drawing.Size(104, 45);
            this.velocityTrackBar.TabIndex = 17;
            this.velocityTrackBar.Value = 30;
            this.velocityTrackBar.Scroll += new System.EventHandler(this.velocityTrackBar_Scroll);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.resultLabel.Location = new System.Drawing.Point(717, 315);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(143, 29);
            this.resultLabel.TabIndex = 18;
            this.resultLabel.Text = "hit the plane";
            this.resultLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 467);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.velocityTrackBar);
            this.Controls.Add(this.angleTrackBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vyCheckBox);
            this.Controls.Add(this.vxCheckBox);
            this.Controls.Add(this.velocityCheckBox);
            this.Controls.Add(this.projectileCheckBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.horizontalDistanceLabel);
            this.Controls.Add(this.totalTimeLabel);
            this.Controls.Add(this.maxHeightLabel);
            this.Controls.Add(this.msLabel);
            this.Controls.Add(this.degreeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.glControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.angleTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocityTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label degreeLabel;
        private System.Windows.Forms.Label msLabel;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Label maxHeightLabel;
        private System.Windows.Forms.Label horizontalDistanceLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox projectileCheckBox;
        private System.Windows.Forms.CheckBox velocityCheckBox;
        private System.Windows.Forms.CheckBox vxCheckBox;
        private System.Windows.Forms.CheckBox vyCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar angleTrackBar;
        private System.Windows.Forms.TrackBar velocityTrackBar;
        private System.Windows.Forms.Label resultLabel;
    }
}

