﻿namespace Logiciel_de_contrôle_technique_automobile
{
    partial class moduleClientForm
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
            lbl_monVehicule = new Label();
            lbl_marque = new Label();
            lbl_modele = new Label();
            lbl_puissance = new Label();
            lbl_miseCirculation = new Label();
            lbl_motorisation = new Label();
            lbl_immatriculation = new Label();
            lbl_VIN = new Label();
            txtBox_marque = new TextBox();
            txtBox_modele = new TextBox();
            txtBox_puissance = new TextBox();
            txtBox_DateMiseEnCiruclation = new TextBox();
            txtBox_immatriculation = new TextBox();
            txtBox_codevin = new TextBox();
            comboBox_motorisation = new ComboBox();
            listBox_resultatControle = new ListBox();
            label1 = new Label();
            btn_valider = new Button();
            label2 = new Label();
            btn_deconnexion = new Button();
            SuspendLayout();
            // 
            // lbl_monVehicule
            // 
            lbl_monVehicule.AutoSize = true;
            lbl_monVehicule.Font = new Font("Segoe UI", 12F);
            lbl_monVehicule.Location = new Point(320, 83);
            lbl_monVehicule.Name = "lbl_monVehicule";
            lbl_monVehicule.Size = new Size(160, 32);
            lbl_monVehicule.TabIndex = 0;
            lbl_monVehicule.Text = "Mon véhicule";
            // 
            // lbl_marque
            // 
            lbl_marque.AutoSize = true;
            lbl_marque.Location = new Point(146, 157);
            lbl_marque.Name = "lbl_marque";
            lbl_marque.Size = new Size(87, 25);
            lbl_marque.TabIndex = 1;
            lbl_marque.Text = "Marque : ";
            // 
            // lbl_modele
            // 
            lbl_modele.AutoSize = true;
            lbl_modele.Location = new Point(153, 213);
            lbl_modele.Name = "lbl_modele";
            lbl_modele.Size = new Size(81, 25);
            lbl_modele.TabIndex = 2;
            lbl_modele.Text = "Modèle :";
            // 
            // lbl_puissance
            // 
            lbl_puissance.AutoSize = true;
            lbl_puissance.Location = new Point(136, 273);
            lbl_puissance.Name = "lbl_puissance";
            lbl_puissance.Size = new Size(97, 25);
            lbl_puissance.TabIndex = 3;
            lbl_puissance.Text = "Puissance :";
            // 
            // lbl_miseCirculation
            // 
            lbl_miseCirculation.AutoSize = true;
            lbl_miseCirculation.Location = new Point(6, 332);
            lbl_miseCirculation.Name = "lbl_miseCirculation";
            lbl_miseCirculation.Size = new Size(234, 25);
            lbl_miseCirculation.TabIndex = 4;
            lbl_miseCirculation.Text = "Date de mise en circulation :";
            // 
            // lbl_motorisation
            // 
            lbl_motorisation.AutoSize = true;
            lbl_motorisation.Location = new Point(110, 387);
            lbl_motorisation.Name = "lbl_motorisation";
            lbl_motorisation.Size = new Size(123, 25);
            lbl_motorisation.TabIndex = 5;
            lbl_motorisation.Text = "Motorisation :";
            // 
            // lbl_immatriculation
            // 
            lbl_immatriculation.AutoSize = true;
            lbl_immatriculation.Location = new Point(87, 457);
            lbl_immatriculation.Name = "lbl_immatriculation";
            lbl_immatriculation.Size = new Size(145, 25);
            lbl_immatriculation.TabIndex = 6;
            lbl_immatriculation.Text = "Immatriculation :";
            // 
            // lbl_VIN
            // 
            lbl_VIN.AutoSize = true;
            lbl_VIN.Location = new Point(136, 522);
            lbl_VIN.Name = "lbl_VIN";
            lbl_VIN.Size = new Size(97, 25);
            lbl_VIN.TabIndex = 7;
            lbl_VIN.Text = "Code VIN :";
            // 
            // txtBox_marque
            // 
            txtBox_marque.Location = new Point(267, 153);
            txtBox_marque.Name = "txtBox_marque";
            txtBox_marque.Size = new Size(294, 31);
            txtBox_marque.TabIndex = 9;
            // 
            // txtBox_modele
            // 
            txtBox_modele.Location = new Point(267, 208);
            txtBox_modele.Name = "txtBox_modele";
            txtBox_modele.Size = new Size(294, 31);
            txtBox_modele.TabIndex = 10;
            // 
            // txtBox_puissance
            // 
            txtBox_puissance.Location = new Point(267, 267);
            txtBox_puissance.Name = "txtBox_puissance";
            txtBox_puissance.Size = new Size(150, 31);
            txtBox_puissance.TabIndex = 11;
            // 
            // txtBox_DateMiseEnCiruclation
            // 
            txtBox_DateMiseEnCiruclation.Location = new Point(267, 325);
            txtBox_DateMiseEnCiruclation.Name = "txtBox_DateMiseEnCiruclation";
            txtBox_DateMiseEnCiruclation.Size = new Size(150, 31);
            txtBox_DateMiseEnCiruclation.TabIndex = 12;
            // 
            // txtBox_immatriculation
            // 
            txtBox_immatriculation.Location = new Point(267, 450);
            txtBox_immatriculation.Name = "txtBox_immatriculation";
            txtBox_immatriculation.Size = new Size(265, 31);
            txtBox_immatriculation.TabIndex = 13;
            // 
            // txtBox_codevin
            // 
            txtBox_codevin.Location = new Point(267, 515);
            txtBox_codevin.Name = "txtBox_codevin";
            txtBox_codevin.Size = new Size(294, 31);
            txtBox_codevin.TabIndex = 14;
            // 
            // comboBox_motorisation
            // 
            comboBox_motorisation.FormattingEnabled = true;
            comboBox_motorisation.Items.AddRange(new object[] { "Diesel", "Essence", "Electrique" });
            comboBox_motorisation.Location = new Point(267, 383);
            comboBox_motorisation.Name = "comboBox_motorisation";
            comboBox_motorisation.Size = new Size(181, 33);
            comboBox_motorisation.TabIndex = 15;
            // 
            // listBox_resultatControle
            // 
            listBox_resultatControle.FormattingEnabled = true;
            listBox_resultatControle.ItemHeight = 25;
            listBox_resultatControle.Location = new Point(830, 153);
            listBox_resultatControle.Name = "listBox_resultatControle";
            listBox_resultatControle.Size = new Size(645, 404);
            listBox_resultatControle.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(830, 83);
            label1.Name = "label1";
            label1.Size = new Size(261, 25);
            label1.TabIndex = 17;
            label1.Text = "Résultat du contrôle technique :";
            // 
            // btn_valider
            // 
            btn_valider.Location = new Point(346, 603);
            btn_valider.Name = "btn_valider";
            btn_valider.Size = new Size(113, 33);
            btn_valider.TabIndex = 18;
            btn_valider.Text = "Valider";
            btn_valider.UseVisualStyleBackColor = true;
            btn_valider.Click += btnValider_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(601, 8);
            label2.Name = "label2";
            label2.Size = new Size(259, 41);
            label2.TabIndex = 19;
            label2.Text = "Mon espace client";
            // 
            // btn_deconnexion
            // 
            btn_deconnexion.Location = new Point(1269, 694);
            btn_deconnexion.Name = "btn_deconnexion";
            btn_deconnexion.Size = new Size(206, 52);
            btn_deconnexion.TabIndex = 20;
            btn_deconnexion.Text = "Déconnexion";
            btn_deconnexion.UseVisualStyleBackColor = true;
            // 
            // moduleClientForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1533, 795);
            Controls.Add(btn_deconnexion);
            Controls.Add(label2);
            Controls.Add(btn_valider);
            Controls.Add(label1);
            Controls.Add(listBox_resultatControle);
            Controls.Add(comboBox_motorisation);
            Controls.Add(txtBox_codevin);
            Controls.Add(txtBox_immatriculation);
            Controls.Add(txtBox_DateMiseEnCiruclation);
            Controls.Add(txtBox_puissance);
            Controls.Add(txtBox_modele);
            Controls.Add(txtBox_marque);
            Controls.Add(lbl_VIN);
            Controls.Add(lbl_immatriculation);
            Controls.Add(lbl_motorisation);
            Controls.Add(lbl_miseCirculation);
            Controls.Add(lbl_puissance);
            Controls.Add(lbl_modele);
            Controls.Add(lbl_marque);
            Controls.Add(lbl_monVehicule);
            Name = "moduleClientForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_monVehicule;
        private Label lbl_marque;
        private Label lbl_modele;
        private Label lbl_puissance;
        private Label lbl_miseCirculation;
        private Label lbl_motorisation;
        private Label lbl_immatriculation;
        private Label lbl_VIN;
        private TextBox txtBox_marque;
        private TextBox txtBox_modele;
        private TextBox txtBox_puissance;
        private TextBox txtBox_DateMiseEnCiruclation;
        private TextBox txtBox_immatriculation;
        private TextBox txtBox_codevin;
        private ComboBox comboBox_motorisation;
        private ListBox listBox_resultatControle;
        private Label label1;
        private Button btn_valider;
        private Label label2;
        private Button btn_deconnexion;
    }
}