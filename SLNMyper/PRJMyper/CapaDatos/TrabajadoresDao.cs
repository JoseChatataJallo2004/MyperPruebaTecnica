using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using PRJMyper.Models;
using System.Data.SqlClient;

namespace PRJMyper.CapaDatos
{
    public class TrabajadoresDao
    {
        private readonly string cad_conex;
        public TrabajadoresDao(IConfiguration config)
        {
            cad_conex = config.GetConnectionString("JoseChatata");
        }

        public List<Trabajadores> ListarTrabajadores()
        {
            List<Trabajadores> lista = new List<Trabajadores>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cad_conex))
                {
                    //me ayuda en el salto de linea 
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("select t.Id,d.iddocumento , d.TipoDocumento[tipo] ,t.NumeroDocumento,t.Nombres,t.Sexo ,de.Id[iddepartamento],de.NombreDepartamento ,");
                    sb.AppendLine(" pro.Id[idprovincia],pro.NombreProvincia ,dis.Id[iddistrito], dis.NombreDistrito from Trabajadores as t inner join Documento as d on t.TipoDocumento =d.iddocumento ");
                    sb.AppendLine(" inner join Departamento as de on t.IdDepartamento=de.Id inner join Provincia as pro on t.IdProvincia=pro.Id  ");
                    sb.AppendLine("  inner join Distrito as dis on t.IdDistrito=dis.Id");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Trabajadores()
                            {
                                IdTrabajador = Convert.ToInt32(dr["Id"]),
                                odocumento=new Documento() { IdDocumento = Convert.ToInt32(dr["iddocumento"]), TipoDocumento = dr["tipo"].ToString() },
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Sexo = dr["Sexo"].ToString(),
                                odepartamento =new Departamento() { IdDepartamento = Convert.ToInt32(dr["iddepartamento"]), NombreDepartamento = dr["NombreDepartamento"].ToString() },
                                oprovincia=new Provincia() { IdProvincia = Convert.ToInt32(dr["idprovincia"]), NombreProvincia = dr["NombreProvincia"].ToString() },
                                odistrito=new Distrito() { IdDistrito = Convert.ToInt32(dr["iddistrito"]), NombreDistrito = dr["NombreDistrito"].ToString() },          
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Trabajadores>();
            }
            return lista;
        }


        public int RegistrarTrabajador(Trabajadores obj, out string mensaje) {
            int idautogenerado = 0;
            mensaje=String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cad_conex)) {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarTrabajador", oconexion);
                    cmd.Parameters.AddWithValue("@TipoDocumento", obj.odocumento.IdDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("@Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                    cmd.Parameters.AddWithValue("@IdDepartamento", obj.odepartamento.IdDepartamento);
                    cmd.Parameters.AddWithValue("@IdProvincia", obj.oprovincia.IdProvincia);
                    cmd.Parameters.AddWithValue("@IdDistrito", obj.odistrito.IdDistrito);
                    cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType= CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idautogenerado = Convert.ToInt32(cmd.Parameters["@resultado"].Value);
                    mensaje = cmd.Parameters["@mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                mensaje = ex.Message;
            }

            return idautogenerado;
        
        }


        public bool ActualizarTrabajador(Trabajadores obj, out string mensaje)
        {
            bool resultado=false;
            mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cad_conex))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarTrabajador", oconexion);
                    cmd.Parameters.AddWithValue("@Id", obj.IdTrabajador);
                    cmd.Parameters.AddWithValue("@TipoDocumento", obj.odocumento.IdDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("@Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                    cmd.Parameters.AddWithValue("@IdDepartamento", obj.odepartamento.IdDepartamento);
                    cmd.Parameters.AddWithValue("@IdProvincia", obj.oprovincia.IdProvincia);
                    cmd.Parameters.AddWithValue("@IdDistrito", obj.odistrito.IdDistrito);
                    cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToBoolean(cmd.Parameters["@resultado"].Value);
                    mensaje = cmd.Parameters["@mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }

            return resultado;

        }


        public bool EliminarTrabajador(int id)
        {
            bool respuesta = true;
            using (SqlConnection oconexion = new SqlConnection(cad_conex))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Trabajadores WHERE Id = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;

        }


    }
}
