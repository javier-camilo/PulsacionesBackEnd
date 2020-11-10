namespace PulsacionesApi.Models
{
    public class Persona
    {

        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public double Pulsacion { get; set; }
        public void CalcularPulsaciones() 
        {
            if (Sexo.Equals("F") || Sexo.Equals("f"))
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