using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Metodos_Datos
    {
        public static DataSet execute_DataSet(string sp, params object[] parametros)
        {

            DataSet ds = new DataSet();//=> Objet de ADO
            string conn = Configuracion.CadenaConexion;
            SqlConnection SQLconn = new SqlConnection(conn);//SqlConnection Object de ADO
            try
            {

                if (SQLconn.State == ConnectionState.Open)
                {
                    SQLconn.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, SQLconn);//=> SqlCommand objeto de ADO(access data object)
                    //defino que el comando sera ejecutado como una SP (StoreProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;//es mas seguro usar sp que text u otro
                    //Pasamos el SP
                    cmd.CommandText = sp;

                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {
                            //sqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }
                        SQLconn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);//SqlDataAdapter => Objeto de ADO  
                        adapter.Fill(ds);
                        SQLconn.Close();
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (SQLconn.State == ConnectionState.Open)
                {
                    SQLconn.Close();
                }
            }
        }

        public static int execute_Scalar(string sp, params object[] parametros)
        {
            int id = 0;
            string conn = Configuracion.CadenaConexion;
            SqlConnection SQLconn = new SqlConnection(conn);
            try
            {
                if (SQLconn.State == ConnectionState.Open)
                {
                    SQLconn.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, SQLconn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }
                        SQLconn.Open();
                        id = int.Parse(cmd.ExecuteScalar().ToString());
                        SQLconn.Close();
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                if (SQLconn.State == ConnectionState.Open)
                {
                    SQLconn.Close();
                }
            }
        }

        public static int execute_nonQuery(string sp, params object[] parametros)
        {
            //intancia un entero
            int id = 0;
            //obtenemos la cadena de conexio
            string conn = Configuracion.CadenaConexion;
            //creamos ua conexio => SqlConnection Object de ADO
            SqlConnection SQLconn = new SqlConnection(conn);
            try
            {
                //verificamos si la conexion esta abierta
                if (SQLconn.State == ConnectionState.Open)
                {
                    //cerramos la conexion para cerrar antes de entrar
                    SQLconn.Close();
                }
                else
                {
                    //comando para SQL(sp, conexion) => SqlCommand objeto de ADO(access data object)
                    SqlCommand cmd = new SqlCommand(sp, SQLconn);
                    //defino que el comando sera ejecutado como una SP (StoreProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;//es mas seguro usar sp que text u otro
                    //Pasamos el SP
                    cmd.CommandText = sp;

                    /*validamos si existen y estan completos los parametros
                    si es diferente de null y su residuo es diferente de 0
                    parametros = {calve:valor}*/
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {
                            //sqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }
                        //abrimos la conexion
                        SQLconn.Open();
                        //ejecuto el comando sin esperar un return
                        cmd.ExecuteNonQuery();
                        id = 1;
                        //creamos la conexion
                        SQLconn.Close();
                    }
                }
                //Retorno el DS (DataSet)
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                if (SQLconn.State == ConnectionState.Open)
                {
                    SQLconn.Close();
                }
            }
        }
    }
}
