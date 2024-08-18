using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banka_Test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-LO1OC4N\\SQLEXPRESS01;Initial Catalog=DbBankaTest;Integrated Security=True");

        void temizle()
        {
            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
                if (item is MaskedTextBox)
                {
                    ((MaskedTextBox)item).Text = "";
                }
            }
        }
        void kaydet()
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("insert into tblkisiler (ad,soyad,tc,telefon,hesap,sifre) values (@ad,@soyad,@tc,@telefon,@hesap,@sifre)", baglan);
            cmd.Parameters.AddWithValue("@ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@tc", mtbTc.Text);
            cmd.Parameters.AddWithValue("@telefon", mtbTel.Text);
            cmd.Parameters.AddWithValue("@hesap", mtbHesapNo.Text);
            cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);

            SqlCommand komut = new SqlCommand("insert into tblhesap (hesapno) select hesap from tblkisiler ", baglan);
            komut.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("bilgiler kaydedildi");

        }
 

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            kaydet();
            temizle();

        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            Random random=new Random();
            int sayi=random.Next(100000,1000000);
            mtbHesapNo.Text=sayi.ToString();
       
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
