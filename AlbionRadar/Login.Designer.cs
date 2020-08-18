namespace AlbionNetwork2D
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
            this.lb_username = new MaterialSkin.Controls.MaterialLabel();
            this.userLogin = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.passwordLogin = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lb_password = new MaterialSkin.Controls.MaterialLabel();
            this.btn_login = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // lb_username
            // 
            resources.ApplyResources(this.lb_username, "lb_username");
            this.lb_username.Depth = 0;
            this.lb_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_username.MouseState = MaterialSkin.MouseState.HOVER;
            this.lb_username.Name = "lb_username";
            // 
            // userLogin
            // 
            resources.ApplyResources(this.userLogin, "userLogin");
            this.userLogin.Depth = 0;
            this.userLogin.Hint = "";
            this.userLogin.MaxLength = 32767;
            this.userLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.userLogin.Name = "userLogin";
            this.userLogin.PasswordChar = '\0';
            this.userLogin.SelectedText = "";
            this.userLogin.SelectionLength = 0;
            this.userLogin.SelectionStart = 0;
            this.userLogin.TabStop = false;
            this.userLogin.UseSystemPasswordChar = false;
            // 
            // passwordLogin
            // 
            resources.ApplyResources(this.passwordLogin, "passwordLogin");
            this.passwordLogin.Depth = 0;
            this.passwordLogin.Hint = "";
            this.passwordLogin.MaxLength = 32767;
            this.passwordLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.passwordLogin.Name = "passwordLogin";
            this.passwordLogin.PasswordChar = '*';
            this.passwordLogin.SelectedText = "";
            this.passwordLogin.SelectionLength = 0;
            this.passwordLogin.SelectionStart = 0;
            this.passwordLogin.TabStop = false;
            this.passwordLogin.UseSystemPasswordChar = true;
            // 
            // lb_password
            // 
            resources.ApplyResources(this.lb_password, "lb_password");
            this.lb_password.Depth = 0;
            this.lb_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_password.MouseState = MaterialSkin.MouseState.HOVER;
            this.lb_password.Name = "lb_password";
            // 
            // btn_login
            // 
            resources.ApplyResources(this.btn_login, "btn_login");
            this.btn_login.Depth = 0;
            this.btn_login.Icon = null;
            this.btn_login.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_login.Name = "btn_login";
            this.btn_login.Primary = true;
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.passwordLogin);
            this.Controls.Add(this.userLogin);
            this.Controls.Add(this.lb_username);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Sizable = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lb_username;
        private MaterialSkin.Controls.MaterialSingleLineTextField userLogin;
        private MaterialSkin.Controls.MaterialSingleLineTextField passwordLogin;
        private MaterialSkin.Controls.MaterialLabel lb_password;
        private MaterialSkin.Controls.MaterialRaisedButton btn_login;
    }
}