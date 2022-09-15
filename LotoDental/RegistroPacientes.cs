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
using MiLibreria;

namespace LotoDental
{
    public partial class RegistroPacientes : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-F6H1TLU1\\SQLEXPRESS;Initial Catalog=LotoDental;Integrated Security=True");//Cadena de conexion a la base de datos
        public RegistroPacientes()
        {
            InitializeComponent();
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            RegistroHistorial registroHistorial = new RegistroHistorial();
            registroHistorial.Show();
        }
       

        private void RegistroPacientes_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
               


               

                int Id=0;



                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                string filefoto = "";

                filefoto = lblRutaImagen.Text.Trim();

               
                if (filefoto=="")
                {
                    string query = "Insert Into Pacientes (nom_paciente,dir_paciente,edad_paciente,email_paciente,num_seguro,tel_paciente) VALUES (@nombrepaciente,@dirpaciente,@edad,@email,@numseguro,@telpaciente)SELECT SCOPE_IDENTITY()";

                    conexion.Open();

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombrepaciente", txtNombre.Text);
                    comando.Parameters.AddWithValue("@dirpaciente", txtDireccion.Text);
                    comando.Parameters.AddWithValue("@edad", txtEdad.Text);
                    comando.Parameters.AddWithValue("@email", txtEmail.Text);
                    comando.Parameters.AddWithValue("@numseguro", txtSeguro.Text);
                    comando.Parameters.AddWithValue("@telpaciente", txtTelefono.Text);
                    Id = Convert.ToInt32(comando.ExecuteScalar());
                    MessageBox.Show("Insertado Correctamente....  Id :" + Id);
                   
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    FileStream fs = new FileStream(filefoto, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    ms.SetLength(fs.Length);
                    fs.Read(ms.GetBuffer(), 0, (int)fs.Length);
                    byte[] arrImg = ms.GetBuffer();
                    ms.Flush();
                    fs.Close();
                    string query = "Insert Into Pacientes (nom_paciente,dir_paciente,edad_paciente,email_paciente,num_seguro,tel_paciente,foto_paciente) VALUES (@nombrepaciente,@dirpaciente,@edad,@email,@numseguro,@telpaciente,@imagen)SELECT SCOPE_IDENTITY()";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombrepaciente", txtNombre.Text);
                    comando.Parameters.AddWithValue("@dirpaciente", txtDireccion.Text);
                    comando.Parameters.AddWithValue("@edad", txtEdad.Text);
                    comando.Parameters.AddWithValue("@email", txtEmail.Text);
                    comando.Parameters.AddWithValue("@numseguro", txtSeguro.Text);
                    comando.Parameters.AddWithValue("@telpaciente", txtTelefono.Text);
                    comando.Parameters.AddWithValue("@imagen", arrImg);
                    Id = Convert.ToInt32(comando.ExecuteScalar());
                    

                   
                    MessageBox.Show("Insertado Correctamente....  Id :" + Id);
                    
                }
                   
                  

               
                //comando.Parameters.AddWithValue("@imagen", SqlDbType.VarBinary).Value = arrImg;
                //comando.Parameters.Add("@nombre", SqlDbType.NVarChar, 64).Value = Path.GetFileName(filefoto);

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //<<chido Id = Convert.ToInt32(comando.ExecuteScalar()) ;
                //lblRutaImagen.Text = "";
                //txtNombreImagen.Text = "";
                //pictureBox2.Image = null;


                //MessageBox.Show("Insertado Correctamente....  Id :"+Id);

                string queryresponsable = "Insert Into Responsables (nom_respons,tel_respons,id_paciente) VALUES (@nomrespons,@telresponse,@Identificador)";
                

                SqlCommand command = new SqlCommand(queryresponsable, conexion);

                command.Parameters.AddWithValue("@nomrespons", txtNomResponsable.Text);
                command.Parameters.AddWithValue("@telresponse", txtResponTelefono.Text);
                command.Parameters.AddWithValue("@Identificador",Id);
                //command.Parameters.AddWithValue("@Identificador",Id.ToString());
                               command.ExecuteNonQuery();

                conexion.Close();
                txtNombre.Clear();
                txtDireccion.Clear();
                txtEdad.Clear();
                txtEmail.Clear();
                txtSeguro.Clear();
                txtTelefono.Clear();
                txtid.Clear();


            }catch(Exception error)
            {
                MessageBox.Show("Error : " + error);

            }

