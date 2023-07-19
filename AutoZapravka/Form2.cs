using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoZapravka
{
    public partial class Form2 : Form
    {
        private string myValue;
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            foreach (var item in Globals.MyValue)
            {
                myValue += $"{item}\r\n";
            }
            label1.Text = myValue;

            Globals.MyValue.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
