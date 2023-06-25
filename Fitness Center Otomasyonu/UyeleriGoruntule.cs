using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Fitness_Center_Otomasyonu
{
    public partial class UyeleriGoruntule : Form
    {
        public UyeleriGoruntule()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=BURAK\SQLEXPRESS;Initial Catalog=FitnessUygulaması;Integrated Security=True");


        private void uyeler ()
        {
            baglanti.Open();
            string query = "select * from UyeTablo";
            SqlDataAdapter sda = new SqlDataAdapter(query,baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            UyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();

        }



        private void UyeleriGoruntule_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            AnaSayfa log = new AnaSayfa();
            log.Show();
            this.Hide();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            uyeler();
        }
        private void AdFiltrele()
        {
            baglanti.Open();
            string query = "select * from UyeTablo where UyeAdSoyad='" + txtUyeAra.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            UyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AdFiltrele();
            txtUyeAra.Text = "";
        }
    }
}
