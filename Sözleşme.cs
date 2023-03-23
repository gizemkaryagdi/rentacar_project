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
    public partial class Sözleşme : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ornekDers;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public Sözleşme()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Arac_Listele()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();

            string komutcümlesi = "select * from tbl_Araclar where Arac_Durum='Boş'";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Arac_Plaka"]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Sözleşme_Load(object sender, EventArgs e)
        {
            Arac_Listele();
            Sozlesme_Listele();
        }

        public void Sozlesme_Listele()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();
            string komutcümlesi = "select * from tbl_Sozlesme";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource=dt;
            baglanti.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();
            string komutcümlesi = "select * from tbl_Araclar where Arac_Plaka like '" + comboBox1.SelectedItem + "'";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox7.Text = dr["Arac_Marka"].ToString();
                textBox8.Text = dr["Arac_Seri"].ToString();
                textBox9.Text = dr["Arac_Model"].ToString();
                textBox10.Text = dr["Arac_Renk"].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TimeSpan fark = DateTime.Parse(dateTimePicker2.Text) - DateTime.Parse(dateTimePicker1.Text);
            int hesapla = fark.Days;
            textBox12.Text = hesapla.ToString();
            textBox13.Text = (hesapla * int.Parse(textBox11.Text)).ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();
            string komutcümlesi = "select Arac_Kira_Ücreti from tbl_Araclar";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                if(comboBox2.SelectedIndex==0)
                {
                    textBox11.Text = (int.Parse(dr["Arac_Kira_Ücreti"].ToString()) * 3).ToString();
                }
                else if (comboBox2.SelectedIndex==1)
                {
                    textBox11.Text = (int.Parse(dr["Arac_Kira_Ücreti"].ToString()) * 2).ToString();
                }
                else if (comboBox2.SelectedIndex==2)
                {
                    textBox11.Text = (int.Parse(dr["Arac_Kira_Ücreti"].ToString()) * 1).ToString();
                }
            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");          
            baglanti.Open();
            string komutcümlesi = "insert into tbl_Sozlesme values (@tc,@adsoyad,@tel,@ehliyet_no,@ehliyet_tarih,@plaka,@marka,@seri,@model,@renk,@kirasekli,@kiraucreti,@gunsayisi,@ucret,@basla,@bitis)";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);

            komut.Parameters.AddWithValue("@tc", textBox2.Text);
            komut.Parameters.AddWithValue("@adsoyad", textBox3.Text);
            komut.Parameters.AddWithValue("@tel", textBox4.Text);
            komut.Parameters.AddWithValue("@ehliyet_no", textBox5.Text);
            komut.Parameters.AddWithValue("@ehliyet_tarih", textBox6.Text);
            komut.Parameters.AddWithValue("@plaka", comboBox1.Text);
            komut.Parameters.AddWithValue("@marka", textBox7.Text);
            komut.Parameters.AddWithValue("@seri", textBox8.Text);
            komut.Parameters.AddWithValue("@model", textBox9.Text);
            komut.Parameters.AddWithValue("@renk", textBox10.Text);
            komut.Parameters.AddWithValue("@kirasekli", comboBox2.Text);
            komut.Parameters.AddWithValue("@kiraucreti", textBox11.Text);
            komut.Parameters.AddWithValue("@gunsayisi", textBox12.Text);
            komut.Parameters.AddWithValue("@ucret", textBox13.Text);
            komut.Parameters.AddWithValue("@basla", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@bitis", dateTimePicker2.Text);
            
            string komutcumlesi = "update tbl_Araclar set Arac_Durum='Dolu' where Arac_Plaka='" + comboBox1.SelectedItem + "'";
            SqlCommand komut2 = new SqlCommand(komutcumlesi, baglanti);

            komut.ExecuteNonQuery();
            komut2.ExecuteNonQuery();
            Sozlesme_Listele();
            Arac_Listele();

            MessageBox.Show("Kayıt Başarıyla Gerçekleştirildi.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();
            string komutcümlesi=" select * from tbl_Musteriler where Musteri_Tc like '"+textBox1.Text+"'";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr["Musteri_Tc"].ToString();
                textBox3.Text = dr["Musteri_Ad_Soyad"].ToString();
                textBox4.Text = dr["Musteri_Tel"].ToString();              
            }
            baglanti.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();

            string komutcümlesi = "delete from tbl_Sozlesme where Sozlesme_ID='" + dataGridView1.CurrentRow.Cells["Sozlesme_ID"].Value.ToString() + "'";
            SqlCommand komut = new SqlCommand(komutcümlesi, baglanti);

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Arac_Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfafrm = new Anasayfa();
            anasayfafrm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

