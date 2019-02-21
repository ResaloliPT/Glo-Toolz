using GloToolz.Http;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace GloToolz.UI.Forms
{
    public partial class Login : Form
    {
        private bool UPDATE_PROGRESSBAR_FLAG = false;


        public Login()
        {
            InitializeComponent();
            UI_UPDATE_TIMER.Start();
            PBAR_TIMEOUT.Maximum = int.Parse(ConfigurationManager.AppSettings.Get("APP_LOGIN_TIMEOUT"));
        }

        private async void BTN_LOGIN_Click(object sender, EventArgs e)
        {
            PBAR_TIMEOUT.Value = 0;
            UPDATE_PROGRESSBAR_FLAG = true;

            await OAuth.Authenticate();

            PBAR_TIMEOUT.Value = 0;
            UPDATE_PROGRESSBAR_FLAG = false;

            if (!OAuth.isAuthenticated())
            {
                MessageBox.Show(OAuth.LastErrorMessage, OAuth.LastErrorMessage, MessageBoxButtons.OK);
                return;
            }

            Hide();
            new MainForm().Show();
        }

        private void UI_UPDATE_TIMER_Tick(object sender, EventArgs e)
        {
            if (UPDATE_PROGRESSBAR_FLAG)
            {
                PBAR_TIMEOUT.Increment(UI_UPDATE_TIMER.Interval);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}