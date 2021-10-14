using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TuristickaAgencija.WinUI
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("Korisnici");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.Username = txtKorisnickoIme.Text;
            APIService.Password = txtLozinka.Text;
            try
            {
                if (string.IsNullOrEmpty(txtKorisnickoIme.Text) || string.IsNullOrEmpty(txtLozinka.Text))
                {
                    MessageBox.Show("All fields are required! Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {
                  
                    Model.Korisnici korisnik = await _service.Authentication<Model.Korisnici>(txtKorisnickoIme.Text, txtLozinka.Text);

                    MessageBox.Show("Welcome:\n " + korisnik.Ime + " " + korisnik.Prezime);
                    DialogResult = DialogResult.OK;
                    this.Hide();
                   
                    frmIndex frm = new frmIndex();
                    frm.Show();
                   
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Wrong username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
