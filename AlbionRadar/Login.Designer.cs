namespace AlbionRadar
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.userLogin = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.passwordLogin = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(18, 89);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(65, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Usuário:";
            // 
            // userLogin
            // 
            this.userLogin.Depth = 0;
            this.userLogin.Hint = "";
            this.userLogin.Location = new System.Drawing.Point(22, 118);
            this.userLogin.Margin = new System.Windows.Forms.Padding(10);
            this.userLogin.MaxLength = 32767;
            this.userLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.userLogin.Name = "userLogin";
            this.userLogin.PasswordChar = '\0';
            this.userLogin.SelectedText = "";
            this.userLogin.SelectionLength = 0;
            this.userLogin.SelectionStart = 0;
            this.userLogin.Size = new System.Drawing.Size(178, 23);
            this.userLogin.TabIndex = 1;
            this.userLogin.TabStop = false;
            this.userLogin.UseSystemPasswordChar = false;
            // 
            // passwordLogin
            // 
            this.passwordLogin.Depth = 0;
            this.passwordLogin.Hint = "";
            this.passwordLogin.Location = new System.Drawing.Point(22, 182);
            this.passwordLogin.Margin = new System.Windows.Forms.Padding(10);
            this.passwordLogin.MaxLength = 32767;
            this.passwordLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.passwordLogin.Name = "passwordLogin";
            this.passwordLogin.PasswordChar = '*';
            this.passwordLogin.SelectedText = "";
            this.passwordLogin.SelectionLength = 0;
            this.passwordLogin.SelectionStart = 0;
            this.passwordLogin.Size = new System.Drawing.Size(178, 23);
            this.passwordLogin.TabIndex = 2;
            this.passwordLogin.TabStop = false;
            this.passwordLogin.UseSystemPasswordChar = true;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(18, 153);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(54, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Senha:";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(46, 235);
            this.materialRaisedButton1.MinimumSize = new System.Drawing.Size(130, 0);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Padding = new System.Windows.Forms.Padding(10);
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(130, 36);
            this.materialRaisedButton1.TabIndex = 4;
            this.materialRaisedButton1.Text = "Fazer Login";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 283);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.passwordLogin);
            this.Controls.Add(this.userLogin);
            this.Controls.Add(this.materialLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Albion Radar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField userLogin;
        private MaterialSkin.Controls.MaterialSingleLineTextField passwordLogin;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}