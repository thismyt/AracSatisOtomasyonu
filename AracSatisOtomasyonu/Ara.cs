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
    public partial class Ara : Form
    {
        public Ara()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP; Initial Catalog = dbalanuygulamasi; Integrated Security = True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter adtr = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable tablo = new DataTable();
        void listele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from arac", baglanti);
            adtr.Fill(ds, "arac");
            dataGridView1.DataSource = ds.Tables["arac"];
            adtr.Dispose();
            baglanti.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Iletisim iletisim = new Iletisim();
            iletisim.Show();
            this.Hide();
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                baglanti.Open();
                tablo.Clear();
                SqlDataAdapter adap = new SqlDataAdapter("select * from arac where Marka='" + textBox1.Text + "'", baglanti);
                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            else if (radioButton2.Checked)
            {
                baglanti.Open();
                tablo.Clear();
                SqlDataAdapter adap = new SqlDataAdapter("select * from arac where Seri='" + textBox1.Text + "'", baglanti);
                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            else if (radioButton3.Checked)
            {
                baglanti.Open();
                tablo.Clear();
                SqlDataAdapter adap = new SqlDataAdapter("select * from arac where Model='" + textBox1.Text + "'", baglanti);
                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            else if (radioButton4.Checked)
            {
                baglanti.Open();
                tablo.Clear();
                SqlDataAdapter adap = new SqlDataAdapter("select * from arac where Kasa='" + textBox1.Text + "'", baglanti);
                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Ara_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            tablo.Clear();
            SqlDataAdapter adap = new SqlDataAdapter("select * from arac", baglanti);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
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
            Report rapor = new Report();
            rapor.Show();
            this.Hide();
        }
    }
}
