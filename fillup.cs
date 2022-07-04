using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL
{
    public partial class fillup : Form
    {
        public fillup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thank You For Your Response", "Thank You", MessageBoxButtons.OK) == DialogResult.OK)
            {
                this.Hide();
                data f3 = new data();
                f3.ShowDialog();
            }
        }
    }
}
