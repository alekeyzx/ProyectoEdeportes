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
    public partial class Juegos : Form
    {
        string connectionString, user;
        public Juegos(string con,string user)
        {
            InitializeComponent();
            this.connectionString = con;
            this.user = user;
        }

        private void Juegos_Load(object sender, EventArgs e)
        {
            MostrarJuegos();
        }
        //Conexion + Query
        public void Insertar()
        {
            //string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            string query = "INSERT INTO juegos(`nombre_juego`,`genero`, `num_campeonatos`, `compañia`, `version_actual`, `plataforma`) VALUES ('" + txtNombreJuego.Text + "', '" + txtGenero.Text + "', '" + txtCampeonato.Text + "', '" + txtCompañia.Text + "', '" + txtVersion.Text + "', '" + txtPlataforma.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Juego registrado en la base de datos", "juegos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Juegos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarJuegos();
        }

        public void MostrarJuegos()
        {
            dgvJuegos.Rows.Clear();
            //string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";
            string query = "SELECT* FROM juegos";
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
                        dgvJuegos.Rows.Add(myReader.GetString(0), myReader.GetString(1), myReader.GetString(2), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5));
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "juegos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void txtID_Leave_1(object sender, EventArgs e)
        {
           
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            Insertar();
        }


        //CONEXION + QUERY PARA BORRAR

        private void button1_Click(object sender, EventArgs e)
        {
            //string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //AQUI IDENTIFICABA CUAL SELECCIONABA DE LA TABLA
            string juego = dgvJuegos.CurrentRow.Cells[0].Value.ToString();

            string query = "DELETE FROM `juegos` WHERE nombre_juego = '" + juego + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Juego eliminado de la base de datos", "juegos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "juegos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarJuegos();
        }

        //CONEXION + QUERY PARA BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
           // string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //AQUI VA LA CONSULTA
            string query = "SELECT * FROM juegos";

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
                    MessageBox.Show("No se encontro nada", "juegos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "juegos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //Aqui identifica el seleccionado en la tabla
            string juego = dgvJuegos.CurrentRow.Cells[0].Value.ToString();

            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `juegos` SET `nombre_juego`='" + txtNombreJuego.Text + "', `genero`='" + txtGenero.Text + "',`num_campeonatos`='" + txtCampeonato.Text + "',`compañia`='" + txtCompañia.Text + "',`version_actual`='" + txtVersion.Text + "',`plataforma`='" + txtPlataforma.Text + "' WHERE nombre_juego = '" + juego + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("La informacion del juego se actualizó correctamente", "juegos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "juegos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarJuegos();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            if (indice != -1)
            {
                txtNombreJuego.Text = dgvJuegos.Rows[indice].Cells[0].Value.ToString();
                txtGenero.Text = dgvJuegos.Rows[indice].Cells[1].Value.ToString();
                txtCampeonato.Text = dgvJuegos.Rows[indice].Cells[2].Value.ToString();
                txtCompañia.Text = dgvJuegos.Rows[indice].Cells[3].Value.ToString();
                txtVersion.Text = dgvJuegos.Rows[indice].Cells[4].Value.ToString();
                txtPlataforma.Text = dgvJuegos.Rows[indice].Cells[5].Value.ToString();
            }
           
        }

        private void dgvJuegos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }




        //ESTO ES PARA EL BOTON ACTUALIZAR
        /*
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=videojuegos;";

            //Aqui identifica el seleccionado en la tabla
            string juego = dgvJuegos.CurrentRow.Cells[0].Value.ToString();

            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `juego` SET `nombre_juego`='" + txtNombreJuego.Text + "', `genero`='" + txtGenero.Text + "',`num_campeonatos`='" + txtCampeonato.Text + "',`compañia`='" + txtCompañia.Text + "',`verion_actual`='" + txtVersion.Text + "',`plataforma`='" + txtPlataforma.Text + "' WHERE Nombre = '" + juego + "'";

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
