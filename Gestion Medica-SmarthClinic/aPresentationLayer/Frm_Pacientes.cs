using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.XtraEditors;
using aPresentationLayer.Validaciones;
using EntidadesLayer;
using System.Windows.Forms;
using System.Transactions;
using BussinesLogicLayer;

namespace aPresentationLayer
{
    public partial class Frm_Pacientes : DevExpress.XtraEditors.XtraForm
    {

        //Entidades
        readonly Ent_Paciente paciente = new Ent_Paciente();
        readonly Ent_Direcciones direcciones = new Ent_Direcciones();
        readonly Ent_Telefono telefonos = new Ent_Telefono();
        readonly Ent_Contacto contacto = new Ent_Contacto();

        //variables del Frm_Paciente
        private static bool NUEVO = false;
        private static bool EDITANDO = false;



        private static Frm_Pacientes frm_pacientes; // Referencia estática al mismo formulario

        public static Frm_Pacientes frm_Pacientes() // Método estatico que hace referencia a el mismo
        {
            if (frm_pacientes == null || frm_pacientes.IsDisposed) // Comprobar si el form esta Null (No ejecutado)
            {
                frm_pacientes = new Frm_Pacientes(); // Se crea instancia
            }
            else
            {
                frm_pacientes.BringToFront(); // De lo contrario, se pasa al frente
            }

            return frm_pacientes; // Retornamos el valor
        }//fin del metodo

        public Frm_Pacientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tabPrincipalPacientes.SelectedTabPage == tabPacientes && !NUEVO == true)
            {
                NUEVO = true;
                EDITANDO = false;

                Controles.VaciarText(frm_pacientes);

                Controles.VaciarDGV(frm_pacientes);

                Controles.HabilitarText(frm_pacientes);

                //Desabilito el txtIDPaciente
                txtIDPaciente.Enabled = false;
                //Paso el Foco Al Nombre
                txtNombres.Focus();

                //Agrego una descripcion para el control
                txtUbicacion.Text = "Agregar una direccion para el paciente";
                txtUbicacion.ForeColor = Color.DarkGray;
                txtContacto.Text = "Agregar nombre de contacto";
                txtContacto.ForeColor = Color.DarkGray;

            }
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tabPrincipalPacientes.SelectedTabPage == tabPacientes && !string.IsNullOrEmpty(txtIDPaciente.Text) && NUEVO == true)
            {
                /*Cambio las variable del sistema a Nuevo = false (me aseguro que este en false) y 
                  Editando = False (indicando que el registro existe) */

                EDITANDO = true;
                NUEVO = false;


                //Habilitos los Txt
                Controles.HabilitarText(frm_pacientes);

                //Habilitos los Txt
                Controles.HabilitarDGV(frm_pacientes);

                //Deshabilito el CampoIDPaciente
                txtIDPaciente.Enabled = false;

                //Paso el Foco Al Nombre
                txtNombres.Focus();
            }//fin del if
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tabPrincipalPacientes.SelectedTabPage == tabPacientes && txtNombres.Enabled == true)
            {
                var Respuesta = MessageBox.Show("Desea realmente cancelar los cambios?", "Smart Clinic", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Respuesta == DialogResult.Yes)
                {
                    NUEVO = false;
                    EDITANDO = false;

                    //Deshabilito los Txt
                    Controles.DeshabilitarText(frm_pacientes);

                    //Deshabilito los Datagried
                    Controles.DeshabilitarDGV(frm_pacientes);

                    //Limpio los Txt
                    Controles.VaciarText(frm_pacientes);

                    //Limpio los DatagriedView
                    Controles.VaciarDGV(frm_pacientes);



                }

            }// fin del if
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //si tenemos el tabpaciente activo y textID no esta vacio y no se esta editando entonces borra.
            if (tabPrincipalPacientes.SelectedTabPage == tabPacientes && !string.IsNullOrEmpty(txtIDPaciente.Text) && EDITANDO == false)
            {
                DialogResult Respuesta = MessageBox.Show("Desea realmente eliminar el registro?", "Smart Clinic", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Respuesta == DialogResult.Yes)
                {

                    using (TransactionScope scope = new TransactionScope())
                    {

                        try
                        {

                            //Si nunguno de los metodos de borrar emite un error entonces borra

                            if (!Bl_Paciente.Delete(Convert.ToInt32(txtIDPaciente.Text.Trim())) && !Bl_Direcciones.Delete(Convert.ToInt32(txtIDPaciente.Text.Trim()))
                                && !Bl_Telefono.Delete(Convert.ToInt32(txtIDPaciente.Text.Trim())) && !Bl_Contacto.Delete(Convert.ToInt32(txtIDPaciente.Text.Trim())))
                            {

                                MessageBox.Show("Hubo problemas eliminando los datos del paciente, comuniquese con el administrador del sistema, disculpe los inconvenientes", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                             
     
                                //Limpio los Txt
                                Controles.VaciarText(frm_pacientes);

                                //Limpio los DatagriedView
                                Controles.VaciarDGV(frm_pacientes);

                                //Deshabilito los Txt
                                Controles.DeshabilitarText(frm_pacientes);

                                //Deshabilito los Datagried
                                Controles.DeshabilitarDGV(frm_pacientes);

                            }


                        }
                        catch (Exception)
                        {

                            throw;
                        }


                        scope.Complete();

                    }//fin del Scope
                }

            }// fin del if
        }
    }
}