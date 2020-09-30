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
    public partial class GelirGider1 : Form
    {
        public GelirGider1()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void GelirGider1_Load(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            SqlCommand komut = new SqlCommand("Select  KategoriAD FROM Kategoriler" , bgl.baglanti());

            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                {
                    cmbveriler.Items.Add(dr["KategoriAD"].ToString());
                    
                }

            }

            bgl.baglanti().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand ekle = new SqlCommand("insert  into Kategoriler  (KategoriAD) Values (@p1)", bgl.baglanti());
                ekle.Parameters.AddWithValue("@p1", textBox1.Text);

                ekle.ExecuteNonQuery();
                bgl.baglanti().Close();
                textBox1.Clear();

            

                MessageBox.Show("Kayıt Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlemler Var!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


        private void button2_Click_1(object sender, EventArgs e)
        {

            SqlDataAdapter da_GetDetails = new SqlDataAdapter("select * from Kategoriler ", bgl.baglanti());


            DataTable dt = new DataTable();
            da_GetDetails.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

    

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SqlCommand komut = new SqlCommand("Select  KategoriID FROM Kategoriler where KategoriAD='"+cmbveriler.SelectedItem+"' ", bgl.baglanti());

            SqlDataReader drr = komut.ExecuteReader();
            while (drr.Read())
            {
                {
             
                    comboBox1.SelectedIndex = comboBox1.Items.Add(drr["KategoriID"].ToString());

                }

            }

            bgl.baglanti().Close();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
              
                SqlCommand kmt = new SqlCommand("insert into islemler (KategoriID,KategoriAD,Yapilanİslem,Tarih,Borc) values (@p1,'" + cmbveriler.Text + "',@p2,@p3,@p4)", bgl.baglanti());
                kmt.Parameters.AddWithValue("@p1", comboBox1.Text);
                kmt.Parameters.AddWithValue("@p2", txtyapilan.Text);
                kmt.Parameters.AddWithValue("@p3", mskdtarih.Text);
                kmt.Parameters.AddWithValue("@p4", double.Parse(txttutar.Text));
                kmt.ExecuteNonQuery();
                txttutar.Clear();
                txtyapilan.Clear();
                mskdtarih.Clear();
                MessageBox.Show("Kayıt Başarılı", "Bildirim Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {

                MessageBox.Show("Kayıt Başarısız", "Lütfen Boş Bırakma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttutar.Clear();
                txtyapilan.Clear();
                mskdtarih.Clear();
            }
              
             bgl.baglanti().Close();
        }

     
        private void button3_Click_1(object sender, EventArgs e)
        {

            Gelirgider2 git = new Gelirgider2();
            git.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GelirGider1 gel = new GelirGider1();
            gel.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaEkran ana = new AnaEkran();
            ana.Show();
            this.Hide();
        }

        
    }

    }

