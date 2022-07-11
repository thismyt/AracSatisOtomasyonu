using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracSatisOtomasyonu
{
    public partial class Iletisim : Form
    {
        public Iletisim()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Iletisim_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ekle ekle = new Ekle();
            ekle.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Düzenle duzenle = new Düzenle();
            duzenle.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listele listele = new Listele();
            listele.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ara ara = new Ara();
            ara.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Report rapor = new Report();
            rapor.Show();
            this.Hide();
        }
    }
}
