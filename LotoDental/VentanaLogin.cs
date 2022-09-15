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
using MiLibreria;

namespace LotoDental
{
    public partial class VentanaLogin : Form
    {
        public VentanaLogin()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();  
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();

        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("Select * From Usuarios Where account='{0}' AND password='{1}'", txtUsuario.Text.Trim(), txtPassword.Text.Trim()); //Remplaza el 0 y el 1 con los valores de los textbox
                //CMD es la cadena que recibe el metodo Ejecutar de nuestra libreria y es metodo devuelve un dataset 

                DataSet ds = Utilidades.Ejecutar(CMD); //El dataset que devuelve lo guardamos en una variable de tipo dataset "ds"
                string cuenta = ds.Tables[0].Rows[0]["account"].ToString().Trim(); //Tenemos guardado el valor de account  de la consulta a la base en esta variable
                string password = ds.Tables[0].Rows[0]["password"].ToString().Trim(); //Tenemos guardada la consulta de la contraseña en la variable password

                if(cuenta==txtUsuario.Text.Trim() && password==txtPassword.Text.Trim())
                {
                    

                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Status_Admin"]) == true) //Valida si el usuario es de tipo 1 Dentista ó 0 recepcionista
                    {

                        VentanaDentista venDent = new VentanaDentista();
                        this.Hide(); //Oculta la ventana actual

                        venDent.Show();//Muestra la ventana del dentista


                    }
                    else
                    {
                        Recepcionista venRecep = new Recepcionista();//Instancio la clase de la ventana recepcionista

                        this.Hide();// Oculta la ventana actual
                        

                        venRecep.Show(); //Muestra la ventana recepcionista

                    }
                }
               
            }
            catch(Exception error)
            {

                MessageBox.Show("Usuario o contraseña incorrectos!");
            }







            //try
            //{
            //    SqlConnection Con = new SqlConnection("Data Source=LAPTOP-F6H1TLU1\\SQLEXPRESS;Initial Catalog=LotoDental;Integrated Security=True");//Cadena de conexion a la base de datos

            //    Con.Open();//Se conecta a la base LotoDental
            //    MessageBox.Show("Se ha conectado !");

            //} catch(Exception error)

            //{


            //    MessageBox.Show("Ha ocurrido un error con la conexion!!" + error.Message);
            //}

            //if (txtUsuario.Text == "ivan" && txtPassword.Text == "1234")
            //{
            //    MessageBox.Show("Es correcto");

            //}
            //else
            //{
            //    MessageBox.Show("Clave incorrecta");

            //    txtPassword.Text = "";
            //    txtUsuario.Text = "";
            //    txtUsuario.Focus();

            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroCitas cita = new RegistroCitas();
            cita.Show();
        }
    }
}
