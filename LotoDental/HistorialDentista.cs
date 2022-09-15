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
    public partial class HistorialDentista : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-F6H1TLU1\\SQLEXPRESS;Initial Catalog=LotoDental;Integrated Security=True");//Cadena de conexion a la base de datos
        public HistorialDentista()
        {
            InitializeComponent();
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
            //try
            //{
            //    string query = "Select p.nom_paciente,h.peso_paciente,h.tipo_sangre,h.hipert_paciente,h.alerg_paciente,h.diab_paciente,h.cir_paciente from Historial as h Join Pacientes as p on p.id_paciente=h.id_paciente where p.id_paciente=@id";
            //    conexion.Open();
            //    SqlCommand command = new SqlCommand(query, conexion);
            //    command.Parameters.AddWithValue("@id", txtid.Text);


            //    SqlDataAdapter adapatador = new SqlDataAdapter();
            //    adapatador.SelectCommand = command;
            //    DataTable tabla = new DataTable();
            //    adapatador.Fill(tabla);
            //    dataGridView1.DataSource = tabla;
            //}
            //catch(Exception error)
            //{
            //    MessageBox.Show("Error: " + error);
            //}



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void HistorialDentista_Load(object sender, EventArgs e)
        {

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    string query = "Select p.nom_paciente,h.peso_paciente,h.tipo_sangre,h.hipert_paciente,h.alerg_paciente,h.diab_paciente,h.cir_paciente from Historial as h Join Pacientes as p on p.id_paciente=h.id_paciente where p.id_paciente=@id";
        //    conexion.Open();
        //    SqlCommand command = new SqlCommand(query, conexion);
        //    command.Parameters.AddWithValue("@id", txtid.Text);
        //    SqlDataReader registro = command.ExecuteReader();
        //    if (registro.Read())
        //    {
        //        txtnombre.Text = registro["nom_paciente"].ToString();
        //        txtsangre.Text = registro["tipo_sangre"].ToString();
        //        txtpeso.Text = registro["peso_paciente"].ToString();
        //        txthiper.Text = registro["hipert_paciente"].ToString();
        //        txtalergias.Text = registro["alerg_paciente"].ToString();
        //        txtdiab.Text = registro["diab_paciente"].ToString();
        //        txtcirrugia.Text = registro["cir_paciente"].ToString();


        //    }
        //    conexion.Close();


        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dataGridView1.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                int id;
                id = Convert.ToInt32(filaSeleccionada.Cells[0].Value.ToString());


                string query = "Select p.nom_paciente,h.peso_paciente,h.tipo_sangre,h.hipert_paciente,h.alerg_paciente,h.diab_paciente,h.cir_paciente,p.foto_paciente from Historial as h Join Pacientes as p on p.id_paciente=h.id_paciente where p.id_paciente=@id";
                conexion.Open();
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@id",id);
                SqlDataReader registro = command.ExecuteReader();
                if (registro.Read())
                {
                    txtnombre.Text = registro["nom_paciente"].ToString();
                    txtsangre.Text = registro["tipo_sangre"].ToString();
                    txtpeso.Text = registro["peso_paciente"].ToString();
                    txthiper.Text = registro["hipert_paciente"].ToString();
                    txtalergias.Text = registro["alerg_paciente"].ToString();
                    txtdiab.Text = registro["diab_paciente"].ToString();
                    txtcirrugia.Text = registro["cir_paciente"].ToString();
                    if (registro["foto_paciente"] != DBNull.Value)
                    {
                        byte[] arrImg = (byte[])registro["foto_paciente"];
                        MemoryStream ms = new MemoryStream(arrImg);
                        Image img = Image.FromStream(ms);
                        ms.Close();

                        pictureBox2.Image = img;
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                    else
                    {
                        pictureBox2.BackColor = Color.LightGray;
                        pictureBox2.Image = null;
                        MessageBox.Show("Paciente sin foto");
                    }


                }
                conexion.Close();
                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConsulRadio_Click(object sender, EventArgs e)
        {
            VisualizadorDeRadiografias vision =new  VisualizadorDeRadiografias();
            vision.Show();
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
