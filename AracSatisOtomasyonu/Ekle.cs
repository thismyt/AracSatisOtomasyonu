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
    public partial class Ekle : Form
    {
        public Ekle()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP; Initial Catalog = dbalanuygulamasi; Integrated Security = True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter adtr = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void button3_Click(object sender, EventArgs e)
        {
            Iletisim iletisim = new Iletisim();
            iletisim.Show();
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                textBox13.Text = openFileDialog1.FileName;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox13.Text = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
            textBox12.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            textBox11.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox13.Text = pictureBox1.ImageLocation;
            if (textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && textBox5.Text != "" && comboBox2.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox3.Text != "")
            {
                komut.Connection = baglanti;
                komut.CommandText = "Insert Into arac(Marka,Seri,Model,Kasa,Vites,KM,Yil,Yakit,Durumu,Fiyat,Aciklama,Resim) Values ('" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + comboBox3.Text + "','" + comboBox1.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "')";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                ds.Clear();
                listele();
            }
            else
            {
                MessageBox.Show("Boş alan geçmeyiniz!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void listele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from arac", baglanti);
            adtr.Fill(ds, "arac");
            dataGridView1.DataSource = ds.Tables["arac"];
            adtr.Dispose();
            baglanti.Close();
        }

        private void Ekle_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Report rapor = new Report();
            rapor.Show();
            this.Hide();
        }
    }
}
