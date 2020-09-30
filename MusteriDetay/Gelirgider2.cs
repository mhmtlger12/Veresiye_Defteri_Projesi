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
using System.Globalization;

namespace MusteriDetay
{
    public partial class Gelirgider2 : Form
    {
        public Gelirgider2()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void Gelirgider2_Load(object sender, EventArgs e)
        {

            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            SqlDataAdapter hesaplama = new SqlDataAdapter("select YEAR(Tarih) as Yıl,  MONTH(Tarih) as Ay,SUM(Borc) as Toplam from islemler  group by YEAR(Tarih), MONTH(Tarih)order by Yıl, Ay", bgl.baglanti());

            DataTable hesap = new DataTable();
            hesaplama.Fill(hesap);
            datahesaplama.DataSource = hesap;
            bgl.baglanti().Close();

            //datagrıdvıewe yillik hesaplamaları yazdırma


            SqlDataAdapter hesaplamayil = new SqlDataAdapter("select YEAR(Tarih) as Yıl,SUM(Borc) as Toplam from islemler group by YEAR(Tarih)", bgl.baglanti());

            DataTable yil = new DataTable();
            hesaplamayil.Fill(yil);
            datagridyillik.DataSource = yil;
            bgl.baglanti().Close();


            SqlDataAdapter da_GetDetails = new SqlDataAdapter("select KategoriID AS KategoriKimlik ,KategoriAD as KategoriAdı,Yapilanİslem as Yapılanişlem,Tarih,Borc as Tutar from islemler ", bgl.baglanti());


            DataTable dt = new DataTable();
            da_GetDetails.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();

            SqlCommand komut = new SqlCommand("Select DISTINCT KategoriAD FROM islemler ", bgl.baglanti());

            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                {
                    comboBox1.Items.Add(dr["KategoriAD"]);
                }

            }

            bgl.baglanti().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
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
            try
            {
               
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;

                object Missing = Type.Missing;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Missing);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                for (int j = 0; j < datahesaplama.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = datahesaplama.Columns[j].HeaderText;

                    excel.Cells[StartCol, StartRow + j].Value = datahesaplama.Columns[j].HeaderText;
                    excel.Cells[StartCol, StartRow + j].Font.Color = System.Drawing.Color.Blue;
                    excel.Cells[StartCol, StartRow + j].Font.Size = 13;
                    excel.Cells[StartCol, StartRow + j].ColumnWidth = 22;
                    excel.Cells[StartCol, StartRow + j].Font.Bold = true;
                    excel.Cells[StartCol, StartRow + j].Font.Name = "Arial Black";
                    excel.Cells[StartCol, StartRow + j].Font.Name = "Arial Black";



                }
                StartRow++;
                for (int i = 0; i < datahesaplama.Rows.Count; i++)
                {

                    for (int j = 0; j < datahesaplama.Columns.Count; j++)
                    {
                        try
                        {

                            DataGridViewCell cell = datahesaplama[j, i];
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
            try
            {

                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;

                object Missing = Type.Missing;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Missing);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                for (int j = 0; j < datahesaplama.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = datahesaplama.Columns[j].HeaderText;

                    excel.Cells[StartCol, StartRow + j].Value = datahesaplama.Columns[j].HeaderText;
                    excel.Cells[StartCol, StartRow + j].Font.Color = System.Drawing.Color.Blue;
                    excel.Cells[StartCol, StartRow + j].Font.Size = 13;
                    excel.Cells[StartCol, StartRow + j].ColumnWidth = 22;
                    excel.Cells[StartCol, StartRow + j].Font.Bold = true;
                    excel.Cells[StartCol, StartRow + j].Font.Name = "Arial Black";
                    excel.Cells[StartCol, StartRow + j].Font.Name = "Arial Black";



                }
                StartRow++;
                for (int i = 0; i < datahesaplama.Rows.Count; i++)
                {

                    for (int j = 0; j < datahesaplama.Columns.Count; j++)
                    {
                        try
                        {

                            DataGridViewCell cell = datahesaplama[j, i];
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Columns[1].Visible = false;
            //cmb ue bilgileri çekme

            SqlDataAdapter da_GetDetails = new SqlDataAdapter("select KategoriID AS KategoriKimlik ,KategoriAD as KategoriAdı,Yapilanİslem as Yapılanişlem,Tarih,Borc as Tutar from islemler  WHERE KategoriAD='" + comboBox1.SelectedItem + "'", bgl.baglanti());

            DataTable dt = new DataTable();
            da_GetDetails.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
            //datagrıdvıewe hesaplamaları yazdırma


            SqlDataAdapter hesaplama = new SqlDataAdapter("select YEAR(Tarih) as Yıl,  MONTH(Tarih) as Ay,SUM(Borc) as Toplam from islemler where KategoriAD='" + comboBox1.Text + "' group by YEAR(Tarih), MONTH(Tarih)order by Yıl, Ay", bgl.baglanti());

            DataTable hesap = new DataTable();
            hesaplama.Fill(hesap);
            datahesaplama.DataSource = hesap;
            bgl.baglanti().Close();

            //datagrıdvıewe yillik hesaplamaları yazdırma


            SqlDataAdapter hesaplamayil = new SqlDataAdapter("select YEAR(Tarih) as Yıl,SUM(Borc) as Toplam from islemler where KategoriAD='" + comboBox1.Text + "'  group by YEAR(Tarih)", bgl.baglanti());

            DataTable yil = new DataTable();
            hesaplamayil.Fill(yil);
            datagridyillik.DataSource = yil;
            bgl.baglanti().Close();


        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
        
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GelirGider1 gel = new GelirGider1();
            gel.Show();
            this.Hide();
        }
    }
    }
