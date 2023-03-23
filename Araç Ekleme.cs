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
    public partial class Araç_Ekleme : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public Araç_Ekleme()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void Araç_Ekleme_Load(object sender, EventArgs e)
        {

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
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a_plaka,a_marka,a_seri,a_model,a_renk,a_km,a_yakit,a_kira,a_durum;           
            komut =new SqlCommand("insert into tbl_Araclar (Arac_Plaka,Arac_Marka,Arac_Seri,Arac_Model,Arac_Renk,Arac_Km,Arac_Yakıt,Arac_Kira_Ücreti,Arac_Durum) values (@a_plaka,@a_marka,@a_seri,@a_model,@a_renk,@a_km,@a_yakit,@a_kira,@a_durum)", baglanti);
            komut.Parameters.AddWithValue("@a_plaka", textBox1.Text);
            komut.Parameters.AddWithValue("@a_marka", comboBox1.Text);
            komut.Parameters.AddWithValue("@a_seri", comboBox2.Text);
            komut.Parameters.AddWithValue("@a_model", textBox2.Text);
            komut.Parameters.AddWithValue("@a_renk", textBox3.Text);
            komut.Parameters.AddWithValue("@a_km", textBox4.Text);
            komut.Parameters.AddWithValue("@a_yakit", comboBox3.Text);
            komut.Parameters.AddWithValue("@a_kira", textBox5.Text);
            komut.Parameters.AddWithValue("@a_durum", comboBox4.Text);

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox3.Text = "";
            textBox5.Text = "";
            comboBox4.Text = "";

            MessageBox.Show("Araç Başarıyla Kaydedildi.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfafrm = new Anasayfa();
            anasayfafrm.Show();
            this.Hide();
        }
    }
}
