using System.ComponentModel.DataAnnotations;

namespace PulsacionesApi.Models
{
    public class Persona
    {

        [Key]
        [Required(ErrorMessage = "La identificacion es requerida")]
        [MinLength(8,ErrorMessage="la identificacion debe tener minimo 8 caracteres")]
        [StringLength(10,ErrorMessage="la identificacion debe tener maximo de 10")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "La el nombre es requerido")]
        [MinLength(3,ErrorMessage="el nombre debe tener minimo 3 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Edad es requerida")]
        public int Edad { get; set; }

         [Required(ErrorMessage = "La Sexo es requerido")]
      
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