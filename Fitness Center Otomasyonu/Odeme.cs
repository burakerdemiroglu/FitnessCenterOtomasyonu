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
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=BURAK\SQLEXPRESS;Initial Catalog=FitnessUygulaması;Integrated Security=True");

        private void Fillname ()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select UyeAdSoyad from UyeTablo ", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("UyeAdSoyad", typeof(string));
            dt.Load(rdr);
            CombomaxAdSoyad.ValueMember = "UyeAdSoyad";
            CombomaxAdSoyad.DataSource = dt;
            baglanti.Close();
           
        }

        private void uyeler()
        {
            baglanti.Open();
            string query = "select * from OdemeTablo";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            OdemDGV.DataSource = ds.Tables[0];
            baglanti.Close();

        }
        private void AdFiltrele()
        {
            baglanti.Open();
            string query = "select * from OdemeTablo where OdemeUye='"+TxtAra.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            OdemDGV.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            AnaSayfa log = new AnaSayfa();
            log.Show();
            this.Hide();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CombomaxAdSoyad.Text = "";
            TxtTutar.Text = "";
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            Fillname();
            uyeler();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (CombomaxAdSoyad.Text == "" || TxtTutar.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                string odemeperiyot = Periyot.Value.Month.ToString() + Periyot.Value.Year.ToString();
                baglanti.Open();
                SqlDataAdapter sda =new SqlDataAdapter("select count(*) from OdemeTablo where OdemeUye='"+CombomaxAdSoyad.SelectedValue.ToString()+"' and OdemeAy='"+ odemeperiyot + "'",baglanti);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows[0][0].ToString()=="1")
                {
                    MessageBox.Show("Zaten Ödeme Yapıldı");
                }
                else
                {
                    string query = "insert into OdemeTablo values ('" + odemeperiyot + "','" + CombomaxAdSoyad.SelectedValue.ToString() + "'," + TxtTutar.Text + ")";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Tutar Başarıyla Ödendi");
                }
                baglanti.Close();
                uyeler();

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            AdFiltrele();
            TxtAra.Text = "";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            uyeler();
        }
    }
}
