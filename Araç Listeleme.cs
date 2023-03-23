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

namespace rentacar_project
{
    public partial class Araç_Listeleme : Form
    {
        //SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ornekDers;Integrated Security=True");
        //SqlCommand komut = new SqlCommand();
        //SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        public Araç_Listeleme()
        {
            InitializeComponent();
        }

        public void Arac_Listele()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();

            string komutcümlesi = "select * from tbl_Araclar";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Items.Clear();
                comboBox2.Text = "";

                comboBox2.Items.Add("GIULIA");
                comboBox2.Items.Add("STELVIO");
                comboBox2.Items.Add("TONALE");
                comboBox2.Items.Add("QUADRIFOGLIO");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Items.Clear();
                comboBox2.Text = "";

                comboBox2.Items.Add("DB7");
                comboBox2.Items.Add("DB9");
                comboBox2.Items.Add("DBS");
                comboBox2.Items.Add("RAPIDE");
                comboBox2.Items.Add("VANQUISH");
                comboBox2.Items.Add("VANTAGE");
                comboBox2.Items.Add("VIRAGE");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.Items.Clear();
                comboBox2.Text = "";

                comboBox2.Items.Add("A3 SPORTBACK");
                comboBox2.Items.Add("A3 SEDAN");
                comboBox2.Items.Add("S3 SPORTBACK");
                comboBox2.Items.Add("S3 SEDAN");
                comboBox2.Items.Add("A4 SEDAN");
                comboBox2.Items.Add("A4 AVANT");
                comboBox2.Items.Add("A4 ALLROAD QUATTRO");
                comboBox2.Items.Add("A5 COUPÈ");
                comboBox2.Items.Add("A5 SPORTBACK");
                comboBox2.Items.Add("A5 CABRİO");
                comboBox2.Items.Add("RS 5 SOORTBACK");
                comboBox2.Items.Add("A6 SEDAN");
                comboBox2.Items.Add("A6 AVANT");
                comboBox2.Items.Add("A6 ALLROAD QUATTRO");
                comboBox2.Items.Add("RS 6 AVANT");
                comboBox2.Items.Add("A7 SPORTBACK");
                comboBox2.Items.Add("A8");
                comboBox2.Items.Add("S8");
                comboBox2.Items.Add("Q2");
                comboBox2.Items.Add("Q3");
                comboBox2.Items.Add("Q3 SPORTBACK");
                comboBox2.Items.Add("RS Q3 SPORTBACK");
                comboBox2.Items.Add("Q5");
                comboBox2.Items.Add("Q5 SPORTBACK");
                comboBox2.Items.Add("Q7");
                comboBox2.Items.Add("Q8");
                comboBox2.Items.Add("RS Q8");
            }
        }
        private void Araç_Listeleme_Load(object sender, EventArgs e)
        {
            Arac_Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {           
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();

            string komutcümlesi = "update tbl_Araclar set Arac_Marka=@marka,Arac_Seri=@seri,Arac_Model=@model,Arac_Renk=@renk,Arac_Km=@km,Arac_Yakıt=@yakıt,Arac_Kira_Ücreti=@kira,Arac_Durum=@durum where Arac_Plaka=@plaka";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);
            komut.Parameters.AddWithValue("@plaka", textBox1.Text);
            komut.Parameters.AddWithValue("@marka", comboBox1.Text);
            komut.Parameters.AddWithValue("@seri", comboBox2.Text);
            komut.Parameters.AddWithValue("@model", textBox2.Text);
            komut.Parameters.AddWithValue("@renk", textBox3.Text);
            komut.Parameters.AddWithValue("@km", textBox4.Text);
            komut.Parameters.AddWithValue("@yakıt", comboBox3.Text);
            komut.Parameters.AddWithValue("@kira",textBox5.Text);
            komut.Parameters.AddWithValue("@durum", comboBox4.Text);
            komut.ExecuteNonQuery();                
            baglanti.Close();
            Arac_Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();

            string komutcümlesi = "delete from tbl_Araclar where Arac_Plaka='" + dataGridView1.CurrentRow.Cells["Arac_Plaka"].Value.ToString() + "'";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Arac_Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfafrm = new Anasayfa();
            anasayfafrm.Show();
            this.Hide();
        }
    }
}
