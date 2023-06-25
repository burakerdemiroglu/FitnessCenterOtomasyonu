using System;
using System.Linq;
using System.Windows.Forms;

namespace Fitness_Center_Otomasyonu
{
    public partial class Login : Form 
    {
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
            if(TxtKullaniciAdi.Text==""||TxtSifre.Text=="")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else if(TxtKullaniciAdi.Text=="Admin" && TxtSifre.Text == "123456")
            {
                AnaSayfa log = new AnaSayfa();
                log.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalaı Kullanıcı Adı veya Şifre");
            }
        }
    }
}
