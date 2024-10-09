using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerGameSimulator
{
    public class SoccerGame
    {
        private Team team1;
        private Team team2;
        private Random rand;

        public SoccerGame(string team1Name, string team2Name)
        {
            team1 = new Team(team1Name);
            team2 = new Team(team2Name);
            rand = new Random();
        }
        private void SimulateTurn(Team attackingTeam, Team defendingTeam, int turn)
        {
            Console.WriteLine($"\nTurn {turn}: {attackingTeam.Name} are attacking...");

            // Calculate the skill sum for attacking team (Forward + Midfielder)
            int attackSkill = attackingTeam.GetSkillSum("Forward") + attackingTeam.GetSkillSum("Midfielder");

            // Calculate the skill sum for defending team (Defender + Goalkeeper)
            int defenseSkill = defendingTeam.GetSkillSum("Defender") + defendingTeam.GetSkillSum("Goalkeeper");


            int threshold = 3;

            // Check if the attacking team successfully scores a goal
            if (attackSkill > (defenseSkill + threshold))
            {
                attackingTeam.Score++;
                Console.WriteLine($"{attackingTeam.Name} scores!");
            }
            else
            {
                Console.WriteLine($"{defendingTeam.Name} defends successfully!");
            }

            // Print the current score after each turn
            Console.WriteLine($"Current Score: {attackingTeam.Name}: {attackingTeam.Score} | {defendingTeam.Name}: {defendingTeam.Score}");


        }
        private void CoinToss()
        {
            if (rand.Next(2) == 0)
            {
                Console.WriteLine($"{team1.Name} will start the game.");
            }
            else
            {
                Console.WriteLine($"{team2.Name} will start the game.");
            }
        }

        public void StartGame()
        {
            // Define unique player names for each team
            List<string> team1Names = new List<string> { "Mohammed", "Ali", "Said", "Saleh", "Ibrahim", "Zubair", "Rashid", "Mahmood", "Moath", "Abdullah", "Monther" };
            List<string> team2Names = new List<string> { "Yasir", "Noah", "Ahmed", "Hamed", "Azhar", "Hussam", "Faried", "Bassam", "Sami", "Asaad", "nasser" };
            List<string> positions = new List<string> { "Forward", "Midfielder", "Defender", "Goalkeeper" };

            // Generate players for both teams
            team1.GeneratePlayers(team1Names, positions);
            team2.GeneratePlayers(team2Names, positions);

            // Display players and  skill levels
            Console.WriteLine("\nGenerating players for both teams...");
            team1.DisplayPlayers();
            Console.WriteLine();
            team2.DisplayPlayers();
            Console.WriteLine();

            //To decide which team attacks first
            CoinToss();

            // First half - 5 turns
            Console.WriteLine("\n--- First Half ---");
            for (int turn = 1; turn <= 5; turn++)
            {
                if (turn % 2 != 0)
                {
                    
                    SimulateTurn(team1, team2, turn);
                }
                else
                {
                    
                    SimulateTurn(team2, team1, turn);
                }
            }

            
            Console.WriteLine("\n--- Second Half ---");
            for (int turn = 6; turn <= 10; turn++)
            {
                if (turn % 2 != 0)
                {
                    
                    SimulateTurn(team1, team2, turn);
                }
                else
                {
                    
                    SimulateTurn(team2, team1, turn);
                }
            }

            // Final score and result
            Console.WriteLine($"\nFinal Score: {team1.Name}: {team1.Score} | {team2.Name}: {team2.Score}");

            if (team1.Score > team2.Score)
            {
                Console.WriteLine($"{team1.Name} wins!");
            }
            else if (team2.Score > team1.Score)
            {
                Console.WriteLine($"{team2.Name} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }

        }
    }
}
