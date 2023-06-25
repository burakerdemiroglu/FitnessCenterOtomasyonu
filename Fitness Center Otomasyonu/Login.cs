using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Fitness_Center_Otomasyonu
{
    public partial class Login : Form 
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=BURAK\SQLEXPRESS;Initial Catalog=FitnessUygulaması;Integrated Security=True");

        public Login()
        {
            InitializeComponent();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            TxtKullaniciAdi.Text = "";
            TxtSifre.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                String sql = "select * from Kullanicilar where Kullanici=@Kullaniciadi AND Sifre=@Sifresi";
                SqlParameter prm1 = new SqlParameter("@Kullaniciadi", TxtKullaniciAdi.Text.Trim());
                SqlParameter prm2 = new SqlParameter("@Sifresi", TxtSifre.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    AnaSayfa fr = new AnaSayfa();
                    fr.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {
                baglanti.Close();
                MessageBox.Show("Hatalı Giriş");
            }
        }
    }
}
