using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotoDental
{
    public partial class Recepcionista : Form
    {
        public Recepcionista()
        {
            InitializeComponent();
        }

        private void VentanaRecepcionista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroPacientes registropacientes = new RegistroPacientes();
            registropacientes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListaPacientesNormal listaPacientesNormal = new ListaPacientesNormal();

            listaPacientesNormal.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistroCitas registrocitas = new RegistroCitas();
            registrocitas.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Recepcionista_Load(object sender, EventArgs e)
        {

        }
    }
}
