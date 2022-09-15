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
using System.IO;

namespace LotoDental
{
    public partial class VisualizadorDeRadiografias : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-F6H1TLU1\\SQLEXPRESS;Initial Catalog=LotoDental;Integrated Security=True");//Cadena de conexion a la base de datos
        public VisualizadorDeRadiografias()
        {
            InitializeComponent();
        }

        private void VisualizadorDeRadiografias_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dataGridView1.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
               


                int id;
                id = Convert.ToInt32(filaSeleccionada.Cells[0].Value.ToString());


                string query = "Select rad_paciente,rad_paciente2 from Historial  where id_paciente=@id";
                conexion.Open();
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader registro = command.ExecuteReader();
                if (registro.Read())
                {
                   
                    if (registro["rad_paciente"] != DBNull.Value)
                    {
                        byte[] arrImg = (byte[])registro["rad_paciente"];
                        MemoryStream ms = new MemoryStream(arrImg);
                        Image img = Image.FromStream(ms);
                        ms.Close();

                        Radiografia1.Image = img;
                        Radiografia1.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                    
                    else
                    {
                        Radiografia1.BackColor = Color.LightGray;
                        Radiografia1.Image = null;
                        MessageBox.Show("Paciente Radiografía #1");
                    }

                    if(registro["rad_paciente2"]!=DBNull.Value)
                    {
                        byte[] arrImg = (byte[])registro["rad_paciente2"];
                        MemoryStream ms = new MemoryStream(arrImg);
                        Image img = Image.FromStream(ms);
                        ms.Close();

                        Radiografia2.Image = img;
                        Radiografia2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        Radiografia2.BackColor = Color.LightGray;
                        Radiografia2.Image = null;
                        MessageBox.Show("Paciente sin Radiografía #2 ");
                    }


                }
                conexion.Close();



            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRadiografia1_Click(object sender, EventArgs e)
        {
            Radiografia1.SizeMode = PictureBoxSizeMode.StretchImage;
            Radiografia2.SizeMode = PictureBoxSizeMode.StretchImage;
            Radiografia1.Show();
            Radiografia2.Show();
        }

        private void Radiografia1_Click(object sender, EventArgs e)
        {
            Radiografia2.Hide();
            Radiografia1.Width = 800;
            Radiografia1.Height = 800;
        }

        private void Radiografia1_DoubleClick(object sender, EventArgs e)
        {
            Radiografia1.Width = 400;
            Radiografia1.Height = 400;
            Radiografia2.Show();
        }

        private void Radiografia2_Click(object sender, EventArgs e)
        {
            Radiografia1.Hide();
            Radiografia2.Width = 800;
            Radiografia2.Height = 800;

        }

        private void Radiografia2_DoubleClick(object sender, EventArgs e)
        {
            Radiografia2.Width = 400;
            Radiografia2.Height = 400;
            Radiografia1.Show();
        }
    }
}
