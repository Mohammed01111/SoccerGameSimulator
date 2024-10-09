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
    }
}
