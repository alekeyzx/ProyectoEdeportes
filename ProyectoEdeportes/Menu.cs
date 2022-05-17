using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace ProyectoEdeportes
{
    public partial class Menu : Form
    {
        string con, user;
        public Menu(string con, string user)
        {
            InitializeComponent();
            this.con = con;
            this.user = user;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            AbrirFormHija(new Inicio());
            lblUsuario.Text= $"Usuario: {user}";
            
        }



        private void pnlBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void pnlBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AbrirFormHija(object FormHija)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);
            Form fh = FormHija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(fh);
            fh.Show();
               
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Jugadores(con,user));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Inicio(con, user));
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Empleados(con, user));
        }

        private void btnJuegos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Juegos(con, user));
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Contrato(con, user));
        }

        private void btnPatrocinadores_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Patrocinador(con, user));
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Historial(con, user));
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuario_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
