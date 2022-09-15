using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LotoDental
{
    public partial class ListaPacientesNormal : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-F6H1TLU1\\SQLEXPRESS;Initial Catalog=LotoDental;Integrated Security=True");//Cadena de conexion a la base
        public ListaPacientesNormal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbusqueda.Text.Trim()) == false)
            {
                try
                {
                    string query= "SELECT id_paciente,nom_paciente,num_seguro FROM Pacientes WHERE nom_paciente LIKE ('%" + txtbusqueda.Text.Trim() + "%')";
                    //string query = "SELECT * FROM Pacientes WHERE nom_paciente LIKE ('%" + txtbusqueda.Text.Trim() + "%')";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);

                    SqlDataAdapter adapatador = new SqlDataAdapter();
                    adapatador.SelectCommand = comando;
                    DataTable tabla = new DataTable();
                    adapatador.Fill(tabla);
                    dataGridView1.DataSource = tabla;
                    conexion.Close();

                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error:" + error.Message);
                }



            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListaPacientesNormal_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dataGridView1.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                int id;
                id = Convert.ToInt32(filaSeleccionada.Cells[0].Value.ToString());
                //txtid.Text= filaSeleccionada.Cells[0].Value.ToString();

                try
                {

                    string query = "SELECT p.nom_paciente,c.f_cita,c.h_cita,t.nom_tratamiento FROM Pacientes AS p JOIN Citas AS c ON p.id_paciente = c.id_paciente RIGHT JOIN Tratamientos AS t ON t.id_paciente = p.id_paciente where p.id_paciente=@id";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@id", id);

                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        txtNombre.Text = registro["nom_paciente"].ToString();
                        txtFecha.Text = registro["f_cita"].ToString();
                        txtHora.Text = registro["h_cita"].ToString();
                        txtTratamiento.Text = registro["nom_tratamiento"].ToString();


                    }
                    conexion.Close();


                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error:" + error.Message);
                }


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
