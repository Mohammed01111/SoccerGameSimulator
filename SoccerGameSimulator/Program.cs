namespace SoccerGameSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Soccer Game Simulator!");
            Console.WriteLine("Enter name for Team 1:");
            string team1Name = Console.ReadLine();
            Console.WriteLine("Enter name for Team 2:");
            string team2Name = Console.ReadLine();

            SoccerGame game = new SoccerGame(team1Name, team2Name);
            game.StartGame();
        }
    }
}
