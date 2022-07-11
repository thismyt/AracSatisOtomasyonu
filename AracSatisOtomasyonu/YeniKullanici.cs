using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AracSatisOtomasyonu
{
    public partial class YeniKullanici : Form
    {
        public YeniKullanici()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP; Initial Catalog = dbalanuygulamasi; Integrated Security = True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter adtr = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnKayıtOl_Click(object sender, EventArgs e)
        {
            TxtFoto.Text = pictureBox1.ImageLocation;
            if (TxtAd.Text != "" && TxtSoyad.Text != "" && TxtFoto.Text != "" && TxtTC.Text != "" && TxtTel.Text != "" && TxtKadi.Text != "" && TxtSifre.Text != "" && comboBox1.Text != "")
            {
                komut.Connection = baglanti;
                komut.CommandText = "Insert Into kullanici(Ad,Soyad,TCno,Telno,Cinsiyet,Kullaniciadi,Sifre,Resim) Values ('" + TxtAd.Text + "','" + TxtSoyad.Text + "','" + TxtTC.Text + "','" + TxtTel.Text + "','" + comboBox1.Text + "','" + TxtKadi.Text + "','" + TxtSifre.Text + "','" + TxtFoto.Text + "')";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                ds.Clear();
                KullaniciGirisi kullanici = new KullaniciGirisi();
                kullanici.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Boş alan geçmeyiniz!");
            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                TxtFoto.Text = openFileDialog1.FileName;
            }
        }
    }
}
