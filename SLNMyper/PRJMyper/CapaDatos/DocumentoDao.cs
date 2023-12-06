using System.Data.SqlClient;
using System.Data;
using PRJMyper.Models;

namespace PRJMyper.CapaDatos
{
    public class DocumentoDao
    {
        private readonly string cad_conex;
        public DocumentoDao(IConfiguration config)
        {
            cad_conex = config.GetConnectionString("JoseChatata");
        }



        public List<Documento> ListarDocumento()
        {
            List<Documento> lista = new List<Documento>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cad_conex))
                {
                    string query = "select * from Documento";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Documento()
                            {
                                IdDocumento = Convert.ToInt32(dr["iddocumento"]),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Documento>();
            }
            return lista;
        }

    }
}
