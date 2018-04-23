namespace DataManagerSystem.Modules
{
    partial class Add_Semester
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
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SemesterTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelbtn.ForeColor = System.Drawing.Color.White;
            this.Cancelbtn.Location = new System.Drawing.Point(206, 100);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(136, 32);
            this.Cancelbtn.TabIndex = 14;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = false;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.White;
            this.SaveBtn.Location = new System.Drawing.Point(15, 100);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(136, 32);
            this.SaveBtn.TabIndex = 13;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Semester:";
            // 
            // SemesterTextBox
            // 
            this.SemesterTextBox.Location = new System.Drawing.Point(117, 27);
            this.SemesterTextBox.Name = "SemesterTextBox";
            this.SemesterTextBox.Size = new System.Drawing.Size(225, 20);
            this.SemesterTextBox.TabIndex = 11;
            // 
            // Add_Semester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 157);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SemesterTextBox);
            this.Name = "Add_Semester";
            this.Text = "Add_Semester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SemesterTextBox;
    }
}