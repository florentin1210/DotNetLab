using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect2MoldovanFlorentin
{
    public partial class Form1 : Form
    {
        private User _CurrentUser;
        public Form1(User user)
        {
            InitializeComponent();
            _CurrentUser = user;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var context = new MagazinContext())
                {
                    var produse = context.Produs.ToList();
                    dataGridView1.DataSource = produse.Select(p => new
                    {
                        p.Id,
                        p.Denumire,
                        p.Descriere,
                        p.Cantitate,
                        p.Data_Intrare,
                        p.Data_Expirare
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException != null
                    ? ex.InnerException.Message
                    : ex.Message;

                MessageBox.Show($"An error occurred: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void adaugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AdaugaProdusForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void vanzareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new VindeProduseForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void istoricToolStripMenuItem(object sender, EventArgs e)
        {
            using (var form = new FormIstoricVanzari())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void stergereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new StergereProdusForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
