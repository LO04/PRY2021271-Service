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
    public partial class EditWorkerProfile : Form
    {
        public EditWorkerProfile()
        {
            InitializeComponent();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != string.Empty || textBoxEmail.Text != string.Empty || textBoxEmail.Text != string.Empty || textBoxEmail.Text != string.Empty)
            {
                if (!IsValidEmail(textBoxEmail.Text))
                {
                    MessageBox.Show("Ingrese un email válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
