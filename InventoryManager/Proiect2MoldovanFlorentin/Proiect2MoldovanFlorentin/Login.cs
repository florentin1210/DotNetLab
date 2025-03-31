using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Proiect2MoldovanFlorentin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            using(MagazinContext dbcontext = new MagazinContext())
            {
                string nume = textBoxNume.Text;
                string parola = textBoxParola.Text;
                string parolaHash = HashPassword(parola);

                var user = dbcontext.User.FirstOrDefault(u => u.Username == nume && u.PasswordHash == parolaHash);
                if(user != null)
                {
                    Form1 mainForm = new Form1(user);
                    mainForm.Show();
                    this.Hide();
                }
                else MessageBox.Show("Nume sau parola gresite");
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

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            using (MagazinContext dbContext = new MagazinContext())
            {
                string nume = textBoxNume.Text;
                string parola = textBoxParola.Text;
                string role = "User";
                string passwordHash = HashPassword(parola);

                var userExistent = dbContext.User.FirstOrDefault(u => u.Username == nume);
                if (userExistent == null)
                {
                    User newUser = new User()
                    {
                        Username = nume,
                        PasswordHash = passwordHash,
                        Role = role
                    };

                    dbContext.User.Add(newUser);
                    dbContext.SaveChanges();

                    MessageBox.Show("Utilizatorul a fost creat cu succes");
                }
                else
                {
                    MessageBox.Show("Acest utilizator exista deja");
                }
            }
        }

        private void buttonResetareParola_Click(object sender, EventArgs e)
        {
            ResetParola resetParola = new ResetParola();
            resetParola.Show();
        }
    }
}
