using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebTarayicisi
{
    public partial class ASLAN : Form
    {
        public ASLAN()
        {
            InitializeComponent();
        }
        VeriTabani variTabani = new VeriTabani();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length != 0)
            {
                if (textBox1.Text.Contains("."))
                {
                    webBrowser1.Navigate(textBox1.Text);
                }
                else
                {
                    webBrowser1.Navigate("https://www.google.com/search?q=" + textBox1.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
            button5.Text = "DURDUR";
            timer1.Start();
            timer1.Interval = 2000;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            button5.Text = "DURDUR";
        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button5.Text = "YENİLE";
            label3.Text = webBrowser1.DocumentTitle;
            textBox1.Text = webBrowser1.Document.Url.ToString();
            variTabani.Gecmise_ekle(webBrowser1.DocumentTitle, webBrowser1.Document.Url.ToString(), DateTime.Now);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button5.Text = "YENİLE";
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.google.com");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.google.com");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //webBrowser1.Navigate(textBox1.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);

        }

        private void textBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text.Trim().Length != 0)
            {
                if (textBox1.Text.Contains("."))
                {
                    webBrowser1.Navigate(textBox1.Text);
                }
                else
                {
                    webBrowser1.Navigate("https://www.google.com/search?q="+textBox1.Text);
                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = webBrowser1.StatusText;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                toolStripProgressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);
                toolStripProgressBar1.Value = Convert.ToInt32(e.CurrentProgress);
            }
            catch (Exception)
            {
                toolStripProgressBar1.Minimum = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gecmis gecmis = new gecmis();
            gecmis.Show();
        }
    }
}
