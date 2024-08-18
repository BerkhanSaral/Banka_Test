using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banka_Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-LO1OC4N\\SQLEXPRESS01;Initial Catalog=DbBankaTest;Integrated Security=True");

        public string adsoyad, hesapno, tel, tc;

        private void btnHareket_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {//gonderilen hesabin para artisi
            baglan.Open();
            SqlCommand komut = new SqlCommand("update tblhesap set bakiye=bakiye+@bakiye where hesapno=@hesapno",baglan);
            komut.Parameters.AddWithValue("@hesapno", mtbHesapNo.Text);
            komut.Parameters.AddWithValue("@bakiye", decimal.Parse(txtTutar.Text));
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("islem basarili");

            //gonderen hesabin para azalisi
            baglan.Open();
            SqlCommand sqlCommand = new SqlCommand("update tblhesap set bakiye=bakiye-@bakiye2 where hesapno=@hesapno2", baglan);
            sqlCommand.Parameters.AddWithValue("@hesapno2",hesapno);
            sqlCommand.Parameters.AddWithValue("@bakiye2",decimal.Parse(txtTutar.Text));
            sqlCommand.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("islem basarili");

            //hareket
            /*
            baglan.Open();
            SqlDataAdapter da=new SqlDataAdapter("select tblhareket.gonderen,tblhareket.alici from tblhareket inner join tblhesap\r\non tblhareket.gonderen=tblhesap.hesapno", baglan);
            DataTable table2 =new DataTable();
            da.Fill(table2);
            dataGridView1.DataSource = table2;
            baglan.Close();
            */

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            lblHesapNo.Text = hesapno;
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from tblkisiler where hesap=@hesap", baglan);
            komut.Parameters.AddWithValue("@hesap", hesapno);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                lblAdSoyad.Text = reader[1] + " " + reader[2];
                lblTc.Text = reader[3].ToString();
                lblTelefon.Text = reader[4].ToString();
            }
            baglan.Close();

        }
    }
}
