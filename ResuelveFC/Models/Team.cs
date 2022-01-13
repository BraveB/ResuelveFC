namespace ResuelveFC.Models
{
    public class Team
    {
        private static readonly Dictionary<string, int> DefaultTabulator = new Dictionary<string, int> {
            { "A", 5 },
            { "B", 10 },
            { "C", 15 },
            { "Cuauh", 20 }
        };

        public string? Name { get; set; }
        public int GoalsRequired { get; set; }
        public int GoalsScored { get; set; }
        public long Percentage { get; set; }
        public Dictionary<string, int> Tabulator { get; set; } = DefaultTabulator;
    }
}