            //try
            //{
            
                
                
            //}catch(Exception error2)
            //{

            //    MessageBox.Show("Error :" + error2);

            //}
            







            //    string query = "INSERT INTO Producto (Nombre,Precio) VALUES (@nombre,@precio)";
            //conexion.Open();
            //SqlCommand comando = new SqlCommand(query, conexion);
            //comando.Parameters.AddWithValue("@nombre", txtNombre.Text);
            //comando.Parameters.AddWithValue("@precio", txtPrecio.Text);
            //comando.ExecuteNonQuery();
            //MessageBox.Show("Producto Insertado");


            //string CMD = string.Format("Select * From Usuarios Where account='{0}' AND password='{1}'", txtUsuario.Text.Trim(), txtPassword.Text.Trim()); //Remplaza el 0 y el 1 con los valores de los textbox
            //                                                                                                                                              //CMD es la cadena que recibe el metodo Ejecutar de nuestra libreria y es metodo devuelve un dataset 

            //DataSet ds = Utilidades.Ejecutar(CMD); //El dataset que devuelve lo guardamos en una variable de tipo dataset "ds"
            //string cuenta = ds.Tables[0].Rows[0]["account"].ToString().Trim(); //Tenemos guardado el valor de account  de la consulta a la base en esta variable
            //string password = ds.Tables[0].Rows[0]["password"].ToString().Trim(); //Tenemos guardada la consulta de la contraseña en la variable password
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
               
                
                
                
                
