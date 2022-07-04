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
using QRCoder;

namespace FINAL
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter Name = new StreamWriter(@"C:\Users\PC16\source\repos\FINAL\FINAL\Info\Information.txt", true); 
            Name.WriteLine(txtbxFirstname.Text + "," + txtlast.Text + "," + txtcontact.Text + "," + txtcity.Text +"," + txtemail.Text+ ","  + VACCINE.Text+ ","+  DATE.Text );
            Name.Close();
          
            {
                this.Hide();
                fillup f3 = new fillup ();
                f3.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(txtbxFirstname.Text + "," + txtlast.Text + "," + txtcontact.Text + "," + txtcity.Text + "," + txtemail.Text + "," + VACCINE.Text+ "," , QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            pictureBox2.Image = code.GetGraphic(5);
            label10.Text = "Save Your QR!";
        }
    }
}
