using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace Main {
					
	public class Program {
		public static void Main() {
		    // Lista de jogadores preenchida
			var players = new List <Player> {
                new Player { Name = "P1", Team = "A", Goals = 1 },
                new Player { Name = "P2", Team = "A", Goals = 7 },
                new Player { Name = "P3", Team = "B", Goals = 6 },
                new Player { Name = "P4", Team = "B", Goals = 4 },
                new Player { Name = "P5", Team = "C", Goals = 9 },
                new Player { Name = "P6", Team = "C", Goals = 2 },
            };
        
            // Agrupa jogadores pelo time e seleciona maior saldo de gols
            var teamBestScores =
                (
                    from player in players
                    group player by player.Team into playerGroup
                    select new
                    {
                        // Nome do time
                        TeamName = playerGroup.Key,
                        // Pega maior saldo de gols do time
                        BestScore = playerGroup.Max(x => x.Goals),
                    }
                ).ToList();
            
            // Imprime jogadores com os melhores saldos de gols dos times
            foreach(var team in teamBestScores) {
                WriteLine("Jogador com maior saldo de gols do time {0}: {1}", team.TeamName, team.BestScore);
                WriteLine();
		    }
		}
	}

    // Jogador
	public class Player {
		public string Name;
		public string Team;
		public int Goals;
	}
}