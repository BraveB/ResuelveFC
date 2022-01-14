using ResuelveFC.Interfaces;
using ResuelveFC.Models;

namespace ResuelveFC.Services
{
    public class ServicePaymentCalculator: IServicePaymentCalculator
    {
        public List<PlayerPaycheckInfo> Payments(PaymentHelper initialData)
        {
            if (initialData == null || initialData.Jugadores == null || initialData.Jugadores.Count() == 0)
                throw new Exception("There are issues with the players field.");

            if (initialData.Tabulator == null || initialData.Tabulator.Count() == 0)
                throw new Exception("There are issues with the tabulator field.");

            var value = 0;
            var players = initialData.Jugadores
                .Select(p => new PlayerPaycheckInfo
                {
                    Nombre = p.Nombre,
                    GolesMinimos = initialData.Tabulator.TryGetValue(p.Nivel, out value) ? value : 1,
                    Goles = p.Goles,
                    Sueldo = p.Sueldo,
                    Bono = p.Bono,
                    Equipo = p.Equipo
                }).ToList();

            var teams = CreateTeams(players);

            var playersPaycheck = players
                .Select(p => new PlayerPaycheckInfo {
                    Nombre = p.Nombre,
                    GolesMinimos = p.GolesMinimos,
                    Goles = p.Goles,
                    Sueldo = p.Sueldo,
                    Bono = p.Bono,
                    Equipo = p.Equipo,
                    SueldoCompleto = (
                    (p.CalculatePersonalPercentage() + 
                        teams.Where(t => t.Name == p.Equipo)
                             .Select(t => t.Percentage).FirstOrDefault())
                        / 2
                        * p.Bono)
                        + p.Sueldo
                }).ToList();

            return (List<PlayerPaycheckInfo>)(playersPaycheck == null ? new List<PlayerPaycheckInfo>() : playersPaycheck);
        }

        public List<Team> CreateTeams(List<PlayerPaycheckInfo> players)
        {
            try
            {
                var teams = players
                        .GroupBy(x => x.Equipo)
                        .Select(t => new Team
                        {
                            Name = t.Key,
                            Percentage = (t.Sum(p => p.Goles) /
                                t.Sum(p => p.GolesMinimos)
                                > 1 ? 1 :
                                t.Sum(p => p.Goles) /
                                t.Sum(p => p.GolesMinimos))
                        }).ToList();

                return (List<Team>)(teams == null ? new List<Team>() : teams);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong creating the teams");
            }

        }
    }
}
