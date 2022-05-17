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
    public partial class Jugadores : Form
    {
        public Jugadores()
        {
            InitializeComponent();
        }

        private void Jugadores_Load(object sender, EventArgs e)
        {MostrarJugadores();

        }
        public void MostrarJugadores()
        {

            dgvJuegos.Rows.Clear();
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";
            string query = "SELECT* FROM jugadores";
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
                        dgvJuegos.Rows.Add(myReader.GetString(1), myReader.GetString(2), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8), myReader.GetString(9), myReader.GetString(10), myReader.GetString(11), myReader.GetString(12), myReader.GetString(13));
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Jugadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Conexion + Query
        public void Insertar()
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            string query = "INSERT INTO jugadores(`nombre`, `apellido_paterno`, `apellido_materno`, `correo`, `telefono`, `nacionalidad`, `fecha_nacimiento`, `residencia`, `rol`, `genero`, `num_campeonatos`, `id_contrato`, `nombre_Juego`) VALUES ('" + txtNombre.Text + "', '" + txtAPaterno.Text + "', '" + txtAMaterno.Text + "', '" + txtCorreo.Text + "', '" + txtTelefono.Text + "', '" + txtNacionalidad.Text + "', '" + txtFechaNacimiento.Text + "', '" + txtResidencia.Text + "', '" + txtRol.Text + "', '" + txtGenero.Text + "', '" + txtCampeonatos.Text + "', '" + txtIDContratos.Text + "', '" + txtNombreJuego.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Jugador registrado en la base de datos", "Jugadores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Jugadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtID_Leave(object sender, EventArgs e)
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
            string jugador = dgvJuegos.CurrentRow.Cells[2].Value.ToString();

            string query = "DELETE FROM `jugadores` WHERE nombre = '" + jugador + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Jugador eliminado de la base de datos", "Jugadores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Jugadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CONEXION + QUERY PARA BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //AQUI VA LA CONSULTA
            string query = "SELECT * FROM jugador";

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
                    MessageBox.Show("No se encontro nada", "Jugadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Jugadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void dgvJuegos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            if (indice != -1)
            {
                txtIDContratos.Text = dgvJuegos.Rows[indice].Cells[0].Value.ToString();
                txtNombreJuego.Text = dgvJuegos.Rows[indice].Cells[1].Value.ToString();
                txtNombre.Text = dgvJuegos.Rows[indice].Cells[2].Value.ToString();
                txtAPaterno.Text = dgvJuegos.Rows[indice].Cells[3].Value.ToString();
                txtAMaterno.Text = dgvJuegos.Rows[indice].Cells[4].Value.ToString();
                txtCorreo.Text = dgvJuegos.Rows[indice].Cells[5].Value.ToString();
                txtTelefono.Text = dgvJuegos.Rows[indice].Cells[6].Value.ToString();
                txtNacionalidad.Text = dgvJuegos.Rows[indice].Cells[7].Value.ToString();
                txtFechaNacimiento.Text = dgvJuegos.Rows[indice].Cells[8].Value.ToString();
                txtResidencia.Text = dgvJuegos.Rows[indice].Cells[9].Value.ToString();
                txtRol.Text = dgvJuegos.Rows[indice].Cells[10].Value.ToString();
                txtGenero.Text = dgvJuegos.Rows[indice].Cells[11].Value.ToString();
                txtCampeonatos.Text = dgvJuegos.Rows[indice].Cells[12].Value.ToString();
            }
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DateTime fechaN=DateTime.Parse(txtFechaNacimiento.Text);    
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //Aqui identifica el seleccionado en la tabla
            string jugador = dgvJuegos.CurrentRow.Cells[2].Value.ToString();

            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `jugadores` SET `nombre`='" + txtNombre.Text + "', `apellido_paterno`='" + txtAPaterno.Text + "',`apellido_materno`='" + txtAMaterno.Text + "',`correo`='" + txtCorreo.Text + "',`telefono`='" + txtTelefono.Text + "',`nacionalidad`='" + txtNacionalidad.Text + "',`fecha_nacimiento`='" + fechaN.ToString("yyyy/MM/dd") + "',`residencia`='" + txtResidencia.Text + "',`rol`='" + txtRol.Text + "',`genero`='" + txtGenero.Text + "',`num_campeonatos`='" + txtCampeonatos.Text + "',`id_contrato`='" + txtIDContratos.Text + "',`nombre_juego`='" + txtNombreJuego.Text + "'  WHERE nombre = '" + jugador + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("La informacion del jugador se actualizó correctamente", "Jugadores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Jugadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarJugadores();
        }



        //ESTO ES PARA EL BOTON ACTUALIZAR
        /*
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=videojuegos;";

            //Aqui identifica el seleccionado en la tabla
            string jugador = dgvJuegos.CurrentRow.Cells[0].Value.ToString();

            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `jugador` SET `nombre`='" + txtNombre.Text + "', `apellido_paterno`='" + txtAPaterno.Text + "',`apellido_materno`='" + txtAMaterno.Text + "',`correo`='" + txtCorreo.Text + "',`telefono`='" + txtTelefono.Text + "',`nacionalidad`='" + txtNacionalidad.Text + "',`fecha_de_nacimiento`='" + txtFechaNacimiento.Text + "',`residencia`='" + txtResidencia.Text + "',`rol`='" + txtRol.Text + "',`genero`='" + txtGenero.Text + "',`num_campeonatos`='" + txtCampeonatos.Text + "',`id_contrato`='" + txtIDContratos.Text + "',`nombre_juego`='" + txtNombreJuego.Text + "'  WHERE Nombre = '" + jugador + "'";

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
