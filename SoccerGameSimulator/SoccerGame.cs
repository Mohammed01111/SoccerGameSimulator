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

    }
}
