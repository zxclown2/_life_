﻿namespace _life_
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.generate = new System.Windows.Forms.Button();
            this.zoom_slider = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tim_stop = new System.Windows.Forms.Button();
            this.tim_start = new System.Windows.Forms.Button();
            this.stopbut = new System.Windows.Forms.Button();
            this.startbut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Density = new System.Windows.Forms.NumericUpDown();
            this.Resolution = new System.Windows.Forms.NumericUpDown();
            this.field = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoom_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Density)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Resolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.field)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.generate);
            this.splitContainer1.Panel1.Controls.Add(this.zoom_slider);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.tim_stop);
            this.splitContainer1.Panel1.Controls.Add(this.tim_start);
            this.splitContainer1.Panel1.Controls.Add(this.stopbut);
            this.splitContainer1.Panel1.Controls.Add(this.startbut);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.Density);
            this.splitContainer1.Panel1.Controls.Add(this.Resolution);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.field);
            this.splitContainer1.Size = new System.Drawing.Size(931, 589);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "zoom";
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(25, 366);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(142, 23);
            this.generate.TabIndex = 10;
            this.generate.Text = "generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // zoom_slider
            // 
            this.zoom_slider.LargeChange = 1;
            this.zoom_slider.Location = new System.Drawing.Point(28, 333);
            this.zoom_slider.Maximum = 5;
            this.zoom_slider.Minimum = 1;
            this.zoom_slider.Name = "zoom_slider";
            this.zoom_slider.Size = new System.Drawing.Size(104, 56);
            this.zoom_slider.TabIndex = 9;
            this.zoom_slider.Value = 1;
            this.zoom_slider.Scroll += new System.EventHandler(this.zoom_slider_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 278);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 8;
            // 
            // tim_stop
            // 
            this.tim_stop.Location = new System.Drawing.Point(32, 249);
            this.tim_stop.Name = "tim_stop";
            this.tim_stop.Size = new System.Drawing.Size(135, 23);
            this.tim_stop.TabIndex = 7;
            this.tim_stop.Text = "stop_timer";
            this.tim_stop.UseVisualStyleBackColor = true;
            this.tim_stop.Click += new System.EventHandler(this.tim_stop_Click);
            // 
            // tim_start
            // 
            this.tim_start.Location = new System.Drawing.Point(32, 220);
            this.tim_start.Name = "tim_start";
            this.tim_start.Size = new System.Drawing.Size(135, 23);
            this.tim_start.TabIndex = 6;
            this.tim_start.Text = "start_timer";
            this.tim_start.UseVisualStyleBackColor = true;
            this.tim_start.Click += new System.EventHandler(this.tim_start_Click);
            // 
            // stopbut
            // 
            this.stopbut.Location = new System.Drawing.Point(32, 191);
            this.stopbut.Name = "stopbut";
            this.stopbut.Size = new System.Drawing.Size(135, 23);
            this.stopbut.TabIndex = 5;
            this.stopbut.Text = "stop";
            this.stopbut.UseVisualStyleBackColor = true;
            this.stopbut.Click += new System.EventHandler(this.stopbut_Click);
            // 
            // startbut
            // 
            this.startbut.Location = new System.Drawing.Point(32, 162);
            this.startbut.Name = "startbut";
            this.startbut.Size = new System.Drawing.Size(135, 23);
            this.startbut.TabIndex = 4;
            this.startbut.Text = "start";
            this.startbut.UseVisualStyleBackColor = true;
            this.startbut.Click += new System.EventHandler(this.startbut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Density";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resolution";
            // 
            // Density
            // 
            this.Density.Location = new System.Drawing.Point(32, 117);
            this.Density.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Density.Name = "Density";
            this.Density.Size = new System.Drawing.Size(120, 22);
            this.Density.TabIndex = 1;
            this.Density.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Density.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Resolution
            // 
            this.Resolution.Location = new System.Drawing.Point(32, 57);
            this.Resolution.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Resolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Resolution.Name = "Resolution";
            this.Resolution.Size = new System.Drawing.Size(120, 22);
            this.Resolution.TabIndex = 0;
            this.Resolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Resolution.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // field
            // 
            this.field.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.field.Location = new System.Drawing.Point(0, 0);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(1500, 1500);
            this.field.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.field.TabIndex = 0;
            this.field.TabStop = false;
            this.field.MouseClick += new System.Windows.Forms.MouseEventHandler(this.field_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 589);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zoom_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Density)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Resolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.field)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Density;
        private System.Windows.Forms.NumericUpDown Resolution;
        private System.Windows.Forms.Button stopbut;
        private System.Windows.Forms.Button startbut;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox field;
        private System.Windows.Forms.Button tim_stop;
        private System.Windows.Forms.Button tim_start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar zoom_slider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button generate;
    }
}

