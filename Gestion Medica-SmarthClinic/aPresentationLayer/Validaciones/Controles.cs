using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace aPresentationLayer.Validaciones
{
     abstract class Controles
    {

        // Para limpiar todos los TextBox que esten dentro del control 
        public static void VaciarText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) VaciarText(contHijo);
                if (contHijo is TextEdit)
                {
                    contHijo.Text = string.Empty;
                }
                else if (contHijo is ComboBoxEdit)
                {
                    contHijo.Text = string.Empty;

                }
                else if (contHijo is DateEdit)
                {

                    contHijo.Text = Convert.ToString(DateTime.Today);

                }
                else if (contHijo is SpinEdit)
                {
                    contHijo.Text = "0.0";

                }
                else if (contHijo is MemoExEdit)
                {
                    contHijo.Text = string.Empty;

                }
                else if (contHijo is MemoEdit)
                {
                    contHijo.Text = string.Empty;

                }
                else if (contHijo is MaskedTextBox)
                {
                    contHijo.Text = string.Empty;

                }
            }

        }

        // Para Habilitar los TextBox que esten dentro del control
        public static void HabilitarText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) HabilitarText(contHijo);
                if (contHijo is TextEdit)
                {
                    contHijo.Enabled = true;
                }
                else if (contHijo is ComboBoxEdit)
                {

                    contHijo.Enabled = true;
                }
                else if (contHijo is DateEdit)
                {
                    contHijo.Enabled = true;

                }
                else if (contHijo is SpinEdit)
                {
                    contHijo.Enabled = true;

                }
                else if (contHijo is MemoEdit)
                {
                    contHijo.Enabled = true;

                }
                else if (contHijo is MemoExEdit)
                {
                    contHijo.Enabled = true;

                }
                else if (contHijo is MaskedTextBox)
                {
                    contHijo.Enabled = true;

                }
            }
        }

        // Para Deshabilitar los TextBox que esten dentro del control
        public static void DeshabilitarText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) DeshabilitarText(contHijo);
                if (contHijo is TextEdit)
                {
                    contHijo.Enabled = false;
                    
                }
                else if (contHijo is ComboBoxEdit)
                {

                    contHijo.Enabled = false;
                }
                else if (contHijo is DateEdit)
                {
                    contHijo.Enabled = false;

                }
                else if (contHijo is SpinEdit)
                {
                    contHijo.Enabled = false;

                }
                else if (contHijo is MemoEdit)
                {
                    contHijo.Enabled = false;

                }
                else if (contHijo is MemoExEdit)
                {
                    contHijo.Enabled = false;

                }
               
                else if (contHijo is MaskedTextBox)
                {
                    contHijo.Enabled = false;

                }
            }
        }

        // Para Habilitar los DatagridView que esten dentro del Control
        public static void HabilitarDGV(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) HabilitarDGV(contHijo);
                if (contHijo is DataGridView)
                {
                    contHijo.Enabled = true;
                }
            }
        }

        // Para deshabilitar los DatagridView que esten dentro del Control
        public static void DeshabilitarDGV(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) DeshabilitarDGV(contHijo);
                if (contHijo is DataGridView)
                {
                    contHijo.Enabled = false;
                }
            }
        }

        // Para limpiar las celdas de un DatagridView que esten dentro del Control
        public static void VaciarDGV(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) VaciarDGV(contHijo);
                if (contHijo is DataGridView)
                {
                    DataGridView DGV = new DataGridView();
                    DGV = (DataGridView)contHijo;
                    DGV.DataSource = null;
                    DGV.Rows.Clear();

                  
                }

                
            }

          
        }

        // Para Pasar Color a los TextBox Dentro del Control
        public static void ColorText(Control control, Color color)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) ColorText(contHijo, color);
                if (contHijo is TextBox)
                {
                    contHijo.BackColor = color;
                }
            }
        }

        // Para limpiar Los MaskTextox
        public static void VaciarMaskText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) VaciarMaskText(contHijo);
                if (contHijo is MaskedTextBox)
                {
                    contHijo.Text = string.Empty;
                }
            }

        }

        // Para Pasar Color a los MaskText Dentro del control
        public static void ColorMaskText(Control control, Color color)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) ColorMaskText(contHijo, color);
                if (contHijo is MaskedTextBox)
                {
                    contHijo.BackColor = color;
                }
            }

        }

        // Para Habilitar  los MaskText Dentro del control
        public static void HabilitarMaskText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) HabilitarMaskText(contHijo);
                if (contHijo is MaskedTextBox)
                {
                    contHijo.Enabled = true;
                }
            }

        }

        // Para Deshabilitar  los MaskText Dentro del control
        public static void DeshabilitarMaskText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) DeshabilitarMaskText(contHijo);
                if (contHijo is MaskedTextBox)
                {
                    contHijo.Enabled = false;
                }
            }

        }

        public static void HabilitarTodo(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) HabilitarText(contHijo);
                contHijo.Enabled = true;
            }

        }

        //Para Verificar que los Telefonos,Celulares,Fax estan llenado de Forma Correcta
        public static bool ValidarTelefono(MaskedTextBox Txt)
        {
            bool flag;
            Txt.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (Txt.Text.Length != 0 && Txt.MaskFull == false)
            {
                flag = false;
                Txt.Focus();
            }
            else
            {
                flag = true;
            }

            return flag;

        }

        //Para Verificar que los Telefonos,Celulares,Fax estan llenado de Forma Correcta en Daragried
        public static bool ValidarTelefono(String Telefono)
        {
            string expresion = "[0-9]{9}";//declaramos nuestra expresion regular
            bool Flag;

            if (System.Text.RegularExpressions.Regex.IsMatch(Telefono, expresion))
            {
                if (System.Text.RegularExpressions.Regex.Replace(Telefono, expresion, String.Empty).Length == 0)
                { Flag = true; }
                else
                { Flag = false; }
            }
            else
            {
                Flag = false;
            }
            return Flag;
        }

        //Para Verificar que la cedula sea Correcta
        public static bool ValidarCedula(TextEdit Txt)
        {
            string sCedula = Txt.Text;
            int iDigital = 0;
            int p = 0;
            int t = 0;
            int d = 0;
            decimal Resultado = 0;
            int i = 0;
            string sCon = null;

            sCedula = sCedula.Replace("-", "");

            sCedula = sCedula.Trim();

            if (sCedula.Length != 11)
                return false;

            if (!decimal.TryParse(sCedula, out Resultado))
                return false;


            iDigital = int.Parse(sCedula.Substring(10, 1));
            sCon = "1212121212";
            p = 0;
            t = 0;
            d = 0;

            for (i = 0; i <= 9; i++)
            {
                sCedula = sCedula.Trim();
                p = Convert.ToInt32(sCedula.Substring(i, 1)) * Convert.ToInt32(sCon.Substring(i, 1));
                if (p > 9)
                {
                    p = p - 10 + 1;
                }
                t = t + p;
            }

            d = (10 - (t % 10)) % 10;
            if (iDigital != d)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Para verficiar que los Email esten Escrito Correctamente
        public static bool ValidarEmail(TextEdit Txt)
        {
            bool flag;

            if (Txt.Text != string.Empty)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(Txt.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    Txt.Focus();
                }
            }
            else
            {
                flag = false;
            }

            return flag;
        }//fin del Metodo ValidarEmail

        public static bool ValidarCampoVacio(TextEdit txt,string mensaje,ToolTipController tooltip)
        {
            bool flag;

            if (string.IsNullOrEmpty(txt.Text))
            {
                tooltip.HideHint();
                tooltip.ShowHint(mensaje, txt, DevExpress.Utils.ToolTipLocation.LeftTop);
                flag = true;

            }
            else 
            {
                flag = false;
           
            }

            return flag;

        }


        public static void MostrarMensajeCampoVacio(TextEdit txt, string mensaje, ToolTipController tooltip)
        {
                tooltip.HideHint();
                tooltip.ShowHint(mensaje, txt, DevExpress.Utils.ToolTipLocation.LeftTop);
        }



        public static bool ValidarCampoVacio(ComboBoxEdit cmb, string mensaje, ToolTipController tooltip)
        {
            bool flag;

            if (string.IsNullOrEmpty(cmb.Text))
            {
                tooltip.HideHint();
                tooltip.ShowHint(mensaje, cmb, DevExpress.Utils.ToolTipLocation.LeftTop);
                flag = true;

            }
            else
            {
                flag = false;

            }

            return flag;

        }
    }



}
