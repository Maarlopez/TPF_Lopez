using System;
using System.Collections.Generic;

namespace TPF_Lopez
{
	public class ComputerPlayer : Jugador
	{
		private List<int> cartas = new List<int>();
		private List<int> cartasHumano = new List<int>();
		private int limite;
		private ArbolGeneral<NCarta> Victorias = new ArbolGeneral<NCarta>(new NCarta());
		//Impar es el humano. Par es la IA
		public ComputerPlayer()
		{
		}
		/** Metodo  que arma el arbol de jugadas */
		private void ArmoArbol(ArbolGeneral<NCarta> raiz, List<NCarta> propias, List<NCarta> oponente, int limite)
		{
			foreach (var elem in oponente)
			{
				NCarta dato = new NCarta { carta = elem.carta, flag = elem.flag }; 
				ArbolGeneral<NCarta> nodo = new ArbolGeneral<NCarta>(dato); //creo un nuevo nodo con un dato dentro
				raiz.agregarHijo(nodo); //agrego nodo como raíz del arbol
				if (limite - dato.carta < 0) //Si el límite menos el valor de la carta jugada es menor a 0
				{
					if (!dato.flag) // 
					{
						dato.victorias++; //
					}
				}
				else
				{
					List<NCarta> copia = new List<NCarta>();
					copia.AddRange(oponente);
					copia.Remove(elem);
					ArmoArbol(nodo, copia, propias, limite - elem.carta);
				}
				raiz.getDatoRaiz().victorias += dato.victorias;

			}

		}

		public override void incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
				
			this.limite = limite;
			Console.Write("*******************************"); // AGREGADO
			Console.Write("\nEl límite actual es:", limite); //MODIFICADO

			ArmoArbol(Victorias, AgregarNodo(cartasPropias, true), AgregarNodo(cartasOponente, false), limite);
			
		}

		private List<NCarta> AgregarNodo(List<int> listaCartas, bool flag)
		{
			List<NCarta> listaNodos = new List<NCarta>();
			foreach (int carta in listaCartas)
			{
				NCarta nodoCarta = new NCarta { carta = carta, flag = flag };
				listaNodos.Add(nodoCarta);
			}
			return listaNodos;
		}

		public override int descartarUnaCarta()
		{
			int max = 0;
			ArbolGeneral<NCarta> ArbolAux = null;

			foreach (ArbolGeneral<NCarta> naipe in Victorias.getHijos())
			{
				if (naipe.getDatoRaiz().getCarta() > max)
				{
					max = naipe.getDatoRaiz().getVictoria();
					ArbolAux = naipe;
				}
			}
			Victorias = ArbolAux;
			return Victorias.getDatoRaiz().getCarta();
		}

		public override void cartaDelOponente(int carta)
		{
			foreach (ArbolGeneral<NCarta> naipe in Victorias.getHijos())
			{
				if (naipe.getDatoRaiz().carta == carta)
				{
					Victorias = naipe;
					break;
				}
			}
		
		}
	}
}
