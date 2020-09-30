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
using DevExpress.Utils.Design;

namespace MusteriDetay
{
    public partial class GosterGuncelle : Form
    {
        public GosterGuncelle()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();
        private void GosterGuncelle_Load(object sender, EventArgs e)
        {
            tXTsİRA.Enabled = false;
            button1.Enabled = false;
            lbltoplamMustei.Parent = pictureBox1;
            lbltoplamMustei.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
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
            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;


            SqlDataAdapter da = new SqlDataAdapter("SELECT*FROM TBLMUSTERİ", bgl.baglanti());
            DataSet ds = new DataSet();
            da.Fill(ds, "TBLMUSTERİ");
            dataGridView1.DataSource = ds.Tables[0];
            bgl.baglanti().Close();
            try
            {
                string islem = "select count(ADSOYAD) as toplam from TBLMUSTERİ";
                SqlCommand komut = new SqlCommand(islem, bgl.baglanti());
                string deger = komut.ExecuteScalar().ToString();
                button1.Text += deger + "   Müşteri Kayıtlı";
                komut.ExecuteNonQuery(); // Komutu çalıştırıyoruz
                bgl.baglanti().Close(); // Bağlantıyı mutlaka kapatıyoruz
            }
            catch
            {
                MessageBox.Show("Hata Var Lütfen Tekrar Deneyiniz..", "   Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand ara = new SqlCommand("select * from TBLMUSTERİ where ADSOYAD like '%" + TxtAra.Text + "%'", bgl.baglanti());
                SqlDataAdapter da = new SqlDataAdapter(ara);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Hatali İşlem var..", " Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {
            try
            {
                int odenen, alacak, yeniborc;
                odenen = Convert.ToInt32(TxtBorcc.Text);
                alacak = Convert.ToInt32(TxtAlacak.Text);
                yeniborc = Convert.ToInt32(TxtBorcc.Text);

                yeniborc = odenen - alacak;
                TxtBorcc.Text = yeniborc.ToString();
                //yeni tutarı veri tabanına kaydetme




                bgl.baglanti().Close();
                string kayit = "update TBLMUSTERİ set ADSOYAD=@ADSOYAD,TELEFON=@TELEFON,ADRES=@ADRES,TARİH=@TARİH,VerilenUrun=@VerilenUrun,Borc=@Borc WHERE MUSTERİID=@MUSTERİID";



                SqlCommand komut = new SqlCommand(kayit, bgl.baglanti());
                komut.Parameters.AddWithValue("@MUSTERİID", tXTsİRA.Text);
                komut.Parameters.AddWithValue("@ADSOYAD", TxtAdSoyad.Text);
                komut.Parameters.AddWithValue("@TELEFON", TxtTel.Text);
                komut.Parameters.AddWithValue("@ADRES", RchAdres.Text);
                komut.Parameters.AddWithValue("@TARİH", DtTarih.Text);
                komut.Parameters.AddWithValue("@VerilenUrun", RchVerilenUrun.Text);
                komut.Parameters.AddWithValue("@Borc", TxtBorcc.Text);
                //0 Oldugu zaman Müzik çaldır.
                int dene;

                dene = Convert.ToInt32(TxtBorcc.Text.ToString());

                if (dene == 0)
                {
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = @"C:\Users\Mehmet\Desktop\CPROJELERİ\Salih\MusteriDetay\MusteriDetay\audıoo\ses.wav";
                    player.Play();

                }
                else
                {

                }
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Başarılı..", "Bilgi..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                GosterGuncelle gs = new GosterGuncelle();
                gs.Show();
                this.Hide();
                tXTsİRA.Clear();
                TxtAdSoyad.Clear();
                TxtTel.Clear();
                TxtBorcc.Clear();
                RchVerilenUrun.Clear();
                RchAdres.Clear();
                TxtAlacak.Clear();
                TxtAlacak.Text = "0";



            }


            catch
            {
                MessageBox.Show("Hatalı İşlem Var. Lütfen Güncellenecek Alanı Seçtikten Sonra İşlem Yapınız", "Uyarı..", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show("Hatalı İşlem Var.Lütfen Alacak Kısmına Boş Geçmek Yerine '0' yazınız, ", "Uyarı..", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            tXTsİRA.Clear();
            TxtAdSoyad.Clear();
            TxtTel.Clear();
            TxtBorcc.Clear();
            RchVerilenUrun.Clear();
            RchAdres.Clear();
        }

        private void BtnRapor_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;

            object Missing = Type.Missing;
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Missing);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                excel.Cells[StartCol, StartRow + j].Value = dataGridView1.Columns[j].HeaderText;
                excel.Cells[StartCol, StartRow + j].Font.Color = System.Drawing.Color.Blue;
                excel.Cells[StartCol, StartRow + j].Font.Size = 13;
                excel.Cells[StartCol, StartRow + j].ColumnWidth = 20;
                excel.Cells[StartCol, StartRow + j].Font.Bold = true;
                excel.Cells[StartCol, StartRow + j].Font.Name = "Arial Black";


            }
            StartRow++;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    try
                    {
                        DataGridViewCell cell = dataGridView1[j, i];
                        sheet1.Cells[i + 2, j + 1] = cell.Value;
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            AnaEkran ana1 = new AnaEkran();
            ana1.Show();
            this.Hide();
        }

        private void TxtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtAlacak_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen;

                string MUSTERİID, ADSOYAD, TELEFON, ADRES, VerilenUrun, Borc;

                secilen = dataGridView1.SelectedCells[0].RowIndex;
                MUSTERİID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                ADSOYAD = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                TELEFON = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                ADRES = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                VerilenUrun = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                Borc = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
                tXTsİRA.Text = MUSTERİID;
                TxtAdSoyad.Text = ADSOYAD;
                TxtTel.Text = TELEFON;
                RchAdres.Text = ADRES;
                RchVerilenUrun.Text = VerilenUrun;
                TxtBorcc.Text = Borc;
                //BorçAlacakHesaplatma
                label9.Text = "0";
                int eski, yeni,fark;
                eski = Convert.ToInt32(TxtBorcc.Text);
                yeni = Convert.ToInt32(label9.Text);
                fark = Convert.ToInt32(TxtAlacak.Text);
                fark = eski - yeni;
                TxtAlacak.Text = fark.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Boş Alan Seçmeyiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Btnsifirla_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLMUSTERİ where Borc>0", bgl.baglanti());
            DataSet ds = new DataSet();
            da.Fill(ds, "TBLMUSTERİ");
            dataGridView1.DataSource = ds.Tables[0];
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GosterGuncelle g = new GosterGuncelle();
            g.Show();
            this.Close();
        }
    }
}
 
