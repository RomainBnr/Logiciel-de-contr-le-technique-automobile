using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logiciel_de_contrôle_technique_automobile
{
    public partial class moduleClientForm : Form
    {
        private string connectionString = "Server=2a03:5840:111:1024:143:e6a5:7dbe:31b3;Database=BDDControleTechnique;User ID=sa;Password=erty64%;TrustServerCertificate=True;";
        private int idClient;

        // Constructeur par défaut (pour le designer)
        public moduleClientForm()
        {
            InitializeComponent();
            this.idClient = 1; // Valeur par défaut pour éviter les erreurs
        }

        // Constructeur avec l'ID du client connecté
        public moduleClientForm(int clientId)
        {
            InitializeComponent();
            this.idClient = clientId;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            string marque = txtBox_marque.Text;
            string modele = txtBox_modele.Text;
            string puissanceStr = txtBox_puissance.Text;
            string dateCirculationStr = txtBox_DateMiseEnCiruclation.Text;
            string motorisation = comboBox_motorisation.Text;
            string immatriculation = txtBox_immatriculation.Text;
            string vin = txtBox_codevin.Text;

            if (!int.TryParse(puissanceStr, out int puissance))
            {
                MessageBox.Show("Puissance invalide.");
                return;
            }

            if (!DateTime.TryParse(dateCirculationStr, out DateTime dateCirculation))
            {
                MessageBox.Show("Date invalide.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string insertQuery = @"
                    INSERT INTO Vehicule (Marque, Modele, Puissance, DateMiseCirculation, Motorisation, Immatriculation, VIN, IdClient)
                    VALUES (@Marque, @Modele, @Puissance, @DateCirculation, @Motorisation, @Immatriculation, @VIN, @IdClient);
                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Marque", marque);
                cmd.Parameters.AddWithValue("@Modele", modele);
                cmd.Parameters.AddWithValue("@Puissance", puissance);
                cmd.Parameters.AddWithValue("@DateCirculation", dateCirculation);
                cmd.Parameters.AddWithValue("@Motorisation", motorisation);
                cmd.Parameters.AddWithValue("@Immatriculation", immatriculation);
                cmd.Parameters.AddWithValue("@VIN", vin);
                cmd.Parameters.AddWithValue("@IdClient", idClient);

                try
                {
                    conn.Open();
                    int idVehicule = Convert.ToInt32(cmd.ExecuteScalar());
                    MessageBox.Show("Véhicule ajouté avec succès.");
                    ChargerResultatsControle(idVehicule);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void ChargerResultatsControle(int idVehicule)
        {
            listBox_resultatControle.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT D.Description, G.Libelle
                    FROM ControleTechnique C
                    INNER JOIN Controle_Defaillance CD ON C.IdControle = CD.IdControle
                    INNER JOIN Defaillance D ON CD.IdDefaillance = D.IdDefaillance
                    INNER JOIN Gravite G ON D.IdGravite = G.IdGravite
                    WHERE C.IdVehicule = @IdVehicule";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdVehicule", idVehicule);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string desc = reader.GetString(0);
                        string gravite = reader.GetString(1);
                        listBox_resultatControle.Items.Add($"{desc} - Gravité : {gravite}");
                    }

                    if (listBox_resultatControle.Items.Count == 0)
                    {
                        listBox_resultatControle.Items.Add("Aucune défaillance détectée.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de chargement des résultats : " + ex.Message);
                }
            }
        }
    }
}