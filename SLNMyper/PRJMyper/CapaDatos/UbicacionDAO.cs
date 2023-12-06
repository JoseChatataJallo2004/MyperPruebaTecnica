using PRJMyper.Models;
using System.Data;
using System.Data.SqlClient;

namespace PRJMyper.CapaDatos
{
    public class UbicacionDAO
    {
        private readonly string cad_conex;
        public UbicacionDAO(IConfiguration config)
        {
            cad_conex = config.GetConnectionString("JoseChatata");
        }
        public List<Departamento> ObtenerDepartamento() {
            List<Departamento> lista=new List<Departamento>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cad_conex)) {

                    string sql = "select * from Departamento";
                    SqlCommand cmd=new SqlCommand(sql, oconexion);
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader()) { 
                        while (dr.Read())
                        {
                            lista.Add(new Departamento
                            {
                                IdDepartamento = Convert.ToInt32(dr["Id"]),
                                NombreDepartamento = dr["NombreDepartamento"].ToString()
                            }) ;
                        }
                    }
                }
            }
            catch 
            {
                   lista=new List<Departamento>();
            }
            return lista;
        
        }


        public List<Provincia> ObtenerProvincia(int iddepartamento)
        {
            List<Provincia> lista = new List<Provincia>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cad_conex))
                {
                    string sql = "select * from Provincia where  IdDepartamento = @iddepartamento";
                    SqlCommand cmd = new SqlCommand(sql, oconexion);
                    cmd.Parameters.AddWithValue("@iddepartamento", iddepartamento);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Provincia
                            {
                                IdProvincia = Convert.ToInt32(dr["Id"]),
                                NombreProvincia = dr["NombreProvincia"].ToString(),
                            });
                        }
                    }
                }
            }
            catch
            {

                lista = new List<Provincia>();
            }
            return lista;
        }


        public List<Distrito> ObtenerDistrito(int idprovincia)
        {
            List<Distrito> lista = new List<Distrito>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cad_conex))
                {
                    string sql = "select * from Distrito where IdProvincia = @idprovincia ";
                    SqlCommand cmd = new SqlCommand(sql, oconexion);
                    cmd.Parameters.AddWithValue("@idprovincia", idprovincia);
                    cmd.CommandType = System.Data.CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Distrito
                            {
                                IdDistrito = Convert.ToInt32(dr["Id"]), 
                                NombreDistrito = dr["NombreDistrito"].ToString(),
                            });
                        }
                    }
                }
            }
            catch
            {

                lista = new List<Distrito>();
            }
            return lista;
        }


    }
}
