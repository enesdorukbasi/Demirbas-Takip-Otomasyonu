
namespace DemirbaşTakip
{
    partial class frmUrunVeyaKategori
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUrunVeyaKategori));
            this.btnKategori = new System.Windows.Forms.Button();
            this.btnDemirbas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKategori
            // 
            this.btnKategori.Location = new System.Drawing.Point(262, 12);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(244, 106);
            this.btnKategori.TabIndex = 3;
            this.btnKategori.Text = "Kategori";
            this.btnKategori.UseVisualStyleBackColor = true;
            this.btnKategori.Click += new System.EventHandler(this.btnKategori_Click);
            // 
            // btnDemirbas
            // 
            this.btnDemirbas.Location = new System.Drawing.Point(12, 12);
            this.btnDemirbas.Name = "btnDemirbas";
            this.btnDemirbas.Size = new System.Drawing.Size(244, 106);
            this.btnDemirbas.TabIndex = 2;
            this.btnDemirbas.Text = "Demirbaş";
            this.btnDemirbas.UseVisualStyleBackColor = true;
            this.btnDemirbas.Click += new System.EventHandler(this.btnDemirbas_Click);
            // 
            // frmUrunVeyaKategori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 130);
            this.Controls.Add(this.btnKategori);
            this.Controls.Add(this.btnDemirbas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUrunVeyaKategori";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUrunVeyaKategori";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKategori;
        private System.Windows.Forms.Button btnDemirbas;
    }
}