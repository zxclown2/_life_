using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            this.Height = 1024;
            this.Width = 1024;
            InitializeComponent();
            
        }
        public void createmap() 
        {   if (timer1.Enabled)
                return;
            Resolution.Enabled = false;
            Density.Enabled = false;
            resolution = (int)Resolution.Value;
            rows = field.Height / resolution;
            cols = field.Width / resolution;
            map = new bool[cols, rows];
            field.Image = new Bitmap(field.Width, field.Height);
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

                    if (neighbours(i, j) == 3 && !map[i, j])
                        nextmap[i, j] = true;
                    if ((neighbours(i, j) == 2 || neighbours(i, j) == 3) && map[i, j])
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
            textBox1.Text = $"{cols} {rows}";
        }

        private void stopbut_Click(object sender, EventArgs e)
        {
            if (!gameison)
                return;
          
            timer1.Stop();  
            gameison = false;
            Resolution.Enabled = true;
            Density.Enabled = true;
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

      
    }
}
