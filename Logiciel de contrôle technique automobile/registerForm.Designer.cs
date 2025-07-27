namespace Logiciel_de_contrôle_technique_automobile
{
    partial class registerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_inscription = new Label();
            txtBox_nom = new TextBox();
            txtBox_prenom = new TextBox();
            txtBox_email = new TextBox();
            txtBox_mdp = new TextBox();
            txtBox_validMdp = new TextBox();
            btn_inscription = new Button();
            lbl_connexion = new Label();
            linkLabel_connexion = new LinkLabel();
            SuspendLayout();
            // 
            // lbl_inscription
            // 
            lbl_inscription.AutoSize = true;
            lbl_inscription.Location = new Point(236, 58);
            lbl_inscription.Name = "lbl_inscription";
            lbl_inscription.Size = new Size(152, 25);
            lbl_inscription.TabIndex = 0;
            lbl_inscription.Text = "Page d'inscription";
            // 
            // txtBox_nom
            // 
            txtBox_nom.Location = new Point(136, 116);
            txtBox_nom.Name = "txtBox_nom";
            txtBox_nom.PlaceholderText = "Votre Nom";
            txtBox_nom.Size = new Size(316, 31);
            txtBox_nom.TabIndex = 1;
            // 
            // txtBox_prenom
            // 
            txtBox_prenom.Location = new Point(136, 170);
            txtBox_prenom.Name = "txtBox_prenom";
            txtBox_prenom.PlaceholderText = "Votre Prénom";
            txtBox_prenom.Size = new Size(316, 31);
            txtBox_prenom.TabIndex = 2;
            // 
            // txtBox_email
            // 
            txtBox_email.Location = new Point(136, 227);
            txtBox_email.Name = "txtBox_email";
            txtBox_email.PlaceholderText = "Votre E-mail ";
            txtBox_email.Size = new Size(388, 31);
            txtBox_email.TabIndex = 3;
            // 
            // txtBox_mdp
            // 
            txtBox_mdp.Location = new Point(136, 284);
            txtBox_mdp.Name = "txtBox_mdp";
            txtBox_mdp.PlaceholderText = "Mot de passe";
            txtBox_mdp.Size = new Size(388, 31);
            txtBox_mdp.TabIndex = 4;
            // 
            // txtBox_validMdp
            // 
            txtBox_validMdp.Location = new Point(136, 340);
            txtBox_validMdp.Name = "txtBox_validMdp";
            txtBox_validMdp.PlaceholderText = "Validez votre mot de passe";
            txtBox_validMdp.Size = new Size(388, 31);
            txtBox_validMdp.TabIndex = 5;
            // 
            // btn_inscription
            // 
            btn_inscription.Location = new Point(199, 407);
            btn_inscription.Name = "btn_inscription";
            btn_inscription.Size = new Size(253, 51);
            btn_inscription.TabIndex = 6;
            btn_inscription.Text = "S'inscrire";
            btn_inscription.UseVisualStyleBackColor = true;
            // 
            // lbl_connexion
            // 
            lbl_connexion.AutoSize = true;
            lbl_connexion.Location = new Point(112, 472);
            lbl_connexion.Name = "lbl_connexion";
            lbl_connexion.Size = new Size(238, 25);
            lbl_connexion.TabIndex = 7;
            lbl_connexion.Text = "Vous avez déjà un compte ? ";
            lbl_connexion.Click += this.lbl_connexion_Click;
            // 
            // linkLabel_connexion
            // 
            linkLabel_connexion.AutoSize = true;
            linkLabel_connexion.Location = new Point(428, 472);
            linkLabel_connexion.Name = "linkLabel_connexion";
            linkLabel_connexion.Size = new Size(96, 25);
            linkLabel_connexion.TabIndex = 8;
            linkLabel_connexion.TabStop = true;
            linkLabel_connexion.Text = "Connexion";
            // 
            // registerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 594);
            Controls.Add(linkLabel_connexion);
            Controls.Add(lbl_connexion);
            Controls.Add(btn_inscription);
            Controls.Add(txtBox_validMdp);
            Controls.Add(txtBox_mdp);
            Controls.Add(txtBox_email);
            Controls.Add(txtBox_prenom);
            Controls.Add(txtBox_nom);
            Controls.Add(lbl_inscription);
            Name = "registerForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_inscription;
        private TextBox txtBox_nom;
        private TextBox txtBox_prenom;
        private TextBox txtBox_email;
        private TextBox txtBox_mdp;
        private TextBox txtBox_validMdp;
        private Button btn_inscription;
        private Label lbl_connexion;
        private LinkLabel linkLabel_connexion;
    }
}