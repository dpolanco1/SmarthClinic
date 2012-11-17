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
    public partial class Frm_Consultas : DevExpress.XtraEditors.XtraForm
    {
        private static Frm_Consultas frm_consultas; // Referencia estática al mismo formulario

        public static Frm_Consultas frm_Consultas()// Método estatico que hace referencia a el mismo
        {
            if (frm_consultas == null || frm_consultas.IsDisposed) // Comprobar si el form esta Null (No ejecutado)
            {
                frm_consultas = new Frm_Consultas(); // Se crea instancia
            }
            else
            {
                frm_consultas.BringToFront(); // De lo contrario, se pasa al frente
            }

            return frm_consultas; // Retornamos el valor
        }//fin del metodo

        public Frm_Consultas()
        {
            InitializeComponent();
        }
    }
}