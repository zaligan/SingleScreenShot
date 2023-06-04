using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace SingleScreenShot
{
    public partial class Form1 : Form
    {
        Rectangle rectangle = new Rectangle(0, 0, 1920, 1080);
        int initialX = 0;
        int originX = 1920;
        Keys selectedKey;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            Bitmap bitmap = SetBitmap(new Point(1920,0));
            Color pixelColor = bitmap.GetPixel(0, 0);
            //メインディスプレイを右にしている場合-1920に設定
            rectangle.X = pixelColor.Name == "0" ? -1920 : 0;
            originX += rectangle.X;
            foreach (var key in Enum.GetValues(typeof(Keys)))
            {
                comboBox1.Items.Add(key);
            }
        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSelectedFile.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            selectedKey = (Keys)comboBox1.SelectedItem;

            if (this.ActiveControl is System.Windows.Forms.TextBox)
                return;
            if (e.KeyCode == selectedKey)
            {
                if (folderBrowserDialog1.SelectedPath == "" || txtPicName.Text == "")
                    MessageBox.Show("保存先と画像名を入力してください");
                else
                {
                    Bitmap bitmap = SetBitmap(new Point(originX, 0));
                    
                    if(pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();
                    pictureBox1.Image = bitmap;

                    txtSelectedFile.Text = folderBrowserDialog1.SelectedPath;
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string filePath = Path.Combine(folderBrowserDialog1.SelectedPath, txtPicName.Text + "_" + timestamp + ".jpeg");
                    bitmap.Save(filePath);
                }
            }
        }

        private void radioBtnLeftScreen_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                initialX = 0;
                originX = initialX + rectangle.X;
            }
        }

        private void radioBtnRightScreen_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                initialX = 1920;
                originX = initialX + rectangle.X;
            }
        }
        private Bitmap SetBitmap(Point capturePoint)
        {
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(capturePoint, new Point(0, 0), bitmap.Size);
            }
            return bitmap;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastPicName = txtPicName.Text;
            Properties.Settings.Default.LastSelectedFolder = folderBrowserDialog1.SelectedPath;
            if (comboBox1.SelectedItem != null)
            {
                Properties.Settings.Default.LastKey = comboBox1.SelectedItem.ToString();
            }
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPicName.Text = Properties.Settings.Default.LastPicName;
            folderBrowserDialog1.SelectedPath = Properties.Settings.Default.LastSelectedFolder;
            string lastKey = Properties.Settings.Default.LastKey;
            if (!string.IsNullOrEmpty(lastKey))
            {
                comboBox1.SelectedItem = Enum.Parse(typeof(Keys), lastKey);
            }
            txtSelectedFile.Text = Properties.Settings.Default.LastSelectedFolder;
        }

    }
}
