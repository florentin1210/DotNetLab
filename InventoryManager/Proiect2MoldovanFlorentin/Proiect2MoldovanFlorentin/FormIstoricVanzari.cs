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
    public partial class FormIstoricVanzari : Form
    {
        public FormIstoricVanzari()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new MagazinContext())
            {
                var vanzari = context.Vanzare.ToList();
                dataGridView1.DataSource = vanzari.Select(v => new
                {
                    v.Id,
                    v.NumeProdus,
                    v.Cantitate,
                    v.DataVanzare
                }).ToList();
            }
        }
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
