namespace StandUPLogin
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.rezerva_button = new Guna.UI.WinForms.GunaGradientButton();
            this.rezervare_locuri = new Guna.UI.WinForms.GunaTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(24)))), ((int)(((byte)(74)))));
            this.gunaPanel1.Controls.Add(this.rezerva_button);
            this.gunaPanel1.Controls.Add(this.rezervare_locuri);
            this.gunaPanel1.Controls.Add(this.label5);
            this.gunaPanel1.Controls.Add(this.label4);
            this.gunaPanel1.Controls.Add(this.label2);
            this.gunaPanel1.Controls.Add(this.label1);
            this.gunaPanel1.Controls.Add(this.label8);
            this.gunaPanel1.Controls.Add(this.label3);
            this.gunaPanel1.Controls.Add(this.gunaPictureBox1);
            this.gunaPanel1.Location = new System.Drawing.Point(-1, -2);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(942, 546);
            this.gunaPanel1.TabIndex = 0;
            this.gunaPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gunaPanel1_MouseDown);
            this.gunaPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gunaPanel1_MouseMove);
            // 
            // rezerva_button
            // 
            this.rezerva_button.AnimationHoverSpeed = 0.07F;
            this.rezerva_button.AnimationSpeed = 0.03F;
            this.rezerva_button.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(74)))));
            this.rezerva_button.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(97)))), ((int)(((byte)(255)))));
            this.rezerva_button.BorderColor = System.Drawing.Color.Black;
            this.rezerva_button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.rezerva_button.FocusedColor = System.Drawing.Color.Empty;
            this.rezerva_button.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rezerva_button.ForeColor = System.Drawing.Color.White;
            this.rezerva_button.Image = null;
            this.rezerva_button.ImageSize = new System.Drawing.Size(20, 20);
            this.rezerva_button.Location = new System.Drawing.Point(323, 458);
            this.rezerva_button.Name = "rezerva_button";
            this.rezerva_button.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(74)))));
            this.rezerva_button.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(97)))), ((int)(((byte)(255)))));
            this.rezerva_button.OnHoverBorderColor = System.Drawing.Color.Black;
            this.rezerva_button.OnHoverForeColor = System.Drawing.Color.White;
            this.rezerva_button.OnHoverImage = null;
            this.rezerva_button.OnPressedColor = System.Drawing.Color.Black;
            this.rezerva_button.Size = new System.Drawing.Size(332, 58);
            this.rezerva_button.TabIndex = 24;
            this.rezerva_button.Text = "Rezerva";
            this.rezerva_button.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rezerva_button.Click += new System.EventHandler(this.rezerva_button_Click);
            // 
            // rezervare_locuri
            // 
            this.rezervare_locuri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(49)))), ((int)(((byte)(195)))));
            this.rezervare_locuri.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.rezervare_locuri.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.rezervare_locuri.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rezervare_locuri.FocusedBaseColor = System.Drawing.Color.White;
            this.rezervare_locuri.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.rezervare_locuri.FocusedForeColor = System.Drawing.Color.Black;
            this.rezervare_locuri.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rezervare_locuri.ForeColor = System.Drawing.Color.White;
            this.rezervare_locuri.Location = new System.Drawing.Point(62, 224);
            this.rezervare_locuri.Name = "rezervare_locuri";
            this.rezervare_locuri.PasswordChar = '\0';
            this.rezervare_locuri.SelectedText = "";
            this.rezervare_locuri.Size = new System.Drawing.Size(332, 53);
            this.rezervare_locuri.TabIndex = 23;
            this.rezervare_locuri.MouseLeave += new System.EventHandler(this.rezervare_locuri_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(52)))), ((int)(((byte)(139)))));
            this.label5.Location = new System.Drawing.Point(623, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 22);
            this.label5.TabIndex = 22;
            this.label5.Text = "/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(52)))), ((int)(((byte)(139)))));
            this.label4.Location = new System.Drawing.Point(639, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 22);
            this.label4.TabIndex = 21;
            this.label4.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(52)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(639, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Locuri total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(52)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(473, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Locuri ocupate  /";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(52)))), ((int)(((byte)(139)))));
            this.label8.Location = new System.Drawing.Point(590, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 22);
            this.label8.TabIndex = 18;
            this.label8.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(52)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(58, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Locuri";
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(49, 14);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(844, 100);
            this.gunaPictureBox1.TabIndex = 0;
            this.gunaPictureBox1.TabStop = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 544);
            this.Controls.Add(this.gunaPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Guna.UI.WinForms.GunaTextBox rezervare_locuri;
        private Guna.UI.WinForms.GunaGradientButton rezerva_button;
    }
}