using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static  ML.Result AlumnoGetAll()
        {
            ML.Result result = new ML.Result();
            try
            { 
                using(SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "AlumnoGetAll";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = contex;

                            DataTable tablaalumno = new DataTable();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            dataAdapter.Fill(tablaalumno);
                            if (tablaalumno.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tablaalumno.Rows)
                                {
                                    ML.Alumno alumno = new ML.Alumno();
                                    alumno.IdAlumno = int.Parse(row[0].ToString());
                                    alumno.Nombre = row[1].ToString();
                                    alumno.ApellidoPaterno = row[2].ToString();
                                    alumno.ApellidoMaterno = row[3].ToString();
                                    result.Objects.Add(alumno);
                                }
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                            }
                        }


                    }

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex=ex;
            }
            return result;
        }
        public static ML.Result AlumnoGetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AlumnoGetById";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = contex;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;
                        cmd.Parameters.AddRange(collection);


                        DataTable tablaalumno = new DataTable();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        dataAdapter.Fill(tablaalumno);
                        if (tablaalumno.Rows.Count > 0)
                        {
                            DataRow row = tablaalumno.Rows[0];
                            result.Objects = new List<object>();
                            
                                ML.Alumno alumno = new ML.Alumno();
                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();
                                result.Objects.Add(alumno);
                            
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result AlumnoAdd(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AlumnoAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = contex;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;
                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;
                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result AlumnoUpDate(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AlumnoUpDate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = contex;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("@IdAlumno", System.Data.SqlDbType.VarChar);
                        collection[0].Value = alumno.IdAlumno;
                        collection[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = alumno.Nombre;
                        collection[2] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoPaterno;
                        collection[3] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[3].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result AlumnoDelete(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AlumnoDElete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = contex;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;
                        cmd.Parameters.AddRange(collection);

                        
                        cmd.Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = !false;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
