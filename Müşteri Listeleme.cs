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
    public partial class Müşteri_Listeleme : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ornekDers;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public Müşteri_Listeleme()
        {
            InitializeComponent();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Müşteri_Listeleme_Load(object sender, EventArgs e)
        {
            Müşteri_Listele();
        }

        public void Müşteri_Listele()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();

            string komutcümlesi = "select * from tbl_Musteriler";
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
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();

            string komutcümlesi="update tbl_Musteriler set Musteri_Ad_Soyad=@m_as,Musteri_Tel=@m_tel,Musteri_Eposta=@m_posta,Musteri_Adres=@m_adres where Musteri_Tc=@m_tc";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);

            komut.Parameters.AddWithValue("@m_tc", textBox1.Text);
            komut.Parameters.AddWithValue("@m_as", textBox2.Text);
            komut.Parameters.AddWithValue("@m_tel", textBox3.Text);
            komut.Parameters.AddWithValue("@m_posta", textBox4.Text);
            komut.Parameters.AddWithValue("@m_adres", textBox5.Text);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();

            string komutcümlesi = "delete from tbl_Musteriler where Musteri_Tc='" + dataGridView1.CurrentRow.Cells["Musteri_Tc"].Value.ToString() + "'";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Müşteri_Listele();
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Anasayfa anasayfafrm = new Anasayfa();
            anasayfafrm.Show();
            this.Hide();
        }
    }
}
