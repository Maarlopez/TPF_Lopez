
using System;
using System.Collections.Generic;
using System.Linq;

namespace juegoIA
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
			//Implementar
			return 0;
		}
		
		public override void cartaDelOponente(int carta)
		{
			//implementar
			
		}
		
	}
}
