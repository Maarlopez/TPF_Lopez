using System;

namespace TPF_Lopez
{
	class Juego
	{
		public static void Main(string[] args)
		{
			string reinicio = "si";
			while (reinicio == "si")
			{
				Game game = new Game();
				game.play();
				Console.ReadKey();
				Console.WriteLine("\n¿Desea jugar de nuevo? (si/no)");
				reinicio = Console.ReadLine();
				Console.Clear();
			}
		}
	}
}
