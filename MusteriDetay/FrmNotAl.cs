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
    public partial class FrmNotAl : Form
    {
        public FrmNotAl()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmNotAl_Load(object sender, EventArgs e)
        {
            //BURDA KALINDI
            try
            {
                SqlCommand komut = new SqlCommand("Select    Date_,AlinanNot  FROM NotKayit", bgl.baglanti());

                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    {
                        //richTextBox2.Text = "";
                        richTextBox2.Text += (dr["AlinanNot".ToString()]  + "\n"+ (dr["Date_".ToString()]));

                    }

                }

                bgl.baglanti().Close();

                label1.BackColor = Color.Transparent;
            }
            catch (Exception)
            {

               MessageBox.Show("Hata");
            }
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into NotKayit (AlinanNot) values (@p1)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", richTextBox1.Text);
              
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Başarılı");
                richTextBox1.Clear();
        }
            catch (Exception )
            {
                MessageBox.Show("Hata");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            AnaEkran anaa = new AnaEkran();
            anaa.Show();
            this.Close();
        }
    }
}
