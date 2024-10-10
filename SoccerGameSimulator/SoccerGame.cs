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

            // Increase the threshold for scoring. Adjust the value as needed.
            int threshold = 15;  // Increase the threshold for scoring

            // Print debug information for better understanding
            Console.WriteLine($"Attack skill: {attackSkill}, Defense skill: {defenseSkill}");

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
            Console.WriteLine($"Current Score: {team1.Name}: {team1.Score} | {team2.Name}: {team2.Score}");
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
        private void PenaltyShootout()
        {
            Console.WriteLine("\n--- Penalty Shootout ---");
            int team1Penalties = 3;
            int team2Penalties = 3;

            int team1Score = 0;
            int team2Score = 0;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nPenalty {i + 1}: {team1.Name} is shooting...");
                if (TakePenaltyShot(team1))
                {
                    team1Score++;
                    Console.WriteLine($"{team1.Name} scores!");
                }
                else
                {
                    Console.WriteLine($"{team1.Name} misses!");
                }

                Console.WriteLine($"\nPenalty {i + 1}: {team2.Name} is shooting...");
                if (TakePenaltyShot(team2))
                {
                    team2Score++;
                    Console.WriteLine($"{team2.Name} scores!");
                }
                else
                {
                    Console.WriteLine($"{team2.Name} misses!");
                }
            }

            // Display final penalty shootout result
            Console.WriteLine($"\nPenalty Shootout Result: {team1.Name}: {team1Score} | {team2.Name}: {team2Score}");

            // Declare the winner based on penalty shootout scores
            if (team1Score > team2Score)
            {
                Console.WriteLine($"{team1.Name} wins the penalty shootout!");
            }
            else if (team2Score > team1Score)
            {
                Console.WriteLine($"{team2.Name} wins the penalty shootout!");
            }
            else
            {
                Console.WriteLine("It's still a draw after penalties!");
            }
        }
        private bool TakePenaltyShot(Team team)
        {

            Player shooter = team.Players[rand.Next(team.Players.Count)];
            int shooterSkill = shooter.Skill;

            // Find the goalkeeper from the opposing team
            Player goalkeeper = team == team1
                ? team2.Players.FirstOrDefault(p => p.Position == "Goalkeeper")
                : team1.Players.FirstOrDefault(p => p.Position == "Goalkeeper");


            int goalkeeperSkill = goalkeeper.Skill;  // The skill of the goalkeeper
            int chanceOfScoring = 50 + (shooterSkill - goalkeeperSkill);


            return rand.Next(100) < chanceOfScoring;
        }


        public void StartGame()
        {
            // Define unique player names for each team
            List<string> team1Names = new List<string> { "Mohammed", "Ali", "Said", "Saleh", "Ibrahim", "Zubair", "Rashid", "Mahmood", "Moath", "Abdullah", "Monther" };
            List<string> team2Names = new List<string> { "Yasir", "Noah", "Ahmed", "Hamed", "Azhar", "Hussam", "Faried", "Bassam", "Sami", "Asaad", "Nasser" };
            List<string> positions = new List<string> { "Forward", "Midfielder", "Defender", "Goalkeeper" };

            // Generate players for both teams
            team1.GeneratePlayers(team1Names, positions);
            team2.GeneratePlayers(team2Names, positions);

            // Display players and their skill levels
            Console.WriteLine("\nGenerating players for both teams...");
            team1.DisplayPlayers();
            Console.WriteLine();
            team2.DisplayPlayers();
            Console.WriteLine();

            // To decide which team attacks first
            CoinToss();

            // First half - 5 turns
            Console.WriteLine("\n--- First Half ---");
            for (int turn = 1; turn <= 5; turn++)
            {
                if (turn % 2 != 0)
                {
                    // Team 1 attacks, Team 2 defends
                    SimulateTurn(team1, team2, turn);
                }
                else
                {
                    // Team 2 attacks, Team 1 defends
                    SimulateTurn(team2, team1, turn);
                }
            }

            // Second half - 5 turns
            Console.WriteLine("\n--- Second Half ---");
            for (int turn = 6; turn <= 10; turn++)
            {
                if (turn % 2 != 0)
                {
                    // Team 1 attacks, Team 2 defends
                    SimulateTurn(team1, team2, turn);
                }
                else
                {
                    // Team 2 attacks, Team 1 defends
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


                Console.WriteLine("Do you want to proceed to penalty shootouts? (yes/no): ");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    PenaltyShootout();
                }
                else
                {
                    Console.WriteLine("Game over! It's a draw ");
                }
            }
        }
    }
}