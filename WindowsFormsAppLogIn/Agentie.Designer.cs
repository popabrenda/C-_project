using System.ComponentModel;

namespace WindowsFormsAppLogIn
{
    partial class Agentie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.Destinatie = new System.Windows.Forms.Label();
            this.labelOra2 = new System.Windows.Forms.Label();
            this.labelOra1 = new System.Windows.Forms.Label();
            this.textBoxObiectivTuristic = new System.Windows.Forms.TextBox();
            this.textBoxOra1 = new System.Windows.Forms.TextBox();
            this.textBoxOra2 = new System.Windows.Forms.TextBox();
            this.labelIdExcursie = new System.Windows.Forms.Label();
            this.labelNume = new System.Windows.Forms.Label();
            this.labelNrTel = new System.Windows.Forms.Label();
            this.labelNrBilete = new System.Windows.Forms.Label();
            this.textBoxIdExcursie = new System.Windows.Forms.TextBox();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.textBoxNumarTelefon = new System.Windows.Forms.TextBox();
            this.textBoxNumarBilete = new System.Windows.Forms.TextBox();
            this.buttonCautare = new System.Windows.Forms.Button();
            this.buttonRezervare = new System.Windows.Forms.Button();
            this.listBoxExcursii = new System.Windows.Forms.ListBox();
            this.listBoxClienti = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Destinatie
            // 
            this.Destinatie.Location = new System.Drawing.Point(32, 402);
            this.Destinatie.Name = "Destinatie";
            this.Destinatie.Size = new System.Drawing.Size(182, 37);
            this.Destinatie.TabIndex = 2;
            this.Destinatie.Text = "Obiectiv Turistic";
            this.Destinatie.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelOra2
            // 
            this.labelOra2.Location = new System.Drawing.Point(32, 492);
            this.labelOra2.Name = "labelOra2";
            this.labelOra2.Size = new System.Drawing.Size(182, 37);
            this.labelOra2.TabIndex = 3;
            this.labelOra2.Text = "Ora 2:";
            this.labelOra2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelOra2.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // labelOra1
            // 
            this.labelOra1.Location = new System.Drawing.Point(32, 439);
            this.labelOra1.Name = "labelOra1";
            this.labelOra1.Size = new System.Drawing.Size(182, 37);
            this.labelOra1.TabIndex = 4;
            this.labelOra1.Text = "Ora 1:";
            this.labelOra1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelOra1.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxObiectivTuristic
            // 
            this.textBoxObiectivTuristic.Location = new System.Drawing.Point(201, 401);
            this.textBoxObiectivTuristic.Name = "textBoxObiectivTuristic";
            this.textBoxObiectivTuristic.Size = new System.Drawing.Size(227, 22);
            this.textBoxObiectivTuristic.TabIndex = 5;
            // 
            // textBoxOra1
            // 
            this.textBoxOra1.Location = new System.Drawing.Point(202, 448);
            this.textBoxOra1.Name = "textBoxOra1";
            this.textBoxOra1.Size = new System.Drawing.Size(225, 22);
            this.textBoxOra1.TabIndex = 6;
            // 
            // textBoxOra2
            // 
            this.textBoxOra2.Location = new System.Drawing.Point(203, 497);
            this.textBoxOra2.Name = "textBoxOra2";
            this.textBoxOra2.Size = new System.Drawing.Size(223, 22);
            this.textBoxOra2.TabIndex = 7;
            // 
            // labelIdExcursie
            // 
            this.labelIdExcursie.Location = new System.Drawing.Point(601, 401);
            this.labelIdExcursie.Name = "labelIdExcursie";
            this.labelIdExcursie.Size = new System.Drawing.Size(147, 22);
            this.labelIdExcursie.TabIndex = 8;
            this.labelIdExcursie.Text = "Id Excursie";
            // 
            // labelNume
            // 
            this.labelNume.Location = new System.Drawing.Point(601, 439);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(147, 22);
            this.labelNume.TabIndex = 9;
            this.labelNume.Text = "Nume";
            // 
            // labelNrTel
            // 
            this.labelNrTel.Location = new System.Drawing.Point(601, 474);
            this.labelNrTel.Name = "labelNrTel";
            this.labelNrTel.Size = new System.Drawing.Size(147, 22);
            this.labelNrTel.TabIndex = 10;
            this.labelNrTel.Text = "Numar Telefon";
            // 
            // labelNrBilete
            // 
            this.labelNrBilete.Location = new System.Drawing.Point(601, 507);
            this.labelNrBilete.Name = "labelNrBilete";
            this.labelNrBilete.Size = new System.Drawing.Size(147, 22);
            this.labelNrBilete.TabIndex = 11;
            this.labelNrBilete.Text = "Numar Bilete";
            // 
            // textBoxIdExcursie
            // 
            this.textBoxIdExcursie.Location = new System.Drawing.Point(742, 398);
            this.textBoxIdExcursie.Name = "textBoxIdExcursie";
            this.textBoxIdExcursie.Size = new System.Drawing.Size(227, 22);
            this.textBoxIdExcursie.TabIndex = 12;
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(742, 439);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(227, 22);
            this.textBoxNume.TabIndex = 13;
            // 
            // textBoxNumarTelefon
            // 
            this.textBoxNumarTelefon.Location = new System.Drawing.Point(742, 474);
            this.textBoxNumarTelefon.Name = "textBoxNumarTelefon";
            this.textBoxNumarTelefon.Size = new System.Drawing.Size(227, 22);
            this.textBoxNumarTelefon.TabIndex = 14;
            // 
            // textBoxNumarBilete
            // 
            this.textBoxNumarBilete.Location = new System.Drawing.Point(742, 507);
            this.textBoxNumarBilete.Name = "textBoxNumarBilete";
            this.textBoxNumarBilete.Size = new System.Drawing.Size(227, 22);
            this.textBoxNumarBilete.TabIndex = 15;
            // 
            // buttonCautare
            // 
            this.buttonCautare.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonCautare.Location = new System.Drawing.Point(121, 566);
            this.buttonCautare.Name = "buttonCautare";
            this.buttonCautare.Size = new System.Drawing.Size(188, 59);
            this.buttonCautare.TabIndex = 16;
            this.buttonCautare.Text = "Cautare";
            this.buttonCautare.UseVisualStyleBackColor = false;
            this.buttonCautare.Click += new System.EventHandler(this.buttonCautare_Click);
            // 
            // buttonRezervare
            // 
            this.buttonRezervare.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonRezervare.Location = new System.Drawing.Point(718, 566);
            this.buttonRezervare.Name = "buttonRezervare";
            this.buttonRezervare.Size = new System.Drawing.Size(186, 59);
            this.buttonRezervare.TabIndex = 17;
            this.buttonRezervare.Text = "Rezervare";
            this.buttonRezervare.UseVisualStyleBackColor = false;
            this.buttonRezervare.Click += new System.EventHandler(this.buttonRezervare_Click);
            // 
            // listBoxExcursii
            // 
            this.listBoxExcursii.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listBoxExcursii.FormattingEnabled = true;
            this.listBoxExcursii.ItemHeight = 16;
            this.listBoxExcursii.Location = new System.Drawing.Point(64, 29);
            this.listBoxExcursii.Name = "listBoxExcursii";
            this.listBoxExcursii.Size = new System.Drawing.Size(363, 324);
            this.listBoxExcursii.TabIndex = 18;
          
