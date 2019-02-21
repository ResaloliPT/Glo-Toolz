namespace GloToolz.UI.Forms
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
            this.components = new System.ComponentModel.Container();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.BTN_LOGIN = new Telerik.WinControls.UI.RadButton();
            this.LABEL_TIMOUT = new Telerik.WinControls.UI.RadLabel();
            this.radThemeManager2 = new Telerik.WinControls.RadThemeManager();
            this.PBAR_TIMEOUT = new System.Windows.Forms.ProgressBar();
            this.UI_UPDATE_TIMER = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PB_LOGO = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_LOGIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LABEL_TIMOUT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_LOGIN
            // 
            this.BTN_LOGIN.Font = new System.Drawing.Font("Fira Code Medium", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.BTN_LOGIN.Location = new System.Drawing.Point(47, 236);
            this.BTN_LOGIN.Name = "BTN_LOGIN";
            this.BTN_LOGIN.Size = new System.Drawing.Size(197, 52);
            this.BTN_LOGIN.TabIndex = 1;
            this.BTN_LOGIN.Text = "Login With Git Kraken";
            this.BTN_LOGIN.ThemeName = "Material";
            this.BTN_LOGIN.Click += new System.EventHandler(this.BTN_LOGIN_Click);
            // 
            // LABEL_TIMOUT
            // 
            this.LABEL_TIMOUT.Font = new System.Drawing.Font("Fira Code", 9.267326F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_TIMOUT.Location = new System.Drawing.Point(47, 308);
            this.LABEL_TIMOUT.Name = "LABEL_TIMOUT";
            this.LABEL_TIMOUT.Size = new System.Drawing.Size(106, 18);
            this.LABEL_TIMOUT.TabIndex = 2;
            this.LABEL_TIMOUT.Text = "Login Timeout";
            this.LABEL_TIMOUT.ThemeName = "Material";
            // 
            // PBAR_TIMEOUT
            // 
            this.PBAR_TIMEOUT.Location = new System.Drawing.Point(47, 332);
            this.PBAR_TIMEOUT.Name = "PBAR_TIMEOUT";
            this.PBAR_TIMEOUT.Size = new System.Drawing.Size(197, 23);
            this.PBAR_TIMEOUT.TabIndex = 3;
            // 
            // UI_UPDATE_TIMER
            // 
            this.UI_UPDATE_TIMER.Tick += new System.EventHandler(this.UI_UPDATE_TIMER_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GloToolz.Properties.Resources.exit_1205463;
            this.pictureBox1.Location = new System.Drawing.Point(250, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PB_LOGO
            // 
            this.PB_LOGO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PB_LOGO.Image = global::GloToolz.Properties.Resources.GloToolz;
            this.PB_LOGO.Location = new System.Drawing.Point(47, 36);
            this.PB_LOGO.Name = "PB_LOGO";
            this.PB_LOGO.Size = new System.Drawing.Size(197, 178);
            this.PB_LOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_LOGO.TabIndex = 0;
            this.PB_LOGO.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 376);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PBAR_TIMEOUT);
            this.Controls.Add(this.LABEL_TIMOUT);
            this.Controls.Add(this.BTN_LOGIN);
            this.Controls.Add(this.PB_LOGO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.BTN_LOGIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LABEL_TIMOUT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LOGO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.MaterialTheme materialTheme1;
        private System.Windows.Forms.PictureBox PB_LOGO;
        private Telerik.WinControls.UI.RadButton BTN_LOGIN;
        private Telerik.WinControls.UI.RadLabel LABEL_TIMOUT;
        private Telerik.WinControls.RadThemeManager radThemeManager2;
        private System.Windows.Forms.ProgressBar PBAR_TIMEOUT;
        private System.Windows.Forms.Timer UI_UPDATE_TIMER;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}