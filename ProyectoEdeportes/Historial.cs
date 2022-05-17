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
    public partial class Historial : Form
    {
        public Historial()
        {
            InitializeComponent();
        }
        private void Historial_Load(object sender, EventArgs e)
        {
            MostrarHistorial();
        }

        public void MostrarHistorial()
        {
            dgvJuegos.Rows.Clear();
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";
            string query = "SELECT* FROM historial";
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
                        dgvJuegos.Rows.Add(myReader.GetString(1), myReader.GetString(2), myReader.GetString(3),myReader.GetString(4));
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Conexion + Query
        public void Insertar()
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            string query = "INSERT INTO historial(`id_historial`,`id_jugador`, `victorias`, `derrotas`, `fecha`) VALUES (Null, '" + txtClaveJugador.Text + "', '" + txtVictorias.Text + "', '" + txtDerrotas.Text + "', '" + txtFecha.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Historial registrado en la base de datos", "Historial", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarHistorial();
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            Insertar();
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

        //CONEXION + QUERY PARA BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //AQUI VA LA CONSULTA
            string query = "SELECT * FROM historial";

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
                    MessageBox.Show("No se encontro nada", "Historial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CONEXION + QUERY PARA BORRAR
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //AQUI IDENTIFICABA CUAL SELECCIONABA DE LA TABLA
            string jugador = dgvJuegos.CurrentRow.Cells[0].Value.ToString();

            string query = "DELETE FROM `historial` WHERE id_jugador= '" + jugador + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Historial eliminado de la base de datos", "Historial", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarHistorial();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //Aqui identifica el seleccionado en la tabla
            string jugador = dgvJuegos.CurrentRow.Cells[0].Value.ToString();
            DateTime fecha=DateTime.Parse(txtFecha.Text);
            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `historial` SET `id_jugador`='" + txtClaveJugador.Text + "',`victorias`='" + txtVictorias.Text + "',`derrotas`='" + txtDerrotas.Text + "',`fecha`='" + fecha.ToString("yyyy/MM/dd") + "' WHERE id_jugador = '" + jugador + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("La informacion del historial se actualizó correctamente", "Historial", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarHistorial();
        }

        private void dgvJuegos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            if (indice != -1)
            {
                txtClaveJugador.Text = dgvJuegos.Rows[indice].Cells[0].Value.ToString();
                txtVictorias.Text = dgvJuegos.Rows[indice].Cells[1].Value.ToString();
                txtDerrotas.Text = dgvJuegos.Rows[indice].Cells[2].Value.ToString();
                txtFecha.Text = dgvJuegos.Rows[indice].Cells[3].Value.ToString();
            }
            
        }

      

        //ESTO ES PARA EL BOTON ACTUALIZAR
        /*
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=videojuegos;";

            //Aqui identifica el seleccionado en la tabla
            string historial = dgvJuegos.CurrentRow.Cells[0].Value.ToString();

            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `historial` SET  `id_historial`= NULL, `id_jugador`='" + txtClaveJugador.Text + "',`victorias`='" + txtVictorias.Text + "',`derrotas`='" + txtDerrotas.Text + "',`fecha`='" + txtFecha.Text + "' WHERE Nombre = '" + historial + "'";

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
