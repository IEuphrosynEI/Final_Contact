using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Windows.Compatibility;
using System.IO;

namespace FINAL
{
    public partial class scanner : Form
    {
        private FilterInfoCollection Information;
        private VideoCaptureDevice CPDevice;
        public scanner()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            CPDevice = new VideoCaptureDevice(Information[comboBox1.SelectedIndex].MonikerString);
            CPDevice.NewFrame += CaptureDevice_NewFrame;
            CPDevice.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void scanner_Load(object sender, EventArgs e)
        {
            Information = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterinfo in Information)
                comboBox1.Items.Add(filterinfo.Name);
            comboBox1.SelectedIndex = 0;
            CPDevice = new VideoCaptureDevice();

        }

        private void scanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CPDevice.IsRunning==true)
                CPDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1 != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                try
                {
                    string decoded = result.ToString().Trim();
                    if(decoded !="")
                    {
                        textBox1.Text = decoded;
                    }
                }
                catch (Exception ex)
                {

                }
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter Name = new StreamWriter(@"C:\Users\PC16\source\repos\FINAL\FINAL\Info\Information.txt", true);
            Name.WriteLine(textBox1.Text + dateTimePicker1.Text, true);
            Name.Close();
            {
                this.Hide();
                fillup f3 = new fillup();
                f3.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}