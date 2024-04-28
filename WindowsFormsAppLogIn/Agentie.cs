using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PoateAiciFunctioneaza.Domain;
using PoateAiciFunctioneaza.Service;

namespace WindowsFormsAppLogIn
{
    public partial class Agentie : Form
    {
        private IService service;
       
        public Agentie(IService service)
        {
            InitializeComponent();
            this.service = service;
            loadDataExcursiiListBox();
            loadDataClientiListBox();
        }
        
        private void label1_Click_1(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

     
        
        private void button1Cautare_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void loadDataExcursiiListBox()
        {
            IEnumerable<Excursie> excursii = service.getAllExcursii();
            listBoxExcursii.Items.Clear();
            foreach (Excursie excursie in excursii)
            {
                listBoxExcursii.Items.Add(excursie);
            }
        }
        private void loadDataClientiListBox()
        {
           IEnumerable<Client> clienti = service.getAllClienti();
          listBoxClienti.Items.Clear();
           foreach (Client client in clienti)
           {
               listBoxClienti.Items.Add(client);
           }
        }
        private void buttonRezervare_Click(object sender, EventArgs e)
        {
            try
            {
                int idExcursie = int.Parse(textBoxIdExcursie.Text); 
                //Excursie excursie = service.Find(idExcursie);
                string numeClient = textBoxNume.Text;
                string telefonClient = textBoxNumarTelefon.Text;
                int nrBilete = int.Parse(textBoxNumarBilete.Text);
                Client client = service.FindClient(numeClient, telefonClient);
                Excursie excursie = service.FindExcursie(idExcursie);

               if(excursie.locuriDisponibile>= nrBilete)
                service.addRezervare(client, excursie, nrBilete);
               else throw new Exception("Nu sunt suficiente locuri disponibile");
                
                var excursiiActualizate = service.getAllExcursii(); 
                listBoxExcursii.Items.Clear();
                foreach (Excursie excursie1 in excursiiActualizate)
                {
                    listBoxExcursii.Items.Add(excursie1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la efectuarea rezervării: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void buttonCautare_Click(object sender, EventArgs e)
        {
            string obiectiv = textBoxObiectivTuristic.Text;
            int ora1 = int.Parse(textBoxOra1.Text);
            int ora2 = int.Parse(textBoxOra2.Text);
         
            
            var excursiiFiltrate = service.filterExcursii(obiectiv, ora1, ora2);
            listBoxExcursii.Items.Clear();
            foreach (Excursie excursie in excursiiFiltrate)
            {
                listBoxExcursii.Items.Add(excursie);
            }

            
        }
    }
}