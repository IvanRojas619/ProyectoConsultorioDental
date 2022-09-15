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
    public partial class RegistroTratamiento : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-F6H1TLU1\\SQLEXPRESS;Initial Catalog=LotoDental;Integrated Security=True");//Cadena de conexion a la base de datos
        public RegistroTratamiento()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            { 
            string query = "Update Tratamientos set nom_tratamiento=@nombre,ses_tratamiento=@sesiones,p_tratamiento=@precio,ob_tratamiento=@observacion,nom_doctor=@nombredoctor,estatus=@estatus where id_paciente=@id ";
            conexion.Open();
            SqlCommand command = new SqlCommand(query,conexion);
            command.Parameters.AddWithValue("@nombre", txtnombre.Text);
            command.Parameters.AddWithValue("@sesiones", txtsesiones.Text);
            command.Parameters.AddWithValue("@precio", txtprecio.Text);
            command.Parameters.AddWithValue("@observacion", txtobserv.Text);
            command.Parameters.AddWithValue("@nombredoctor", "Sonia Camacho");
            command.Parameters.AddWithValue("@estatus", txtstatus.Text);
            command.Parameters.AddWithValue("@id", txtid.Text);
            command.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Registro Actualizado..");
            }catch(Exception error)
            {

                MessageBox.Show("Error: " + error);

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text.Trim()) == false)
            {
                try
                {

                    string query = "SELECT id_paciente,nom_paciente,num_seguro FROM Pacientes WHERE nom_paciente LIKE ('%" + txtBuscar.Text.Trim() + "%')";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);

                    SqlDataAdapter adapatador = new SqlDataAdapter();
                    adapatador.SelectCommand = comando;
                    DataTable tabla = new DataTable();
                    adapatador.Fill(tabla);
                    dataGridView1.DataSource = tabla;



                    //// Seleccion de indice por dos clicks directos
                    //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[e.RowIndexZ];
                    //if (row.Index != null)
                    //{
                    //    txtid= Convert.ToString(row.Cells[0].Value);

                    //}

                    conexion.Close();
                }
                
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error:" + error.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "Insert into Tratamientos (nom_tratamiento,ses_tratamiento,p_tratamiento,ob_tratamiento,nom_doctor,id_paciente,estatus) Values (@nombre,@sesion,@precio,@observacion,@nombredoctor,@id,@estatus)";
                conexion.Open();
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@nombre",txtnombre.Text);
                command.Parameters.AddWithValue("@sesion", txtsesiones.Text);
                command.Parameters.AddWithValue("@precio", txtprecio.Text);
                command.Parameters.AddWithValue("@observacion", txtobserv.Text);
                command.Parameters.AddWithValue("@nombredoctor", "Sonia Camacho");
                command.Parameters.AddWithValue("@id", txtid.Text);
                command.Parameters.AddWithValue("@estatus", txtstatus.Text);
                command.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Registro Exitoso");
                txtnombre.Clear();
                txtsesiones.Clear();
                txtprecio.Clear();
                txtobserv.Clear();
                txtid.Clear();
                txtstatus.Clear();





            }catch(Exception error)
            {
                MessageBox.Show("Error: " + error);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from Tratamientos where id_paciente =@id", conexion);

            command.Parameters.AddWithValue("@id", txtid.Text.Trim());
            conexion.Open();
            SqlDataReader registro = command.ExecuteReader();
            if (registro.Read())
            {
                txtnombre.Text = registro["nom_tratamiento"].ToString();
               txtsesiones.Text = registro["ses_tratamiento"].ToString();
                txtprecio.Text = registro["p_tratamiento"].ToString();
                txtobserv.Text = registro["ob_tratamiento"].ToString();
                txtstatus.Text = registro["estatus"].ToString();
                


            }
            conexion.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Close();
            this.Close();
        }

        private void RegistroTratamiento_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dataGridView1.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                txtid.Text = filaSeleccionada.Cells[0].Value.ToString();
            }

        }
    }
}
