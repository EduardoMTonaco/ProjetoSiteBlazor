﻿using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace ProjetoSite.Class
{
    public class SQLHandler
    {
        public SQLHandler(string _connectionString)
        {
            connectionString = _connectionString;
        }
        private static string connectionString { get; set; } = "";
        public static void SQLCommand(string sql)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static List<Array> SQLReader(string sql)
        {
            try
            {
                List<Array> ArrayList = new List<Array>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    List<string> list = new List<string>();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    connection.Open();
                    //SqlDataReader xxx = cmd.ExecuteReader();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            object[] retorno = new object[rdr.FieldCount];
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                              
                                retorno.SetValue(rdr.GetValue(i), i);
                            }
                            ArrayList.Add(retorno);
                        }
                    }
                    connection.Close();
                }
                return ArrayList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
