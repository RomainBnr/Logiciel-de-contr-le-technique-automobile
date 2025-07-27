using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logiciel_de_contrôle_technique_automobile
{
    public partial class loginForm : Form
    {
        private string connectionString = "Server=2a03:5840:111:1024:143:e6a5:7dbe:31b3;Database=BDDControleTechnique;User ID=sa;Password=erty64%;TrustServerCertificate=True;";

        public loginForm()
        {
            InitializeComponent();
            
            // Configurer le champ mot de passe
            txtBox_mdp.UseSystemPasswordChar = true;
            
            // Ajouter les événements
            btn_connexion.Click += Btn_connexion_Click;
            linkLabel_inscription.LinkClicked += LinkLabel_inscription_LinkClicked;
            
            // Permettre la connexion avec la touche Entrée
            txtBox_mdp.KeyPress += TxtBox_mdp_KeyPress;
        }

        private void TxtBox_mdp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_connexion_Click(sender, e);
            }
        }

        private async void Btn_connexion_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier que les champs sont remplis
                if (string.IsNullOrWhiteSpace(txtBox_mail.Text) || string.IsNullOrWhiteSpace(txtBox_mdp.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Désactiver le bouton pendant la connexion
                btn_connexion.Enabled = false;
                btn_connexion.Text = "Connexion en cours...";

                // Authentifier l'utilisateur
                var userInfo = await AuthenticateUserAsync(txtBox_mail.Text, txtBox_mdp.Text);

                if (userInfo != null)
                {
                    MessageBox.Show($"Connexion réussie ! Bienvenue {userInfo.Prenom} {userInfo.Nom}", "Succès", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Rediriger selon le type d'utilisateur
                    if (userInfo.UserType == "Client")
                    {
                        moduleClientForm clientForm = new moduleClientForm(userInfo.Id); // Passer l'ID du client
                        clientForm.Show();
                    }
                    else if (userInfo.UserType == "Technicien")
                    {
                        moduleTechnicien technicienForm = new moduleTechnicien(userInfo.Id); // Passer l'ID du technicien
                        technicienForm.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Email ou mot de passe incorrect.", "Erreur de connexion", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la connexion : {ex.Message}", "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Réactiver le bouton
                btn_connexion.Enabled = true;
                btn_connexion.Text = "Se connecter";
            }
        }

        private async Task<UserInfo> AuthenticateUserAsync(string email, string password)
        {
            string hashedPassword = HashPassword(password);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    // Vérifier d'abord dans la table Client
                    string clientQuery = @"SELECT idClient, Nom, Prenom, Email FROM Client 
                                         WHERE Email = @email AND MotDePasse = @password";
                    
                    using (SqlCommand cmd = new SqlCommand(clientQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                return new UserInfo
                                {
                                    Id = reader.GetInt32("idClient"),
                                    Nom = reader.GetString("Nom"),
                                    Prenom = reader.GetString("Prenom"),
                                    Email = reader.GetString("Email"),
                                    UserType = "Client"
                                };
                            }
                        }
                    }

                    // Si pas trouvé dans Client, vérifier dans Technicien
                    string technicienQuery = @"SELECT idTechnicien, Nom, Prenom, Email FROM Technicien 
                                             WHERE Email = @email AND MotDePasse = @password";
                    
                    using (SqlCommand cmd = new SqlCommand(technicienQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                return new UserInfo
                                {
                                    Id = reader.GetInt32("idTechnicien"),
                                    Nom = reader.GetString("Nom"),
                                    Prenom = reader.GetString("Prenom"),
                                    Email = reader.GetString("Email"),
                                    UserType = "Technicien"
                                };
                            }
                        }
                    }

                    return null;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Erreur de base de données : {ex.Message}", "Erreur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        private string HashPassword(string password)
        {
            // Utilisation du même hachage que dans registerForm
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private void LinkLabel_inscription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Rediriger vers la page d'inscription
            registerForm registerForm = new registerForm();
            registerForm.Show();
            this.Hide();
        }
    }

    // Classe pour stocker les informations de l'utilisateur connecté
    public class UserInfo
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; } // "Client" ou "Technicien"
    }
}
