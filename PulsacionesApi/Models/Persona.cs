using System.ComponentModel.DataAnnotations;

namespace PulsacionesApi.Models
{
    public class Persona
    {
        [Key]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public double Pulsacion { get; set; }
        public void CalcularPulsaciones() 
        {
            if (Sexo.ToUpper().Equals("F"))
            {
                Pulsacion=(220 - Edad) / 10;
            }
            else
            {
                Pulsacion=(210 - Edad) / 10;
            }
        }

        
    }
}