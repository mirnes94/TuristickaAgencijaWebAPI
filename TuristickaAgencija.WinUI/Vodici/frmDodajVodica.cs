using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TuristickaAgencija.Model.Request;

namespace TuristickaAgencija.WinUI.Vodici
{
    public partial class frmDodajVodica : Form
    {
        private readonly APIService _service = new APIService("Vodic");
        private int? _id = null;
        


        public frmDodajVodica(int? vodicId = null)
        {
            InitializeComponent();
            _id = vodicId;
        }
        /*
        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                
                errorProvider.SetError(txtIme, "Obavezno polje");
                isFormValid = false;
            }
            else
            {
                isFormValid = true;
                errorProvider.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {

                errorProvider.SetError(txtPrezime, "Obavezno polje");
                isFormValid = false;
            }
            else
            {
                isFormValid = true;
                errorProvider.SetError(txtPrezime, null);
            }
        }

        private void txtKontakt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKontakt.Text))
            {

                errorProvider.SetError(txtKontakt, "Obavezno polje");
                isFormValid = false;
            }
            else
            {
                isFormValid = true;
                errorProvider.SetError(txtKontakt, null);
            }
        }

        private void txtJmbg_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJmbg.Text))
            {
                errorProvider.SetError(txtJmbg, "Obavezno polje");
                isFormValid = false;
            }
            else if (txtJmbg.Text.Length != 13 && IsNumber(txtJmbg.Text))
            {
                errorProvider.SetError(txtJmbg, "JMBG mora imati 13 znakova");
                isFormValid = false;
            }
            else
            {
                isFormValid = true;
                errorProvider.SetError(txtJmbg, null);
            }
        }
        private void txtSlikaInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSlikaInput.Text))
            {

                errorProvider.SetError(txtSlikaInput, "Obavezno polje");
                isFormValid = false;
            }
            else
            {
                isFormValid = true;
                errorProvider.SetError(txtSlikaInput, null);
            }
           
        }*/
        VodicInsertUpdateRequest request = new VodicInsertUpdateRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (IsFormValidAll())
            {


                request.Ime = txtIme.Text;
                request.Prezime = txtPrezime.Text;
                request.Kontakt = txtKontakt.Text;
                request.Jmbg = txtJmbg.Text;
                if (_id.HasValue)
                {
                    await _service.Update<Model.Vodic>((int)_id, request);
                }
                else
                {
                    await _service.Insert<Model.Vodic>(request);

                }
                MessageBox.Show("Operacija uspješna");
            }
            else
            {
                MessageBox.Show("Molimo Vas da ispravno popunite sva obavezna polja prije nego što nastavite.");
            }
        }
        
       
        
        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                
                var fileName = openFileDialog.FileName;

                var file = File.ReadAllBytes(fileName);

                request.Slika = file;

                txtSlikaInput.Text = fileName;

                Image image = Image.FromFile(fileName);

                pictureBox.Image = image;
              
            }
          

           
        }
        

        private async void frmDodajVodica_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var vodic= await _service.GetById<Model.Vodic>((int)_id);
                txtIme.Text = vodic.Ime;
                txtPrezime.Text = vodic.Prezime;
                txtJmbg.Text = vodic.Jmbg;
                txtKontakt.Text = vodic.Kontakt;
                
                    
            }
        }

        private bool IsFormValidAll()
        {
            // Resetirajte error providere prije nove provjere
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, "Obavezno polje");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, "Obavezno polje");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKontakt.Text))
            {
                errorProvider.SetError(txtKontakt, "Obavezno polje");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtJmbg.Text))
            {
                errorProvider.SetError(txtJmbg, "Obavezno polje");
                return false;
            }
            else if (txtJmbg.Text.Length != 13 || !IsNumber(txtJmbg.Text))
            {
                errorProvider.SetError(txtJmbg, "JMBG mora imati 13 cifara");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSlikaInput.Text))
            {
                errorProvider.SetError(txtSlikaInput, "Obavezno polje");
                return false;
            }

            return true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            return;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static bool IsNumber(string input)
        {
            // Koristi regex za proveru
            string pattern = @"^\d+$";
            return Regex.IsMatch(input, pattern);
        }

    }
}
