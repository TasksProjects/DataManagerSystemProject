namespace DataManagerSystem
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AdminButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.AddButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.EditButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.SettingButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.StudiengangButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.ShowDbButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.Helpbutton = new Bunifu.Framework.UI.BunifuTileButton();
            this.LogoutButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.labelStatut = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 2;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.AdminButton);
            this.flowLayoutPanel1.Controls.Add(this.AddButton);
            this.flowLayoutPanel1.Controls.Add(this.EditButton);
            this.flowLayoutPanel1.Controls.Add(this.SettingButton);
            this.flowLayoutPanel1.Controls.Add(this.StudiengangButton);
            this.flowLayoutPanel1.Controls.Add(this.ShowDbButton);
            this.flowLayoutPanel1.Controls.Add(this.Helpbutton);
            this.flowLayoutPanel1.Controls.Add(this.LogoutButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 56);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(847, 383);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // AdminButton
            // 
            this.AdminButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.AdminButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AdminButton.color = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.AdminButton.colorActive = System.Drawing.Color.Gray;
            this.AdminButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdminButton.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AdminButton.Image = global::DataManagerSystem.Properties.Resources.Admin;
            this.AdminButton.ImagePosition = 15;
            this.AdminButton.ImageZoom = 50;
            this.AdminButton.LabelPosition = 44;
            this.AdminButton.LabelText = "Admins";
            this.AdminButton.Location = new System.Drawing.Point(25, 27);
            this.AdminButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.AdminButton.Name = "AdminButton";
            this.AdminButton.Size = new System.Drawing.Size(190, 160);
            this.AdminButton.TabIndex = 4;
            this.AdminButton.Click += new System.EventHandler(this.AdminButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.AddButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddButton.color = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.AddButton.colorActive = System.Drawing.Color.Gray;
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddButton.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AddButton.Image = global::DataManagerSystem.Properties.Resources.add;
            this.AddButton.ImagePosition = 15;
            this.AddButton.ImageZoom = 50;
            this.AddButton.LabelPosition = 44;
            this.AddButton.LabelText = "New Student";
            this.AddButton.Location = new System.Drawing.Point(225, 27);
            this.AddButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(190, 160);
            this.AddButton.TabIndex = 2;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.EditButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditButton.color = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.EditButton.colorActive = System.Drawing.Color.Gray;
            this.EditButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditButton.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.EditButton.Image = global::DataManagerSystem.Properties.Resources.edit;
            this.EditButton.ImagePosition = 15;
            this.EditButton.ImageZoom = 50;
            this.EditButton.LabelPosition = 44;
            this.EditButton.LabelText = "Edit Student";
            this.EditButton.Location = new System.Drawing.Point(425, 27);
            this.EditButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(190, 160);
            this.EditButton.TabIndex = 3;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // SettingButton
            // 
            this.SettingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.SettingButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SettingButton.color = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.SettingButton.colorActive = System.Drawing.Color.Gray;
            this.SettingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingButton.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SettingButton.Image = global::DataManagerSystem.Properties.Resources.emblem_system;
            this.SettingButton.ImagePosition = 15;
            this.SettingButton.ImageZoom = 50;
            this.SettingButton.LabelPosition = 44;
            this.SettingButton.LabelText = "Settings";
            this.SettingButton.Location = new System.Drawing.Point(625, 27);
            this.SettingButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(190, 160);
            this.SettingButton.TabIndex = 5;
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // StudiengangButton
            // 
            this.StudiengangButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.StudiengangButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StudiengangButton.color = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.StudiengangButton.colorActive = System.Drawing.Color.Gray;
            this.StudiengangButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StudiengangButton.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudiengangButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.StudiengangButton.Image = global::DataManagerSystem.Properties.Resources.fakultaet_icon;
            this.StudiengangButton.ImagePosition = 15;
            this.StudiengangButton.ImageZoom = 50;
            this.StudiengangButton.LabelPosition = 44;
            this.StudiengangButton.LabelText = "Studiengang";
            this.StudiengangButton.Location = new System.Drawing.Point(25, 201);
            this.StudiengangButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.StudiengangButton.Name = "StudiengangButton";
            this.StudiengangButton.Size = new System.Drawing.Size(190, 160);
            this.StudiengangButton.TabIndex = 6;
            this.StudiengangButton.Click += new System.EventHandler(this.StudiengangButton_Click);
            // 
            // ShowDbButton
            // 
            this.ShowDbButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ShowDbButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShowDbButton.color = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ShowDbButton.colorActive = System.Drawing.Color.Gray;
            this.ShowDbButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowDbButton.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowDbButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ShowDbButton.Image = global::DataManagerSystem.Properties.Resources.Database_Active_icon;
            this.ShowDbButton.ImagePosition = 15;
            this.ShowDbButton.ImageZoom = 50;
            this.ShowDbButton.LabelPosition = 44;
            this.ShowDbButton.LabelText = "Show Content";
            this.ShowDbButton.Location = new System.Drawing.Point(225, 201);
            this.ShowDbButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.ShowDbButton.Name = "ShowDbButton";
            this.ShowDbButton.Size = new System.Drawing.Size(190, 160);
            this.ShowDbButton.TabIndex = 7;
            this.ShowDbButton.Click += new System.EventHandler(this.ShowDbButton_Click);
            // 
            // Helpbutton
            // 
            this.Helpbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Helpbutton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Helpbutton.color = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Helpbutton.colorActive = System.Drawing.Color.Gray;
            this.Helpbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Helpbutton.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helpbutton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Helpbutton.Image = global::DataManagerSystem.Properties.Resources.symbol_help;
            this.Helpbutton.ImagePosition = 15;
            this.Helpbutton.ImageZoom = 50;
            this.Helpbutton.LabelPosition = 44;
            this.Helpbutton.LabelText = "Help";
            this.Helpbutton.Location = new System.Drawing.Point(425, 201);
            this.Helpbutton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Helpbutton.Name = "Helpbutton";
            this.Helpbutton.Size = new System.Drawing.Size(190, 160);
            this.Helpbutton.TabIndex = 9;
            this.Helpbutton.Click += new System.EventHandler(this.Helpbutton_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.LogoutButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogoutButton.color = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.LogoutButton.colorActive = System.Drawing.Color.Gray;
            this.LogoutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoutButton.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LogoutButton.Image = global::DataManagerSystem.Properties.Resources.arrow_left;
            this.LogoutButton.ImagePosition = 15;
            this.LogoutButton.ImageZoom = 50;
            this.LogoutButton.LabelPosition = 44;
            this.LogoutButton.LabelText = "Exit";
            this.LogoutButton.Location = new System.Drawing.Point(625, 201);
            this.LogoutButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(190, 160);
            this.LogoutButton.TabIndex = 10;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.ForeColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.bunifuSeparator2.LineThickness = 5;
            this.bunifuSeparator2.Location = new System.Drawing.Point(12, 40);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(847, 10);
            this.bunifuSeparator2.TabIndex = 13;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.ForeColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.bunifuSeparator1.LineThickness = 5;
            this.bunifuSeparator1.Location = new System.Drawing.Point(12, 445);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(847, 10);
            this.bunifuSeparator1.TabIndex = 14;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 33);
            this.label1.TabIndex = 15;
            this.label1.Text = "Data Manager";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(827, 8);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(32, 29);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // labelStatut
            // 
            this.labelStatut.AutoSize = true;
            this.labelStatut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatut.Location = new System.Drawing.Point(9, 461);
            this.labelStatut.Name = "labelStatut";
            this.labelStatut.Size = new System.Drawing.Size(140, 18);
            this.labelStatut.TabIndex = 17;
            this.labelStatut.Text = "You are loged as:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelStatus.Location = new System.Drawing.Point(155, 463);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(51, 16);
            this.labelStatus.TabIndex = 18;
            this.labelStatus.Text = "Status";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelTime.Location = new System.Drawing.Point(699, 463);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(43, 15);
            this.labelTime.TabIndex = 19;
            this.labelTime.Text = "Time:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(870, 490);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelStatut);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Bunifu.Framework.UI.BunifuTileButton AdminButton;
        private Bunifu.Framework.UI.BunifuTileButton AddButton;
        private Bunifu.Framework.UI.BunifuTileButton EditButton;
        private Bunifu.Framework.UI.BunifuTileButton SettingButton;
        private Bunifu.Framework.UI.BunifuTileButton StudiengangButton;
        private Bunifu.Framework.UI.BunifuTileButton ShowDbButton;
        private Bunifu.Framework.UI.BunifuTileButton Helpbutton;
        private Bunifu.Framework.UI.BunifuTileButton LogoutButton;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelStatut;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer1;
    }
}

