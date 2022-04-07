
namespace PRY2021271
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        private void InitializeComponent()
        {
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSupport = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.panelWorkerSubMenu = new System.Windows.Forms.Panel();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnWorker = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelSideMenu.SuspendLayout();
            this.panelWorkerSubMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSideMenu.Controls.Add(this.btnExit);
            this.panelSideMenu.Controls.Add(this.btnSupport);
            this.panelSideMenu.Controls.Add(this.btnReport);
            this.panelSideMenu.Controls.Add(this.panelWorkerSubMenu);
            this.panelSideMenu.Controls.Add(this.btnWorker);
            this.panelSideMenu.Controls.Add(this.btnStart);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 561);
            this.panelSideMenu.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.ForeColor = System.Drawing.Color.Silver;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 514);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(248, 45);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSupport
            // 
            this.btnSupport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnSupport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnSupport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSupport.ForeColor = System.Drawing.Color.Silver;
            this.btnSupport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupport.Location = new System.Drawing.Point(0, 306);
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSupport.Size = new System.Drawing.Size(248, 45);
            this.btnSupport.TabIndex = 8;
            this.btnSupport.Text = "Soporte";
            this.btnSupport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupport.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.ForeColor = System.Drawing.Color.Silver;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(0, 261);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReport.Size = new System.Drawing.Size(248, 45);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Reporte";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // panelWorkerSubMenu
            // 
            this.panelWorkerSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelWorkerSubMenu.Controls.Add(this.btnEditProfile);
            this.panelWorkerSubMenu.Controls.Add(this.btnProfile);
            this.panelWorkerSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWorkerSubMenu.Location = new System.Drawing.Point(0, 182);
            this.panelWorkerSubMenu.Name = "panelWorkerSubMenu";
            this.panelWorkerSubMenu.Size = new System.Drawing.Size(248, 79);
            this.panelWorkerSubMenu.TabIndex = 4;
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnEditProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnEditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditProfile.ForeColor = System.Drawing.Color.Silver;
            this.btnEditProfile.Location = new System.Drawing.Point(0, 40);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnEditProfile.Size = new System.Drawing.Size(248, 40);
            this.btnEditProfile.TabIndex = 3;
            this.btnEditProfile.Text = "Editar Perfil";
            this.btnEditProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditProfile.UseVisualStyleBackColor = true;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProfile.ForeColor = System.Drawing.Color.Silver;
            this.btnProfile.Location = new System.Drawing.Point(0, 0);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnProfile.Size = new System.Drawing.Size(248, 40);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.Text = "Perfil";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnWorker
            // 
            this.btnWorker.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWorker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnWorker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnWorker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWorker.ForeColor = System.Drawing.Color.Silver;
            this.btnWorker.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWorker.Location = new System.Drawing.Point(0, 137);
            this.btnWorker.Name = "btnWorker";
            this.btnWorker.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnWorker.Size = new System.Drawing.Size(248, 45);
            this.btnWorker.TabIndex = 3;
            this.btnWorker.Text = "Trabajador";
            this.btnWorker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWorker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWorker.UseVisualStyleBackColor = true;
            this.btnWorker.Click += new System.EventHandler(this.btnWorker_Click);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.ForeColor = System.Drawing.Color.Silver;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(0, 92);
            this.btnStart.Name = "btnStart";
            this.btnStart.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnStart.Size = new System.Drawing.Size(248, 45);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Inicio";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBoxLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(248, 92);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(36, 15);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(159, 60);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(250, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(684, 561);
            this.panelChildForm.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelSideMenu.ResumeLayout(false);
            this.panelWorkerSubMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSupport;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Panel panelWorkerSubMenu;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnWorker;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Button btnEditProfile;
    }
}

