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
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }

        private void AnaEkran_Load(object sender, EventArgs e)
        {

            
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ToplamBorc tb = new ToplamBorc();
                tb.Show();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                AlarmFormEkranı fr = new AlarmFormEkranı();
                fr.Show();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Raporlar rp = new Raporlar();
                rp.Show();
                this.Hide();
            }
            catch (Exception)
            {

                
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MusteriEkleme ms = new MusteriEkleme();
                ms.Show();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

   

        private void BtnGosterGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                GosterGuncelle gg = new GosterGuncelle();
                gg.Show();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                FrmİlkEkran fr = new FrmİlkEkran();
                fr.Show();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void BtnNotal_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult secenek = MessageBox.Show("Çıkış Yapacaksınız !", "Çıkış Ekranı ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {

                    Application.Exit();

                }
                else if (secenek == DialogResult.No)
                {

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
          
          

        }
        

        private void BtnHesapMak2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Calc.exe");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void BtnAjanda_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNotAl frnot = new FrmNotAl();
                frnot.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                GelirGider1 gel = new GelirGider1();
                gel.Show();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }
    }
}
