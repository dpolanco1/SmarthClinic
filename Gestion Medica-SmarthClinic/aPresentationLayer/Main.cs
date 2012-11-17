using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace aPresentationLayer
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnPacientes_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Frm_Pacientes.frm_Pacientes().MdiParent = this;
            Frm_Pacientes.frm_Pacientes().Show();
        }

        private void navBarItem11_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Frm_Consultas.frm_Consultas().MdiParent = this;
            Frm_Consultas.frm_Consultas().Show();
        }
    }
}