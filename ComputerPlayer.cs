using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TrabajoFinal_Cartas;
using juegoIA;

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
		private void ArmoArbol(ArbolGeneral<NCarta> raiz, List<NCarta> propias, List<NCarta> oponente, int limite){
			foreach (var elem in oponente) {
				NCarta dato = new NCarta{carta = elem.carta, flag = elem.flag };   
				ArbolGeneral<NCarta> nodo = new ArbolGeneral<NCarta>(dato);
				raiz.agregarHijo(nodo);
				if (limite-dato.carta < 0) {
					if (!dato.flag) {
						dato.victorias++;
					}
				} else {
					List<NCarta> copia = new List<NCarta>();
					copia.AddRange(oponente);
					copia.Remove(elem);
					ArmoArbol(nodo, copia, propias, limite-elem.carta);
				}
				raiz.getDatoRaiz().victorias+=dato.victorias;
			
			}
			
		}
		
		public override void incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			this.limite = limite;
			Console.Write("El límite actual es:", limite); //imprimo en pantalla el límite inicial.

			//AgregarNodo(cartasPropias, true);
			//AgregarNodo(cartasOponente, false);

			//IMPREMENTAR UN MENÚ, QUE EL USUARIO ELIJA SI ES POR NIVELES O INORDEN


			//jugará primero el humano. Para guía mirar el gráfico del informe

			//Dado un conjunto de jugadas imprimir todos los posibles resultados.
			//Dada una profundidad imprimir las jugadas a dicha profundidad.

			/*int[] dato = new int[2];
			ArbolGeneral<int []> raiz = new ArbolGeneral<int[]>(dato);*/
			

			ArmoArbol(Victorias, AgregarNodo(cartasPropias, true), AgregarNodo(cartasOponente, false), limite);
			}
		
			private List<NCarta> AgregarNodo(List<int> listaCartas, bool flag)
            {
				List<NCarta> listaNodos = new List<NCarta>();
				foreach(int carta in listaCartas)
                {
					NCarta nodoCarta = new NCarta{carta = carta, flag = flag }; 
					listaNodos.Add(nodoCarta);
                }
				return listaNodos;
            }
/*
			int op;
			do
			{ // Implemento un Do While para que el menú se ejecute al menos una vez  
				Console.Clear();
				Console.WriteLine("¿Desea utilizar un algoritmo por niveles o inorden?\n"); // Muestro el menú  

				Console.WriteLine("1) Por niveles");
				Console.WriteLine("2) Inorden");
				Console.WriteLine("3) Salir");

				op = int.Parse(Console.ReadLine()); // Parseo el dato ingresado por el usuario para pasarlo de string a entero 

				switch (op)
				{ // Inicializo el menu con un switch 

					case 1:
						PorNiveles(); //llamo al método de esta misma clase
						break;
					case 2:
						Inorden();
						break;
					case 3:
						break;
					default:
						Console.WriteLine("Opcion incorrecta"); // Agrego una opción más en caso de que se ingrese un numero fuera de rango 
						break;
				}

			} while (op != 3);
		}*/
		
		

        /****************Inincio del comentario ********************/
		/** Para que el juego funcione correctamente lo unico que falta implementar es este metodo
		 * Una vez implementado unicamente el metodo descartarUnaCarta() se deberia 
		 *  poder jugar una partida sin problemas y estaria terminada la parte de implementacion
		 *  del TP Final.
		 */
		
        public override int descartarUnaCarta()
		{
        	return 0;
		}
		
		/**************** Fin del comentario ********************/
		
		public override void cartaDelOponente(int carta)
		{
			foreach(ArbolGeneral<NCarta> naipe in Victorias.getHijos())
           		{
				if(naipe.getDatoRaiz().carta == carta)
                		{
					Victorias = naipe;
					break;
                		}
            		}
		}
/*
		public void PorNiveles()
		{
			Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();
			cola.encolar(this);

			while (!cola.esVacia())
			{
				ArbolGeneral<T> subarbol = cola.desencolar;
				Console.Write(subarbol.getDatoRaiz() + " desencolado.");
				if (subarbol.getHijos() != null)
				{
					foreach (var hijo in subarbol.getHijos())
					{
						cola.ensolar(hijo);
					}
				}
			}
		}

		public void Inorden() { }
*/
	

	}
}
