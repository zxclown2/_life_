﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _life_
{
    public partial class Form1 : Form
    {   private Graphics g;
        private int resolution;
        private bool [,] map;
        private int rows; //y
        private int cols; //x
        private bool gameison;
        private int zoom;
        private int orig_width;
        private int orig_height;
        private int orig_resolution;
        private Image orig_image;
        private List<int> toalive;
        private List<int> tostay;
        public Form1()
        {
           
            InitializeComponent();
            Resolution.Value = Properties.Settings.Default.Resolutionset;
            
        }
        public List<int> getiinfo(ListBox listbox)
        {
            List<int> ind = new List<int>();
            foreach(var ob in listbox.SelectedItems)
            {
                ind.Add(Int32.Parse(ob.ToString()));
            }
            if (ind.Count == 0)
            { 
                ind.Add(0);
                listbox.SetSelected(0, true);
            }
            return ind;
        }
      
        public void createmap() 
        {   
            Resolution.Enabled = false;
            Density.Enabled = false;
            zoom_slider.Enabled = true;
            resolution = (int)Resolution.Value;
            Resolution.Value = resolution;
            rows = field.Height / resolution;
            toalive = getiinfo(to_alive);
            tostay = getiinfo(to_stay);
            cols = field.Width / resolution;
            Properties.Settings.Default.Resolutionset=resolution;
            map = new bool[cols, rows];
            field.Image = new Bitmap(field.Width, field.Height);
            orig_image=field.Image;
            orig_height = field.Height;
            orig_width = field.Width;
            orig_resolution = resolution;
            g = Graphics.FromImage(field.Image);
            gameison = true;
        }
        public int neighbours(int x, int y)
        {
            int ans = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if ((i != x || j != y) && map[(i + 2 * cols) % cols, (j + 2 * rows) % rows])
                        ans++;
                }
            }
            return ans;
        }

        public void drawmap()
        {
            g.Clear(Color.White);
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (map[i,j])
                    {
                        g.FillRectangle(Brushes.Black,i * resolution, j * resolution, resolution, resolution);
                    }
                }
            }
           
            field.Refresh();
        }
        public void nextmove()
        {  bool[,] nextmap=new bool[cols,rows];
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    nextmap[i, j] = false;

                    if (toalive.Contains(neighbours(i, j)) && !map[i, j])
                        nextmap[i, j] = true;
                    if (tostay.Contains(neighbours(i, j)) && map[i, j])
                        nextmap[i, j] = true;
                  
                }
            }
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    map[i,j]=nextmap[i,j];
                }
            }

            drawmap();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            nextmove();
        }

      

        private void startbut_Click(object sender, EventArgs e)
        {
            if (gameison) return;
            
            createmap();
            //textBox1.Text = $"{cols} {rows}";
        }

        private void stopbut_Click(object sender, EventArgs e)
        {
            if (!gameison)
                return;
          
            timer1.Stop();
            return_to_default_size();
          

        }

     

        private void tim_start_Click(object sender, EventArgs e)
        {
            if (!gameison) return;
            timer1.Start();
        }

        private void tim_stop_Click(object sender, EventArgs e)
        {
            if(!gameison) return;
            timer1.Stop();
        }

        private void field_MouseClick(object sender, MouseEventArgs e)
        {
            if (!gameison) return;

            Point p = e.Location;
            int x = e.X / resolution;
            int y = e.Y / resolution;
            if (x >= cols || y >= rows || x < 0 || y < 0) return;
            if (e.Button != MouseButtons.Left) return;
            map[x, y] = !map[x, y];
            drawmap();
        }
        public void PictureBoxZoom(Image img, int zoom)
        {
            //    cols=cols*Size.Width;
            //  rows=rows*Size.Height;
            
         field.Height=orig_height*zoom;
         field.Width = orig_width*zoom;
         resolution=orig_resolution*zoom;
         field.Image = null;
         field.Image = new Bitmap(field.Width, field.Height);
         g = Graphics.FromImage(field.Image);
        drawmap();
           
        }
      public void  return_to_default_size()
        {
            gameison = false;
            Resolution.Enabled = true;
            Density.Enabled = true;
            zoom_slider.Enabled = false;
            zoom_slider.Value = 1;
            field.Height = orig_height ;
            field.Width = orig_width ;
            resolution = orig_resolution ;
            field.Image = new Bitmap(field.Width, field.Height);
            g = Graphics.FromImage(field.Image);
        }
        private void zoom_slider_Scroll(object sender, EventArgs e)
        { if (!gameison) return;
            if (zoom_slider.Value != 0)
            {
                zoom = zoom_slider.Value;
                textBox1.Text = zoom_slider.Value.ToString();
                 PictureBoxZoom(orig_image, zoom);
            }
        }

        private void generate_Click(object sender, EventArgs e)
        {  if (!gameison) return;
            var rnd= new Random();
            for(int i=0;i<cols;i++)
            {
                for(int j=0;j<rows;j++)
                {
                    map[i, j] = rnd.Next((int)Density.Value) == 0;
                }
            }
            drawmap();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                Properties.Settings.Default.Save();

            
        }
    }
}
