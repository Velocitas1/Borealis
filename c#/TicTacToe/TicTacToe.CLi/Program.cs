using System.ComponentModel.Design;

namespace TicTacToe.CLi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Player 1 name: ");
            var hey = "Hello";
            var player1 = new Person();
            player1.Name = Console.ReadLine();
            Console.WriteLine("Your name is " + player1.Name);
            Console.Write("Player 2 name: ");
            var player2 = new Person();
            player2.Name = Console.ReadLine();
            Console.WriteLine("Your friends name is " + player2.Name);
            Console.Write("Please enter " + player1.Name + " age: ");
            while (!int.TryParse(s:Console.ReadLine(), out player1.Age))
            {
                Console.Write("Not a number, write a number: ");
            }
            Console.WriteLine(player1.Name + "'s age is " + player1.Age);
        }
    }
}
