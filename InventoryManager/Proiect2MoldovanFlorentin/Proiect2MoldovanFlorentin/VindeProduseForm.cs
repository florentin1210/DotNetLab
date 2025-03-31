using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect2MoldovanFlorentin
{
    public partial class VindeProduseForm : Form
    {
        private MagazinContext _context;
        public VindeProduseForm()
        {
            InitializeComponent();
            _context = new MagazinContext();
            LoadData();
        }

        private void LoadData()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectati un produs!");
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            var produsId = (int)selectedRow.Cells["Id"].Value;
            var cantitateDeVandut = (int)numericUpDown1.Value;

            var produs = _context.Produs.FirstOrDefault(p => p.Id == produsId);

            if (produs != null)
            {
                if (produs.Cantitate >= cantitateDeVandut)
                {
                    produs.Cantitate -= cantitateDeVandut;

                    var vanzare = new Vanzare
                    {
                        NumeProdus = produs.Denumire,
                        Cantitate = cantitateDeVandut,
                        DataVanzare = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                    _context.Vanzare.Add(vanzare);

                    _context.SaveChanges();

                    MessageBox.Show("Produs vandut cu succes");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cantitate insuficienta");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }
    }
}
