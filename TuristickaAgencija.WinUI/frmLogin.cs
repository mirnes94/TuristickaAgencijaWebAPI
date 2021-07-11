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
            try
            {
                APIService.Username = txtKorisnickoIme.Text;
                APIService.Password = txtLozinka.Text;
                await _service.Get<dynamic>(null);

                frmIndex frm = new frmIndex();
                frm.Show();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Authentikacija",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
