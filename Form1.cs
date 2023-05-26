using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace SingleScreenShot
{
    public partial class Form1 : Form
    {
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSelectedFile.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnShot_Click(object sender, EventArgs e)
        {

        }

        private void d(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Constants.shotKey)
            {
                Rectangle rectangle = new Rectangle(1920, 0, 1920, 1080);
                Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(new Point(rectangle.X, rectangle.Y), new Point(0, 0), bitmap.Size);
               
                graphics.Dispose();
                
                if (folderBrowserDialog1.SelectedPath.Length < 1)
                    MessageBox.Show("保存先を入力してください");
                else
                {
                    pictureBox1.Image = bitmap;
                    MessageBox.Show(folderBrowserDialog1.SelectedPath);
                    txtSelectedFile.Text = folderBrowserDialog1.SelectedPath;
                    bitmap.Save(@folderBrowserDialog1.SelectedPath + "\\" + txtPicName.Text + i,ImageFormat.Jpeg);
                    i++;
                }
            }
        }
    }
    static class Constants
    {
        public const Keys shotKey = Keys.F1;
    }
}
