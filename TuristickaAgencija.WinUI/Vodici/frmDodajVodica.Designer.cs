
namespace TuristickaAgencija.WinUI.Vodici
{
    partial class frmDodajVodica
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
            this.components = new System.ComponentModel.Container();
            this.Prezime = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.Ime = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.Kontakt = new System.Windows.Forms.Label();
            this.txtKontakt = new System.Windows.Forms.TextBox();
            this.Jmbg = new System.Windows.Forms.Label();
            this.txtJmbg = new System.Windows.Forms.TextBox();
            this.txtSlikaInput = new System.Windows.Forms.TextBox();
            this.btnUploadPicture = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Prezime
            // 
            this.Prezime.AutoSize = true;
            this.Prezime.Location = new System.Drawing.Point(12, 88);
            this.Prezime.Name = "Prezime";
            this.Prezime.Size = new System.Drawing.Size(49, 15);
            this.Prezime.TabIndex = 7;
            this.Prezime.Text = "Prezime";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(11, 106);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(201, 23);
            this.txtPrezime.TabIndex = 6;
            this.txtPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrezime_Validating);
            // 
            // Ime
            // 
            this.Ime.AutoSize = true;
            this.Ime.Location = new System.Drawing.Point(13, 31);
            this.Ime.Name = "Ime";
            this.Ime.Size = new System.Drawing.Size(27, 15);
            this.Ime.TabIndex = 5;
            this.Ime.Text = "Ime";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(12, 52);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(200, 23);
            this.txtIme.TabIndex = 4;
            this.txtIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtIme_Validating);
            // 
            // Kontakt
            // 
            this.Kontakt.AutoSize = true;
            this.Kontakt.Location = new System.Drawing.Point(12, 145);
            this.Kontakt.Name = "Kontakt";
            this.Kontakt.Size = new System.Drawing.Size(48, 15);
            this.Kontakt.TabIndex = 9;
            this.Kontakt.Text = "Kontakt";
            // 
            // txtKontakt
            // 
            this.txtKontakt.Location = new System.Drawing.Point(11, 163);
            this.txtKontakt.Name = "txtKontakt";
            this.txtKontakt.Size = new System.Drawing.Size(201, 23);
            this.txtKontakt.TabIndex = 8;
            this.txtKontakt.Validating += new System.ComponentModel.CancelEventHandler(this.txtKontakt_Validating);
            // 
            // Jmbg
            // 
            this.Jmbg.AutoSize = true;
            this.Jmbg.Location = new System.Drawing.Point(12, 202);
            this.Jmbg.Name = "Jmbg";
            this.Jmbg.Size = new System.Drawing.Size(37, 15);
            this.Jmbg.TabIndex = 11;
            this.Jmbg.Text = "JMBG";
            // 
            // txtJmbg
            // 
            this.txtJmbg.Location = new System.Drawing.Point(11, 220);
            this.txtJmbg.Name = "txtJmbg";
            this.txtJmbg.Size = new System.Drawing.Size(201, 23);
            this.txtJmbg.TabIndex = 10;
            this.txtJmbg.Validating += new System.ComponentModel.CancelEventHandler(this.txtJmbg_Validating);
            // 
            // txtSlikaInput
            // 
            this.txtSlikaInput.Location = new System.Drawing.Point(251, 131);
            this.txtSlikaInput.Name = "txtSlikaInput";
            this.txtSlikaInput.Size = new System.Drawing.Size(153, 23);
            this.txtSlikaInput.TabIndex = 32;
            this.txtSlikaInput.Validating += new System.ComponentModel.CancelEventHandler(this.txtSlikaInput_Validating);
            // 
            // btnUploadPicture
            // 
            this.btnUploadPicture.Location = new System.Drawing.Point(416, 130);
            this.btnUploadPicture.Name = "btnUploadPicture";
            this.btnUploadPicture.Size = new System.Drawing.Size(75, 23);
            this.btnUploadPicture.TabIndex = 31;
            this.btnUploadPicture.Text = "Upload";
            this.btnUploadPicture.UseVisualStyleBackColor = true;
            this.btnUploadPicture.Click += new System.EventHandler(this.btnUploadPicture_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(416, 220);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 33;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(251, 52);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(240, 72);
            this.pictureBox.TabIndex = 34;
            this.pictureBox.TabStop = false;
            // 
            // frmDodajVodica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 265);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.txtSlikaInput);
            this.Controls.Add(this.btnUploadPicture);
            this.Controls.Add(this.Jmbg);
            this.Controls.Add(this.txtJmbg);
            this.Controls.Add(this.Kontakt);
            this.Controls.Add(this.txtKontakt);
            this.Controls.Add(this.Prezime);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.Ime);
            this.Controls.Add(this.txtIme);
            this.Name = "frmDodajVodica";
            this.Text = "frmDodajVodica";
            this.Load += new System.EventHandler(this.frmDodajVodica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Prezime;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label Ime;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label Kontakt;
        private System.Windows.Forms.TextBox txtKontakt;
        private System.Windows.Forms.Label Jmbg;
        private System.Windows.Forms.TextBox txtJmbg;
        private System.Windows.Forms.TextBox txtSlikaInput;
        private System.Windows.Forms.Button btnUploadPicture;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}