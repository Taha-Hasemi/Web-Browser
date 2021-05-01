using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WebTarayicisi
{
    public partial class gecmis : Form
    {
        public gecmis()
        {
            InitializeComponent();
        }
        VeriTabani veriTabani = new VeriTabani();
        private void gecmis_Load(object sender, EventArgs e)
        {
            OleDbCommand sdhafiza = veriTabani.Gecmis_sec("");
            OleDbDataReader oku = sdhafiza.ExecuteReader();
            while (oku.Read())
            {
                string[] gecmis = { oku["title"].ToString(), oku["url"].ToString(), oku["zaman"].ToString() };
                ListViewItem kayit = new ListViewItem(gecmis);
                listView1.Items.Add(kayit);
            }
            veriTabani.Baglanti_Kapa();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            OleDbCommand sdhafiza = veriTabani.Gecmis_sec(textBox1.Text);
            OleDbDataReader oku = sdhafiza.ExecuteReader();
            while (oku.Read())
            {
                string[] gecmis = { oku["title"].ToString(), oku["url"].ToString(), oku["zaman"].ToString() };
                ListViewItem kayit = new ListViewItem(gecmis);
                listView1.Items.Add(kayit);
            }
            veriTabani.Baglanti_Kapa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string cevab = veriTabani.Gecmisi_Sil(listView1.SelectedItems[0].SubItems[1].Text.ToString());
                veriTabani.Baglanti_Kapa();
                textBox1_TextChanged(null, e);
            }
            else
            {
                MessageBox.Show("LÜTFEN ÖNCE BİR ÜYE SEÇİNİZ!", "GEÇMİŞ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1_TextChanged(null, e);
        }
    }
}
