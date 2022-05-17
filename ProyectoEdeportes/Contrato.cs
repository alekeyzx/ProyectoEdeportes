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
    public partial class Contrato : Form
    {
        public Contrato()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //Conexion + Query
        public void Insertar()
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            string query = "INSERT INTO contratos(`id_contrato`,`inicio_contrato`, `terminacion_contrato`, `clausulas`, `sueldo`, `firma`) VALUES (Null, '" + txtGenero.Text + "', '" + txtCampeonato.Text + "', '" + txtCompañia.Text + "', '" + txtVersion.Text + "', '" + txtPlataforma.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Contrato registrado en la base de datos", "Contrato", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarContratos();
        }

        public void MostrarContratos()
        {
            dgvJuegos.Rows.Clear();
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";
            string query = "SELECT* FROM contratos";
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
                        dgvJuegos.Rows.Add(myReader.GetString(0), myReader.GetString(1).ToString(), myReader.GetString(2), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5));
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        //CONEXION + QUERY PARA BORRAR
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //AQUI IDENTIFICABA CUAL SELECCIONABA DE LA TABLA
            string contrato = dgvJuegos.CurrentRow.Cells[0].Value.ToString();

            string query = "DELETE FROM `contratos` WHERE id_contrato = '" + contrato + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Contrato eliminado de la base de datos", "Contrato", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarContratos();
        }

        //CONEXION + QUERY PARA BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";

            //AQUI VA LA CONSULTA
            string query = "SELECT * FROM contratos";

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
                    MessageBox.Show("No se encontro nada", "Contrato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string connectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team;";
            DateTime fechaI = DateTime.Parse(txtGenero.Text);
            DateTime fechaF = DateTime.Parse(txtCampeonato.Text);

            //Aqui identifica el seleccionado en la tabla
            string contrato = dgvJuegos.CurrentRow.Cells[0].Value.ToString();

            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `contratos` SET `inicio_contrato`='" + fechaI.ToString("yyyy/MM/dd") + "',`terminacion_contrato`='" + fechaF.ToString("yyyy/MM/dd") + "',`clausulas`='" + txtCompañia.Text + "',`sueldo`='" + txtVersion.Text + "',`firma`='" + txtPlataforma.Text + "' WHERE id_contrato = '" + contrato + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("La informacion del contrato se actualizó correctamente", "Contrato", MessageBoxButtons.OK, MessageBoxIcon.Information);

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarContratos();
        }

        private void Contrato_Load(object sender, EventArgs e)
        {
            MostrarContratos();
        }

        private void dgvJuegos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        //ESTO ES PARA EL BOTON ACTUALIZAR
        /*
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=videojuegos;";

            //Aqui identifica el seleccionado en la tabla
            string contrato = dgvJuegos.CurrentRow.Cells[0].Value.ToString();

            //QUERY PARA ACTUALIZAR
            string query = "UPDATE `contrato` SET  `id_contrato`= NULL, `inicio_contrato`='" + txtGenero.Text + "',`terminacion_contrato`='" + txtCampeonato.Text + "',`clausulas`='" + txtCompañia.Text + "',`prestacion_economica`='" + txtVersion.Textt + "',`firma`='" + txtPlataforma.Text + "' WHERE Nombre = '" + contrato + "'";

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