                MessageBox.Show("Insertado correctamente Id");
                conexion.Close();
            }catch(Exception error)
            {
                MessageBox.Show("Error :" + error);


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filefoto;
            filefoto = lblRutaImagen.Text.Trim();
            if(filefoto=="")
            {
                string query = "UPDATE PACIENTES SET nom_paciente=@nompaciente,dir_paciente=@direccion,edad_paciente=@edad,email_paciente=@email,num_seguro=@seguro,tel_paciente=@telefono WHERE id_paciente=@id";
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@nompaciente", txtNombre.Text);
                comando.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                comando.Parameters.AddWithValue("@edad", txtEdad.Text);
                comando.Parameters.AddWithValue("@email", txtEmail.Text);
                comando.Parameters.AddWithValue("@seguro", txtSeguro.Text);
                comando.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                comando.Parameters.AddWithValue("@id", txtid.Text);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                FileStream fs = new FileStream(filefoto, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                ms.SetLength(fs.Length);
                fs.Read(ms.GetBuffer(), 0, (int)fs.Length);
                byte[] arrImg = ms.GetBuffer();
                ms.Flush();
                fs.Close();
                string query = "UPDATE PACIENTES SET nom_paciente=@nompaciente,dir_paciente=@direccion,edad_paciente=@edad,email_paciente=@email,num_seguro=@seguro,tel_paciente=@telefono,foto_paciente=@imagen WHERE id_paciente=@id";
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@nompaciente", txtNombre.Text);
                comando.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                comando.Parameters.AddWithValue("@edad", txtEdad.Text);
                comando.Parameters.AddWithValue("@email", txtEmail.Text);
                comando.Parameters.AddWithValue("@seguro", txtSeguro.Text);
                comando.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                comando.Parameters.AddWithValue("@id", txtid.Text);
                comando.Parameters.AddWithValue("@imagen", arrImg);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            
            
            string Query2 = "UPDATE Responsables SET nom_respons=@nombreresp,tel_respons=@tel WHERE id_paciente=@idpac";
            conexion.Open();
            SqlCommand command = new SqlCommand(Query2,conexion);
            command.Parameters.AddWithValue("@nombreresp", txtNomResponsable.Text);
            command.Parameters.AddWithValue("@idpac", txtid.Text);
            command.Parameters.AddWithValue("@tel", txtResponTelefono.Text);
            command.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Actualizado correctamente...");

            txtNombre.Clear();
            txtDireccion.Clear();
            txtEdad.Clear();
            txtEmail.Clear();
            txtSeguro.Clear();
            txtTelefono.Clear();
            txtid.Clear();
            pictureBox2.Image = null;
            txtNombreImagen.Text="";
            lblRutaImagen.Text = "";






        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbusqueda.Text.Trim()) == false)
            {
                try
                {
                    string query = "SELECT id_paciente,nom_paciente,num_seguro FROM Pacientes WHERE nom_paciente LIKE ('%" + txtbusqueda.Text.Trim() + "%')";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        //private void buttonCargar_Click(object sender, EventArgs e)
        //{

        //    SqlCommand command = new SqlCommand("Select * from Pacientes where id_paciente =@id", conexion);

        //    command.Parameters.AddWithValue("@id", txtid.Text.Trim());
        //    conexion.Open();
        //    SqlDataReader registro = command.ExecuteReader();
        //    if (registro.Read())
        //    {
        //        txtNombre.Text = registro["nom_paciente"].ToString();
        //        txtDireccion.Text = registro["dir_paciente"].ToString();
        //        txtEdad.Text = registro["edad_paciente"].ToString();
        //        txtEmail.Text = registro["email_paciente"].ToString();
        //        txtTelefono.Text = registro["tel_paciente"].ToString();
        //        txtSeguro.Text = registro["num_seguro"].ToString();


        //    }
        //    conexion.Close();


        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dataGridView1.CurrentRow;
            int id;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                id=Convert.ToInt32( filaSeleccionada.Cells[0].Value.ToString());
                SqlCommand command = new SqlCommand("Select * from Pacientes where id_paciente =@id", conexion);

                command.Parameters.AddWithValue("@id",id);
                conexion.Open();
                SqlDataReader registro = command.ExecuteReader();
                if (registro.Read())
                {
                    txtNombre.Text = registro["nom_paciente"].ToString();
                    txtDireccion.Text = registro["dir_paciente"].ToString();
                    txtEdad.Text = registro["edad_paciente"].ToString();
                    txtEmail.Text = registro["email_paciente"].ToString();
                    txtTelefono.Text = registro["tel_paciente"].ToString();
                    txtSeguro.Text = registro["num_seguro"].ToString();
                   
                   //Validacion si en el campo foto_paciente hay algo  muestralo si esta vacio osea null muestra mensaje 
                    if(registro["foto_paciente"]!= DBNull.Value)
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
                      
                        pictureBox2.Image = null;
                        MessageBox.Show("Paciente sin foto");
                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Obtener BitMap de Base de datos
                   


                    // byte[] arrImg = (byte[])command.ExecuteScalar();



                    



                    txtid.Text = Convert.ToString(id);
                   
                    
                }
                conexion.Close();


            }
        }
        
        public void txtEdad_TextChanged(object sender, EventArgs e)
        {
            // int edad =Convert.ToInt32( txtEdad.Text.Trim());  // No es el adecuado para esta validacion
            int edad;

            Int32.TryParse(txtEdad.Text, out edad); //Se ocupa el Try parse para que no mande excepecion al momento de tener null o vacio en la variable edad
            if(edad>18)
            {

                txtResponTelefono.Enabled = false;
                txtNomResponsable.Enabled = false;
                txtResponTelefono.BackColor = Color.Red;
                txtNomResponsable.BackColor = Color.Red;
                
            }
            else
            {
                txtNomResponsable.Enabled = true;
                txtResponTelefono.Enabled = true;
                txtResponTelefono.BackColor = Color.White;
                txtNomResponsable.BackColor = Color.White;

            }

           









        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGreen;
        }

        private void btnModificar_MouseEnter(object sender, EventArgs e)
        {
            btnModificar.BackColor = Color.LightGreen;
        }

        //private void buttonCargar_MouseEnter(object sender, EventArgs e)
        //{
        //    buttonCargar.BackColor = Color.LightGreen;
        //}

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            btnSalir.BackColor = Color.LightGreen;
        }

        private void btnHistorial_MouseEnter(object sender, EventArgs e)
        {
            btnHistorial.BackColor = Color.LightGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
            btnModificar.BackColor = Color.LightGray;
        }

        //private void buttonCargar_MouseLeave(object sender, EventArgs e)
        //{
        //    buttonCargar.BackColor = Color.LightGray;
        //}

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btnSalir.BackColor = Color.LightGray;
        }

        private void btnHistorial_MouseLeave(object sender, EventArgs e)
        {
            btnHistorial.BackColor = Color.LightGray;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            btnAgregarFoto.BackColor = Color.LightGreen;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            btnAgregarFoto.BackColor = Color.LightGray;
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
                pictureBox2.Image = Image.FromFile(Abrir.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;


            }
            else

            {
                lblRutaImagen.Text = "";
                pictureBox2.Image = null;

            }
        }
    }
}
