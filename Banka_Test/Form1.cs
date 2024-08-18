using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banka_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-LO1OC4N\\SQLEXPRESS01;Initial Catalog=DbBankaTest;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lnkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from tblkisiler where hesap=@hesap and sifre=@sifre", baglan);
            komut.Parameters.AddWithValue("@hesap", mtbHesapNo.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 form2 = new Form2();
                form2.hesapno = mtbHesapNo.Text;
                form2.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("hatali bilgi");
            }
            baglan.Close();
        }
    }
}