            // 
            // listBoxClienti
            // 
            this.listBoxClienti.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listBoxClienti.FormattingEnabled = true;
            this.listBoxClienti.ItemHeight = 16;
            this.listBoxClienti.Location = new System.Drawing.Point(601, 29);
            this.listBoxClienti.Name = "listBoxClienti";
            this.listBoxClienti.Size = new System.Drawing.Size(368, 324);
            this.listBoxClienti.TabIndex = 19;
            // 
            // Agentie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1095, 702);
            this.Controls.Add(this.listBoxClienti);
            this.Controls.Add(this.listBoxExcursii);
            this.Controls.Add(this.buttonRezervare);
            this.Controls.Add(this.buttonCautare);
            this.Controls.Add(this.textBoxNumarBilete);
            this.Controls.Add(this.textBoxNumarTelefon);
            this.Controls.Add(this.textBoxNume);
            this.Controls.Add(this.textBoxIdExcursie);
            this.Controls.Add(this.labelNrBilete);
            this.Controls.Add(this.labelNrTel);
            this.Controls.Add(this.labelNume);
            this.Controls.Add(this.labelIdExcursie);
            this.Controls.Add(this.textBoxOra2);
            this.Controls.Add(this.textBoxOra1);
            this.Controls.Add(this.textBoxObiectivTuristic);
            this.Controls.Add(this.labelOra1);
            this.Controls.Add(this.labelOra2);
            this.Controls.Add(this.Destinatie);
            this.Name = "Agentie";
            this.Text = "Agentie";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox listBoxClienti;

        private System.Windows.Forms.ListBox listBoxExcursii;

        private System.Windows.Forms.Button buttonRezervare;

        private System.Windows.Forms.TextBox textBoxIdExcursie;
        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.TextBox textBoxNumarTelefon;
        private System.Windows.Forms.TextBox textBoxNumarBilete;
        private System.Windows.Forms.Label labelNrTel;
        private System.Windows.Forms.Button buttonCautare;

        private System.Windows.Forms.Label labelIdExcursie;
        private System.Windows.Forms.Label labelNume;

        private System.Windows.Forms.Label labelNrBilete;

        private System.Windows.Forms.TextBox textBoxObiectivTuristic;
        private System.Windows.Forms.TextBox textBoxOra1;
        private System.Windows.Forms.TextBox textBoxOra2;

        private System.Windows.Forms.Label labelOra2;
        private System.Windows.Forms.Label labelOra1;

        private System.Windows.Forms.Label Destinatie;

        #endregion
    }
}