namespace PRJMyper.Models
{
    public class Trabajadores
    {
        public int IdTrabajador { get; set; }
        public Documento odocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public Departamento odepartamento { get; set; }
        public Provincia oprovincia { get; set; }
        public Distrito odistrito { get; set; }

    }
}
