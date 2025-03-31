using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect2MoldovanFlorentin
{
    public partial class ResetParola : Form
    {
        public ResetParola()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MagazinContext dbContext = new MagazinContext())
            {
                string nume = textBoxNume.Text;
                string parolaNoua = textBoxParolaNoua.Text;
                string newPasswordHash = HashPassword(parolaNoua);

                var user = dbContext.User.FirstOrDefault(u => u.Username == nume);
                if (user != null)
                {
                    user.PasswordHash = newPasswordHash;
                    dbContext.SaveChanges();
                    MessageBox.Show("Parola ta a fost schimbata cu succes!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username-ul nu a fost gasit!");
                }
            }
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
