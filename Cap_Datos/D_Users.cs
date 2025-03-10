﻿using Cap_Entidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Cap_Datos
{
    public class D_Users
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_User(E_Users obje)
        {

            SqlCommand cmd = new SqlCommand("logeo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", obje.usuario);
            cmd.Parameters.AddWithValue("@pass", obje.pass);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


    }
}
