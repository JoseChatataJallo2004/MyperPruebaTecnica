using Microsoft.AspNetCore.Mvc;
using PRJMyper.CapaNegocio;
using PRJMyper.Models;

namespace PRJMyper.Controllers
{
    public class MyperController : Controller
    {
        private readonly Trabajadores_CN trabajorescn;
        private readonly Ubicacion_CN ubicacioncn;
        private readonly Documento_CN documentocn;
        public MyperController(Trabajadores_CN _cnTrabajadores, Ubicacion_CN _ubicacioncn, Documento_CN _documentocn)
        {
            trabajorescn = _cnTrabajadores;
            ubicacioncn = _ubicacioncn;
            documentocn = _documentocn;
        }



        public IActionResult Trabajadores()
        {
            return View();
        }


        [HttpGet]
        public JsonResult ListarTrabajadores()
        {
            List<Trabajadores> olista = trabajorescn.ListarTrabajadores();
            return Json(new { data = olista });
        }




        [HttpPost]
        public JsonResult RegistrarTrabajador([FromBody] Trabajadores obj)
        {
            object? resultado=null;
            string mensaje = string.Empty;


            if (obj.IdTrabajador == 0)
            {
                resultado = trabajorescn.RegistrarTrabajador(obj, out mensaje);
            }
            else {
                resultado = trabajorescn.ActualizarTrabajador(obj, out mensaje);
            }
                 
                return Json(new { resultado = resultado, mensaje = mensaje });
            
            
        }


        [HttpPost]
        public JsonResult EliminarTrabajador(int id)
        {
            try
            {
                bool respuesta = trabajorescn.EliminarTrabajador(id);
                return Json(new { resultado = respuesta });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }

        }


        #region Tipo de Documento
        [HttpGet]
        public JsonResult ListarDocumento()
        {
            List<Documento> olista = documentocn.ListarDocumento();
            return Json(new { data = olista });
        }
        #endregion


        #region Ubicaciones

        [HttpPost]
        public JsonResult ObtenerDepartamento()
        {
            List<Departamento> olista = ubicacioncn.ObtenerDepartamento();
            return Json(new { data = olista });
        }
        [HttpPost]
        public JsonResult ObtenerProvincias(int iddepartamento)
        {
            List<Provincia> olista = ubicacioncn.ObtenerProvincia(iddepartamento);
            return Json(new { data = olista }); 
        }
        [HttpPost]
        public JsonResult ObtenerDistritos(int idprovincia)
        {
            List<Distrito> olista= ubicacioncn.ObtenerDistrito(idprovincia);
            return Json(new { data = olista });
        }


        #endregion


    }
}
