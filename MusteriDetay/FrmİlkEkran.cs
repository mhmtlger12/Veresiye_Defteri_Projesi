using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Utils.IoC;

namespace MusteriDetay
{
    public partial class FrmİlkEkran : Form
    {
        public FrmİlkEkran()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmİlkEkran_Load(object sender, EventArgs e)
        {


            try

            {

                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                timer1.Enabled = true;
                pictureBox2.Visible = true;
                //labelın arka planıını deiştirme
                lblkayanyazi.Parent = pictureBox1;
                lblkayanyazi.BackColor = Color.Transparent;
                label2.Parent = pictureBox1;
                label2.BackColor = Color.Transparent;
                label3.Parent = pictureBox1;
                label3.BackColor = Color.Transparent;
                label1.Parent = pictureBox1;
                label1.BackColor = Color.Transparent;
                label4.Parent = pictureBox1;
                label4.BackColor = Color.Transparent;
                timer2.Start();
                label5.Parent = pictureBox1;
                label5.BackColor = Color.Transparent;
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void TxtAd_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
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
                    TxtAd.Focus();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
          
      
        }

        private void TxtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komut = new SqlCommand("Select * From TBLADMİN Where Yetkili='" + TxtAd.Text + "' and Sifre='" + TxtSifre.Text + "'", bgl.baglanti());
                SqlDataReader getir = komut.ExecuteReader();

                if (getir.Read())
                {
                    AnaEkran ana = new AnaEkran();
                    ana.Show();
                    this.Hide();
                    MessageBox.Show("Giriş Başarılı..", "Giriş Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifreniz Hatalıdır..!", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 bgl.baglanti().Close();
                 

                }
            }

            catch (Exception)
            {
                MessageBox.Show("Hatalı işlem Tekrar Deneyiniz", "  Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblkayanyazi.Left > -340)
            {
                lblkayanyazi.Left -= 5;
            }
            else
            {
                lblkayanyazi.Left = 300;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label4.Text = DateTime.Now.ToLongTimeString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtAd.Clear();
            TxtSifre.Clear();
            TxtAd.Focus();
        }


    }
}


               
