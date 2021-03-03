using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebListaGenerica.Models.Data
{
    public class DataMascotas
    {
        
        public DataTable ObtenerSinSp()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from mascotas order by nombre", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable Obtener()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spObtenerMascotas",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataRow Obtener(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from mascotas where id_mascota ="+id, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0];
        }

        public DataTable Obtener(string nombreMascota)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter($"select * from mascotas where nombre like '%{nombreMascota}%'" , con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int AgregarSinSp(string nombre, string raza, int edad, string especie, string sexo, string fechaAlta, string nombreRazaEspecie)
        {
            int filasAfectadas = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            try
            {

                SqlCommand cmd = new SqlCommand($"insert into mascotas values('{nombre}','{raza}',{edad},'{especie}','{sexo}','{fechaAlta}','{nombreRazaEspecie}');",con);
                con.Open();
                filasAfectadas = cmd.ExecuteNonQuery();
                con.Close();
                return filasAfectadas;
            }
            catch(Exception)
            {
                con.Close();
                throw;
            }
        }

        public int Agregar(string nombre, string raza, int edad, string especie, string sexo, string fechaAlta, string nombreRazaEspecie)
        {
            int filasAfectadas = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            try
            {

                SqlCommand cmd = new SqlCommand("spAgregarMascota", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@raza", raza);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.Parameters.AddWithValue("@especie", especie);
                cmd.Parameters.AddWithValue("@sexo", sexo);
                cmd.Parameters.AddWithValue("@fechaAlta", fechaAlta);
                cmd.Parameters.AddWithValue("@nombreRazaEspecie", nombreRazaEspecie);
                con.Open();
                filasAfectadas = cmd.ExecuteNonQuery();
                con.Close();
                return filasAfectadas;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }

        public int Editar(string nombre, string raza, int edad, string especie, string sexo,string nombreRazaEspecie, int id)
        {
            int filasAfectadas = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand($"update mascotas set nombre='{nombre}',raza='{raza}',edad={edad},especie='{especie}',sexo='{sexo}',nombreRazaEspecie='{nombreRazaEspecie}' where id_mascota={id}", con);
                con.Open();
                filasAfectadas = cmd.ExecuteNonQuery();
                con.Close();
                return filasAfectadas;
            }
            catch(Exception)
            {
                con.Close();
                throw;
            }
        }

        public int Borrar(int id)
        {
            int filasAfectadas = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand($"delete from mascotas where id_mascota={id};", con);
                con.Open();
                filasAfectadas = cmd.ExecuteNonQuery();
                con.Close();
                return filasAfectadas;
            }
            catch(Exception)
            {
                con.Close();
                throw;
            }
        }

        public bool ValidarNombreRepetidoAgregar(string nombre, string raza)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            try
            {
                bool existe = false;
                SqlCommand cmd = new SqlCommand($"select 1 from mascotas where nombre='{nombre}' and raza='{raza}'",con);
                con.Open();
                existe = Convert.ToBoolean(cmd.ExecuteScalar());
                return existe;
            }
            catch(Exception)
            {
                con.Close();
                throw;
            }
        }

        public bool ValidarNombreRepetidoEditar(string nombre, string raza, int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            try
            {
                bool existe = false;
                SqlCommand cmd = new SqlCommand($"select 1 from mascotas where nombre='{nombre}' and raza='{raza}' and id_mascota != {id}", con);
                con.Open();
                existe = Convert.ToBoolean(cmd.ExecuteScalar());
                return existe;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
    }
}