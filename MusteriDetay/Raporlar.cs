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
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            SqlDataAdapter da_GetDetails = new SqlDataAdapter("select MUSTERİID,ADSOYAD as ADISOYADI,TELEFON,ADRES,TARİH,VerilenUrun AS VerilenÜrün,Borc as Borç from TBLHAREKETLER  WHERE ADSOYAD='" + comboBox1.SelectedItem + "'", bgl.baglanti());

            DataTable dt = new DataTable();
            da_GetDetails.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
            dataGridView1.Columns[0].Visible = false;

            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Raporlar_Load(object sender, EventArgs e)
        {
            try
            {
                cmbkimlik.Enabled = false;
                label2.Parent = groupBox1;
                label2.BackColor = Color.Transparent;
                label1.Parent = groupBox1;
                label1.BackColor = Color.Transparent;
                SqlCommand komut = new SqlCommand("Select DISTINCT ADSOYAD FROM TBLHAREKETLER", bgl.baglanti());

                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    {
                        comboBox1.Items.Add(dr["ADSOYAD"]);

                    }

                }

                bgl.baglanti().Close();

            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               cmbkimlik.Items.Clear();
            SqlCommand komut = new SqlCommand("Select  MUSTERİID FROM TBLHAREKETLER WHERE ADSOYAD='" + comboBox1.SelectedItem + "'", bgl.baglanti());

            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                {

                    cmbkimlik.SelectedIndex = cmbkimlik.Items.Add(dr["MUSTERİID"].ToString());
                }

            }

            bgl.baglanti().Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaEkran ana = new AnaEkran();
            ana.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show("Lütfen Bekleyiniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    excel.Cells[StartCol, StartRow + j].ColumnWidth = 22;
                    excel.Cells[StartCol, StartRow + j].Font.Bold = true;
                    excel.Cells[StartCol, StartRow + j].Font.Name = "Arial Black";
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
            catch (Exception)
            {

                MessageBox.Show("Hatalı İşlem Var", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

            SqlDataAdapter da_GetDetails = new SqlDataAdapter("select MUSTERİID, ADSOYAD as ADISOYADI,TELEFON,ADRES,TARİH,VerilenUrun AS VerilenÜrün,Borc as Borç from TBLHAREKETLER ", bgl.baglanti());


            DataTable dt = new DataTable();
            da_GetDetails.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
            dataGridView1.Columns[0].Visible = false;
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

                SqlCommand ara = new SqlCommand("select  MUSTERİID, ADSOYAD as ADISOYADI,TELEFON,ADRES,TARİH,VerilenUrun AS VerilenÜrün,Borc as Borç from TBLHAREKETLER where ADSOYAD like '%" + TxtAra.Text + "%'", bgl.baglanti());
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


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //datagridview daki bilgileri yazdırıyoruz.

            Bitmap bmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);

            dataGridView1.DrawToBitmap(bmap, new Rectangle(0, 0,dataGridView1.Width, dataGridView1.Height));

            e.Graphics.DrawImage(bmap, 20, 20, 600, 500);

        }

     
        private void button6_Click_1(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int secilen;

                string MUSTERİID;

                secilen = dataGridView1.SelectedCells[0].RowIndex;
                MUSTERİID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();



                cmbkimlik.Text = MUSTERİID;

            }
            catch (Exception)
            {
                MessageBox.Show("Hata!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

       
    }
}
            
            
   