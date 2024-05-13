using System.ComponentModel;
using System.Windows.Forms;

namespace TripClient
{
    partial class MainApplication
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
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.buttonCauta = new System.Windows.Forms.Button();
            this.mainGridView = new System.Windows.Forms.DataGridView();
            this.secondGridView = new System.Windows.Forms.DataGridView();
            this.comboDeLa = new System.Windows.Forms.ComboBox();
            this.fieldObiectiv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPanaLa = new System.Windows.Forms.ComboBox();
            this.buttonRezerva = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.fieldClient = new System.Windows.Forms.TextBox();
            this.formRezervare = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fieldTelefon = new System.Windows.Forms.TextBox();
            this.fieldNumarBilete = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondGridView)).BeginInit();
            this.formRezervare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldNumarBilete)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.Width = -1;
            // 
            // buttonCauta
            // 
            this.buttonCauta.Location = new System.Drawing.Point(482, 361);
            this.buttonCauta.Name = "buttonCauta";
            this.buttonCauta.Size = new System.Drawing.Size(179, 47);
            this.buttonCauta.TabIndex = 1;
            this.buttonCauta.Text = "Cauta";
            this.buttonCauta.UseVisualStyleBackColor = true;
            this.buttonCauta.Click += new System.EventHandler(this.buttonCauta_Click);
            // 
            // mainGridView
            // 
            this.mainGridView.AllowUserToAddRows = false;
            this.mainGridView.AllowUserToDeleteRows = false;
            this.mainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainGridView.Location = new System.Drawing.Point(139, 0);
            this.mainGridView.MultiSelect = false;
            this.mainGridView.Name = "mainGridView";
            this.mainGridView.ReadOnly = true;
            this.mainGridView.RowTemplate.Height = 28;
            this.mainGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainGridView.Size = new System.Drawing.Size(884, 215);
            this.mainGridView.TabIndex = 0;
            this.mainGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.mainGridView_RowPostPaint);
            // 
            // secondGridView
            // 
            this.secondGridView.AllowUserToAddRows = false;
            this.secondGridView.AllowUserToDeleteRows = false;
            this.secondGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.secondGridView.Location = new System.Drawing.Point(140, 414);
            this.secondGridView.MultiSelect = false;
            this.secondGridView.Name = "secondGridView";
            this.secondGridView.ReadOnly = true;
            this.secondGridView.RowTemplate.Height = 28;
            this.secondGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.secondGridView.Size = new System.Drawing.Size(884, 172);
            this.secondGridView.TabIndex = 2;
            this.secondGridView.Visible = false;
            this.secondGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.secondGridView_RowPostPaint);
            this.secondGridView.SelectionChanged += new System.EventHandler(this.secondGridView_SelectionChanged);
            // 
            // comboDeLa
            // 
            this.comboDeLa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboDeLa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDeLa.FormattingEnabled = true;
            this.comboDeLa.Location = new System.Drawing.Point(526, 19);
            this.comboDeLa.Name = "comboDeLa";
            this.comboDeLa.Size = new System.Drawing.Size(160, 28);
            this.comboDeLa.TabIndex = 4;
            // 
            // fieldObiectiv
            // 
            this.fieldObiectiv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fieldObiectiv.Location = new System.Drawing.Point(98, 87);
            this.fieldObiectiv.Name = "fieldObiectiv";
            this.fieldObiectiv.Size = new System.Drawing.Size(207, 26);
            this.fieldObiectiv.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Location = new System.Drawing.Point(96, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Obiectiv Turistic";
            // 
            // comboPanaLa
            // 
            this.comboPanaLa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboPanaLa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPanaLa.FormattingEnabled = true;
            this.comboPanaLa.Location = new System.Drawing.Point(526, 86);
            this.comboPanaLa.Name = "comboPanaLa";
            this.comboPanaLa.Size = new System.Drawing.Size(160, 28);
            this.comboPanaLa.TabIndex = 7;
            // 
            // buttonRezerva
            // 
            this.buttonRezerva.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRezerva.Location = new System.Drawing.Point(259, 126);
            this.buttonRezerva.Name = "buttonRezerva";
            this.buttonRezerva.Size = new System.Drawing.Size(179, 49);
            this.buttonRezerva.TabIndex = 8;
            this.buttonRezerva.Text = "Rezerva";
            this.buttonRezerva.UseVisualStyleBackColor = true;
            this.buttonRezerva.Click += new System.EventHandler(this.buttonRezerva_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCancel.Location = new System.Drawing.Point(444, 126);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(179, 49);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // fieldClient
            // 
            this.fieldClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fieldClient.Location = new System.Drawing.Point(558, 9);
            this.fieldClient.Name = "fieldClient";
            this.fieldClient.Size = new System.Drawing.Size(207, 26);
            this.fieldClient.TabIndex = 10;
            // 
            // formRezervare
            // 
            this.formRezervare.ColumnCount = 2;
            this.formRezervare.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formRezervare.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formRezervare.Controls.Add(this.label4, 0, 2);
            this.formRezervare.Controls.Add(this.label3, 0, 1);
            this.formRezervare.Controls.Add(this.fieldClient, 1, 0);
            this.formRezervare.Controls.Add(this.buttonCancel, 1, 3);
            this.formRezervare.Controls.Add(this.fieldTelefon, 1, 1);
            this.formRezervare.Controls.Add(this.buttonRezerva, 0, 3);
            this.formRezervare.Controls.Add(this.fieldNumarBilete, 1, 2);
            this.formRezervare.Controls.Add(this.label2, 0, 0);
            this.formRezervare.Location = new System.Drawing.Point(140, 592);
            this.formRezervare.Name = "formRezervare";
            this.formRezervare.RowCount = 4;
            this.formRezervare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formRezervare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formRezervare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.formRezervare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.formRezervare.Size = new System.Drawing.Size(883, 178);
            this.formRezervare.TabIndex = 11;
            this.formRezervare.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Location = new System.Drawing.Point(145, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "Numar bilete";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Location = new System.Drawing.Point(145, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Telefon Client";
            // 
            // fieldTelefon
            // 
            this.fieldTelefon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fieldTelefon.Location = new System.Drawing.Point(558, 54);
            this.fieldTelefon.Name = "fieldTelefon";
            this.fieldTelefon.Size = new System.Drawing.Size(207, 26);
            this.fieldTelefon.TabIndex = 11;
            // 
            // fieldNumarBilete
            // 
            this.fieldNumarBilete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fieldNumarBilete.Location = new System.Drawing.Point(598, 93);
            this.fieldNumarBilete.Name = "fieldNumarBilete";
            this.fieldNumarBilete.Size = new System.Drawing.Size(127, 26);
            this.fieldNumarBilete.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Location = new System.Drawing.Point(145, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nume Client";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fieldObiectiv, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboPanaLa, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboDeLa, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(173, 221);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(809, 134);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // MainApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1199, 802);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.formRezervare);
            this.Controls.Add(this.secondGridView);
            this.Controls.Add(this.buttonCauta);
            this.Controls.Add(this.mainGridView);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainApplication";
            this.Text = "Aplicatie";
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondGridView)).EndInit();
            this.formRezervare.ResumeLayout(false);
            this.formRezervare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldNumarBilete)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        private System.Windows.Forms.TextBox fieldTelefon;
        private System.Windows.Forms.NumericUpDown fieldNumarBilete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TableLayoutPanel formRezervare;

        private System.Windows.Forms.TextBox fieldClient;

        private System.Windows.Forms.Button buttonRezerva;
        private System.Windows.Forms.Button buttonCancel;

        private System.Windows.Forms.ComboBox comboPanaLa;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ComboBox comboDeLa;
        private System.Windows.Forms.TextBox fieldObiectiv;

        private System.Windows.Forms.DataGridView secondGridView;

        private System.Windows.Forms.DataGridView mainGridView;

        private System.Windows.Forms.Button buttonCauta;

        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;

        #endregion
    }
}