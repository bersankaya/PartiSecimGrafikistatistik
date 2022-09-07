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
namespace Veri_Tabanli_Parti_Secim_Grafik_Istatistik
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-AGQ4V6UP\WOLVOX8;Initial Catalog=DbSecimProje;Integrated Security=True");
        private void BtnOyGiriş_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_ilce (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) Values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", Txtilcead.Text);
            komut.Parameters.AddWithValue("@p2", TxtAParti.Text);
            komut.Parameters.AddWithValue("@p3", TxtBParti.Text);
            komut.Parameters.AddWithValue("@p4", TxtCParti.Text);
            komut.Parameters.AddWithValue("@p5", TxtDParti.Text);
            komut.Parameters.AddWithValue("@p6", TxtEParti.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy Girişi Gerçekleşti");
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
