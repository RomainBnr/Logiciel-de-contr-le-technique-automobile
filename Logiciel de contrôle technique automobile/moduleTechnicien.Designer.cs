namespace Logiciel_de_contrôle_technique_automobile
{
    partial class moduleTechnicien
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
            button1 = new Button();
            listBox1 = new ListBox();
            lbl_defaillance = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            lbl_infoClient = new Label();
            listBox_infoClient = new ListBox();
            lbl_infoVehicule = new Label();
            listBox_infoVehicule = new ListBox();
            button2 = new Button();
            label3 = new Label();
            comboBox_gravite = new ComboBox();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(46, 58);
            button1.Name = "button1";
            button1.Size = new Size(605, 68);
            button1.TabIndex = 0;
            button1.Text = "Charger véhicule";
            button1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(46, 151);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(605, 579);
            listBox1.TabIndex = 1;
            // 
            // lbl_defaillance
            // 
            lbl_defaillance.AutoSize = true;
            lbl_defaillance.Location = new Point(767, 525);
            lbl_defaillance.Name = "lbl_defaillance";
            lbl_defaillance.Size = new Size(168, 25);
            lbl_defaillance.TabIndex = 3;
            lbl_defaillance.Text = "Choisir une gravité :";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(983, 467);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(501, 33);
            comboBox1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(693, 475);
            label1.Name = "label1";
            label1.Size = new Size(242, 25);
            label1.TabIndex = 8;
            label1.Text = "Choisir un point de contrôle :";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(983, 628);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(501, 144);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(824, 628);
            label2.Name = "label2";
            label2.Size = new Size(111, 25);
            label2.TabIndex = 10;
            label2.Text = "Description :";
            // 
            // lbl_infoClient
            // 
            lbl_infoClient.AutoSize = true;
            lbl_infoClient.Location = new Point(766, 80);
            lbl_infoClient.Name = "lbl_infoClient";
            lbl_infoClient.Size = new Size(169, 25);
            lbl_infoClient.TabIndex = 11;
            lbl_infoClient.Text = "Informations client :";
            // 
            // listBox_infoClient
            // 
            listBox_infoClient.FormattingEnabled = true;
            listBox_infoClient.ItemHeight = 25;
            listBox_infoClient.Location = new Point(983, 80);
            listBox_infoClient.Name = "listBox_infoClient";
            listBox_infoClient.Size = new Size(501, 129);
            listBox_infoClient.TabIndex = 12;
            // 
            // lbl_infoVehicule
            // 
            lbl_infoVehicule.AutoSize = true;
            lbl_infoVehicule.Location = new Point(744, 243);
            lbl_infoVehicule.Name = "lbl_infoVehicule";
            lbl_infoVehicule.Size = new Size(191, 25);
            lbl_infoVehicule.TabIndex = 13;
            lbl_infoVehicule.Text = "Informations véhicule :";
            // 
            // listBox_infoVehicule
            // 
            listBox_infoVehicule.FormattingEnabled = true;
            listBox_infoVehicule.ItemHeight = 25;
            listBox_infoVehicule.Location = new Point(983, 243);
            listBox_infoVehicule.Name = "listBox_infoVehicule";
            listBox_infoVehicule.Size = new Size(501, 129);
            listBox_infoVehicule.TabIndex = 14;
            // 
            // button2
            // 
            button2.Location = new Point(1076, 817);
            button2.Name = "button2";
            button2.Size = new Size(336, 56);
            button2.TabIndex = 15;
            button2.Text = "Fin contrôle technique ";
            button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(609, 9);
            label3.Name = "label3";
            label3.Size = new Size(326, 41);
            label3.TabIndex = 16;
            label3.Text = "Mon espace Technicien";
            // 
            // comboBox_gravite
            // 
            comboBox_gravite.FormattingEnabled = true;
            comboBox_gravite.Location = new Point(983, 517);
            comboBox_gravite.Name = "comboBox_gravite";
            comboBox_gravite.Size = new Size(501, 33);
            comboBox_gravite.TabIndex = 17;
            // 
            // button3
            // 
            button3.Location = new Point(46, 811);
            button3.Name = "button3";
            button3.Size = new Size(177, 51);
            button3.TabIndex = 18;
            button3.Text = "Déconnexion";
            button3.UseVisualStyleBackColor = true;
            // 
            // moduleTechnicien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1522, 916);
            Controls.Add(button3);
            Controls.Add(comboBox_gravite);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(listBox_infoVehicule);
            Controls.Add(lbl_infoVehicule);
            Controls.Add(listBox_infoClient);
            Controls.Add(lbl_infoClient);
            Controls.Add(label2);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(lbl_defaillance);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Name = "moduleTechnicien";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private Label lbl_defaillance;
        private ComboBox comboBox1;
        private Label label1;
        private RichTextBox richTextBox1;
        private Label label2;
        private Label lbl_infoClient;
        private ListBox listBox_infoClient;
        private Label lbl_infoVehicule;
        private ListBox listBox_infoVehicule;
        private Button button2;
        private Label label3;
        private ComboBox comboBox_gravite;
        private Button button3;
    }
}