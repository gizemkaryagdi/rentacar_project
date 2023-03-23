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
    public partial class Anasayfa : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=rentacar;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            //label1.Enabled = true;
            //label1.Text = "     Araç Kiralama Otomasyonu     ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Müşteri_Ekleme musterieklemefrm = new Müşteri_Ekleme();
            musterieklemefrm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Müşteri_Listeleme musterilistefrm = new Müşteri_Listeleme();
            musterilistefrm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Araç_Ekleme araceklemefrm = new Araç_Ekleme();
            araceklemefrm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Araç_Listeleme araclistefrm = new Araç_Listeleme();
            araclistefrm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sözleşme sozlesmefrm = new Sözleşme();
            sozlesmefrm.Show();
            this.Hide();
        }
    }
}
