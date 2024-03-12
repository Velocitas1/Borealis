namespace RockPaperScissors.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Player 1, Enter your name: ");
            var player1 = new Person();
            player1.Name = Console.ReadLine();
            Console.WriteLine("Why hello there " + player1.Name);
            Console.Write("Please enter Player's age: ");
            while (!int.TryParse(Console.ReadLine(), out player1.Age))
            {
                Console.Write("You goof, that's not a number. Enter age: ");
            }
        }
    }
}
