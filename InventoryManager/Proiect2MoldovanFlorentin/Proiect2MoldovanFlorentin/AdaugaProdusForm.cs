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
    public partial class AdaugaProdusForm : Form
    {
        public AdaugaProdusForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdaugaProdus(Produs produsNou)
        {
            using (var context = new MagazinContext())
            {
                context.Produs.Add(produsNou);
                context.SaveChanges(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                using (MagazinContext context = new MagazinContext())
                {
                    Produs p = new Produs();
                    
                   p.Denumire = textBox1.Text;
                   p.Descriere = textBox2.Text;
                   p.Data_Intrare = dateTimePicker1.Value.ToString();
                   p.Data_Expirare = dateTimePicker2.Value.ToString();
                   p.Cantitate = (int)numericUpDown1.Value;
                    

                    context.Produs.Add(p);
                    context.SaveChanges();
                }

                MessageBox.Show("Produs adaugat cu succes!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            
         
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
