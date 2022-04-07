using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRY2021271
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            panelWorkerSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        #region SubMenus
        private void btnStart_Click(object sender, EventArgs e)
        {
            openChildForm(new Login());
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
            showSubMenu(panelWorkerSubMenu);
        }
        #endregion

        #region WorkerSubMenu
        private void btnProfile_Click(object sender, EventArgs e)
        {
            openChildForm(new WorkerProfile());
            hideSubMenu();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            openChildForm(new EditWorkerProfile());
            hideSubMenu();
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
