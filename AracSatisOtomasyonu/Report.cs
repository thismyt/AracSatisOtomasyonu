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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("Data Source = DESKTOP; Initial Catalog = dbalanuygulamasi; Integrated Security = True");
        DataTable tablo = new DataTable();
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From arac", bag);
            adtr.Fill(tablo);
            CrystalReport1 rapor = new CrystalReport1();
            rapor.SetDataSource(tablo);
            crystalReportViewer1.ReportSource = rapor;
        }
    }
}
