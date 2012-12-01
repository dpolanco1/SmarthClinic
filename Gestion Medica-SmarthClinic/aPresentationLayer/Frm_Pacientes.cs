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

        //para saber si ocurrio un error en las tablas
        bool seGuardoDirecciones = true;
        bool seGuardoTelefonos = true;
        bool seGuardoContactos = true;

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

              //  Controles.VaciarText(frm_pacientes);

                Controles.VaciarDGV(frm_pacientes);

                Controles.HabilitarText(frm_pacientes);

                //Desabilito el txtIDPaciente
                txtIDPaciente.Enabled = false;
                //Paso el Foco Al Nombre
                txtNombres.Focus();

                //Agrego una descripcion para el control
                txtUbicacion.Text = "Agregar una Dirección para el paciente";
                txtUbicacion.ForeColor = Color.DarkGray;
                txtContacto.Text = "Agregar Nombre de Contacto";
                txtContacto.ForeColor = Color.DarkGray;
                txtTelefonos.Text = "Agregar Teléfono";
                txtTelefonos.ForeColor = Color.DarkGray;
                txtTelefonoContacto.Text = "Agregar Teléfono";
                txtTelefonoContacto.ForeColor = Color.DarkGray;

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
                  //  Controles.VaciarText(frm_pacientes);

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

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
           using (TransactionScope scope = new TransactionScope())
            {
                //si la conexcion esta disponible
                if (Bl_Paciente.VerificarConecxion())
                {
                    //Si tengo seleccionado el tabPacientes, los botones estan enable false  
                    if (tabPrincipalPacientes.SelectedTabPage == tabPacientes && txtNombres.Enabled == true)
                    {
                        //Validar los datos importantes

                        if (String.IsNullOrEmpty(txtNombres.Text) || String.IsNullOrEmpty(txtApellidos.Text) ||
                            String.IsNullOrEmpty(cmbTipoIdentificacion.Text) || String.IsNullOrEmpty(txtIdentificacion.Text) ||
                            String.IsNullOrEmpty(cmbGenero.Text))
                        {
                            MessageBox.Show("Campos en negrita son obligatorios", " Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            
                        }
                        else if (!Controles.ValidarCedula(txtIdentificacion) && cmbTipoIdentificacion.Text == "Cedula")
                        {
                            MessageBox.Show("La cedula proporcionada no es valida", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtIdentificacion.Focus();
                        }
                        else if (!Controles.ValidarEmail(txtEmail) && txtEmail.Text != string.Empty)
                        {
                            MessageBox.Show("El email no es valido, favor verifique", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtEmail.Focus();

                        }


                        else
                        {
                            try
                            {
                              
                                //-----------------------------------------------------INSERT--------------------------------------------------------------------//

                                if (NUEVO == true)
                                {

                                //Valores Entidad Direcciones
                                    if (vistaDirecciones.RowCount > 0)
                                    {
                                        for (int i = 0; i < vistaDirecciones.RowCount; i++)
                                        {

                                            //paso el valor de la columna a la entidad al parecer es ese.
                                            direcciones.Direccion = Convert.ToString(vistaDirecciones.GetRowCellValue(i, "Direcciones")).Trim();


                                            if (!Bl_Direcciones.Insert(direcciones))
                                            {
                                                seGuardoDirecciones = false;
                                                MessageBox.Show("Hay problemas para insertar las direcciones del paciente, comuniquese con el administrador del sistema, disculpe los inconvenientes", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }

                                        }//fin del for dtgDireccionn

                                    }//fin insert direcciones

                                    if (vistaTelefonos.RowCount > 0 && seGuardoDirecciones == true)
                                       {
                                           for (int i = 0; i < vistaTelefonos.RowCount; i++)
                                           {

                                               telefonos.Telefono = Convert.ToString(vistaTelefonos.GetRowCellValue(i, "Teléfonos")).Trim();

                                               if (!Bl_Telefono.Insert(telefonos))
                                               {
                                                   seGuardoTelefonos = false;
                                                   MessageBox.Show("Hay problemas para insertar los telefonos del paciente, comuniquese con el administrador del sistema, disculpe los inconvenientes", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                               }

                                           }//fin del for dtgTelefonos


                                       }//fin insert Telefonos

                                    if (VistaContactos.RowCount > 0 && seGuardoTelefonos == true)
                                    {
                                        for (int i = 0; i < VistaContactos.RowCount ; i++)
                                        {

                                            contacto.Contacto = Convert.ToString(VistaContactos.GetRowCellValue(i, "Nombre de Contacto")).Trim();
                                            contacto.Telefono = Convert.ToString(VistaContactos.GetRowCellValue(i, "Teléfono")).Trim();

                                            if (!Bl_Contacto.Insert(contacto))
                                            {
                                                seGuardoContactos = false;
                                                MessageBox.Show("Hay problemas para insertar los contactos del paciente, comuniquese con el administrador del sistema, disculpe los inconvenientes", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }


                                        }//fin del for dtgContactos

                                    }//fin insert Contactos




                                       //Valores Entidad Paciente
                                       txtIDPaciente.Text = Convert.ToString(Bl_Paciente.SearchIDPaciente());//para actualizar
                                       paciente.IDPaciente = txtIDPaciente.Text.Trim();
                                       paciente.Nombres = txtNombres.Text;
                                       paciente.Apellidos = txtApellidos.Text;
                                       paciente.IDTipoIdentifacion = cmbTipoIdentificacion.SelectedIndex;
                                       paciente.Identificacion = txtIdentificacion.Text;
                                       paciente.Edad = txtEdad.Text.Trim();
                                       paciente.Genero = cmbGenero.Text;
                                       paciente.EstadoCivil = cmbEstadoCivil.Text.Trim();
                                       paciente.TipoSangre = cmbTipoSangre.Text.Trim();
                                       paciente.TipoPaciente = cmbTipoPaciente.SelectedIndex;
                                       paciente.Email = txtEmail.Text;
                                       paciente.Direccion = txtDireccion.Text;
                                       paciente.Peso = txtPeso.Value;
                                       paciente.Altura = txtAltura.Value;


                                       Bl_Paciente.Insert(paciente);

                                       MessageBox.Show("El paciente se insetó correctamente ", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Information);



                                    /*

                                     

                                       if (seGuardoDirecciones == true && seGuardoTelefonos == true && seGuardoContactos == true)
                                       {
                                           if (Bl_Paciente.Insert(paciente))
                                           {
                                               txtIDPaciente.Text = Bl_Paciente.SearchIDPaciente().ToString();
                                               //Si todo paso bien

                                               MessageBox.Show("Los datos del paciente fueron insertados correctamente", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                               NUEVO = false;

                                               //Deshabilito los Txt
                                               Bl_AdministrarControles.DeshabilitarText(frm_pacientes);

                                               //Deshabilito los Datagried
                                               Bl_AdministrarControles.DeshabilitarDGV(frm_pacientes);

                                               //Si se inserto el paciente bien 
                                               seGuardoDirecciones = false;
                                               seGuardoTelefonos = false;
                                               seGuardoTelefonos = false;
                                           }
                                           else
                                               MessageBox.Show("Hay problemas para insertar los datos del paciente, comuniquese con el administrador del sistema, disculpe los inconvenientes", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);



                                       }//fin del insert Bl_Contacto.Inserts

                                       else
                                       {
                                           MessageBox.Show("Hay problemas para insertar los datos en general del paciente, comuniquese con el administrador del sistema, disculpe los inconvenientes", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                       }



                                   }//fin de todos los insert con Nuevo

                                       //-----------------------------------------------------UPDATE--------------------------------------------------------------------//

                                       //si existe un problema entonces muestro un mensaje de aviso al usuario.
                                   else if (EDITANDO == true)
                                   {

                                       //Valores Entidad Direcciones
                                       if (dtgDirecciones.Rows.Count > 1)
                                       {
                                           if (Bl_Direcciones.Delete(Convert.ToInt32(txtIDPaciente.Text.Trim())))
                                           {

                                               for (int i = 0; i < dtgDirecciones.RowCount - 1; i++)
                                               {
                                                   direcciones.IDPaciente = txtIDPaciente.Text.Trim();
                                                   direcciones.Direccion = Convert.ToString(dtgDirecciones.Rows[i].Cells[0].Value);

                                                   if (!Bl_Direcciones.Update(direcciones))
                                                   {
                                                       seGuardoDirecciones = false;
                                                       MessageBox.Show("Hay problemas para actualizar las direcciones del paciente, comuniquese con el administrador del sistema, disculpe los inconvenientes", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                   }

                                               }

                                           }

                                       }

                                       if (dtgTelefonos.Rows.Count > 1 && seGuardoDirecciones == true)
                                       {
                                           if (Bl_Telefono.Delete(Convert.ToInt32(txtIDPaciente.Text.Trim())))
                                           {
                                               for (int i = 0; i < dtgTelefonos.RowCount - 1; i++)
                                               {
                                                   telefonos.IDPaciente = txtIDPaciente.Text.Trim();
                                                   telefonos.Telefono = Convert.ToString(dtgTelefonos.Rows[i].Cells[0].Value);

                                                   if (!Bl_Telefono.Update(telefonos))
                                                   {
                                                       seGuardoTelefonos = false;
                                                       MessageBox.Show("Hay problemas para actualizar los telefonos del paciente, comuniquese con el administrador del sistema, disculpe los inconvenientes", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                                   }

                                               }

                                           }

                                       }

                                       if (dtgContactos.Rows.Count > 1 && seGuardoTelefonos == true)
                                       {

                                           if (Bl_Contacto.Delete(Convert.ToInt32(txtIDPaciente.Text.Trim())))
                                           {
                                               for (int i = 0; i < dtgContactos.RowCount - 1; i++)
                                               {
                                                   contacto.IDContacto = txtIDPaciente.Text.Trim();
                                                   contacto.Contacto = Convert.ToString(dtgContactos.Rows[i].Cells[0].Value);
                                                   contacto.Telefono = Convert.ToString(dtgContactos.Rows[i].Cells[1].Value);

                                                   if (!Bl_Contacto.Update(contacto))
                                                   {
                                                       seGuardoContactos = false;
                                                       MessageBox.Show("Hay problemas para actualizar los contactos del paciente, comuniquese con el administrador del sistema, disculpe los inconvenientes", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                                   }

                                               }//fin del for dtgContactos

                                           }
                                       }

                                       if (seGuardoDirecciones == true && seGuardoTelefonos == true && seGuardoContactos == true)
                                       {
                                           if (Bl_Paciente.Update(paciente))
                                           {

                                               MessageBox.Show("La edición se realizó correctamente", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                               //Deshabilito los Txt
                                               Bl_AdministrarControles.DeshabilitarText(frm_pacientes);

                                               //Deshabilito los Datagried
                                               Bl_AdministrarControles.DeshabilitarDGV(frm_pacientes);

                                               NUEVO = true;
                                               EDITANDO = false;
                                               CONSULTANDO = true;

                                               //si todo anduvo bien
                                               seGuardoDirecciones = false;
                                               seGuardoTelefonos = false;
                                               seGuardoContactos = false;
                                           }

                                       }*/

                                   }//fin del if UPDATE  */
                                
                            }//FIN DEL TRY
                            catch (Exception)
                            {
                                MessageBox.Show("Hubo un error para obtener los datos del paciente, comuniquese con el administrador del sistema, disculpe los inconvenientes", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }


                        }//fin del Else ya se asignaron los valores a la entidad Paciente


                    }//Fin del If TabControl


                    //si todo esta bien y es el fin del If Tabcontrol envia los datos al sevidor

                }
                else if (!Bl_Paciente.VerificarConecxion() && txtNombres.Enabled == true)
                {
                    //si no hay una conexcion a la base de datos entonces emitira este mensaje.
                    MessageBox.Show("Hay problemas de conexión a la base de datos, comuniquese con el administrador del sistema, disculpe los inconvenientes", "Smart Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                scope.Complete();
            }//fin del Using Scope
        }

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            if (txtUbicacion.Text.Length != 0 && txtUbicacion.Text != string.Empty
               && txtUbicacion.Text != "Agregar una direccion para el paciente" && txtDireccion.Enabled == true)
            {

                vistaDirecciones.AddNewRow();
                vistaDirecciones.SetRowCellValue(vistaDirecciones.FocusedRowHandle, "Direcciones", txtUbicacion.Text.Trim());
                vistaDirecciones.UpdateCurrentRow();
                txtUbicacion.Text = string.Empty;
                txtUbicacion.Focus();
            }
            else { txtUbicacion.Focus(); }


        }

        private void Frm_Pacientes_Load(object sender, EventArgs e)
        {
           string[] ColumnasDtgDirecciones = { "Direcciones" };
           string[] ColumnasDtgTelefonos = { "Teléfonos" };
           string[] ColumnasDtgContactos = { "Nombre de Contacto", "Teléfono" };
            

             DataTable dtdirecciones = new DataTable();
             DataTable dtTelefono = new DataTable();
             DataTable dtContactos = new DataTable();

            foreach (var nombreColumna in ColumnasDtgDirecciones)
            {
                
                dtdirecciones.Columns.Add(nombreColumna);
            
            }

            foreach (var nombreColumna in ColumnasDtgTelefonos)
            {
                dtTelefono.Columns.Add(nombreColumna);
            }

            foreach (var nombreColumna in ColumnasDtgContactos)
            {
                dtContactos.Columns.Add(nombreColumna);
            }
             
              dtgDirecciones.DataSource = dtdirecciones;
              dtgTelefonos.DataSource = dtTelefono;
              dtgContactos.DataSource = dtContactos;



          
        }

        private void txtUbicacion_Enter(object sender, EventArgs e)
        {
            txtUbicacion.Text = string.Empty;
            txtUbicacion.ForeColor = Color.Black;
        }

        private void txtUbicacion_Leave(object sender, EventArgs e)
        {
            if (txtUbicacion.Text == string.Empty)
            {
                txtUbicacion.Text = "Agregar una direccion para el paciente";
                txtUbicacion.ForeColor = Color.DarkGray;
            }
            else if (txtUbicacion.Text != string.Empty && this.ActiveControl.Name != this.btnAgregarDireccion.Name)
            {
                txtUbicacion.Text = "Agregar una direccion para el paciente";
                txtUbicacion.ForeColor = Color.DarkGray;
            }
        }

        private void Frm_Pacientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            NUEVO = false;
            EDITANDO = false;
        }

        private void btnAgregarDireccion_Leave(object sender, EventArgs e)
        {
              if (txtUbicacion.Text != string.Empty)
            {
                txtUbicacion.Text = "Agregar una direccion para el paciente";
                txtUbicacion.ForeColor = Color.DarkGray;
            }
        }

        private void btnAgregarTelefonos_Click(object sender, EventArgs e)
        {
            if (txtTelefonos.Text.Length != 0 && txtTelefonos.Text != string.Empty)
            {
                vistaTelefonos.AddNewRow();
                vistaTelefonos.SetRowCellValue(vistaTelefonos.FocusedRowHandle, "Teléfonos", txtTelefonos.Text.Trim());
                vistaTelefonos.UpdateCurrentRow();
                txtTelefonos.Text = string.Empty;
                txtTelefonos.Focus();
            }
            else { txtTelefonos.Focus(); }
        }

        private void txtTelefonos_Enter(object sender, EventArgs e)
        {
            txtTelefonos.Text = string.Empty;
            txtTelefonos.ForeColor = Color.Black;
        }

        private void txtTelefonos_Leave(object sender, EventArgs e)
        {

            if (txtTelefonos.Text == string.Empty)
            {
                txtTelefonos.Text = "Agregar Télefono";
                txtTelefonos.ForeColor = Color.DarkGray;
            }
            else if (txtTelefonos.Text != string.Empty && this.ActiveControl.Name != this.btnAgregarTelefonos.Name)
            {
                txtTelefonos.Text = "Agregar Télefono";
                txtTelefonos.ForeColor = Color.DarkGray;
            }
        }

        private void btnAgregarTelefonos_Leave(object sender, EventArgs e)
        {
            if (txtTelefonos.Text != string.Empty)
            {
                txtTelefonos.Text = "Agregar Télefono";
                txtTelefonos.ForeColor = Color.DarkGray;
            }
            else 
            {
                txtTelefonos.Text = "Agregar Télefono";
                txtTelefonos.ForeColor = Color.DarkGray;
            }
        }

        private void btnEliminarDireccion_Click(object sender, EventArgs e)
        {
            if (vistaDirecciones.RowCount > 0 && txtUbicacion.Enabled == true)
            {
                vistaDirecciones.DeleteSelectedRows();
            }
        }

        private void btnEliminarTelefonos_Click(object sender, EventArgs e)
        {
            if (vistaTelefonos.RowCount > 0 && txtTelefonos.Enabled == true)
            {
                vistaTelefonos.DeleteSelectedRows();
            }
        }

        private void btnEliminarContacto_Click(object sender, EventArgs e)
        {
            if (VistaContactos.RowCount > 0 && txtContacto.Enabled == true && txtTelefonos.Enabled == true)
            {
                VistaContactos.DeleteSelectedRows();
            }
        }

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            if (txtContacto.Text != string.Empty && txtTelefonoContacto.Text != string.Empty)
            {
                VistaContactos.AddNewRow();
                VistaContactos.SetRowCellValue(VistaContactos.FocusedRowHandle, "Nombre de Contacto", txtContacto.Text.Trim());
                VistaContactos.SetRowCellValue(VistaContactos.FocusedRowHandle, "Teléfono", txtTelefonoContacto.Text.Trim());
                VistaContactos.UpdateCurrentRow();
                txtContacto.Text = string.Empty;
                txtTelefonoContacto.Text = string.Empty;
                txtContacto.Focus();
            }
            else { txtContacto.Focus(); }
        }

        private void txtContacto_Enter(object sender, EventArgs e)
        {
            txtContacto.Text = string.Empty;
            txtContacto.ForeColor = Color.Black;
        }

        private void txtTelefonoContacto_Enter(object sender, EventArgs e)
        {
            txtTelefonoContacto.Text = string.Empty;
            txtTelefonoContacto.ForeColor = Color.Black;
        }

        private void txtContacto_Leave(object sender, EventArgs e)
        {
            if (txtContacto.Text == string.Empty)
            {
                txtContacto.Text = "Agregar Nombre de Contacto";
                txtContacto.ForeColor = Color.DarkGray;
            }
            else if (txtContacto.Text != string.Empty &&   this.ActiveControl.Name != this.txtTelefonoContacto.Name)
            {
                txtContacto.Text = "Agregar Nombre de Contacto";
                txtContacto.ForeColor = Color.DarkGray;
            }
        }

        private void btnEliminarContacto_Leave(object sender, EventArgs e)
        {
            txtNombres.Focus();
        }


    }
}