using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbionNetwork2D
{
    public partial class Login : MaterialForm
    {
        private string version = "1131";
        public Login()
        {
            InitializeComponent();
            Settings.loadLanguage();
            loadLanguage();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, (Accent)Primary.BlueGrey500, TextShade.WHITE);
        }
        public void loadLanguage()
        {
            CultureInfo ci = new CultureInfo(Settings.languageSelected);
            Assembly a = Assembly.Load("Discord");
            ResourceManager rm = new ResourceManager("AlbionNetwork2D.Lang.langres", a);

            this.Text = rm.GetString("login.title", ci);

            lb_username.Text = rm.GetString("login.username", ci);
            lb_password.Text = rm.GetString("login.password", ci);
            btn_login.Text = rm.GetString("login.login", ci);

        }
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (userLogin.Text.Length > 1 && passwordLogin.Text.Length > 1)
            {
                var hwid = UHWID.UHWID.SimpleUid;

                WebRequest request = WebRequest.Create("https://teclandotec.com/api/login.php?login="
                + userLogin.Text + "&password="
                + passwordLogin.Text + "&hwid="
                + hwid + "&version="
                + version);

                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.
                WebResponse response = request.GetResponse();
                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    dynamic jsonArray = JsonConvert.DeserializeObject(responseFromServer);
                    
                    if(jsonArray != null)
                    {
                        if(jsonArray.canLogin == true)
                        {
                            Options options = new Options();

                            this.Hide();
                            options.Show();
                        }
                        else
                        {
                            var result = MessageBox.Show((string)jsonArray.errorMessage, this.Text,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (jsonArray.link != null)
                            {
                                Process.Start((string)jsonArray.link);
                            }
                        }
                    }
                }

                // Close the response.
                response.Close();
            }
        }
    }
}
