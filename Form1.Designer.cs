namespace _life_
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Game = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.generate = new System.Windows.Forms.Button();
            this.zoom_slider = new System.Windows.Forms.TrackBar();
            this.startbut = new System.Windows.Forms.Button();
            this.stopbut = new System.Windows.Forms.Button();
            this.tim_start = new System.Windows.Forms.Button();
            this.tim_stop = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.TabPage();
            this.to_stay = new System.Windows.Forms.ListBox();
            this.to_alive = new System.Windows.Forms.ListBox();
            this.b = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Resolution = new System.Windows.Forms.NumericUpDown();
            this.Density = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.field = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Game.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoom_slider)).BeginInit();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Resolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Density)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.field);
            this.splitContainer1.Size = new System.Drawing.Size(931, 589);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Game);
            this.tabControl1.Controls.Add(this.Settings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(179, 585);
            this.tabControl1.TabIndex = 0;
            // 
            // Game
            // 
            this.Game.Controls.Add(this.label3);
            this.Game.Controls.Add(this.textBox1);
            this.Game.Controls.Add(this.generate);
            this.Game.Controls.Add(this.zoom_slider);
            this.Game.Controls.Add(this.startbut);
            this.Game.Controls.Add(this.stopbut);
            this.Game.Controls.Add(this.tim_start);
            this.Game.Controls.Add(this.tim_stop);
            this.Game.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Game.Location = new System.Drawing.Point(4, 25);
            this.Game.Name = "Game";
            this.Game.Padding = new System.Windows.Forms.Padding(3);
            this.Game.Size = new System.Drawing.Size(171, 556);
            this.Game.TabIndex = 0;
            this.Game.Text = "Game";
            this.Game.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "zoom";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 338);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 27);
            this.textBox1.TabIndex = 8;
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(3, 206);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(135, 31);
            this.generate.TabIndex = 10;
            this.generate.Text = "generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // zoom_slider
            // 
            this.zoom_slider.Enabled = false;
            this.zoom_slider.LargeChange = 1;
            this.zoom_slider.Location = new System.Drawing.Point(9, 267);
            this.zoom_slider.Maximum = 5;
            this.zoom_slider.Minimum = 1;
            this.zoom_slider.Name = "zoom_slider";
            this.zoom_slider.Size = new System.Drawing.Size(104, 56);
            this.zoom_slider.TabIndex = 9;
            this.zoom_slider.Value = 1;
            this.zoom_slider.Scroll += new System.EventHandler(this.zoom_slider_Scroll);
            // 
            // startbut
            // 
            this.startbut.Location = new System.Drawing.Point(3, 58);
            this.startbut.Name = "startbut";
            this.startbut.Size = new System.Drawing.Size(135, 31);
            this.startbut.TabIndex = 4;
            this.startbut.Text = "start";
            this.startbut.UseVisualStyleBackColor = true;
            this.startbut.Click += new System.EventHandler(this.startbut_Click);
            // 
            // stopbut
            // 
            this.stopbut.Location = new System.Drawing.Point(3, 95);
            this.stopbut.Name = "stopbut";
            this.stopbut.Size = new System.Drawing.Size(135, 31);
            this.stopbut.TabIndex = 5;
            this.stopbut.Text = "stop";
            this.stopbut.UseVisualStyleBackColor = true;
            this.stopbut.Click += new System.EventHandler(this.stopbut_Click);
            // 
            // tim_start
            // 
            this.tim_start.Location = new System.Drawing.Point(3, 132);
            this.tim_start.Name = "tim_start";
            this.tim_start.Size = new System.Drawing.Size(135, 31);
            this.tim_start.TabIndex = 6;
            this.tim_start.Text = "start_timer";
            this.tim_start.UseVisualStyleBackColor = true;
            this.tim_start.Click += new System.EventHandler(this.tim_start_Click);
            // 
            // tim_stop
            // 
            this.tim_stop.Location = new System.Drawing.Point(3, 169);
            this.tim_stop.Name = "tim_stop";
            this.tim_stop.Size = new System.Drawing.Size(135, 31);
            this.tim_stop.TabIndex = 7;
            this.tim_stop.Text = "stop_timer";
            this.tim_stop.UseVisualStyleBackColor = true;
            this.tim_stop.Click += new System.EventHandler(this.tim_stop_Click);
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.to_stay);
            this.Settings.Controls.Add(this.to_alive);
            this.Settings.Controls.Add(this.b);
            this.Settings.Controls.Add(this.a);
            this.Settings.Controls.Add(this.label1);
            this.Settings.Controls.Add(this.Resolution);
            this.Settings.Controls.Add(this.Density);
            this.Settings.Controls.Add(this.label2);
            this.Settings.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Settings.Location = new System.Drawing.Point(4, 25);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Settings.Size = new System.Drawing.Size(171, 556);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // to_stay
            // 
            this.to_stay.FormattingEnabled = true;
            this.to_stay.ItemHeight = 19;
            this.to_stay.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.to_stay.Location = new System.Drawing.Point(-1, 216);
            this.to_stay.Name = "to_stay";
            this.to_stay.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.to_stay.Size = new System.Drawing.Size(120, 42);
            this.to_stay.TabIndex = 9;
            // 
            // to_alive
            // 
            this.to_alive.FormattingEnabled = true;
            this.to_alive.ItemHeight = 19;
            this.to_alive.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.to_alive.Location = new System.Drawing.Point(0, 143);
            this.to_alive.Name = "to_alive";
            this.to_alive.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.to_alive.Size = new System.Drawing.Size(120, 42);
            this.to_alive.TabIndex = 8;
            // 
            // b
            // 
            this.b.AutoSize = true;
            this.b.Location = new System.Drawing.Point(3, 194);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(74, 19);
            this.b.TabIndex = 7;
            this.b.Text = "Stay alive";
            // 
            // a
            // 
            this.a.AutoSize = true;
            this.a.Location = new System.Drawing.Point(10, 121);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(45, 19);
            this.a.TabIndex = 5;
            this.a.Text = "Alive";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resolution";
            // 
            // Resolution
            // 
            this.Resolution.Location = new System.Drawing.Point(0, 31);
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
            this.Resolution.Size = new System.Drawing.Size(120, 27);
            this.Resolution.TabIndex = 0;
            this.Resolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Resolution.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Density
            // 
            this.Density.Location = new System.Drawing.Point(-1, 87);
            this.Density.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Density.Name = "Density";
            this.Density.Size = new System.Drawing.Size(120, 27);
            this.Density.TabIndex = 1;
            this.Density.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Density.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Density";
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
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Game.ResumeLayout(false);
            this.Game.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoom_slider)).EndInit();
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Resolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Density)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Game;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.Label b;
        private System.Windows.Forms.Label a;
        private System.Windows.Forms.ListBox to_alive;
        private System.Windows.Forms.ListBox to_stay;
    }
}

