namespace ResuelveFC.Models
{
    public class PlayerPaycheckInfo
    {
        public string? Nombre { get; set; }
        public decimal GolesMinimos { get; set; }
        public decimal Goles { get; set; }
        public decimal Sueldo { get; set; }
        public decimal Bono { get; set; }
        public decimal SueldoCompleto { get; set; }
        public string? Equipo { get; set; }

        public decimal CalculatePersonalPercentage()
        {
            return (Goles / GolesMinimos) > 1 ? 1 : (Goles / GolesMinimos);
        }
    }
}
