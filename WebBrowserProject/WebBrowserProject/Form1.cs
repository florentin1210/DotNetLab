using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowserProject
{
    public partial class Form1 : Form
    {
        private List<string> blockedKeywords = new List<string>();
        public Form1()
        {
            InitializeComponent();
            webBrowser1.Navigating += webBrowser1_Navigating;
            webBrowser1.ScriptErrorsSuppressed = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com");
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            toolStripTextBox1.Text = webBrowser1.Url.ToString();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            string url = toolStripTextBox1.Text;
            if (!string.IsNullOrWhiteSpace(url))
            {
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }
                webBrowser1.Navigate(url);
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com");
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1_Click(sender, e); 
                e.SuppressKeyPress = true; 
            }
        }
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string url = e.Url.ToString(); 

            if (blockedKeywords.Any(keyword => url.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                e.Cancel = true;
                MessageBox.Show($"Accesul la această adresă este interzis: {url}", "Blocare URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            KeyWordManagerForm keywordForm = new KeyWordManagerForm(blockedKeywords);
            keywordForm.ShowDialog();

            blockedKeywords = keywordForm.GetKeywords();
        }
    }
}
