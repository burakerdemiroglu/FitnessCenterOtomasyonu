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
using DevExpress.XtraGrid.Views.Grid;

namespace Fitness_Center_Otomasyonu
{
    public partial class GuncelleSil : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=BURAK\SQLEXPRESS;Initial Catalog=FitnessUygulaması;Integrated Security=True");

        public GuncelleSil()
        {
            InitializeComponent();
        }
        int key = 0;
        private void UyeDGV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1) // Sol fare düğmesine tek tıklama kontrolü
            {
                var gridView = gridView1; // gridView değişkeni, gridView1 adlı bir Grid Control nesnesini temsil eder 
                var hitInfo = gridView.CalcHitInfo(e.Location); // Tıklama konumuna göre hitInfo nesnesi oluşturulur 
                if (hitInfo.InRow) // Eğer tıklama bir satırın içinde gerçekleşmişse
                {
                    var selectedRow = gridView.GetDataRow(hitInfo.RowHandle); // Seçilen satırın verilerini içeren bir DataRow nesnesi elde edilir

                    if (selectedRow != null) // Seçilen satır null değilse
                    {
                        
                        key = Convert.ToInt32(selectedRow["Uyeid"].ToString());
                        TxtUyeAd.Text = selectedRow["UyeAdSoyad"].ToString(); // UyeAdSoyad sütunundaki değer, TxtUyeAd TextBox'ına atanır
                        TxtTelefon.Text = selectedRow["UyeTelefon"].ToString(); // UyeTelefon sütunundaki değer, txtTelefon1 TextBox'ına atanır
                        comboBoxCinsiyet.Text = selectedRow["UyeCinsiyet"].ToString(); // UyeCinsiyet sütunundaki değer, comboBoxCinsiyet ComboBox'ına atanır
                        TxtYas.Text = selectedRow["UyeYas"].ToString(); // UyeYas sütunundaki değer, TxtYas TextBox'ına atanır
                        TxtAylıkTutar.Text = selectedRow["UyeOdeme"].ToString(); // UyeOdeme sütunundaki değer, TxtAylıkTutar TextBox'ına atanır
                        comboBoxZamanlama.Text = selectedRow["UyeZamanlama"].ToString(); // UyeZamanlama sütunundaki değer, comboBoxZamanlama ComboBox'ına atanır
                    }
                }
            }

        }

        private void uyeler()
        {
            baglanti.Open();
            string query = "select * from UyeTablo";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            UyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        private void GuncelleSil_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            TxtUyeAd.Text = "";
            TxtTelefon.Text = "";
            TxtAylıkTutar.Text = "";
            TxtYas.Text = "";
            comboBoxCinsiyet.Text = "";
            comboBoxZamanlama.Text = "";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            AnaSayfa log = new AnaSayfa();
            log.Show();
            this.Hide();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Üyeyi Seçiniz");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "delete from UyeTablo where Uyeid=" + key + ";";
                    SqlCommand komut = new SqlCommand(query,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Silindi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message );
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (key == 0 || TxtUyeAd.Text==""|| TxtTelefon.Text ==""||TxtYas.Text==""||TxtAylıkTutar.Text==""||comboBoxCinsiyet.Text==""||comboBoxZamanlama.Text=="")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update UyeTablo set UyeAdSoyad='" + TxtUyeAd.Text + "',UyeTelefon='" + TxtTelefon.Text + "', UyeCinsiyet= '" + comboBoxCinsiyet.Text + "',UyeYas='" + TxtYas.Text + "',UyeOdeme='" + TxtAylıkTutar.Text + "',UyeZamanlama='" + comboBoxZamanlama.Text + "' where Uyeid=" + key + ";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Güncellendi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
