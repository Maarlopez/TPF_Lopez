using System;
using System.Collections.Generic;
using System.Linq;

namespace TPF_Lopez
{
	public class ComputerPlayer: Jugador
	{
		
		public ComputerPlayer()
		{
		}
		
		public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			List<int> IA = cartasPropias;
			List<int> humano = cartasOponente;

			//jugará primero el humano. Para guía mirar el gráfico del informe

			foreach(var carta in humano)
			{
				ArbolGeneral<int> nodo = new ArbolGeneral<int>(carta);
				//crear arbol de victorias de la IA
			}

		}
		
		
		public override int descartarUnaCarta()
		{
			List<int> monticulo = 0;
			// si usuario descarto una carta, el valor de esa carta se suma al monticulo, lo mismo para la IA. 
			// Quito del camino a usar esa carta en ese momento, ver diagrama

			if (monticulo > limite)
				//Si el límite lo superó la IA
				//¿A quién? .printWinner();
			return 0;
		}
		
		public override void cartaDelOponente(int carta)
		{
			//implementar
			
		}
		
	}
}
