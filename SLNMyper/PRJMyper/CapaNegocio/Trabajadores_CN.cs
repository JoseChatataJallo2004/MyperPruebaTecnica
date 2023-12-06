using PRJMyper.CapaDatos;
using PRJMyper.Models;

namespace PRJMyper.CapaNegocio
{
    public class Trabajadores_CN
    {


        private TrabajadoresDao objtrabajadoresdao;
        
        
        public Trabajadores_CN(IConfiguration config) { 
        
            objtrabajadoresdao=new TrabajadoresDao(config);
        }



        public List<Trabajadores> ListarTrabajadores() { 
            return objtrabajadoresdao.ListarTrabajadores();
        
        }

        public int RegistrarTrabajador(Trabajadores obj, out string mensaje)
        {
            mensaje=string.Empty;
            if (obj.odocumento.IdDocumento == 0)
            {
                mensaje = "Debe Seleccionar un Tipo de Documento";
            }
            else if (string.IsNullOrEmpty(obj.NumeroDocumento) || string.IsNullOrWhiteSpace(obj.NumeroDocumento))
            {
                mensaje = "El Numero de Documento no se puede ser Vacio";

            }
            else if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                mensaje = "Los Nombres no se puede ser Vacio";

            }
            else if (string.IsNullOrEmpty(obj.Sexo)) {
                mensaje = "Escoge un Genero";
            }

            else if (obj.odepartamento.IdDepartamento == 0)
            {
                mensaje = "Debe Seleccionar un Departamento";
            }
            else if (obj.oprovincia.IdProvincia == 0)
            {
                mensaje = "Debe Seleccionar un Provincia";
            }
            else if (obj.odistrito.IdDistrito == 0)
            {
                mensaje = "Debe Seleccionar un Distrito";
            }


            if (string.IsNullOrEmpty(mensaje))
            {
                return objtrabajadoresdao.RegistrarTrabajador(obj, out mensaje);
            }
            else {
                return 0;
            }

        }

        public bool ActualizarTrabajador(Trabajadores obj, out string mensaje) {
            mensaje = string.Empty;
            if (obj.odocumento.IdDocumento == 0)
            {
                mensaje = "Debe Seleccionar un Tipo de Documento";
            }
            else if (string.IsNullOrEmpty(obj.NumeroDocumento) || string.IsNullOrWhiteSpace(obj.NumeroDocumento))
            {
                mensaje = "El Numero de Documento no se puede ser Vacio";

            }
            else if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                mensaje = "Los Nombres no se puede ser Vacio";

            }
            else if (string.IsNullOrEmpty(obj.Sexo))
            {
                mensaje = "Escoge un Genero";
            }

            else if (obj.odepartamento.IdDepartamento == 0)
            {
                mensaje = "Debe Seleccionar un Departamento";
            }
            else if (obj.oprovincia.IdProvincia == 0)
            {
                mensaje = "Debe Seleccionar un Provincia";
            }
            else if (obj.odistrito.IdDistrito == 0)
            {
                mensaje = "Debe Seleccionar un Distrito";
            }


            if (string.IsNullOrEmpty(mensaje))
            {
                return objtrabajadoresdao.ActualizarTrabajador(obj, out mensaje);
            }
            else
            {
                return false;
            }


        }

            public bool EliminarTrabajador(int id)
        {
            return objtrabajadoresdao.EliminarTrabajador(id);
        }
    }
}
