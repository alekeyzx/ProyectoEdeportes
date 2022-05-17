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
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            AbrirFormHija(new Inicio());
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
            AbrirFormHija(new Jugadores());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Inicio());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Empleados());
        }

        private void btnJuegos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Juegos());
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Contrato());
        }

        private void btnPatrocinadores_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Patrocinador());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Historial());
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
