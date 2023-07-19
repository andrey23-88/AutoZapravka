using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace AutoZapravka
{
    public partial class Form1 : Form
    {
        private double price = 0;//Цена
        private double value = 0;
        private double tempPrice = 0;
        private double CafePrice = 0;
        private string key;

        public Form1()
        {
            InitializeComponent();
        }
        private void rbtnLiter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnLiter.Checked)
                Jobs();
        }

        private void rbtnCena_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtnCena.Checked)
                Jobs();
        }
        //загрузка различных вводных(например с базы данных)
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Dictionary<string, double> comboSource = new Dictionary<string, double>();
            comboSource.Add("АИ-92", 48.20);
            comboSource.Add("АИ-95", 52.70);
            comboSource.Add("АИ-98", 58.40);
            comboSource.Add("ДТ", 59.80);
            cbxMarka.DataSource = new BindingSource(comboSource, null);
            cbxMarka.DisplayMember = "Key";
            cbxMarka.ValueMember = "Value";

            double[] myArray1 = { 50.20, 35.70, 75.40, 30.80 };
            string[] myArray = { "Чебурек", "Ватрушка", "Хот-дог", "Кофе 3 в 1" };


            checkBox1.Text = myArray[0];
            lblCafe1.Text = myArray1[0].ToString();
            checkBox2.Text = myArray[1];
            lblCafe2.Text = myArray1[1].ToString();
            checkBox3.Text = myArray[2];
            lblCafe3.Text = myArray1[2].ToString();
            checkBox4.Text = myArray[3];
            lblCafe4.Text = myArray1[3].ToString();
        }
        //событие на выбор марки топлива
        private void cbxMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = ((KeyValuePair<string, double>)cbxMarka.SelectedItem).Key;
            value = ((KeyValuePair<string, double>)cbxMarka.SelectedItem).Value;
            lblZaprCena.Text = value.ToString("0.00");
            price = value;
            Jobs();
        }
        //метод подсчета отдела с кафе
        private void CafeJob()
        {
            CafePrice = 0;
            if (checkBox1.Checked)
            {
                if (textBoxCafe1.Text == "") textBoxCafe1.Text = "0";
                CafePrice += (Convert.ToDouble(textBoxCafe1.Text) * Convert.ToDouble(lblCafe1.Text));
            }
            if (checkBox2.Checked)
            {
                if (textBoxCafe2.Text == "") textBoxCafe2.Text = "0";
                CafePrice += (Convert.ToDouble(textBoxCafe2.Text) * Convert.ToDouble(lblCafe2.Text));
            }
            if (checkBox3.Checked)
            {
                if (textBoxCafe3.Text == "") textBoxCafe3.Text = "0";
                CafePrice += (Convert.ToDouble(textBoxCafe3.Text) * Convert.ToDouble(lblCafe3.Text));
            }
            if (checkBox4.Checked)
            {
                if (textBoxCafe4.Text == "") textBoxCafe4.Text = "0";
                CafePrice += (Convert.ToDouble(textBoxCafe4.Text) * Convert.ToDouble(lblCafe4.Text));
            }

            label2.Text = CafePrice.ToString();
            ViewInfoPrice(tempPrice, CafePrice);
        }
        //метод подсчета отдела с топливом
        private void Jobs()
        {
            tempPrice = value;
            if (tbxLiter.Text == "")
            {
                tbxCena.Text = "0.00";
                tempPrice = 0;
            }

            else if (rbtnLiter.Checked)
            {
                tbxCena.Enabled = false;
                tbxLiter.Enabled = true;
                double Liter = Convert.ToDouble(tbxLiter.Text);
                tempPrice *= Liter;
                lblItogoCena.Text = tempPrice.ToString("0.00");
                lblItogoPatrol.Text = Liter.ToString("0.00");
            }
            else
            {
                tbxCena.Enabled = true;
                tbxLiter.Enabled = false;
                if (tbxCena.Text == "") return;
                double Cena = Convert.ToDouble(tbxCena.Text);
                if (Cena != 0) tempPrice = Cena;
                else tempPrice = 0;
                lblItogoCena.Text = tempPrice.ToString("0.00");
                lblItogoPatrol.Text = (Cena / value).ToString("0.00");
            }
            ViewInfoPrice(tempPrice, CafePrice);
        }
        //метод подсчета и печати итоговых данных
        private void ViewInfoPrice(double tempPrice1, double CafePrice1)
        {
            price = tempPrice1 + CafePrice1;
            lblPay.Text = price.ToString("0.00");

        }
        //событие на изменение литража
        private void tbxLiter_TextChanged_1(object sender, EventArgs e)
        {
            Jobs();
        }
        //событие на изменение суммы
        private void tbxCena_TextChanged_1(object sender, EventArgs e)
        {
            Jobs();
        }

        private void tbxLiter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxCena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxCafe1_TextChanged_1(object sender, EventArgs e)
        {
            CafeJob();
        }
        private void textBoxCafe2_TextChanged(object sender, EventArgs e)
        {
            CafeJob();
        }

        private void textBoxCafe3_TextChanged(object sender, EventArgs e)
        {
            CafeJob();
        }

        private void textBoxCafe4_TextChanged(object sender, EventArgs e)
        {
            CafeJob();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBoxCafe1.Enabled = checkBox1.Checked;
            CafeJob();
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            textBoxCafe2.Enabled = checkBox2.Checked;
            CafeJob();
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            textBoxCafe3.Enabled = checkBox3.Checked;
            CafeJob();
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            textBoxCafe4.Enabled = checkBox4.Checked;
            CafeJob();
        }
        private void btnPay_Click_1(object sender, EventArgs e)
        {
            double Price = Convert.ToDouble(lblItogoCena.Text);
            if (Price != 0)
            {
                string temp5 = $"{key}   {value} X {lblItogoPatrol.Text} = {lblItogoCena.Text} руб.";
                Globals.MyValue.Add(temp5);
            }
            if (textBoxCafe1.Enabled)
            {
                double temp = Convert.ToDouble(lblCafe1.Text);
                double temp1 = Convert.ToDouble(textBoxCafe1.Text);
                if (temp1 != 0)
                {
                    double temp2 = temp * temp1;
                    string temp3 = $"{checkBox1.Text}   {lblCafe1.Text} X {textBoxCafe1.Text} = {temp2.ToString("0.00")} руб.";
                    Globals.MyValue.Add(temp3);
                    Price += temp2;
                }
            }
            if (textBoxCafe2.Enabled)
            {
                double temp = Convert.ToDouble(lblCafe2.Text);
                double temp1 = Convert.ToDouble(textBoxCafe2.Text);
                if (temp1 != 0)
                {
                    double temp2 = temp * temp1;
                    string temp3 = $"{checkBox2.Text}   {lblCafe2.Text} X {textBoxCafe2.Text} = {temp2.ToString("0.00")} руб.";
                    Globals.MyValue.Add(temp3);
                    Price += temp2;
                }
            }
            if (textBoxCafe3.Enabled)
            {
                double temp = Convert.ToDouble(lblCafe3.Text);
                double temp1 = Convert.ToDouble(textBoxCafe3.Text);
                if (temp1 != 0)
                {
                    double temp2 = temp * temp1;
                    string temp3 = $"{checkBox3.Text}   {lblCafe3.Text} X {textBoxCafe3.Text} = {temp2.ToString("0.00")} руб.";
                    Globals.MyValue.Add(temp3);
                    Price += temp2;
                }
            }
            if (textBoxCafe4.Enabled)
            {
                double temp = Convert.ToDouble(lblCafe4.Text);
                double temp1 = Convert.ToDouble(textBoxCafe4.Text);
                if (temp1 != 0)
                {
                    double temp2 = temp * temp1;
                    string temp3 = $"{checkBox4.Text}   {lblCafe4.Text} X {textBoxCafe4.Text} = {temp2.ToString("0.00")} руб.";
                    Globals.MyValue.Add(temp3);
                    Price += temp2;
                }
            }
            Globals.MyValue.Add("Всего: " + Price.ToString("0.00") + " руб.");

            //обнуление формы
            tbxCena.Text = "0";
            tbxLiter.Text = "0";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            textBoxCafe1.Text = "0";
            textBoxCafe2.Text = "0";
            textBoxCafe3.Text = "0";
            textBoxCafe4.Text = "0";

            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void lblItogoCena_Click(object sender, EventArgs e)
        {

        }

       
    }
    //статический класс для передачи данных между формами
    public static class Globals
    {
        public static List<string> MyValue = new List<string>();

    }
}


