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
    public partial class GirisPanel : Form
    {
        public GirisPanel()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A7AFDHF\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;TrustServerCertificate=True");

        void temizle()
        {
            txid.Text = "";
            txad.Text = "";
            txsoyad.Text = "";
            txsehir.Text = "";
            txmaas.Text = "";
            txmeslek.Text = "";
            txevli.Checked = false;
            txbekar.Checked = false;
            txad.Focus();
        }
 

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet1.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet1.Tbl_Personel);

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,permeslek,perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1",txad.Text);
            komut.Parameters.AddWithValue("@p2", txsoyad.Text);
            komut.Parameters.AddWithValue("@p3", txsehir.Text);
            komut.Parameters.AddWithValue("@p4", txmaas.Text);
            komut.Parameters.AddWithValue("@p5", txmeslek.Text);
            komut.Parameters.AddWithValue("@p6", durum.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Personel Eklendi");

            baglanti.Close();
        }

        private void txevli_CheckedChanged(object sender, EventArgs e)
        {
            if (txevli.Checked == true)
            {
                durum.Text = "True";
            }
        }

        private void txbekar_CheckedChanged(object sender, EventArgs e)
        {
            if (txbekar.Checked == true)
            {
                durum.Text = "False";
            }
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet1.Tbl_Personel);
        }

        private void btntemizlik_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            durum.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void durum_TextChanged(object sender, EventArgs e)
        {
            if (durum.Text == "True" )
            {
                txevli.Checked = true;
            }
            else if (durum.Text == "False" )
            {
                txbekar.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Personel Where Perid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1",txid.Text);
            komutsil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Kayit Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1,PerSoyad=@a2,Persehir=@a3,Permaas=@a4,Perdurum=@a5,Permeslek=@a6 where Perid=@a7",baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", txad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", txsehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", txmaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", durum.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txid.Text);
            komutguncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel Bilgileri Güncellendi");
        }

        private void btnistatislik_Click(object sender, EventArgs e)
        {
            frm_istatislik fr = new frm_istatislik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            FrmAnaForm fr = new FrmAnaForm();
            fr.Show();
        }
    }
}
