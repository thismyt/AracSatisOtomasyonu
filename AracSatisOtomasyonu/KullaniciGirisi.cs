using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace AracSatisOtomasyonu
{
    public partial class KullaniciGirisi : Form
    {
        public KullaniciGirisi()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP; Initial Catalog = dbalanuygulamasi; Integrated Security = True");

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen giriş bilgilerini doldurunuz");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcı adını boş bırakmayın");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen şifreyi boş bırakmayın");
            }
            else
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * From kullanici where Kullaniciadi='" + textBox1.Text.ToString() + "'", baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read() == true)
                {
                    if (textBox1.Text.ToString() == okuyucu["Kullaniciadi"].ToString() && textBox2.Text.ToString() == okuyucu["Sifre"].ToString())
                    {
                        Iletisim iletisim1 = new Iletisim();
                        iletisim1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlıştır. Lütfen kontrol ediniz");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlıştır. Lütfen kontrol ediniz");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                baglanti.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            YeniKullanici yenikullanici = new YeniKullanici();
            yenikullanici.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.mertveli.somee.com");
        }
    }
}
