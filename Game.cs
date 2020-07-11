using System;
using System.Collections.Generic;
using System.Linq;

namespace TPF_Lopez
{

	public class Game
	{
		public static int WIDTH = 12; //Cantidad de cartas
		public static int UPPER = 35;
		public static int LOWER = 25;
		
		private Jugador player1 = new ComputerPlayer();
		private Jugador player2 = new HumanPlayer();
		private List<int> naipesHuman = new List<int>();
		private List<int> naipesComputer = new List<int>();
		private int limite;
		private bool juegaHumano = false;
		
		
		public Game()
		{
			var rnd = new Random();
			limite = rnd.Next(LOWER, UPPER);
			
			naipesHuman = Enumerable.Range(1, WIDTH).OrderBy(x => rnd.Next()).Take(WIDTH / 2).ToList();
			
			for (int i = 1; i <= WIDTH; i++) {
				if (!naipesHuman.Contains(i)) {
					naipesComputer.Add(i);
				}
			}
			player1.incializar(naipesComputer, naipesHuman, limite);
			player2.incializar(naipesHuman, naipesComputer, limite);
			
		}

		private void printScreen()
		{
			Console.WriteLine();
			Console.WriteLine("Limite:" + limite.ToString());
		}
		
		private void turno(Jugador jugador, Jugador oponente, List<int> naipes)
		{
			int carta = jugador.descartarUnaCarta(); // Jugador actual descarta una carta
			naipes.Remove(carta); //Remueve la carta
			limite -= carta; //A limite le resto carta
			Console.Write("\n*******************************"); // AGREGADO
			Console.WriteLine("\nSe jugó la carta:" + carta); // MODIFICADO
			oponente.cartaDelOponente(carta); 
			juegaHumano = !juegaHumano;
		}
		
		
		private void printWinner()
		{
			if (!juegaHumano) {
				Console.WriteLine("\nGano usted"); // MODIFICADO
				//Console.WriteLine("\n¿Desea jugar de nuevo?");
				

			} else {
				Console.WriteLine("\nGano la computadora"); // MODIFICADO
				//Console.WriteLine("\n¿Desea jugar de nuevo?");
			}
			
		}
		
		private bool fin()
		{
			return limite < 0;
		}
		
		public void play()
		{
			while (!this.fin()) {
				this.printScreen();
				this.turno(player2, player1, naipesHuman); // Juega el usuario
				if (!this.fin()) {
					this.printScreen();
					this.turno(player1, player2, naipesComputer); // Juega la IA
				}
			}
			this.printWinner();
			if (this.fin())
			{
				Console.WriteLine("\n¿Desea jugar de nuevo? (si/no)");
                string reinicio = Console.ReadLine();
				if (reinicio == "si")
                {
					Console.Clear();
					Game game = new Game();
					game.play();
					Console.ReadKey();
				}

			}
		}

	}
}
