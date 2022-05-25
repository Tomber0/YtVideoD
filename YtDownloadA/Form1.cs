using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtDownloadTest;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YtDownloadA
{
    public partial class Form1 : Form
    {
        YtVideoDownloader _ytVideoDownloader;

        public Form1()
        {
            InitializeComponent();
}
        private void button1_Click(object sender, EventArgs e)
        {
            _ytVideoDownloader = new YtDownloadVideo();
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;

            }

            string filename = saveFileDialog1.FileName;
            var fileNewName = Path.GetFileName(filename);
            string fileDir = Path.GetDirectoryName(filename);
            _ytVideoDownloader.Download(textBox1.Text, fileDir, fileNewName);
            if (checkBox1.Checked)
            {
                _ytVideoDownloader.Convert($"{fileDir}\\" + $"{fileNewName}" + ".mp4");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = ClipBoard.Paste();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var userN = Environment.UserName;
            saveFileDialog1.InitialDirectory = $"C:\\Users\\{userN}\\Music\\";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            _ytVideoDownloader = new YtDownloadVideo();
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;

            }

            string filename = saveFileDialog1.FileName;
            var fileNewName = Path.GetFileName(filename);
            string fileDir = Path.GetDirectoryName(filename);
            _ytVideoDownloader.Convert(filename);

        }
    }
}
