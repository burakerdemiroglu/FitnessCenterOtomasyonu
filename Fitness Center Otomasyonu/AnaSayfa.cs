using System;
using System.Linq;
using System.Windows.Forms;

namespace Fitness_Center_Otomasyonu
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UyeEkle uye = new UyeEkle();
            uye.Show();
            this.Hide();


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GuncelleSil guncelle = new GuncelleSil();
            guncelle.Show();
            this.Hide();

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Odeme odeme = new Odeme();
            odeme.Show();
            this.Hide();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            UyeleriGoruntule uyeGoruntule = new UyeleriGoruntule();
            uyeGoruntule.Show();
            this.Hide();
        }
    }
}
