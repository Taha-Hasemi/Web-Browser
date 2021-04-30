using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace WebTarayicisi
{
    public class VeriTabani
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\gecmis.accdb");
        public void Gecmise_ekle(string title, string url, DateTime zaman)
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter ekle_komutu = new OleDbDataAdapter("insert into gecmis(title,url,zaman) values('" + title + "','" + url + "','" + zaman + "')", baglanti);
                DataSet sdhafiza = new DataSet();
                ekle_komutu.Fill(sdhafiza);
                baglanti.Close();
            }
            catch (Exception aciklama)
            {
                //MessageBox.Show(aciklama.Message, "Veri tabanı işlemleri (EKLE KOMUTU)");
                baglanti.Close();
            }
        }
        public OleDbCommand Gecmis_sec(string title)
        {
            try
            {
                baglanti.Open();
                OleDbCommand ekle_komutu = new OleDbCommand("select * from gecmis where title like '%"+title+"%' order by ID desc", baglanti);
                return ekle_komutu;
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Veri tabanı işlemleri");
                baglanti.Close();
                OleDbCommand ekle_komutu = new OleDbCommand();
                return ekle_komutu;
            }
        }
        public string Gecmisi_Sil(string url)
        {
            try
            {
                baglanti.Open();
                OleDbCommand ekle_komutu = new OleDbCommand("delete * from gecmis where url='"+url+"'", baglanti);
                ekle_komutu.ExecuteNonQuery();
                return "SİLİNDİ";
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Veri tabanı işlemleri");
                baglanti.Close();
                OleDbCommand ekle_komutu = new OleDbCommand();
                return aciklama.Message.ToString();
            }

        }
        public void Baglanti_Kapa1()
        {

        }
        public void Baglanti_Kapa()
        {
            baglanti.Close();
        }
    }
}
