
namespace DemirbaşTakip
{
    partial class frmPersonelVeyaMudur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonelVeyaMudur));
            this.btnMudur = new System.Windows.Forms.Button();
            this.btnPersonel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMudur
            // 
            this.btnMudur.Location = new System.Drawing.Point(12, 12);
            this.btnMudur.Name = "btnMudur";
            this.btnMudur.Size = new System.Drawing.Size(244, 106);
            this.btnMudur.TabIndex = 0;
            this.btnMudur.Text = "Müdür";
            this.btnMudur.UseVisualStyleBackColor = true;
            this.btnMudur.Click += new System.EventHandler(this.btnMudur_Click);
            // 
            // btnPersonel
            // 
            this.btnPersonel.Location = new System.Drawing.Point(262, 12);
            this.btnPersonel.Name = "btnPersonel";
            this.btnPersonel.Size = new System.Drawing.Size(244, 106);
            this.btnPersonel.TabIndex = 1;
            this.btnPersonel.Text = "Personel";
            this.btnPersonel.UseVisualStyleBackColor = true;
            this.btnPersonel.Click += new System.EventHandler(this.btnPersonel_Click);
            // 
            // frmPersonelVeyaMudur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 130);
            this.Controls.Add(this.btnPersonel);
            this.Controls.Add(this.btnMudur);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonelVeyaMudur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPersonelVeyaMudur";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMudur;
        private System.Windows.Forms.Button btnPersonel;
    }
}