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

            for (int i = 0; i < 11; i++)
            {
                string name = playerNames[i]; // Choose a name from the given list
                string position = positions[i % 4]; // Alternate between positions 
                int skill = rand.Next(50, 101);  // Skill between 50 and 100
                Player player = new Player(name, position, skill);
                Players.Add(player);
            }
        }
    }
}
