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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-AGQ4V6UP\WOLVOX8;Initial Catalog=DbSecimProje;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //ilçe adlarını comboboxa çekme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select ILCEAD From Tbl_ilce ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }

            baglanti.Close();
            //Grafiğe Toplam Sonuçları Getirme
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) FROM Tbl_ilce", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTİ", dr1[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTİ ", dr1[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİ ", dr1[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİ ", dr1[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİ ", dr1[4]);
            }

            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_ilce where ILCEAD=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value =int.Parse(dr[2].ToString()); 
                progressBar2.Value =int.Parse(dr[3].ToString()); 
                progressBar3.Value =int.Parse(dr[4].ToString()); 
                progressBar4.Value =int.Parse(dr[5].ToString()); 
                progressBar5.Value =int.Parse(dr[6].ToString());
                
                LblA.Text = dr[2].ToString();
                LblB.Text = dr[3].ToString();
                LblC.Text = dr[4].ToString();
                LblD.Text = dr[5].ToString();
                LblE.Text = dr[6].ToString();
            }
            baglanti.Close();
        }
    }
}
