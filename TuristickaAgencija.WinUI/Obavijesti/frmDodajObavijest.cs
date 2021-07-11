using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuristickaAgencija.Model.Request;

namespace TuristickaAgencija.WinUI.Obavijesti
{

    public partial class frmDodajObavijest : Form
    {
        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _obavijestiService = new APIService("Obavijesti");
        private int? _id = null;
        public frmDodajObavijest(int? obavijestId = null)
        {
            InitializeComponent();
            _id = obavijestId;
        }
        private async Task LoadKorisnici()
        {

            var result = await _korisniciService.Get<List<Model.Korisnici>>(null);
            result.Insert(0, new Model.Korisnici());
            cmbKorisnik.DataSource = result;
            cmbKorisnik.DisplayMember = "KorisnickoIme";
            cmbKorisnik.ValueMember = "Id";
        }

        private async void frmDodajObavijest_Load(object sender, EventArgs e)
        {
            await LoadKorisnici();
            await LoadObavijesti();
        }

        private async Task LoadObavijesti()
        {
            if (_id.HasValue)
            {
                var obavijest = await _obavijestiService.GetById<Model.Obavijesti>((int)_id);
                txtNazivObavijesti.Text = obavijest.Naziv;
                txtSadrzajObavijesti.Text = obavijest.Sadrzaj;
                var korisnik = await _korisniciService.GetById<Model.Korisnici>((int)_id);
                cmbKorisnik.Text = korisnik.KorisnickoIme;
            }
        }
        private async void btnDodajObavijest_Click(object sender, EventArgs e)
        {
            ObavijestiInsertUpdateRequest request = new ObavijestiInsertUpdateRequest();
            if (this.ValidateChildren())
            {
                var idKorisnik = cmbKorisnik.SelectedValue;
                if (int.TryParse(idKorisnik.ToString(), out int KorisnikId))
                {
                    request.KorisnikId = KorisnikId;
                }


                
                request.Datum = DateTime.Now;
                request.Naziv = txtNazivObavijesti.Text;
                request.Sadrzaj = txtSadrzajObavijesti.Text;

                if (_id.HasValue)
                {
                    await _obavijestiService.Update<Model.Obavijesti>((int)_id, request);
                }
                else
                {
                    await _obavijestiService.Insert<Model.Obavijesti>(request);
                }
               

                MessageBox.Show("Operacija uspješna");
            }
        }

        private void txtNazivObavijesti_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivObavijesti.Text))
            {
                errorProvider1.SetError(txtNazivObavijesti, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNazivObavijesti, null);
            }
        }

        private void txtOpisPutovanja_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSadrzajObavijesti.Text))
            {
                errorProvider1.SetError(txtSadrzajObavijesti, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtSadrzajObavijesti, null);
            }
        }
        /*
        private void cmbKorisnik_Validating(object sender, CancelEventArgs e)
        {
            if (cmbKorisnik.SelectedItem==null)
            {
                errorProvider1.SetError(cmbKorisnik, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbKorisnik, null);
            }
        }*/
    }
}
