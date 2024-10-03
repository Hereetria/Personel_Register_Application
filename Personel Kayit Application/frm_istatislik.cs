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


namespace Personel_Kayit_Application
{
    public partial class frm_istatislik : Form
    {
        public frm_istatislik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A7AFDHF\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;TrustServerCertificate=True");
        private void frm_istatislik_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read()) 
            {
                lbltopper.Text = dr1[0].ToString();
            }

            baglanti.Close();

            //Evli
            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel where perDurum=1",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevliper.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Bekar
            baglanti.Open();

            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel where perDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblbekarper.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //sehirsayi
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(PerSehir)) From Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblsehirper.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //Toplam Maas
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbltopmaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //Ortalama Maas
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblortmaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
