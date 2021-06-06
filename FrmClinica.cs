using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinica
{
    public partial class FrmClinica : Form
    {
        private string[] OBRAS_SOCIALES = { "Apross", "Met", "Osde", "Otras" };
        private string[] ESPECIALIDADES = { "Traumatología", "Pediatría", "Cardiología" };
        private Clinica oClinica;

        public FrmClinica()
        {
            InitializeComponent();
            rbMasculino.Checked = true;
            lblExtra1.Text = "";
            cboExtra.Enabled = false;
            lblExtra2.Text = "";
            txtExtra.Enabled = false;

            oClinica = new Clinica("CLINICA SALUD", 100);
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboExtra.Items.Clear();
            cboExtra.Enabled = true;
            txtExtra.Enabled = true;

            if (cboTipo.SelectedIndex == 0)
            {
                lblExtra1.Text = "OS:";
                lblExtra2.Text = "H.C:";

                foreach (string item in OBRAS_SOCIALES)
                {
                    cboExtra.Items.Add(item);
                }

            }
            else
            {

                lblExtra1.Text = "Esp.:";
                lblExtra2.Text = "$ Cons:";
                cboExtra.Items.AddRange(ESPECIALIDADES);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //cierra el formulario y libera los recursos asociados:
            this.Dispose();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar(true);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Persona p = null;

            if (ValidarCampos()== false)
                return;

            int dni = Convert.ToInt32(txtDni.Text);
            string nombre = txtNombre.Text;
            string tel = txtTelefono.Text;
            bool sexo = rbMasculino.Checked;
            string extra1 = cboExtra.Text;
            double consulta;
            string hc;


            if (cboTipo.SelectedIndex == 0)
            {
                hc = txtExtra.Text;
                p = new Paciente(dni, nombre, sexo, tel, extra1, hc);
            }
            else
            {

                consulta = Double.Parse(txtExtra.Text);
                p = new Medico(dni, nombre, sexo, tel, extra1, consulta);
            }
            //Agregramos la persona creada al listado (lstPersonas)
            oClinica.registrarPersona(p);
            lstPersonas.Items.Add(p);
            //actualizar el label de riesgo
            lblRiesgo.Text = "NIVEL DE RIESGO " + oClinica.CalcularNivelRiesgo();
            limpiar();
            habilitar(false);

        }

        private void FrmClinica_Load(object sender, EventArgs e)
        {
            rbMasculino.Checked = true;
            habilitar(false);

           /* SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=.\Luk0-PC;Initial Catalog=ABMPersonas;Integrated Security=True";
            cnn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM T_TIPOS", cnn);
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                cboTipo.DataSource = table;
                cboTipo.DisplayMember = "n_tipo"; //que columna muestra
                cboTipo.ValueMember = "id_tipo"; //que columna guarda
            cnn.Close();*/
        }

        private void habilitar(bool habilitado)
        {
            gbFormulario.Enabled = habilitado;
            btnNuevo.Enabled = !habilitado;
            btnGrabar.Enabled = habilitado;
            btnCancelar.Enabled = habilitado;
        }

        private void limpiar() {
            cboTipo.SelectedIndex = -1;
            cboExtra.SelectedIndex = -1;
            txtDni.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtExtra.Text = "";
            lblExtra1.Text = "";
            lblExtra2.Text = "";
            rbMasculino.Checked = true;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitar(false);
            limpiar();
        }

        private bool ValidarCampos() {
            bool aux = true;
            try
            {
                int dni = Convert.ToInt32(txtDni.Text);
            }
            catch (Exception) {
                aux = false;
                MessageBox.Show("Dato DNI incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return aux;
        }   
    }
}
