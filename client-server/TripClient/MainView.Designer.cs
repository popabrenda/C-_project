namespace TripClient
{
    partial class MainView
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
            this.loginPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.passwordLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameLogin = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.registerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.usernameRegister = new System.Windows.Forms.TextBox();
            this.buttonAddNewUser = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numeTextField = new System.Windows.Forms.TextBox();
            this.loginPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.registerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loginPanel.ColumnCount = 2;
            this.loginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.loginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.loginPanel.Controls.Add(this.buttonLogin, 1, 2);
            this.loginPanel.Controls.Add(this.passwordLogin, 1, 1);
            this.loginPanel.Controls.Add(this.label1, 0, 0);
            this.loginPanel.Controls.Add(this.label2, 0, 1);
            this.loginPanel.Controls.Add(this.usernameLogin, 1, 0);
            this.loginPanel.Controls.Add(this.buttonRegister, 0, 2);
            this.loginPanel.Location = new System.Drawing.Point(193, 127);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.RowCount = 3;
            this.loginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.loginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.loginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.loginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.loginPanel.Size = new System.Drawing.Size(634, 314);
            this.loginPanel.TabIndex = 0;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonLogin.Location = new System.Drawing.Point(320, 273);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(109, 38);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // passwordLogin
            // 
            this.passwordLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordLogin.Location = new System.Drawing.Point(320, 189);
            this.passwordLogin.Name = "passwordLogin";
            this.passwordLogin.PasswordChar = '*';
            this.passwordLogin.Size = new System.Drawing.Size(311, 26);
            this.passwordLogin.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Location = new System.Drawing.Point(68, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Location = new System.Drawing.Point(68, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 43);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // usernameLogin
            // 
            this.usernameLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameLogin.Location = new System.Drawing.Point(320, 54);
            this.usernameLogin.Name = "usernameLogin";
            this.usernameLogin.Size = new System.Drawing.Size(311, 26);
            this.usernameLogin.TabIndex = 2;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRegister.Location = new System.Drawing.Point(205, 273);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(109, 38);
            this.buttonRegister.TabIndex = 4;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(103, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 34);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(103, 23);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(94, 26);
            this.textBox3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // registerPanel
            // 
            this.registerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.registerPanel.ColumnCount = 2;
            this.registerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.registerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.registerPanel.Controls.Add(this.buttonCancel, 1, 3);
            this.registerPanel.Controls.Add(this.passwordField, 1, 2);
            this.registerPanel.Controls.Add(this.label4, 0, 0);
            this.registerPanel.Controls.Add(this.label5, 0, 2);
            this.registerPanel.Controls.Add(this.usernameRegister, 1, 0);
            this.registerPanel.Controls.Add(this.buttonAddNewUser, 0, 3);
            this.registerPanel.Controls.Add(this.label6, 0, 1);
            this.registerPanel.Controls.Add(this.numeTextField, 1, 1);
            this.registerPanel.Location = new System.Drawing.Point(193, 124);
            this.registerPanel.Name = "registerPanel";
            this.registerPanel.RowCount = 4;
            this.registerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.registerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.registerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.registerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.registerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.registerPanel.Size = new System.Drawing.Size(634, 314);
            this.registerPanel.TabIndex = 1;
            this.registerPanel.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCancel.Location = new System.Drawing.Point(320, 267);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(109, 44);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // passwordField
            // 
            this.passwordField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordField.Location = new System.Drawing.Point(320, 206);
            this.passwordField.Name = "passwordField";
            this.passwordField.PasswordChar = '*';
            this.passwordField.Size = new System.Drawing.Size(311, 26);
            this.passwordField.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Location = new System.Drawing.Point(68, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 41);
            this.label4.TabIndex = 0;
            this.label4.Text = "Username";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Location = new System.Drawing.Point(68, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 37);
            this.label5.TabIndex = 1;
            this.label5.Text = "Password";
            // 
            // usernameRegister
            // 
            this.usernameRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameRegister.Location = new System.Drawing.Point(320, 32);
            this.usernameRegister.Name = "usernameRegister";
            this.usernameRegister.Size = new System.Drawing.Size(311, 26);
            this.usernameRegister.TabIndex = 2;
            // 
            // buttonAddNewUser
            // 
            this.buttonAddNewUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddNewUser.Location = new System.Drawing.Point(205, 267);
            this.buttonAddNewUser.Name = "buttonAddNewUser";
            this.buttonAddNewUser.Size = new System.Drawing.Size(109, 44);
            this.buttonAddNewUser.TabIndex = 4;
            this.buttonAddNewUser.Text = "Register";
            this.buttonAddNewUser.UseVisualStyleBackColor = true;
            this.buttonAddNewUser.Click += new System.EventHandler(this.buttonAddNewUser_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Location = new System.Drawing.Point(68, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 32);
            this.label6.TabIndex = 6;
            this.label6.Text = "Nume";
            // 
            // numeTextField
            // 
            this.numeTextField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numeTextField.Location = new System.Drawing.Point(320, 119);
            this.numeTextField.Name = "numeTextField";
            this.numeTextField.Size = new System.Drawing.Size(311, 26);
            this.numeTextField.TabIndex = 7;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 604);
            this.Controls.Add(this.registerPanel);
            this.Controls.Add(this.loginPanel);
            this.Name = "MainView";
            this.Text = "Login";
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.registerPanel.ResumeLayout(false);
            this.registerPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox numeTextField;

        private System.Windows.Forms.TableLayoutPanel registerPanel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox usernameRegister;
        private System.Windows.Forms.Button buttonAddNewUser;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameLogin;
        private System.Windows.Forms.TextBox passwordLogin;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonLogin;

        private System.Windows.Forms.TableLayoutPanel loginPanel;

        #endregion
    }
}