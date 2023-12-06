using PRJMyper.CapaDatos;
using PRJMyper.Models;

namespace PRJMyper.CapaNegocio
{
    public class Ubicacion_CN
    {
        private UbicacionDAO objubicaciondao;


        public Ubicacion_CN(IConfiguration config)
        {

            objubicaciondao = new UbicacionDAO(config);
        }
        public List<Departamento> ObtenerDepartamento()
        {
            return objubicaciondao.ObtenerDepartamento();
        }

        public List<Provincia> ObtenerProvincia(int iddepartamento)
        {
            return objubicaciondao.ObtenerProvincia(iddepartamento);
        }
        public List<Distrito> ObtenerDistrito(int idprovincia)
        {
            return objubicaciondao.ObtenerDistrito(idprovincia);
        }

    }
}
