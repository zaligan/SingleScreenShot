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
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(new Point(1920, 0), new Point(0, 0), bitmap.Size);
            }
            Color pixelColor = bitmap.GetPixel(0, 0);
            if (pixelColor.Name == "0")
                rectangle.X = -1920;
            originX += rectangle.X;
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
            if (this.ActiveControl is System.Windows.Forms.TextBox)
                return;
            if (e.KeyCode == Constants.shotKey)
            {
                if (folderBrowserDialog1.SelectedPath == "" || txtPicName.Text == "")
                    MessageBox.Show("保存先と画像名を入力してください");
                else
                {
                    Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(new Point(originX, 0), new Point(0, 0), bitmap.Size);
                    }
                    
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

    }
    static class Constants
    {
        public const Keys shotKey = Keys.S;
    }
}
