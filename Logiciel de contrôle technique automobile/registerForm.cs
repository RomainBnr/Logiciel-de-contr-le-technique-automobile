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
    public partial class registerForm : Form
    {
        private string connectionString = "Server=2a03:5840:111:1024:143:e6a5:7dbe:31b3;Database=BDDControleTechnique;User ID=sa;Password=erty64%;TrustServerCertificate=True;";

        public registerForm()
        {
            InitializeComponent();
            
            // Initialiser le bouton comme désactivé
            btn_inscription.Enabled = false;
            
            // Configurer les champs de mot de passe
            txtBox_mdp.UseSystemPasswordChar = true;
            txtBox_validMdp.UseSystemPasswordChar = true;
            
            // Ajouter les événements pour valider les champs
            txtBox_nom.TextChanged += ValidateFields;
            txtBox_prenom.TextChanged += ValidateFields;
            txtBox_email.TextChanged += ValidateFields;
            txtBox_mdp.TextChanged += ValidateFields;
            txtBox_validMdp.TextChanged += ValidateFields;
            
            // Ajouter les événements pour les boutons
            btn_inscription.Click += Btn_inscription_Click;
            linkLabel_connexion.LinkClicked += LinkLabel_connexion_LinkClicked;
        }

        private void ValidateFields(object sender, EventArgs e)
        {
            // Vérifier que tous les champs sont remplis
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(txtBox_nom.Text) &&
                                  !string.IsNullOrWhiteSpace(txtBox_prenom.Text) &&
                                  !string.IsNullOrWhiteSpace(txtBox_email.Text) &&
                                  !string.IsNullOrWhiteSpace(txtBox_mdp.Text) &&
                                  !string.IsNullOrWhiteSpace(txtBox_validMdp.Text);

            // Activer/désactiver le bouton selon l'état des champs
            btn_inscription.Enabled = allFieldsFilled;
        }

        private async void Btn_inscription_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier que les mots de passe correspondent
                if (txtBox_mdp.Text != txtBox_validMdp.Text)
                {
                    MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Vérifier le format de l'email
                if (!IsValidEmail(txtBox_email.Text))
                {
                    MessageBox.Show("Veuillez saisir une adresse email valide.", "Erreur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Enregistrer l'utilisateur dans la base de données
                bool success = await RegisterUserAsync();
                
                if (success)
                {
                    MessageBox.Show("Inscription réussie ! Vous allez être redirigé.", "Succès", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Rediriger vers moduleClientForm
                    moduleClientForm clientForm = new moduleClientForm();
                    clientForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'inscription : {ex.Message}", "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> RegisterUserAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    
                    // Vérifier si l'email existe déjà
                    string checkQuery = "SELECT COUNT(*) FROM Client WHERE Email = @email";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@email", txtBox_email.Text);
                        int existingUsers = (int)await checkCmd.ExecuteScalarAsync();
                        
                        if (existingUsers > 0)
                        {
                            MessageBox.Show("Cette adresse email est déjà utilisée.", "Erreur", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    
                    // Insérer le nouvel utilisateur
                    string insertQuery = @"INSERT INTO Client (Nom, Prenom, Email, MotDePasse) 
                                         VALUES (@nom, @prenom, @email, @motdepasse)";
                    
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@nom", txtBox_nom.Text.Trim());
                        cmd.Parameters.AddWithValue("@prenom", txtBox_prenom.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtBox_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@motdepasse", HashPassword(txtBox_mdp.Text));
                        
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Erreur de base de données : {ex.Message}", "Erreur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private string HashPassword(string password)
        {
            // Utilisation d'un hachage simple
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void LinkLabel_connexion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Hide();
        }

        private void lbl_connexion_Click(object sender, EventArgs e)
        {
            LinkLabel_connexion_LinkClicked(sender, null);
        }
    }
}
