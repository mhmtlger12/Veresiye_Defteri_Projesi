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

namespace MusteriDetay
{
    public partial class ToplamBorc : Form
    {
        public ToplamBorc()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void ToplamBorc_Load(object sender, EventArgs e)
        {
            try
            {
                string islem = "select  sum(Borc) as toplam from TBLMUSTERİ";
             // Bağlantıyı açıyoruz // Sorguyu komuta atıyoruz
                SqlCommand komut = new SqlCommand(islem, bgl.baglanti());

                int deger = Convert.ToInt32(komut.ExecuteScalar().ToString());
                string gorunendeger = String.Format("{0:N}", deger);


                label5.Text =gorunendeger ;
                

                komut.ExecuteNonQuery(); // Komutu çalıştırıyoruz
                bgl.baglanti().Close(); // Bağlantıyı mutlaka kapatıyoruz

                //Label Aka Plan Silme
                label2.Parent = pictureBox1;
                label2.BackColor = Color.Transparent;
                label5.Parent = pictureBox1;
                label5.BackColor = Color.Transparent;
                label3.Parent = pictureBox1;
                label3.BackColor = Color.Transparent;

                //Charta aylık veri çekme BURDA

                SqlCommand grafik = new SqlCommand("SELECT DISTINCT MONTH(TARİH),SUM (Borc) FROM TBLMUSTERİ group by MONTH(TARİH) ", bgl.baglanti());
                SqlDataReader drd = grafik.ExecuteReader();
                while (drd.Read())
                {
                    this.chart1.Series["Aylık"].Points.AddXY(drd[0], drd[1]);
                }
                bgl.baglanti().Close();

                //Charta yıllık veri çekme BURDA
                SqlCommand yillik = new SqlCommand("select DISTINCT (year(TARİH)) AS TARİH, sum(BORC) as Borc from TBLMUSTERİ GROUP BY year(TARİH)  ", bgl.baglanti());
                SqlDataReader drd1 = yillik.ExecuteReader();
                while (drd1.Read())
                {
                    this.ChartYillik.Series["Yillik"].Points.AddXY(drd1[0], drd1[1]);


                }
                bgl.baglanti().Close();

                //Charta yıllık veri çekme BURDA
                SqlCommand gidis = new SqlCommand("select DISTINCT (year(TARİH)) AS TARİH, sum(BORC) as Borc from TBLMUSTERİ GROUP BY year(TARİH)  ", bgl.baglanti());
                SqlDataReader gds = gidis.ExecuteReader();
                while (gds.Read())
                {
                    this.chart2.Series["Yıllık Analiz"].Points.AddXY(gds[0], gds[1]);


                }
                bgl.baglanti().Close();


            }
            catch
            {
                MessageBox.Show("Hatalı işlem Tekrar Deneyiniz", "  Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaEkran ana = new AnaEkran();
            ana.Show();
            this.Hide();
      
        }

      
  

       
    }
}
