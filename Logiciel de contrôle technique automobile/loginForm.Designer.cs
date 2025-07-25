namespace Logiciel_de_contrôle_technique_automobile
{
    partial class loginForm
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
            label1 = new Label();
            txtBox_mail = new TextBox();
            txtBox_mdp = new TextBox();
            btn_connexion = new Button();
            lbl_inscription = new Label();
            linkLabel_inscription = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(299, 57);
            label1.Name = "label1";
            label1.Size = new Size(161, 25);
            label1.TabIndex = 0;
            label1.Text = "Page de connexion";
            // 
            // txtBox_mail
            // 
            txtBox_mail.Location = new Point(201, 118);
            txtBox_mail.Name = "txtBox_mail";
            txtBox_mail.PlaceholderText = "Adresse mail";
            txtBox_mail.Size = new Size(343, 31);
            txtBox_mail.TabIndex = 1;
            // 
            // txtBox_mdp
            // 
            txtBox_mdp.Location = new Point(201, 175);
            txtBox_mdp.Name = "txtBox_mdp";
            txtBox_mdp.PlaceholderText = "Mot de Passe";
            txtBox_mdp.Size = new Size(343, 31);
            txtBox_mdp.TabIndex = 2;
            // 
            // btn_connexion
            // 
            btn_connexion.Location = new Point(251, 243);
            btn_connexion.Name = "btn_connexion";
            btn_connexion.Size = new Size(239, 48);
            btn_connexion.TabIndex = 3;
            btn_connexion.Text = "Se connecter";
            btn_connexion.UseVisualStyleBackColor = true;
            // 
            // lbl_inscription
            // 
            lbl_inscription.AutoSize = true;
            lbl_inscription.Location = new Point(68, 330);
            lbl_inscription.Name = "lbl_inscription";
            lbl_inscription.Size = new Size(300, 25);
            lbl_inscription.TabIndex = 4;
            lbl_inscription.Text = "Vous n'avez pas encore de compte ?";
            // 
            // linkLabel_inscription
            // 
            linkLabel_inscription.AutoSize = true;
            linkLabel_inscription.Location = new Point(463, 330);
            linkLabel_inscription.Name = "linkLabel_inscription";
            linkLabel_inscription.Size = new Size(81, 25);
            linkLabel_inscription.TabIndex = 5;
            linkLabel_inscription.TabStop = true;
            linkLabel_inscription.Text = "S'inscrire";
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLabel_inscription);
            Controls.Add(lbl_inscription);
            Controls.Add(btn_connexion);
            Controls.Add(txtBox_mdp);
            Controls.Add(txtBox_mail);
            Controls.Add(label1);
            Name = "loginForm";
            Text = "Connexion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBox_mail;
        private TextBox txtBox_mdp;
        private Button btn_connexion;
        private Label lbl_inscription;
        private LinkLabel linkLabel_inscription;
    }
}