using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _life_
{
   
    public partial class Dota3 : Form
    {
        private Graphics g;
        private int resolution;
        private my_map _map;
        private bool gameison;
        private int zoom;
        private int orig_width;
        private int orig_height;
        private int orig_resolution;
        private Image orig_image;


        public Dota3()
        {

            InitializeComponent();
            Resolution.Value = Properties.Settings.Default.Resolutionset;
            setinfofromsettings(Properties.Settings.Default.Aliveset, to_alive);
            setinfofromsettings(Properties.Settings.Default.Stayset, to_stay);


        }
        public List<int> getiinfo(ListBox listbox)
        {
            List<int> ind = new List<int>();
            foreach (var ob in listbox.SelectedItems)
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
        public void setinfofromsettings(string s, ListBox list)
        {
            List<int> ans = new List<int>();
            string[] s0 = s.Split(' ');
            foreach (var ch in s0)
            {
                ans.Add(Int32.Parse(ch));
            }
            foreach (var ch in ans)
                list.SetSelected(ch, true);

        }
        public string tostring(List<int> list)
        {
            string ans = "";
            foreach (var i in list)
                ans += i.ToString() + " ";
            ans = ans.Substring(0, ans.Length - 1);
            return ans;

        }
        public void chabge_enable()
        {
            Resolution.Enabled = !Resolution.Enabled;
            Density.Enabled = !Density.Enabled;
            zoom_slider.Enabled = !zoom_slider.Enabled;
            to_alive.Enabled = !to_alive.Enabled;
            to_stay.Enabled = !to_stay.Enabled;
            save.Enabled = !save.Enabled;
            load.Enabled = !load.Enabled;
            generate.Enabled = !generate.Enabled;
            tim_start.Enabled = !tim_start.Enabled;
            tim_stop.Enabled = !tim_stop.Enabled;
            kval.Enabled = !kval.Enabled;
            next.Enabled = !next.Enabled;
        }

        public void createmap()
        {
            chabge_enable();
            resolution = (int)Resolution.Value;
            Resolution.Value = resolution;
            int cols = field.Width / resolution;
            int rows = field.Height / resolution;
            textBox1.Text = $"{cols}, {rows}";
            _map = new my_map(cols, rows, new bool[cols, rows], new int[cols, rows], getiinfo(to_alive), getiinfo(to_stay));
            Properties.Settings.Default.Resolutionset = resolution;
            Properties.Settings.Default.Aliveset = tostring(_map.toalive);
            Properties.Settings.Default.Stayset = tostring(_map.tostay);
            field.Image = new Bitmap(field.Width, field.Height);
            orig_image = field.Image;
            orig_height = field.Height;
            orig_width = field.Width;
            orig_resolution = resolution;
            g = Graphics.FromImage(field.Image);
            g.Clear(Color.White);
            gameison = true;
        }


        public void drawmap()
        {
            g.Clear(Color.White);
            for (int i = 0; i < _map.cols; i++)
            {
                for (int j = 0; j < _map.rows; j++)
                {
                    if (_map.map[i, j])
                    {
                        g.FillRectangle(Brushes.Black, i * resolution, j * resolution, resolution, resolution);
                    }
                }
            }

            field.Refresh();
        }
        public void nextmove()
        {
            _map.count_next_phase();
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
            if (!gameison) return;
            timer1.Stop();
        }

        private void field_MouseClick(object sender, MouseEventArgs e)
        {
            if (!gameison) return;

            Point p = e.Location;
            int x = e.X / resolution;
            int y = e.Y / resolution;
            if (x >= _map.cols || y >= _map.rows || x < 0 || y < 0) return;
            if (e.Button != MouseButtons.Left) return;
            _map.map[x, y] = !_map.map[x, y];
            drawmap();
        }
        public void PictureBoxZoom(int zoom)
        {
            field.Height = orig_height * zoom;
            field.Width = orig_width * zoom;
            resolution = orig_resolution * zoom;
            field.Image = null;
            field.Image = new Bitmap(field.Width, field.Height);
            g = Graphics.FromImage(field.Image);
            drawmap();

        }
        public void return_to_default_size()
        {
            gameison = false;
            chabge_enable();
            zoom_slider.Value = 1;
            field.Height = orig_height;
            field.Width = orig_width;
            resolution = orig_resolution;
            field.Image = new Bitmap(field.Width, field.Height);
            g = Graphics.FromImage(field.Image);
        }
        private void zoom_slider_Scroll(object sender, EventArgs e)
        {
            if (!gameison) return;
            if (zoom_slider.Value != 0)
            {
                zoom = zoom_slider.Value;
                textBox1.Text = zoom_slider.Value.ToString();
                PictureBoxZoom(zoom);
            }
        }

        private void generate_Click(object sender, EventArgs e)
        {
            if (!gameison) return;

            _map.random();
            drawmap();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            Properties.Settings.Default.Save();


        }

        private void save_Click(object sender, EventArgs e)
        {

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string filePath = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    filePath = saveFileDialog1.FileName;
                    myStream.Close();
                }
            }
            if (filePath == String.Empty)
                return;
            var extension = Path.GetExtension(filePath);
            if (extension.ToLower() == ".bmp")
            {
                var temp = zoom_slider.Value;
                PictureBoxZoom(1);
                Bitmap bmp = new Bitmap(field.Image);
                PictureBoxZoom(temp);
                bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            else
            {
                var temp = zoom_slider.Value;
                PictureBoxZoom(1);
                Bitmap bmp = new Bitmap(field.Image);
                byte[] ans = new byte[orig_width * orig_height];
                for (int i = 0; i < orig_width; i++)
                {
                    for (int j = 0; j < orig_height; j++)
                    {
                        ans[i * orig_height + j] = bmp.GetPixel(i, j).Name.Equals("ff000000") ? (byte)1 : (byte)0;
                    }
                }

                PictureBoxZoom(temp);

                File.WriteAllBytes(filePath, ans);









            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            //  if (g == null) return;

            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            if (filePath == String.Empty)
                return;
            Array.Clear(_map.livelen, 0, _map.livelen.Length);
            zoom_slider.Value = 1;
            PictureBoxZoom(1);
            var extension = Path.GetExtension(filePath);
            if (extension.ToLower() == ".bmp")
            {
                Bitmap bitmap = new Bitmap(filePath);

                resolution = (int)Resolution.Value;
                _map.resize(bitmap.Width / resolution, bitmap.Height / resolution);
                textBox1.Text = $"{_map.cols} {_map.rows}";
                for (int i = 0; i < _map.cols; i++)
                {
                    for (int j = 0; j < _map.rows; j++)
                    {

                        _map.map[i, j] = false;

                        if (bitmap.GetPixel(i * resolution, j * resolution).Name.Equals("ff000000"))
                            _map.map[i, j] = true;
                    }
                }


                drawmap();
            }
            else
            {
                var res = File.ReadAllBytes(filePath);
                for(int i=0;i<_map.cols;i++)
                {
                    for(int j=0;j<_map.rows;j++)
                    {
                        _map.map[i, j] = res[i * orig_height * resolution + j * resolution] == (byte)0 ? false : true;
                    }
                }
         
                drawmap();
            }

        }

        private void next_Click(object sender, EventArgs e)
        {
            int k = (int)kval.Value;
            for (int i = 0; i < k; i++)
                _map.count_next_phase();
            drawmap();
        }

        private void field_MouseMove(object sender, MouseEventArgs e)
        {
            if (!gameison) return;

            Point p = e.Location;
            int x = e.X / resolution;
            int y = e.Y / resolution;
             if (x >= _map.cols || y >= _map.rows || x < 0 || y < 0) return;
            textBox1.Text = $"{_map.livelen[x, y]}";
        }
    }
    public class my_map
    {
        public int cols, rows;
        public bool[,] map;
        public int[,] livelen;
        public List<int> toalive;
        public List<int> tostay;
        public my_map(int cols, int rows, bool[,] map, int[,] livelen, List<int> toalive, List<int> tostay)
        {
            this.cols = cols;
            this.rows = rows;
            this.map = map;
            this.livelen = livelen;
            this.toalive = toalive;
            this.tostay = tostay;
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
        public void count_next_phase()
        {
            bool[,] nextmap = new bool[cols, rows];
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
                    map[i, j] = nextmap[i, j];
                    livelen[i, j] += map[i, j] ? 1 : 0;
                    livelen[i, j] *= map[i, j] ? 1 : 0;
                }
            }
        }
        public void random()
        {
            var rnd = new Random();
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    map[i, j] = rnd.Next(2) == 0;
                }
            }
        }
        public void resize(int cols, int rows)
        {
            this.cols = cols;
            this.rows = rows;
            this.map = new bool[cols, rows];
        }
    }
}