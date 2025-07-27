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
    public partial class moduleTechnicien : Form
    {
        private string connectionString = "Server=2a03:5840:111:1024:143:e6a5:7dbe:31b3;Database=BDDControleTechnique;User ID=sa;Password=erty64%;TrustServerCertificate=True;";
        private List<VehiculeInfo> vehicules = new List<VehiculeInfo>();
        private VehiculeInfo selectedVehicule = null;

        public moduleTechnicien()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeComboBoxes();
        }

        private void InitializeEvents()
        {
            // Ajouter les événements pour les boutons et contrôles
            button1.Click += Button1_Click; // Charger véhicule
            button2.Click += Button2_Click; // Fin contrôle technique
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged; // Sélection véhicule
        }

        private async void InitializeComboBoxes()
        {
            try
            {
                await LoadPointsControleAsync();
                await LoadGravitesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                button1.Text = "Chargement en cours...";
                
                await LoadVehiculesAsync();
                
                MessageBox.Show($"{vehicules.Count} véhicules chargés avec succès.", "Information", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des véhicules : {ex.Message}", "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button1.Enabled = true;
                button1.Text = "Charger véhicule";
            }
        }

        private async Task LoadVehiculesAsync()
        {
            vehicules.Clear();
            listBox1.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    SELECT 
                        v.idVehicule,
                        v.Immatriculation,
                        v.Marque,
                        v.VIN,
                        v.Modele,
                        v.Puissance,
                        v.DateMiseCirculation,
                        v.Motorisation,
                        c.idClient,
                        c.Nom,
                        c.Prenom,
                        c.Email
                    FROM Vehicule v
                    INNER JOIN Client c ON v.idClient = c.idClient";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var vehicule = new VehiculeInfo
                            {
                                IdVehicule = reader.GetInt32("idVehicule"),
                                Immatriculation = reader.GetString("Immatriculation"),
                                Marque = reader.GetString("Marque"),
                                VIN = reader.GetString("VIN"),
                                Modele = reader.GetString("Modele"),
                                Puissance = reader.GetInt32("Puissance"),
                                DateMiseCirculation = reader.GetDateTime("DateMiseCirculation"),
                                Motorisation = reader.GetString("Motorisation"),
                                Client = new ClientInfo
                                {
                                    IdClient = reader.GetInt32("idClient"),
                                    Nom = reader.GetString("Nom"),
                                    Prenom = reader.GetString("Prenom"),
                                    Email = reader.GetString("Email")
                                }
                            };

                            vehicules.Add(vehicule);
                            
                            // Ajouter à la listBox avec le format demandé : Modèle - Immatriculation - Nom Prénom
                            string displayText = $"{vehicule.Modele} - {vehicule.Immatriculation} - {vehicule.Client.Nom} {vehicule.Client.Prenom}";
                            listBox1.Items.Add(displayText);
                        }
                    }
                }
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < vehicules.Count)
            {
                selectedVehicule = vehicules[listBox1.SelectedIndex];
                LoadClientInfo();
                LoadVehiculeInfo();
            }
        }

        private void LoadClientInfo()
        {
            if (selectedVehicule?.Client != null)
            {
                listBox_infoClient.Items.Clear();
                listBox_infoClient.Items.Add($"Nom: {selectedVehicule.Client.Nom}");
                listBox_infoClient.Items.Add($"Prénom: {selectedVehicule.Client.Prenom}");
                listBox_infoClient.Items.Add($"Email: {selectedVehicule.Client.Email}");
            }
        }

        private void LoadVehiculeInfo()
        {
            if (selectedVehicule != null)
            {
                listBox_infoVehicule.Items.Clear();
                listBox_infoVehicule.Items.Add($"Immatriculation: {selectedVehicule.Immatriculation}");
                listBox_infoVehicule.Items.Add($"Marque: {selectedVehicule.Marque}");
                listBox_infoVehicule.Items.Add($"VIN: {selectedVehicule.VIN}");
                listBox_infoVehicule.Items.Add($"Modèle: {selectedVehicule.Modele}");
                listBox_infoVehicule.Items.Add($"Puissance: {selectedVehicule.Puissance} CV"); // Ajout d'une unité pour clarifier
                listBox_infoVehicule.Items.Add($"Date mise en circulation: {selectedVehicule.DateMiseCirculation:dd/MM/yyyy}");
                listBox_infoVehicule.Items.Add($"Motorisation: {selectedVehicule.Motorisation}");
            }
        }

        private async Task LoadPointsControleAsync()
        {
            comboBox1.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT idPointControle, Nom FROM PointControle ORDER BY Nom";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var pointControle = new PointControleInfo
                            {
                                Id = reader.GetInt32("idPointControle"),
                                Nom = reader.GetString("Nom")
                            };

                            comboBox1.Items.Add(pointControle);
                        }
                    }
                }
            }

            comboBox1.DisplayMember = "Nom";
            comboBox1.ValueMember = "Id";
        }

        private async Task LoadGravitesAsync()
        {
            comboBox_gravite.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT IdGravite, Libelle FROM Gravite ORDER BY Libelle";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var gravite = new GraviteInfo
                            {
                                Id = reader.GetInt32("IdGravite"),
                                Libelle = reader.GetString("Libelle")
                            };

                            comboBox_gravite.Items.Add(gravite);
                        }
                    }
                }
            }

            comboBox_gravite.DisplayMember = "Libelle";
            comboBox_gravite.ValueMember = "Id";
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation des données
                if (selectedVehicule == null)
                {
                    MessageBox.Show("Veuillez sélectionner un véhicule.", "Validation", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner un point de contrôle.", "Validation", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox_gravite.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner une gravité.", "Validation", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(richTextBox1.Text))
                {
                    MessageBox.Show("Veuillez saisir une description.", "Validation", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                button2.Enabled = false;
                button2.Text = "Enregistrement en cours...";

                await SaveDefaillanceAsync();

                MessageBox.Show("Contrôle technique enregistré avec succès !", "Succès", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Réinitialiser les champs
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement : {ex.Message}", "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button2.Enabled = true;
                button2.Text = "Fin contrôle technique";
            }
        }

        private async Task SaveDefaillanceAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Créer ou récupérer le contrôle technique pour ce véhicule
                        int idControle = await GetOrCreateControleTechniqueAsync(connection, transaction);

                        // 2. Créer la défaillance
                        int idDefaillance = await CreateDefaillanceAsync(connection, transaction);

                        // 3. Lier le contrôle technique à la défaillance
                        await LinkControleDefaillanceAsync(connection, transaction, idControle, idDefaillance);

                        // 4. Mettre à jour le statut final du contrôle technique
                        await UpdateStatutFinalAsync(connection, transaction, idControle);

                        // Valider la transaction
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private async Task UpdateStatutFinalAsync(SqlConnection connection, SqlTransaction transaction, int idControle)
        {
            // Vérifier s'il existe des défaillances avec une gravité autre que "RAS"
            string checkQuery = @"
                SELECT COUNT(*) 
                FROM Controle_Defaillance cd
                INNER JOIN Defaillance d ON cd.idDefaillance = d.idDefaillance
                INNER JOIN Gravite g ON d.idGravite = g.IdGravite
                WHERE cd.idControle = @idControle AND g.Libelle != 'RAS'";

            using (SqlCommand cmd = new SqlCommand(checkQuery, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idControle", idControle);
                
                int defaillancesNonRAS = (int)await cmd.ExecuteScalarAsync();
                
                // Déterminer le statut final selon les valeurs autorisées par la contrainte CHECK
                string statutFinal = defaillancesNonRAS > 0 ? "Contre-visite" : "Favorable";

                // Mettre à jour le statut final dans ControleTechnique
                string updateQuery = @"
                    UPDATE ControleTechnique 
                    SET StatutFinal = @statutFinal
                    WHERE idControle = @idControle";

                using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection, transaction))
                {
                    updateCmd.Parameters.AddWithValue("@statutFinal", statutFinal);
                    updateCmd.Parameters.AddWithValue("@idControle", idControle);

                    await updateCmd.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task<int> GetOrCreateControleTechniqueAsync(SqlConnection connection, SqlTransaction transaction)
        {
            // D'abord vérifier s'il existe déjà un contrôle technique en cours pour ce véhicule
            string checkQuery = @"
                SELECT idControle 
                FROM ControleTechnique 
                WHERE idVehicule = @vehicule AND StatutFinal IS NULL";

            using (SqlCommand cmd = new SqlCommand(checkQuery, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@vehicule", selectedVehicule.IdVehicule);
                
                var existingId = await cmd.ExecuteScalarAsync();
                if (existingId != null)
                {
                    return (int)existingId;
                }
            }

            // Si aucun contrôle en cours, en créer un nouveau
            string insertQuery = @"
                INSERT INTO ControleTechnique (DateControle, idVehicule, idTechnicien)
                OUTPUT INSERTED.idControle
                VALUES (@dateControle, @vehicule, @technicien)";

            using (SqlCommand cmd = new SqlCommand(insertQuery, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@dateControle", DateTime.Now);
                cmd.Parameters.AddWithValue("@vehicule", selectedVehicule.IdVehicule);
                // Vous devrez adapter selon comment vous gérez l'ID du technicien connecté
                cmd.Parameters.AddWithValue("@technicien", 1); // À remplacer par l'ID du technicien connecté

                return (int)await cmd.ExecuteScalarAsync();
            }
        }

        private async Task<int> CreateDefaillanceAsync(SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"
                INSERT INTO Defaillance (Description, idPointControle, idGravite)
                OUTPUT INSERTED.idDefaillance
                VALUES (@description, @pointControle, @gravite)";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@description", richTextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@pointControle", ((PointControleInfo)comboBox1.SelectedItem).Id);
                cmd.Parameters.AddWithValue("@gravite", ((GraviteInfo)comboBox_gravite.SelectedItem).Id);

                return (int)await cmd.ExecuteScalarAsync();
            }
        }

        private async Task LinkControleDefaillanceAsync(SqlConnection connection, SqlTransaction transaction, int idControle, int idDefaillance)
        {
            string query = @"
                INSERT INTO Controle_Defaillance (idControle, idDefaillance)
                VALUES (@controle, @defaillance)";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@controle", idControle);
                cmd.Parameters.AddWithValue("@defaillance", idDefaillance);

                await cmd.ExecuteNonQueryAsync();
            }
        }

        private void ResetForm()
        {
            comboBox1.SelectedIndex = -1;
            comboBox_gravite.SelectedIndex = -1;
            richTextBox1.Clear();
            listBox_infoClient.Items.Clear();
            listBox_infoVehicule.Items.Clear();
            listBox1.SelectedIndex = -1;
            selectedVehicule = null;
        }
    }

    // Classes pour gérer les données
    public class VehiculeInfo
    {
        public int IdVehicule { get; set; }
        public string Immatriculation { get; set; }
        public string Marque { get; set; }
        public string VIN { get; set; }
        public string Modele { get; set; }
        public int Puissance { get; set; }  // Changé de string à int
        public DateTime DateMiseCirculation { get; set; }
        public string Motorisation { get; set; }
        public ClientInfo Client { get; set; }
    }

    public class ClientInfo
    {
        public int IdClient { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
    }

    public class PointControleInfo
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public override string ToString()
        {
            return Nom;
        }
    }

    public class GraviteInfo
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public override string ToString()
        {
            return Libelle;
        }
    }
}
