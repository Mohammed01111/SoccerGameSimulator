using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerGameSimulator
{
    public class Player
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Skill { get; set; }

        public Player(string name, string position, int skill)
        {
            Name = name;
            Position = position;
            Skill = skill;
        }
    }
}
