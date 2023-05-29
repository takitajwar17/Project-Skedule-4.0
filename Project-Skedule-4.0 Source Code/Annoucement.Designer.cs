namespace Skedule_v3
{
    partial class Announcement
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
            this.labelLogin = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.dgw_announce = new System.Windows.Forms.DataGridView();
            this.txt_notice = new System.Windows.Forms.TextBox();
            this.buttondash = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_announce)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Ebrima", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.ForeColor = System.Drawing.SystemColors.Control;
            this.labelLogin.Location = new System.Drawing.Point(57, 18);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(273, 45);
            this.labelLogin.TabIndex = 12;
            this.labelLogin.Text = "Announcements";
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(45)))));
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Ebrima", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonLogin.Location = new System.Drawing.Point(914, 553);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(97, 38);
            this.buttonLogin.TabIndex = 41;
            this.buttonLogin.Text = "Add";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(45)))));
            this.btn_remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_remove.FlatAppearance.BorderSize = 0;
            this.btn_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_remove.Font = new System.Drawing.Font("Ebrima", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remove.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_remove.Location = new System.Drawing.Point(1019, 553);
            this.btn_remove.Margin = new System.Windows.Forms.Padding(4);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(97, 38);
            this.btn_remove.TabIndex = 41;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = false;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // dgw_announce
            // 
            this.dgw_announce.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_announce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_announce.Location = new System.Drawing.Point(25, 66);
            this.dgw_announce.Name = "dgw_announce";
            this.dgw_announce.RowHeadersWidth = 51;
            this.dgw_announce.RowTemplate.Height = 24;
            this.dgw_announce.Size = new System.Drawing.Size(1091, 463);
            this.dgw_announce.TabIndex = 42;
            this.dgw_announce.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgw_announce.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_announce_CellMouseEnter);
            // 
            // txt_notice
            // 
            this.txt_notice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_notice.Location = new System.Drawing.Point(25, 553);
            this.txt_notice.Name = "txt_notice";
            this.txt_notice.Size = new System.Drawing.Size(882, 33);
            this.txt_notice.TabIndex = 43;
            // 
            // buttondash
            // 
            this.buttondash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(45)))));
            this.buttondash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttondash.FlatAppearance.BorderSize = 0;
            this.buttondash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttondash.Font = new System.Drawing.Font("Ebrima", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttondash.ForeColor = System.Drawing.SystemColors.Control;
            this.buttondash.Location = new System.Drawing.Point(914, 25);
            this.buttondash.Margin = new System.Windows.Forms.Padding(4);
            this.buttondash.Name = "buttondash";
            this.buttondash.Size = new System.Drawing.Size(200, 38);
            this.buttondash.TabIndex = 44;
            this.buttondash.Text = "Dashboard";
            this.buttondash.UseVisualStyleBackColor = false;
            this.buttondash.Click += new System.EventHandler(this.buttondash_Click);
            // 
            // Announcement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1234, 657);
            this.Controls.Add(this.buttondash);
            this.Controls.Add(this.txt_notice);
            this.Controls.Add(this.dgw_announce);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelLogin);
            this.Name = "Announcement";
            this.Text = "Annoucement";
            this.Load += new System.EventHandler(this.Announcement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_announce)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.DataGridView dgw_announce;
        private System.Windows.Forms.TextBox txt_notice;
        private System.Windows.Forms.Button buttondash;
    }
}