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
    public partial class VentanaDentista : Form
    {
        public VentanaDentista()
        {
            InitializeComponent();
        }

        private void VentanaDentista_Load(object sender, EventArgs e)
        {

        }

        private void VentanaDentista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListaPacientesDentista listaPacientesDentista = new ListaPacientesDentista();
            listaPacientesDentista.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroTratamiento trata = new RegistroTratamiento();
            
            trata.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HistorialDentista historialDentista = new HistorialDentista();
            historialDentista.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
