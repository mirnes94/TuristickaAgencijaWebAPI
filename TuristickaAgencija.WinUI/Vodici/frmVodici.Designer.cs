
namespace TuristickaAgencija.WinUI.Vodici
{
    partial class frmVodici
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
            this.Vodici = new System.Windows.Forms.GroupBox();
            this.dgvVodici = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.Vodici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVodici)).BeginInit();
            this.SuspendLayout();
            // 
            // Vodici
            // 
            this.Vodici.Controls.Add(this.dgvVodici);
            this.Vodici.Location = new System.Drawing.Point(12, 57);
            this.Vodici.Name = "Vodici";
            this.Vodici.Size = new System.Drawing.Size(530, 236);
            this.Vodici.TabIndex = 0;
            this.Vodici.TabStop = false;
            this.Vodici.Text = "Vodici";
            // 
            // dgvVodici
            // 
            this.dgvVodici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVodici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id});
            this.dgvVodici.Location = new System.Drawing.Point(6, 14);
            this.dgvVodici.Name = "dgvVodici";
            this.dgvVodici.RowTemplate.Height = 25;
            this.dgvVodici.Size = new System.Drawing.Size(518, 216);
            this.dgvVodici.TabIndex = 0;
            this.dgvVodici.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvVodici_MouseDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "ID";
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(198, 28);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.PlaceholderText = "Prezime";
            this.txtPrezime.Size = new System.Drawing.Size(140, 23);
            this.txtPrezime.TabIndex = 6;
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(18, 28);
            this.txtIme.Name = "txtIme";
            this.txtIme.PlaceholderText = "Ime";
            this.txtIme.Size = new System.Drawing.Size(140, 23);
            this.txtIme.TabIndex = 5;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(450, 28);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(86, 23);
            this.btnPrikazi.TabIndex = 4;
            this.btnPrikazi.Text = "Prikazi";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // frmVodici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 295);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.Vodici);
            this.Name = "frmVodici";
            this.Text = "frmVodici";
            this.Load += new System.EventHandler(this.frmVodici_Load);
            this.Vodici.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVodici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Vodici;
        private System.Windows.Forms.DataGridView dgvVodici;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}