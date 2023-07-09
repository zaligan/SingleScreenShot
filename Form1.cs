using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SingleScreenShot
{
    // スクリーン位置を表す列挙型
    public enum ScreenPosition
    {
        Left,
        Right
    }

    public partial class Form1 : Form
    {
        // 画面のサイズと色を定義する定数
        private const int SCREEN_WIDTH = 1920;
        private const int SCREEN_HEIGHT = 1080;
        private const string BLACK_PIXEL_COLOR_NAME = "0";

        // スクリーンキャプチャの範囲を定義する矩形
        private Rectangle rectangle = new Rectangle(0, 0, SCREEN_WIDTH, SCREEN_HEIGHT);
        // 現在のスクリーン位置を保持する変数
        private ScreenPosition initialPosition = ScreenPosition.Left;
        // オリジンXの初期位置
        private int originX = SCREEN_WIDTH;
        private Keys selectedKey;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            Bitmap bitmap = CaptureBitmap(new Point(SCREEN_WIDTH, 0));
            // 左上のピクセルの色を取得
            Color pixelColor = bitmap.GetPixel(0, 0);
            // メインディスプレイが右側にある場合にX座標を修正
            rectangle.X = pixelColor.Name == BLACK_PIXEL_COLOR_NAME ? -SCREEN_WIDTH : 0;
            originX += rectangle.X;
            // 全てのキーをコンボボックスに追加
            foreach (var key in Enum.GetValues(typeof(Keys)))
            {
                comboBox1.Items.Add(key);
            }
        }

        // フォルダ選択ダイアログを開き、選択されたパスをテキストボックスに表示
        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSelectedFile.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        // 特定のキーが押されたらスクリーンショットを保存
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            selectedKey = (Keys)comboBox1.SelectedItem;

            if (this.ActiveControl is System.Windows.Forms.TextBox)
                return;

            if (e.KeyCode == selectedKey)
            {
                if (string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath) || string.IsNullOrEmpty(txtPicName.Text))
                    MessageBox.Show("保存先と画像名を入力してください");
                else
                {
                    // スクリーンショットを取得して表示
                    Bitmap bitmap = CaptureBitmap(new Point(originX, 0));

                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();

                    pictureBox1.Image = bitmap;

                    // 画像を保存
                    txtSelectedFile.Text = folderBrowserDialog1.SelectedPath;
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string filePath = Path.Combine(folderBrowserDialog1.SelectedPath, $"{txtPicName.Text}_{timestamp}.jpeg");
                    bitmap.Save(filePath);
                }
            }
        }

        // ラジオボタンが選択されたらスクリーン位置を更新
        private void radioBtnLeftScreen_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScreenPosition(sender, ScreenPosition.Left);
        }

        private void radioBtnRightScreen_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScreenPosition(sender, ScreenPosition.Right);
        }

        // スクリーン位置を更新
        private void UpdateScreenPosition(object sender, ScreenPosition position)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                initialPosition = position;
                originX = GetOriginX();
            }
        }

        // 指定した位置からスクリーンショットを取得
        private Bitmap CaptureBitmap(Point capturePoint)
        {
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(capturePoint, new Point(0, 0), bitmap.Size);
            }
            return bitmap;
        }

        // フォームが閉じる際の処理。最後の設定を保存
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

        // フォームが読み込まれた際の処理。最後の設定を読み込む
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

        // 画面位置に応じてoriginXを計算
        private int GetOriginX()
        {
            return initialPosition == ScreenPosition.Left ? 0 : SCREEN_WIDTH + rectangle.X;
        }
    }
}
