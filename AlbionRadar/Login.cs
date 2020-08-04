using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbionRadar
{
    public partial class Login : MaterialForm
    {
        private string version = "1005";
        public Login()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, (Accent)Primary.BlueGrey500, TextShade.WHITE);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (userLogin.Text.Length > 1 && passwordLogin.Text.Length > 1)
            {
                var hwid = UHWID.UHWID.SimpleUid;

                WebRequest request = WebRequest.Create("https://www.teclandotec.com/api/loginRadar.php?login="
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
                            MessageBox.Show((string)jsonArray.errorMessage, "Albion Radar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                // Close the response.
                response.Close();
            }
        }
    }
}
