﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;

namespace aPresentationLayer.Validaciones
{
     abstract class AdministrarControles
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
                    contHijo.Text = String.Empty;

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
                    contHijo.Text = String.Empty;

                }
                else if (contHijo is MemoEdit)
                {
                    contHijo.Text = String.Empty;

                }
                else if (contHijo is MaskedTextBox)
                {
                    contHijo.Text = String.Empty;

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
                    contHijo.Text = String.Empty;
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

    }
}
