using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Para poder utilizar los tipos de dato dataset
using System.Data.SqlClient;

namespace MiLibreria
{
    public class Utilidades
    {
        public static DataSet Ejecutar(string cmd) // Este metodo de tipo DataSet va a recibir instrucciones sql cmd
        {

            SqlConnection Con = new SqlConnection("Data Source=LAPTOP-F6H1TLU1\\SQLEXPRESS;Initial Catalog=LotoDental;Integrated Security=True");//Cadena de conexion a la base de datos

            Con.Open();//Se conecta a la base LotoDental

            DataSet Ds = new DataSet(); //Creamos el Dataset en donde va almacenar las consultas que requiramos

            SqlDataAdapter Dp = new SqlDataAdapter(cmd,Con); //Creamos un SqlDataAdapter para adaptar los datos que devuelva la consulta al dataset Ds

            Dp.Fill(Ds); //Rellena el dataset

            Con.Close(); //Cierra la conexion
            return Ds;



        }


    }
}
