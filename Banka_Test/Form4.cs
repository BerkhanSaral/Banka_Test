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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-LO1OC4N\\SQLEXPRESS01;Initial Catalog=DbBankaTest;Integrated Security=True");

        void load()
        {
            SqlDataAdapter da= new SqlDataAdapter("select * from tblhareket",baglan);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            //dataGridView1.DataSource = dt;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
