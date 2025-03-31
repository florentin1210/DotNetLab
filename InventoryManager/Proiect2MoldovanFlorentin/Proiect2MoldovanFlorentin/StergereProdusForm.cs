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
    public partial class StergereProdusForm : Form
    {
        private MagazinContext _context;
        public StergereProdusForm()
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

        private void buttonSterge_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectati un produs!");
                return;
            }
            var selectedRow = dataGridView1.SelectedRows[0];
            var produsId = (int)selectedRow.Cells["Id"].Value;
            var produs = _context.Produs.FirstOrDefault(p => p.Id == produsId);
            if (produs != null)
            {
                var confirmResult = MessageBox.Show("Sunteti sigur ca doriti sa stergeti acest produs?",
                                                    "Confirmare stergere",
                                                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    _context.Produs.Remove(produs);
                    _context.SaveChanges();

                    MessageBox.Show("Produs sters cu succes");
                    LoadData();
                }
            }
        }
    }
}
