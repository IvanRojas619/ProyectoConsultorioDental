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
    public partial class RegistroHistorial : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-F6H1TLU1\\SQLEXPRESS;Initial Catalog=LotoDental;Integrated Security=True");//Cadena de conexion a la base de datos
        public RegistroHistorial()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filefoto = "";

            filefoto = lblRutaImagen.Text.Trim();

            string filefoto2;
            filefoto2 = lblRutaImagen2.Text.Trim();

            if(filefoto==""&&filefoto2=="")
            {

                try
                {
                    string query = "Insert into Historial (peso_paciente,tipo_sangre,hipert_paciente,alerg_paciente,diab_paciente,cir_paciente,id_paciente) Values (@peso,@sangre,@hipertension,@alergia,@diabetes,@cirugia,@id)";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@peso", txtPeso.Text);
                    comando.Parameters.AddWithValue("@sangre", comboSangre.SelectedItem.ToString());
                    comando.Parameters.AddWithValue("@hipertension", comboHipertension.SelectedItem.ToString());
                    comando.Parameters.AddWithValue("@alergia", textAlergia.Text);
                    comando.Parameters.AddWithValue("@diabetes", comboDiabetes.SelectedItem.ToString());
                    comando.Parameters.AddWithValue("@cirugia", textCirugia.Text);
                    comando.Parameters.AddWithValue("@id", txtid.Text);

                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro Exitoso ...");
                    conexion.Close();
                }
                catch (Exception error)

                {

                    MessageBox.Show("Error :" + error);
                }

            }
             if(filefoto2=="")
            {
                //Se obtiene el bitmap de la foto1
                MemoryStream ms = new MemoryStream();
                FileStream fs = new FileStream(filefoto, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                ms.SetLength(fs.Length);
                fs.Read(ms.GetBuffer(), 0, (int)fs.Length);
                byte[] arrImg = ms.GetBuffer();
                ms.Flush();
                fs.Close();
                //Se obtiene el bitmap de la segunda radiografia

               

                try
                {
                    string query = "Insert into Historial (peso_paciente,tipo_sangre,hipert_paciente,alerg_paciente,diab_paciente,cir_paciente,id_paciente,rad_paciente) Values (@peso,@sangre,@hipertension,@alergia,@diabetes,@cirugia,@id,@radiografia)";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@peso", txtPeso.Text);
                    comando.Parameters.AddWithValue("@sangre", comboSangre.SelectedItem.ToString());
                    comando.Parameters.AddWithValue("@hipertension", comboHipertension.SelectedItem.ToString());
                    comando.Parameters.AddWithValue("@alergia", textAlergia.Text);
                    comando.Parameters.AddWithValue("@diabetes", comboDiabetes.SelectedItem.ToString());
                    comando.Parameters.AddWithValue("@cirugia", textCirugia.Text);
                    comando.Parameters.AddWithValue("@id", txtid.Text);
                    comando.Parameters.AddWithValue("@radiografia", arrImg);
                   
                   
                    
                    
                    

                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro Exitoso ...");
                    conexion.Close();
                }
                catch (Exception error)

                {

                    MessageBox.Show("Error :" + error);
                }




            }
            if(filefoto=="")
            {
                //Se obtiene el bitmap de la foto 2
                
                //bitmap de la segunda
                MemoryStream ms2 = new MemoryStream();
                FileStream fs2 = new FileStream(filefoto2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                ms2.SetLength(fs2.Length);
                fs2.Read(ms2.GetBuffer(), 0, (int)fs2.Length);
                byte[] arrImg2 = ms2.GetBuffer();
                ms2.Flush();
                fs2.Close();
                string query = "Insert into Historial (peso_paciente,tipo_sangre,hipert_paciente,alerg_paciente,diab_paciente,cir_paciente,id_paciente,rad_paciente2) Values (@peso,@sangre,@hipertension,@alergia,@diabetes,@cirugia,@id,@radiografia2)";
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@peso", txtPeso.Text);
                comando.Parameters.AddWithValue("@sangre", comboSangre.SelectedItem.ToString());
                comando.Parameters.AddWithValue("@hipertension", comboHipertension.SelectedItem.ToString());
                comando.Parameters.AddWithValue("@alergia", textAlergia.Text);
                comando.Parameters.AddWithValue("@diabetes", comboDiabetes.SelectedItem.ToString());
                comando.Parameters.AddWithValue("@cirugia", textCirugia.Text);
                comando.Parameters.AddWithValue("@id", txtid.Text);
    

                comando.Parameters.AddWithValue("@radiografia2", arrImg2);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Exitoso ...");




            }
            if(filefoto!=""&&filefoto2!="")
            {

                //Se obtiene el bitmap de la foto1
                MemoryStream ms = new MemoryStream();
                FileStream fs = new FileStream(filefoto, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                ms.SetLength(fs.Length);
                fs.Read(ms.GetBuffer(), 0, (int)fs.Length);
                byte[] arrImg = ms.GetBuffer();
                ms.Flush();
                fs.Close();
                //Se obtiene el bitmap de la segunda radiografia
                MemoryStream ms2 = new MemoryStream();
                FileStream fs2 = new FileStream(filefoto2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                ms2.SetLength(fs2.Length);
                fs2.Read(ms2.GetBuffer(), 0, (int)fs2.Length);
                byte[] arrImg2 = ms2.GetBuffer();
                ms2.Flush();
                fs2.Close();


                try
                {
                    string query = "Insert into Historial (peso_paciente,tipo_sangre,hipert_paciente,alerg_paciente,diab_paciente,cir_paciente,id_paciente,rad_paciente,rad_paciente2) Values (@peso,@sangre,@hipertension,@alergia,@diabetes,@cirugia,@id,@radiografia,@radiografia2)";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@peso", txtPeso.Text);
                    comando.Parameters.AddWithValue("@sangre", comboSangre.SelectedItem.ToString());
                    comando.Parameters.AddWithValue("@hipertension", comboHipertension.SelectedItem.ToString());
                    comando.Parameters.AddWithValue("@alergia", textAlergia.Text);
                    comando.Parameters.AddWithValue("@diabetes", comboDiabetes.SelectedItem.ToString());
                    comando.Parameters.AddWithValue("@cirugia", textCirugia.Text);
                    comando.Parameters.AddWithValue("@id", txtid.Text);
                    comando.Parameters.AddWithValue("@radiografia", arrImg);
                    comando.Parameters.AddWithValue("@radiografia2", arrImg2);






                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro Exitoso ...");
                    conexion.Close();
                }
                catch (Exception error)

                {

                    MessageBox.Show("Error :" + error);
                }



            }
            
            
           
            



           
        }

        private void Buscar_Click(object sender, EventArgs e)
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

        public void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text.Trim()) == false)
            {
                try
                {
                    string query = "SELECT id_paciente,nom_paciente,num_seguro FROM Pacientes WHERE nom_paciente LIKE ('%" + txtBuscar.Text.Trim() + "%')";

                    //string query = "SELECT id_paciente,nom_paciente,num_seguro FROM Pacientes WHERE nom_paciente LIKE ('%" + txtBuscar.Text.Trim() + "%')";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);

                    SqlDataAdapter adapatador = new SqlDataAdapter();
                    adapatador.SelectCommand = comando;
                    DataTable tabla = new DataTable();
                    adapatador.Fill(tabla);
                    dataGridView1.DataSource = tabla;



                    // Seleccion de indice por dos clicks directos
                    //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[e.RowIndex];
                    //if (row.Index != null)
                    //{
                    //    = Convert.ToString(row.Cells[0].Value);
                    //    txtTexbox2.Text = Convert.ToString(row.Cells[1].Value);
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
            if (dataGridView1.CurrentRow == null)
               return;

            DataGridViewRow row = dataGridView1.CurrentRow;
            txtid.Text = row.Cells[0].Value.ToString();




        }

        private void button3_Click(object sender, EventArgs e)
        {
            //peso_paciente,tipo_sangre,hipert_paciente,alerg_paciente,diab_paciente,cir_paciente,id_paciente

            try
            {
                //string query = "UPDATE Historial  SET peso_paciente=@peso,tipo_sangre=@sangre,hipert_paciente=@hipertension,alerg_paciente=@alergia,diab_paciente=@diabetes,cir_paciente=@cirugia WHERE id_paciente=@id ";

                string cadena="UPDATE Historial  SET peso_paciente = @peso,tipo_sangre=@sangre,hipert_paciente=@hipertension,diab_paciente=@diabetes,alerg_paciente=@alergia,cir_paciente=@cirugia WHERE id_paciente = @id ";
                conexion.Open();
                
                SqlCommand command = new SqlCommand(cadena, conexion);
                command.Parameters.AddWithValue("@id", txtid.Text);
                command.Parameters.AddWithValue("@peso", txtPeso.Text);
                command.Parameters.AddWithValue("@sangre", comboSangre.SelectedItem);
                command.Parameters.AddWithValue("@hipertension", comboHipertension.SelectedItem) ;
                command.Parameters.AddWithValue("@diabetes", comboDiabetes.SelectedItem.ToString());
                command.Parameters.AddWithValue("@alergia", textAlergia.Text);
                command.Parameters.AddWithValue("cirugia", textCirugia.Text);
                

                command.ExecuteNonQuery();
               
                conexion.Close();
                MessageBox.Show("Registro Actualziado..");

            }
            catch(Exception error)
            {
                MessageBox.Show("Error :" + error);

            }
            

        }

        private void RegistroHistorial_Load(object sender, EventArgs e)
        {

        }

        private void textAlergia_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
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

        private void btnAgregarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.Filter = "*.bmp;*.gif;*.jpg;*.png|*.bmp;*.gif;*.jpg;*.png";
            Abrir.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Abrir.Title = "Seleccionar la imagen que guardara en la base de datos";
            if (Abrir.ShowDialog() == DialogResult.OK)
            {

                lblRutaImagen.Text = Abrir.FileName;
                txtNombreImagen.Text = Abrir.SafeFileName;
                Radiografia.Image = Image.FromFile(Abrir.FileName);
                Radiografia.SizeMode = PictureBoxSizeMode.StretchImage;


            }
            else

            {
                lblRutaImagen.Text = "";
                Radiografia.Image = null;

            }
        }

        private void btnAgregarfoto2_Click(object sender, EventArgs e)
        {
            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.Filter = "*.bmp;*.gif;*.jpg;*.png|*.bmp;*.gif;*.jpg;*.png";
            Abrir.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Abrir.Title = "Seleccionar la imagen que guardara en la base de datos";
            if (Abrir.ShowDialog() == DialogResult.OK)
            {

                lblRutaImagen2.Text = Abrir.FileName;
                txtNombreImagen2.Text = Abrir.SafeFileName;
                Radiografia2.Image = Image.FromFile(Abrir.FileName);
                Radiografia2.SizeMode = PictureBoxSizeMode.StretchImage;


            }
            else

            {
                lblRutaImagen2.Text = "";
                Radiografia2.Image = null;

            }
        }
    }
}
