namespace ResuelveFC.Models
{
    public class PaymentHelper
    {
        private static readonly Dictionary<string, int> DefaultTabulator = new Dictionary<string, int> {
            { "A", 5 },
            { "B", 10 },
            { "C", 15 },
            { "Cuauh", 20 }
        };

        public List<Player>? Jugadores { get; set; }
        public Dictionary<string, int> Tabulator { get; set; } = DefaultTabulator;
    }
}
