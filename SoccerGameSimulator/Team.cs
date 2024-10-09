using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerGameSimulator
{
    public class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; private set; }
        public int Score { get; set; }

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
            Score = 0;
        }

        public void GeneratePlayers(List<string> playerNames, List<string> positions)
        {
            Random rand = new Random();

            // Shuffle the positions randomly
            List<string> shuffledPositions = positions.OrderBy(x => rand.Next()).ToList();

            for (int i = 0; i < 11; i++)
            {
                string name = playerNames[i]; // Choose a name from the given list
                string position = shuffledPositions[i % shuffledPositions.Count]; // Randomly pick a position
                int skill = rand.Next(50, 101);  // Skill between 50 and 100

                Player player = new Player(name, position, skill);
                Players.Add(player);
            }
        }

        public int GetSkillSum(string position)
        {
            int sum = 0;
            foreach (var player in Players)
            {
                if (player.Position == position)
                {
                    sum += player.Skill;
                }
            }
            return sum;
        }

        // Display players and skills for the team
        public void DisplayPlayers()
        {
            Console.WriteLine($"{Name}:");
            for (int i = 0; i < Players.Count; i++)
            {
                Player player = Players[i];
                Console.WriteLine($"{i + 1}. {player.Name} - {player.Position} (Skill: {player.Skill})");
            }
        }
    }
}