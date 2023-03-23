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
    public partial class Müşteri_Ekleme : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public Müşteri_Ekleme()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string m_tc,m_as,m_tel,m_posta,m_adres;
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty) 
                MessageBox.Show("Tüm Alanlar Doldurulmalıdır...");
            else
                komut = new SqlCommand("insert into tbl_Musteriler(Musteri_Tc,Musteri_Ad_Soyad,Musteri_Tel,Musteri_Eposta,Musteri_Adres) values (@m_tc,@m_as,@m_tel,@m_posta,@m_adres)", baglanti);
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
            MessageBox.Show("Kişi Başarıyla Kaydedildi.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfafrm = new Anasayfa();
            anasayfafrm.Show();
            this.Hide();
        }
    }
}
