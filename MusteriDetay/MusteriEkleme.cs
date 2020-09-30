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
using System.Media;

namespace MusteriDetay
{
    public partial class MusteriEkleme : Form
    {
        public MusteriEkleme()
        {
            InitializeComponent();
        }

 
        SqlBaglantim bgl = new SqlBaglantim();
        private void MusteriEkleme_Load(object sender, EventArgs e)
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
        }

        private void BtnMusteriEkle_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand ekle = new SqlCommand("insert  into TBLMUSTERİ  (ADSOYAD,TELEFON,ADRES,TARİH,VerilenUrun,Borc) Values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
                ekle.Parameters.AddWithValue("@p1", TxtAd.Text);
                ekle.Parameters.AddWithValue("@p2", TxtTel.Text);
                ekle.Parameters.AddWithValue("@p3", RchAdres.Text);
                ekle.Parameters.AddWithValue("@p4", DtTarih.Text);
                ekle.Parameters.AddWithValue("@p5", RchVerilenUrun.Text);
                ekle.Parameters.AddWithValue("@p6", double.Parse(TxtBorc.Text));
                ekle.ExecuteNonQuery();
                TxtTel.Clear();
                TxtBorc.Clear();
                RchAdres.Clear();
                RchVerilenUrun.Clear();
                DtTarih.Clear();
                MessageBox.Show("Kayıt Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlemler Var!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                TxtAd.Clear();

                TxtTel.Clear();
                TxtBorc.Clear();
                RchAdres.Clear();
                RchVerilenUrun.Clear();
                DtTarih.Clear();
                MessageBox.Show("Temizleme İşi Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Temizleme İşlemi Başarısız!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaEkran ana = new AnaEkran();
            ana.Show();
            this.Hide();
        }

        private void TxtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void TxtAd_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);
        }


    }
}






