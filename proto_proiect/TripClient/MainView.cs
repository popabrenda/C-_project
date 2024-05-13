using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TripModel;
using TripService;
using Utils;

namespace TripClient
{
    public partial class MainView : Form
    {
        private ITripServices _server;
        // private ServiceUtilizator _serviceUtilizator;
        // private ServiceApplication _serviceApplication;
        // private ArrayList _listaUseriLogati = new ArrayList();

        public MainView(ITripServices server)
        {
            this._server = server;
            InitializeComponent();
        }
        
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            // this.loginPanel.Visible = false;
            // this.registerPanel.Visible = true;
            // this.ClearFields();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.registerPanel.Visible = false;
            this.loginPanel.Visible = true;
            this.ClearFields();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = usernameLogin.Text;
            string password = passwordLogin.Text;
            Console.WriteLine("MAIN VIEW |||||username + parloa luate din interfata: "+username + " " + password);
            ClearFields();
            Optional<Utilizator> clientOpt;
            MainApplication userStage = null;
            try
            {
                userStage = new MainApplication(this, _server);
                clientOpt = _server.LoginUser(username, password, userStage);
                Console.WriteLine("MAIN VIEW ||||| clientOpt:  "+ clientOpt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(userStage != null)
                    userStage.Close();
                // MessageAlert.showMessage(null, Alert.AlertType.ERROR, "Eroare", e.getMessage());
                return;
            }
            if (!clientOpt.HasValue)
            {
                if (userStage != null)
                    userStage.Close();
                MessageBox.Show("Nu exista userul", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            userStage.SetUtilizator(clientOpt.Value);
            userStage.Show();
            this.Hide();

           
        }
        
        private void ClearFields(){
            numeTextField.Clear();
            usernameLogin.Clear();
            passwordField.Clear();
            usernameRegister.Clear();
            passwordLogin.Clear();
        }

        private void buttonAddNewUser_Click(object sender, EventArgs e)
        {
            // registerPanel.Visible = false;
            // loginPanel.Visible = true;
            // try {
            //     this._serviceUtilizator.RegisterUser(usernameRegister.Text, passwordField.Text, numeTextField.Text);
            // }
            // catch (Exception ex){
            //     MessageBox.Show("Eroare", "Exista usernameul");
            // }
            ClearFields();
        }
    }
}