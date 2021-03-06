namespace ResuelveFC.Models
{
    public class Player
    {
        public string? Nombre { get; set; }
        public string? Nivel { get; set; } = "A";
        public decimal Goles { get; set; }
        public decimal Sueldo { get; set; }
        public decimal Bono { get; set; }
        public decimal SueldoCompleto { get; set; }
        public string? Equipo { get; set; }
    }
}
