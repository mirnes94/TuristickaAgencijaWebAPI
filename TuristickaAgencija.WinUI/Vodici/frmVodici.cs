using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuristickaAgencija.Model.Request;

namespace TuristickaAgencija.WinUI.Vodici
{
    
    public partial class frmVodici : Form
    {
        private readonly APIService _apiService = new APIService("Vodic");
        public frmVodici()
        {
            InitializeComponent();
            this.dgvVodici.DataError += dataGridView1_DataError;

        }
        private async Task LoadVodici()
        {
            var result = await _apiService.Get<List<Model.Vodic>>(null);
            dgvVodici.DataSource = result;
        }
        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new VodicSearchRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text
            };
            var result = await _apiService.Get<List<Model.Vodic>>(search);
            dgvVodici.DataSource = result;
        }

        private void dgvVodici_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvVodici.SelectedRows[0].Cells[0].Value;

            frmDodajVodica frm = new frmDodajVodica(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void frmVodici_Load(object sender, EventArgs e)
        {
            await LoadVodici();
        }

        private void dgvVodici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Ovaj događaj će se pozvati kada se desi greška u podacima DataGridView-a
            // e.RowIndex i e.ColumnIndex pružaju informacije o indeksima reda i kolone gde se greška desila
            // e.Context pruža informacije o kontekstu u kojem se greška desila

            MessageBox.Show($"Greška u podacima na indeksu reda {e.RowIndex} i koloni {e.ColumnIndex}. Detalji: {e.Exception.Message}");

            // Postavljanje e.Cancel na true sprečava da DataGridView sam rukuje greškom
            e.Cancel = true;
        }
    }
}
