
using  PulsacionesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PulsacionesApi.Context
{
    public class PulsacionesContext  : DbContext
    {
        
        public PulsacionesContext (DbContextOptions options) : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
    }
}