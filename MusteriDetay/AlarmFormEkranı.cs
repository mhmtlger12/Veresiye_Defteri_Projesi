using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusteriDetay
{
    public partial class AlarmFormEkranı : Form
    {
        public AlarmFormEkranı()
        {
            InitializeComponent();
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        double st, sn, dk;

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                Color c;
                c = textBox6.BackColor;
                textBox6.BackColor = textBox6.ForeColor;
                textBox6.ForeColor = c;
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                st = int.Parse(textBox1.Text);
                dk = int.Parse(textBox2.Text);
                sn = int.Parse(textBox3.Text);
                label3.Text = sn.ToString();
                label1.Text = st.ToString();
                label2.Text = dk.ToString();
                timer1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("lütfen adam akıllı saati giriniz");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                sn++;
                label3.Text = sn.ToString();
                if (sn == 60)
                {
                    dk++;
                    sn = 00;
                    label2.Text = dk.ToString();
                }
                if (dk == 60)
                {
                    st++;
                    label1.Text = st.ToString();
                    dk = 00;
                    label2.Text = dk.ToString();
                }
                if (st == 24)
                {
                    st = 00;
                    label1.Text = st.ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

 
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (label4.Visible == false)
            {
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
            }
            if (label5.Visible == false)
            {
                label5.Visible = true;
            }
            else
            {
                label5.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnaEkran anaa = new AnaEkran();
            anaa.Show();
            this.Hide();
        }

        private void AlarmFormEkranı_Load(object sender, EventArgs e)
        {
            try
            {
                label1.Parent = pictureBox1;
                label1.BackColor = Color.Transparent;
                label3.Parent = pictureBox1;
                label3.BackColor = Color.Transparent;
                label4.Parent = pictureBox1;
                label4.BackColor = Color.Transparent;
                label5.Parent = pictureBox1;
                label5.BackColor = Color.Transparent;
                label6.Parent = pictureBox1;
                label6.BackColor = Color.Transparent;
                label7.Parent = pictureBox1;
                label7.BackColor = Color.Transparent;

                label2.Parent = pictureBox1;
                label2.BackColor = Color.Transparent;

                label8.Parent = pictureBox1;
                label8.BackColor = Color.Transparent;
                label9.Parent = pictureBox1;
                label9.BackColor = Color.Transparent;
                label10.Parent = pictureBox1;
                label10.BackColor = Color.Transparent;
                label11.Parent = pictureBox1;
                label11.BackColor = Color.Transparent;


                textBox1.Text = "00";
                textBox2.Text = "00";
                textBox3.Text = "00";
                textBox4.Text = DateTime.Now.ToShortDateString();
                textBox5.Text = DateTime.Now.ToLongTimeString();
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer1.Interval = 1000;
                timer2.Interval = 1000;
                timer3.Interval = 1000;
                timer4.Enabled = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == DateTime.Now.ToShortDateString() && textBox5.Text == DateTime.Now.ToLongTimeString())
                {
                    MessageBox.Show(textBox6.Text);
                    timer3.Enabled = true;
                }

            }
            catch (Exception)
            {


                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }
    }
}
