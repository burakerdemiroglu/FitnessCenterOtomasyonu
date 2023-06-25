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
    public partial class UyeEkle : Form
    {
        public UyeEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=BURAK\SQLEXPRESS;Initial Catalog=FitnessUygulaması;Integrated Security=True");

        private void UyeEkle_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (TxtUyeAdıSoyad.Text == "" || maskTelefon.Text == "" || TxtAylıkTutar.Text == "" || TxtYas.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = $"insert into UyeTablo values('{TxtUyeAdıSoyad.Text}','{maskTelefon.Text}','{comboBoxCinsiyet.Text}',{TxtYas.Text},{TxtAylıkTutar.Text},'{comboBoxZamanlama.Text}')";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Eklendi");
                    baglanti.Close();
                    TxtUyeAdıSoyad.Text = "";
                    maskTelefon.Text = "";
                    TxtAylıkTutar.Text = "";
                    TxtYas.Text = "";
                    comboBoxCinsiyet.Text = "";
                    comboBoxZamanlama.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Hata var.\n" + Ex.Message);
                }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            TxtUyeAdıSoyad.Text = "";
            maskTelefon.Text = "";
            TxtAylıkTutar.Text= "";
            TxtYas.Text = "";
            comboBoxCinsiyet.Text = "";
            comboBoxZamanlama.Text = "";
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            AnaSayfa log = new AnaSayfa();
            log.Show();
            this.Hide();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
