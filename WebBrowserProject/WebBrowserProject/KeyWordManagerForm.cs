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
    public partial class KeyWordManagerForm : Form
    {
        private List<string> keywords;
        private void UpdateKeywordList()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = keywords;
        }
        public KeyWordManagerForm(List<string> keywords)
        {
            InitializeComponent();
            this.keywords = new List<string>(keywords);
            UpdateKeywordList();
        }
        public List<string> GetKeywords()
        {
            return keywords;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newKeyword = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(newKeyword) && !keywords.Contains(newKeyword, StringComparer.OrdinalIgnoreCase))
            {
                keywords.Add(newKeyword);
                UpdateKeywordList();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Keyword is empty or already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedKeyword = comboBox1.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedKeyword))
            {
                keywords.Remove(selectedKeyword);
                UpdateKeywordList();
            }
            else
            {
                MessageBox.Show("No keyword elected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
