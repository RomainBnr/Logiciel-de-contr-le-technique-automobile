using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Logiciel_de_contrôle_technique_automobile
{
    public partial class moduleClientForm : Form
    {
        private string connectionString = "Server=2a03:5840:111:1024:143:e6a5:7dbe:31b3;Database=BDDControleTechnique;User ID=sa;Password=erty64%;TrustServerCertificate=True;";
        private int idClient;

        public moduleClientForm()
        {
            InitializeComponent();
            this.idClient = 1;
            this.Load += moduleClientForm_Load;
            InitializeEvents();
        }

        public moduleClientForm(int clientId)
        {
            InitializeComponent();
            this.idClient = clientId;
            this.Load += moduleClientForm_Load;
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            btn_deconnexion.Click += Btn_deconnexion_Click;
        }

        private void Btn_deconnexion_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir vous déconnecter ?",
                    "Confirmation de déconnexion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetForm();

                    loginForm loginForm = new loginForm();
                    loginForm.Show();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la déconnexion : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            txtBox_marque.Clear();
            txtBox_modele.Clear();
            txtBox_puissance.Clear();
            txtBox_DateMiseEnCiruclation.Clear();
            txtBox_immatriculation.Clear();
            txtBox_codevin.Clear();
            comboBox_motorisation.SelectedIndex = -1;

            listBox_resultatControle.Items.Clear();
        }

        private void moduleClientForm_Load(object sender, EventArgs e)
        {
            ChargerResultatsPremierVehicule();
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

        private void ChargerResultatsPremierVehicule()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT TOP 1 IdVehicule
                    FROM Vehicule
                    WHERE IdClient = @IdClient
                    ORDER BY IdVehicule DESC;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdClient", idClient);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int idVehicule = Convert.ToInt32(result);
                        ChargerResultatsControle(idVehicule);
                    }
                    else
                    {
                        listBox_resultatControle.Items.Clear();
                        listBox_resultatControle.Items.Add("Aucun véhicule trouvé.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de chargement du véhicule : " + ex.Message);
                }
            }
        }

        private void ChargerResultatsControle(int idVehicule)
        {
            listBox_resultatControle.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string vehiculeQuery = @"
                SELECT Marque, Modele
                FROM Vehicule
                WHERE IdVehicule = @IdVehicule";

                    SqlCommand vehiculeCmd = new SqlCommand(vehiculeQuery, conn);
                    vehiculeCmd.Parameters.AddWithValue("@IdVehicule", idVehicule);

                    SqlDataReader vehiculeReader = vehiculeCmd.ExecuteReader();
                    string marque = "", modele = "";

                    if (vehiculeReader.Read())
                    {
                        marque = vehiculeReader.GetString(0);
                        modele = vehiculeReader.GetString(1);
                    }
                    vehiculeReader.Close();

                    listBox_resultatControle.Items.Add($"Marque : {marque}");
                    listBox_resultatControle.Items.Add($"Modèle : {modele}");
                    listBox_resultatControle.Items.Add("");

                    string controleQuery = @"
                SELECT P.Nom AS PointControle, G.Libelle AS Gravite, D.Description
                FROM ControleTechnique C
                INNER JOIN Controle_Defaillance CD ON C.IdControle = CD.IdControle
                INNER JOIN Defaillance D ON CD.IdDefaillance = D.IdDefaillance
                INNER JOIN Gravite G ON D.IdGravite = G.IdGravite
                INNER JOIN PointControle P ON D.IdPointControle = P.IdPointControle
                WHERE C.IdVehicule = @IdVehicule";

                    SqlCommand controleCmd = new SqlCommand(controleQuery, conn);
                    controleCmd.Parameters.AddWithValue("@IdVehicule", idVehicule);

                    SqlDataReader reader = controleCmd.ExecuteReader();
                    bool hasResults = false;

                    while (reader.Read())
                    {
                        string pointControle = reader.GetString(0);
                        string gravite = reader.GetString(1);
                        string description = reader.GetString(2);

                        listBox_resultatControle.Items.Add($"• Point de contrôle : {pointControle}");
                        listBox_resultatControle.Items.Add($"  Gravité : {gravite}");
                        listBox_resultatControle.Items.Add($"  Description : {description}");
                        listBox_resultatControle.Items.Add("");

                        hasResults = true;
                    }

                    if (!hasResults)
                    {
                        listBox_resultatControle.Items.Add("Aucune défaillance détectée.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de chargement des résultats : " + ex.Message);
                }
            }
        }
    }
}
