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
    public partial class RegistroCitas : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-F6H1TLU1\\SQLEXPRESS;Initial Catalog=LotoDental;Integrated Security=True");//Cadena de conexion a la base de datos

        DateTime mPreviousTime;

        public RegistroCitas()
        {
            InitializeComponent();
            mPreviousTime = DateTime.Now;

        }

        private void RegistroCitas_Load(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string fecha;
                string hora;


                // dateTimePicker2.Format = DateTimePickerFormat.Custom;

                fecha = Convert.ToString(dateTimePicker1.Value.Day) + "/" + Convert.ToString(dateTimePicker1.Value.Month) + "/" + Convert.ToString(dateTimePicker1.Value.Year);
                hora = Convert.ToString(dateTimePicker2.Value.Hour) + " : " + Convert.ToString(dateTimePicker2.Value.Minute);
                // hora = dateTimePicker2.CustomFormat = "hh:mm tt";
                string query = "UPDATE Citas SET f_cita=@fecha,h_cita=@hora WHERE id_paciente= @id";
                conexion.Open();
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@hora", hora);
                command.Parameters.AddWithValue("@id", txtid.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Registro Actualizado..");
                conexion.Close();




            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }



        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha;
                string hora;


                // dateTimePicker2.Format = DateTimePickerFormat.Custom;

                fecha = Convert.ToString(dateTimePicker1.Value.Day) + "/" + Convert.ToString(dateTimePicker1.Value.Month) + "/" + Convert.ToString(dateTimePicker1.Value.Year);
                hora = Convert.ToString(dateTimePicker2.Value.Hour) + " : " + Convert.ToString(dateTimePicker2.Value.Minute);
                // hora = dateTimePicker2.CustomFormat = "hh:mm tt";


                string query = "Insert Into Citas (f_cita,h_cita,id_paciente) Values (@fecha,@hora,@id)";
                conexion.Open();
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@hora", hora);
                command.Parameters.AddWithValue("id", txtid.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Exitoso!");
                conexion.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error :" + error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("La fecha seleccionada es  la correcta ?" +



      mPreviousTime.ToLongDateString() + "?",

      "Confirm Date Change", MessageBoxButtons.YesNo);



            if (dr == DialogResult.Yes)

            {

                mPreviousTime = dateTimePicker1.Value;

            }

            else

            {

                MessageBox.Show("Vuelva a seleccionar la fecha");

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dataGridView1.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                
                //id = Convert.ToInt32(filaSeleccionada.Cells[0].Value.ToString());
                txtid.Text = filaSeleccionada.Cells[0].Value.ToString();
            }
        }
    }
}
