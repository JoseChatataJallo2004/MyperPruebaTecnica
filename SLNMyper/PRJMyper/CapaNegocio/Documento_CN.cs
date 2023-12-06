using PRJMyper.CapaDatos;
using PRJMyper.Models;

namespace PRJMyper.CapaNegocio
{
    public class Documento_CN
    {
        private DocumentoDao objdocumentodao;


        public Documento_CN(IConfiguration config)
        {

            objdocumentodao = new DocumentoDao(config);
        }

        public List<Documento> ListarDocumento() { 
            return objdocumentodao.ListarDocumento();
        }
    }
}
