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
    public partial class Patrocinador : Form
    {
        public Patrocinador()
        {
            InitializeComponent();
        }

        public void MostrarPatrocinadores()
        {
            dgvJuegos.Rows.Clear();
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";
            string query = "SELECT* FROM patrocinadores";
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
                        dgvJuegos.Rows.Add(myReader.GetString(0), myReader.GetString(2), myReader.GetString(1));
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Patrocioandor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Conexion + Query
        public void Insertar()
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            string query = "INSERT INTO patrocinadores(`id_patrocinador`,`nombre`, `id_contrato`) VALUES (Null, '" + txtNombreP.Text + "', '" + txtIDContrato.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Patrocinador registrado en la base de datos", "Patrocioandor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Patrocioandor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarPatrocinadores();
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
            string patrocinador = dgvJuegos.CurrentRow.Cells[1].Value.ToString();

            string query = "DELETE FROM `patrocinadores` WHERE nombre = '" + patrocinador + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Patrocinador eliminado de la base de datos", "Patrocioandor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Patrocinador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarPatrocinadores();
        }

        //CONEXION + QUERY PARA BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //AQUI VA LA CONSULTA
            string query = "SELECT * FROM patrocinadores";

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
                    MessageBox.Show("No se encontro nada", "Patrocioandor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Patrocioandor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //Aqui identifica el seleccionado en la tabla
            string patrocinador = dgvJuegos.CurrentRow.Cells[1].Value.ToString();

            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `patrocinadores` SET `nombre`='" + txtNombreP.Text + "',`id_contrato`='" + txtIDContrato.Text + "' WHERE Nombre = '" + patrocinador + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("La informacion del patrocinador se actualizó correctamente", "Patrocioandor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Patrocioandor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarPatrocinadores();
        }

        private void Patrocinador_Load(object sender, EventArgs e)
        {
            MostrarPatrocinadores();
        }

        private void dgvJuegos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            if (indice != -1)
            {
                txtIDPatrocinador.Text = dgvJuegos.Rows[indice].Cells[0].Value.ToString();
                txtNombreP.Text = dgvJuegos.Rows[indice].Cells[1].Value.ToString();
                txtIDContrato.Text = dgvJuegos.Rows[indice].Cells[2].Value.ToString();
            }
          
            
        }

        //ESTO ES PARA EL BOTON ACTUALIZAR
        /*
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=videojuegos;";

            //Aqui identifica el seleccionado en la tabla
            string patrocinador = dgvJuegos.CurrentRow.Cells[0].Value.ToString();

            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `patrocinador` SET  `id_patrocinador`= NULL, `nombre`='" + txtNombreP.Text + "',`id_contrato`='" + txtIDContrato.Text + "' WHERE Nombre = '" + patrocinador + "'";

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
