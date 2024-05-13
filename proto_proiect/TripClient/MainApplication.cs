using System;
using System.Threading;
using System.Windows.Forms;
using TripModel;
using TripService;

namespace TripClient
{
    public partial class MainApplication : Form, ITripObserver
    {
        private ITripServices _serviceApplication;
        private MainView parent;
        private Utilizator _utilizator;
        private string _obiectiv;
        private string _deLa;
        private string _panaLa;
        public MainApplication(MainView parent,ITripServices serviceApplication, Utilizator utilizator=null)
        {
            this.parent = parent;
            this._serviceApplication = serviceApplication;
            this._utilizator = utilizator;
            // _serviceApplication.AddObserver(this);
            InitializeComponent();
        }

        public void SetUtilizator(Utilizator utilizator)
        {
            _utilizator = utilizator;
            LoadMainGridView();
            LoadSecondGridView();
            LoadComboBoxes();
            this.Closing += (sender, args) => LogOutUser();
        }
        
        private void LogOutUser()
        {
            if(_utilizator == null)
                return;
            try
            {
                _serviceApplication.LogOut(_utilizator.Username);
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadMainGridView()
        {
            mainGridView.ColumnCount = 6;
            mainGridView.Columns[0].Name = "Id";
            mainGridView.Columns[1].Name = "Obiectiv turistic";
            mainGridView.Columns[2].Name = "Firma transport";
            mainGridView.Columns[3].Name = "Ora plecarii";
            mainGridView.Columns[4].Name = "Pret";
            mainGridView.Columns[5].Name = "Numar locuri disponibile";
            mainGridView.Columns[0].Visible = false;
            ReloadMainGridView();
        }

        private void LoadSecondGridView()
        {
            secondGridView.ColumnCount = 6;
            secondGridView.Columns[0].Name = "Id";
            secondGridView.Columns[1].Name = "Obiectiv turistic";
            secondGridView.Columns[2].Name = "Firma transport";
            secondGridView.Columns[3].Name = "Ora plecarii";
            secondGridView.Columns[4].Name = "Pret";
            secondGridView.Columns[5].Name = "Numar locuri disponibile";
            secondGridView.Columns[0].Visible = false;
            // ReloadSecondGridView();
        }

        private void LoadComboBoxes()
        {
            comboDeLa.Items.Add("De la");
            comboPanaLa.Items.Add("Pana la");
            comboDeLa.SelectedIndex = 0;
            comboPanaLa.SelectedIndex = 0;
            for (int i = 0; i < 24; i+=2)
            {
                comboDeLa.Items.Add(i + ":00");
                comboPanaLa.Items.Add(i + ":00");
            }
        }

        private void ReloadSecondGridView()
        {
                var listaExcursiiFiltrate =
                    _serviceApplication.GetExcursiiByFilter(_obiectiv, TimeSpan.Parse(_deLa), TimeSpan.Parse(_panaLa));
                secondGridView.Rows.Clear();
                foreach (var excursie in listaExcursiiFiltrate)
                {
                    secondGridView.Rows.Add(excursie.Id, excursie.ObiectivTuristic, excursie.FirmaTransport,
                        excursie.OraPlecarii, excursie.Pret, excursie.NumarLocuriDisponibile);
                }

                secondGridView.ClearSelection();

            
        }

        private void ReloadMainGridView()
        {
            mainGridView.Rows.Clear();
            var listaExcursii = _serviceApplication.GetAllExcursii();
            
            foreach (var excursie in listaExcursii)
            {
                mainGridView.Rows.Add(excursie.Id, excursie.ObiectivTuristic, excursie.FirmaTransport,
                    excursie.OraPlecarii, excursie.Pret, excursie.NumarLocuriDisponibile);
            }
        }

        private void buttonCauta_Click(object sender, EventArgs e)
        {
            if (_obiectiv == "")
            {
                MessageBox.Show("Introduceti obiectivul turistic");
                return;
            }
            if (comboDeLa.SelectedIndex == 0 || comboPanaLa.SelectedIndex == 0 || TimeSpan.Parse(comboDeLa.SelectedItem.ToString()) >= TimeSpan.Parse(comboPanaLa.SelectedItem.ToString()))
            {
                MessageBox.Show("Selectati corect intervalul orar");
                return;
            }
            secondGridView.Visible = true;
            _obiectiv = fieldObiectiv.Text;
            _deLa = comboDeLa.SelectedItem.ToString();
            _panaLa = comboPanaLa.SelectedItem.ToString();
            ReloadSecondGridView();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Update();
            ClearForm();
        }

        private void ClearForm()
        {
            formRezervare.Visible = false;
            fieldTelefon.Clear();
            fieldClient.Clear();
            fieldNumarBilete.Value = 0;
            secondGridView.ClearSelection();
        }

        private void secondGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (secondGridView.SelectedRows.Count == 0)
            {
                formRezervare.Visible = false;
                return;
            }
            var selectedRowNrBilete = int.Parse(secondGridView.SelectedRows[0].Cells[5].Value.ToString());
            if (selectedRowNrBilete == 0)
            {
                secondGridView.ClearSelection();
                return;
            }
            formRezervare.Visible = true;
            fieldNumarBilete.Maximum = int.Parse(secondGridView.SelectedRows[0].Cells[5].Value.ToString());
        }

        private void buttonRezerva_Click(object sender, EventArgs e)
        {
            if(secondGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectati o excursie");
                return;
            }
            var idExcursie = int.Parse(secondGridView.SelectedRows[0].Cells[0].Value.ToString());
            var numarTelefon = fieldTelefon.Text;
            var numeClient = fieldClient.Text;
            if (numeClient == "" || numarTelefon == "")
            {
                MessageBox.Show("Introduceti numele si numarul de telefon");
                return;
            }

            var numarBilete = int.Parse(fieldNumarBilete.Value.ToString());
            if (numarBilete == 0)
            {
                MessageBox.Show("Introduceti numarul de bilete");
                return;
            }
            
            try
            {
                _serviceApplication.RezervaBilete(idExcursie, numeClient, numarTelefon, numarBilete);
                ClearForm();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Nu mai sunt locuri disponibile pentru aceasta excursie");
                return;
            }
        }
        private void mainGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if(e.RowIndex == 0) return;
            var numarLocuri = int.Parse(mainGridView.Rows[e.RowIndex].Cells[5].Value.ToString());
            if (numarLocuri == 0)
            {
                mainGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void secondGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if(e.RowIndex == 0) return;
            var numarLocuri = int.Parse(secondGridView.Rows[e.RowIndex].Cells[5].Value.ToString());
            if (numarLocuri == 0)
            {
                secondGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            }
        }

        public new void Update()
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    ReloadMainGridView();
                    ReloadSecondGridView();
                });
            }
            else
            {
                ReloadMainGridView();
                ReloadSecondGridView();
            }

        }

        public void ReservationUpdate()
        {
            Update();
        }
        
    }
}