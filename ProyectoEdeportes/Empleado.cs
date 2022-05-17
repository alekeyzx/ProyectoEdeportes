using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace ProyectoEdeportes
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void MostrarEmpleados()
        {
            dgvJuegos.Rows.Clear();
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";
            string query = "SELECT* FROM empleados";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        dgvJuegos.Rows.Add(myReader.GetString(1),myReader.GetString(2), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8), myReader.GetString(9), myReader.GetString(10), myReader.GetString(11));
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Conexion + Query
        public void Insertar()
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            string query = "INSERT INTO empleados(`nombre`, `apellido_paterno`, `apellido_materno`, `correo`, `telefono`, `nacionalidad`, `fecha_nacimiento`, `residencia`, `rol`, `genero`, `id_contrato`) VALUES ('" + txtNombre.Text + "', '" + txtApaterno.Text + "', '" + txtAmaterno.Text + "', '" + txtCorreo.Text + "', '" + txtTelefono.Text + "', '" + txtNacionalidad.Text + "', '" + txtFechaNacimiento.Text + "', '" + txtResidenciaE.Text + "', '" + txtRol.Text + "', '" + txtGenero.Text + "', '" + txtIDcontrato.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Empleado registrado en la base de datos", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarEmpleados();

        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        //CONEXION + QUERY PARA BORRAR
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //AQUI IDENTIFICABA CUAL SELECCIONABA DE LA TABLA
            string empleado = dgvJuegos.CurrentRow.Cells[1].Value.ToString();

            string query = "DELETE FROM `empleados` WHERE nombre = '" + empleado + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Empleado eliminado de la base de datos", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CONEXION + QUERY PARA BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=esports;";

            //AQUI VA LA CONSULTA
            string query = "SELECT * FROM empleados";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            dgvJuegos.Rows.Clear();

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //AQUI LOS DESPLIEGA EN LA TABLA
                        dgvJuegos.Rows.Add(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro nada", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";
            DateTime fechaN=DateTime.Parse(txtFechaNacimiento.Text);

            //Aqui identifica el seleccionado en la tabla
            string empleado = dgvJuegos.CurrentRow.Cells[1].Value.ToString();

            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `empleados` SET `nombre`='" + txtNombre.Text + "', `apellido_paterno`='" + txtApaterno.Text + "',`apellido_materno`='" + txtAmaterno.Text + "',`correo`='" + txtCorreo.Text + "',`telefono`='" + txtTelefono.Text + "',`nacionalidad`='" + txtNacionalidad.Text + "',`fecha_nacimiento`='" + fechaN.ToString("yyyy/MM/dd") + "',`residencia`='" + txtResidenciaE.Text + "',`rol`='" + txtRol.Text + "',`genero`='" + txtGenero.Text + "',`id_contrato`='" + txtIDcontrato.Text + "' WHERE nombre = '" + empleado + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("La informacion del empleado se actualizó correctamente", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarEmpleados();

        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            MostrarEmpleados();
        }

        private void dgvJuegos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            if (indice != -1)
            {
                txtIDcontrato.Text = dgvJuegos.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvJuegos.Rows[indice].Cells[1].Value.ToString();
                txtApaterno.Text = dgvJuegos.Rows[indice].Cells[2].Value.ToString();
                txtAmaterno.Text = dgvJuegos.Rows[indice].Cells[3].Value.ToString();
                txtCorreo.Text = dgvJuegos.Rows[indice].Cells[4].Value.ToString();
                txtTelefono.Text = dgvJuegos.Rows[indice].Cells[5].Value.ToString();
                txtNacionalidad.Text = dgvJuegos.Rows[indice].Cells[6].Value.ToString();
                txtFechaNacimiento.Text = dgvJuegos.Rows[indice].Cells[7].Value.ToString();
                txtResidenciaE.Text = dgvJuegos.Rows[indice].Cells[8].Value.ToString();
                txtRol.Text = dgvJuegos.Rows[indice].Cells[9].Value.ToString();
                txtGenero.Text = dgvJuegos.Rows[indice].Cells[10].Value.ToString();
            }
           
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //ESTO ES PARA EL BOTON ACTUALIZAR
        /*
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=videojuegos;";

            //Aqui identifica el seleccionado en la tabla
            string empleado = dgvJuegos.CurrentRow.Cells[0].Value.ToString();

            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `empleado` SET `nombre`='" + txtNombre.Text + "', `apellido_paterno`='" + txtApaterno.Text + "',`apellido_materno`='" + txtAmaterno.Text + "',`correo`='" + txtCorreo.Text + "',`telefono`='" + txtTelefono.Text + "',`nacionalidad`='" + txtNacionalidad.Text + "',`fecha_de_nacimiento`='" + txtFechaNacimiento.Text + "',`residencia`='" + txtResidenciaE.Text + "',`rol`='" + txtRol.Text + "',`genero`='" + txtGenero.Text + "',`id_contrato`='" + txtIDContratos.Text + "' WHERE Nombre = '" + empleado + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("La informacion del juego se actualizó correctamente");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
         */

    }
}
