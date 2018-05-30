namespace DataManagerSystem.Modules
{
    partial class UebersichtBetreuer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UebersichtBetreuer));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Schlißen = new System.Windows.Forms.Button();
            this.BetreuerLoeschen = new System.Windows.Forms.Button();
            this.BetreuerHinzufuegen = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 368);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Übersicht Betreuer";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 334);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(694, 334);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // Schlißen
            // 
            this.Schlißen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Schlißen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Schlißen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Schlißen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Schlißen.ForeColor = System.Drawing.Color.White;
            this.Schlißen.Location = new System.Drawing.Point(487, 428);
            this.Schlißen.Name = "Schlißen";
            this.Schlißen.Size = new System.Drawing.Size(210, 39);
            this.Schlißen.TabIndex = 61;
            this.Schlißen.Text = "Schließen";
            this.Schlißen.UseVisualStyleBackColor = false;
            this.Schlißen.Click += new System.EventHandler(this.Schlißen_Click);
            // 
            // BetreuerLoeschen
            // 
            this.BetreuerLoeschen.AllowDrop = true;
            this.BetreuerLoeschen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BetreuerLoeschen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.BetreuerLoeschen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BetreuerLoeschen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BetreuerLoeschen.ForeColor = System.Drawing.Color.White;
            this.BetreuerLoeschen.Location = new System.Drawing.Point(248, 428);
            this.BetreuerLoeschen.Name = "BetreuerLoeschen";
            this.BetreuerLoeschen.Size = new System.Drawing.Size(208, 39);
            this.BetreuerLoeschen.TabIndex = 60;
            this.BetreuerLoeschen.Text = "Betreuer Löschen";
            this.BetreuerLoeschen.UseVisualStyleBackColor = false;
            this.BetreuerLoeschen.Click += new System.EventHandler(this.BetreuerLoeschen_Click);
            // 
            // BetreuerHinzufuegen
            // 
            this.BetreuerHinzufuegen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BetreuerHinzufuegen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.BetreuerHinzufuegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BetreuerHinzufuegen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BetreuerHinzufuegen.ForeColor = System.Drawing.Color.White;
            this.BetreuerHinzufuegen.Location = new System.Drawing.Point(12, 428);
            this.BetreuerHinzufuegen.Name = "BetreuerHinzufuegen";
            this.BetreuerHinzufuegen.Size = new System.Drawing.Size(210, 39);
            this.BetreuerHinzufuegen.TabIndex = 59;
            this.BetreuerHinzufuegen.Text = "Betreuer hinzufügen";
            this.BetreuerHinzufuegen.UseVisualStyleBackColor = false;
            this.BetreuerHinzufuegen.Click += new System.EventHandler(this.BetreuerHinzufuegen_Click);
            // 
            // UebersichtBetreuer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 473);
            this.Controls.Add(this.Schlißen);
            this.Controls.Add(this.BetreuerLoeschen);
            this.Controls.Add(this.BetreuerHinzufuegen);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UebersichtBetreuer";
            this.Text = "ÜbersichtBetreuer";
            this.Load += new System.EventHandler(this.ÜbersichtBetreuer_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button Schlißen;
        private System.Windows.Forms.Button BetreuerLoeschen;
        private System.Windows.Forms.Button BetreuerHinzufuegen;
    }
}