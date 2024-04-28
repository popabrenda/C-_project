using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Config;
using PoateAiciFunctioneaza.Domain;
using PoateAiciFunctioneaza.Repository;
using PoateAiciFunctioneaza.Service;

namespace WindowsFormsAppLogIn
{
    public partial class Form1 : Form
    {
        protected IService service;

        public Form1(IService service)
        {
            InitializeComponent();
            textBoxParola.UseSystemPasswordChar = true;
            this.service = service;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IUtilizatorReposiroty utilizatorRepository;
            //SignInBuuton
            String username = textBoxUsername.Text;
            String parola = textBoxParola.Text;
            Console.Write("Username primit:"+username);
            Console.Write("Parola primita:"+parola);

            try
            {
                if (service.validateUsername(username, parola))
                {
                    Agentie agentie = new Agentie(service);
                    agentie.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Parola introdusă este greșită!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}