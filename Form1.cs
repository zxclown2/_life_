using System;
using System.Collections.Generic;

using System.Drawing;

using System.IO;

using System.Windows.Forms;

namespace _life_
{
   
    public partial class life_form : Form
    {
        
        private int resolution1;
        private bool gameison;
        private int zoom;
        private drawer _drawer;
 


        public life_form()
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
            
            resolution1 = (int)Resolution.Value;
            Resolution.Value = resolution1;
            int cols = field.Width / resolution1;
            int rows = field.Height / resolution1;
            textBox1.Text = $"{cols}, {rows}";
            my_map _map = new my_map(cols, rows, new bool[cols, rows], new int[cols, rows], getiinfo(to_alive), getiinfo(to_stay));
            _drawer = new drawer(field,_map,resolution1, new Bitmap(field.Width, field.Height));
            Properties.Settings.Default.Resolutionset = resolution1;
            Properties.Settings.Default.Aliveset = tostring(_map.toalive);
            Properties.Settings.Default.Stayset = tostring(_map.tostay);
            _drawer.g.Clear(Color.White);
            gameison = true;
        }


      
        public void nextmove()
        {
            _drawer.pb_map.count_next_phase();
            _drawer.drawmap();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nextmove();
        }



        private void startbut_Click(object sender, EventArgs e)
        {
            if (gameison) return;
            createmap();
            var res = MessageBox.Show("Do you want to download any game?", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {

                load_Click(sender, e);
            }

           

        }

        private void stopbut_Click(object sender, EventArgs e)
        {
            if (!gameison)
                return;

            timer1.Stop();
            var res = MessageBox.Show("Do you want to save changes?", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {

                save_Click(sender, e);
            }
            gameison = false;
            chabge_enable();
            zoom_slider.Value = 1;
            _drawer.return_to_default_size();
           



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
            int x = e.X / _drawer.resolution;
            int y = e.Y / _drawer.resolution;
            if (x >= _drawer.pb_map.cols || y >= _drawer.pb_map.rows || x < 0 || y < 0) return;
            if (e.Button != MouseButtons.Left) return;
            _drawer.pb_map.map[x, y] = !_drawer.pb_map.map[x, y];
            _drawer.drawmap();
        }
     
      
        private void zoom_slider_Scroll(object sender, EventArgs e)
        {
            if (!gameison) return;
            if (zoom_slider.Value != 0)
            {
                zoom = zoom_slider.Value;
                textBox1.Text = zoom_slider.Value.ToString();
                _drawer.PictureBoxZoom(zoom);
            }
        }

        private void generate_Click(object sender, EventArgs e)
        {
            if (!gameison) return;
            _drawer.pb_map.random();
            _drawer.drawmap();
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
                _drawer.PictureBoxZoom(1);
                Bitmap bmp = new Bitmap(field.Image);
                _drawer.PictureBoxZoom(temp);
                bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            else
            {
                var temp = zoom_slider.Value;
                _drawer.PictureBoxZoom(1);
                Bitmap bmp = new Bitmap(field.Image);
                byte[] ans = new byte[_drawer.orig_width * _drawer.orig_height];
                _drawer.PictureBoxZoom(temp);
                for (int i = 0; i < _drawer.orig_width; i++)
                {
                    for (int j = 0; j < _drawer.orig_height; j++)
                    {
                        ans[i * _drawer.orig_height + j] = bmp.GetPixel(i, j).Name.Equals("ff000000") ? (byte)1 : (byte)0;
                    }
                }

              

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
            Array.Clear(_drawer.pb_map.livelen, 0, _drawer.pb_map.livelen.Length);
            zoom_slider.Value = 1;
            _drawer.PictureBoxZoom(1);
            var extension = Path.GetExtension(filePath);
            if (extension.ToLower() == ".bmp")
            {
                Bitmap bitmap = new Bitmap(filePath);

                _drawer.resolution = (int)Resolution.Value;
                _drawer.pb_map.resize(bitmap.Width / _drawer.resolution, bitmap.Height / _drawer.resolution);
                textBox1.Text = $"{_drawer.pb_map.cols} {_drawer.pb_map.rows}";
                for (int i = 0; i < _drawer.pb_map.cols; i++)
                {
                    for (int j = 0; j < _drawer.pb_map.rows; j++)
                    {

                        _drawer.pb_map.map[i, j] = false;

                        if (bitmap.GetPixel(i * _drawer.resolution, j * _drawer.resolution).Name.Equals("ff000000"))
                            _drawer.pb_map.map[i, j] = true;
                    }
                }


                _drawer.drawmap();
            }
            else
            {
                var res = File.ReadAllBytes(filePath);
                for(int i=0;i< _drawer.pb_map.cols;i++)
                {
                    for(int j=0;j< _drawer.pb_map.rows;j++)
                    {
                        _drawer.pb_map.map[i, j] = res[i * _drawer.orig_height * _drawer.resolution + j * _drawer.resolution] == (byte)0 ? false : true;
                    }
                }

                _drawer.drawmap();
            }

        }

        private void next_Click(object sender, EventArgs e)
        {
            int k = (int)kval.Value;
            for (int i = 0; i < k; i++)
                _drawer.pb_map.count_next_phase();
            _drawer.drawmap();
        }

        private void field_MouseMove(object sender, MouseEventArgs e)
        {
            if (!gameison) return;

            Point p = e.Location;
            int x = e.X / _drawer.resolution;
            int y = e.Y / _drawer.resolution;
             if (x >= _drawer.pb_map.cols || y >= _drawer.pb_map.rows || x < 0 || y < 0) return;
            textBox1.Text = $"{_drawer.pb_map.livelen[x, y]}";
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
    public class drawer
    {
        public PictureBox picturebox;
        public my_map pb_map;
        public int resolution;
        public Graphics g;
        public int orig_width;
        public int orig_height;
        public int orig_resolution;
        public drawer(PictureBox pb,my_map mp,int res,Image img)
        {
            picturebox = pb;
            pb_map = mp;
            resolution = res;
            orig_height = picturebox.Height;
            orig_width=picturebox.Width;
            orig_resolution = resolution;
            picturebox.Image = img;
            g = Graphics.FromImage(img);
        }
        public void resize(int width,int height)
        {
            picturebox.Width = width;
            picturebox.Height = height;
        }
        public void drawmap()
        {
            g.Clear(Color.White);
            for (int i = 0; i < pb_map.cols; i++)
            {
                for (int j = 0; j < pb_map.rows; j++)
                {
                    if (pb_map.map[i, j])
                    {
                        g.FillRectangle(Brushes.Black, i * resolution, j * resolution, resolution, resolution);
                    }
                }
            }

            picturebox.Refresh();
        }
        public void PictureBoxZoom(int zoom)
        {
            picturebox.Height = orig_height * zoom;
            picturebox.Width = orig_width * zoom;
            resolution = orig_resolution * zoom;
            picturebox.Image = null;
            picturebox.Image = new Bitmap(picturebox.Width, picturebox.Height);
            g = Graphics.FromImage(picturebox.Image);
            drawmap();

        }
        public void return_to_default_size()
        {

            picturebox.Height = orig_height;
            picturebox.Width = orig_width;
            resolution = orig_resolution;
            picturebox.Image = new Bitmap(picturebox.Width, picturebox.Height);
            g = Graphics.FromImage(picturebox.Image);
        }
    }

}