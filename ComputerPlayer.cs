using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TrabajoFinal_Cartas;

namespace TPF_Lopez
{
	public class ComputerPlayer : Jugador, NodoGeneral, ArbolGeneral, NCarta
	{
		private List<int> cartas = new List<int>();
		private List<int> cartasHumano = new List<int>();
		private int limite;
		private ArbolGeneral<NCarta> Victorias = new ArbolGeneral<NCarta>(new NCarta());
		//Impar es el humano. Par es la IA
		public ComputerPlayer()
		{
		}
		public override void incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			this.limite = limite;
			Console.Write("El límite actual es:", limite); //imprimo en pantalla el límite inicial.

			AgregarNodo(cartasPropias, true);
			AgregarNodo(cartasOponente, false);

			//IMPREMENTAR UN MENÚ, QUE EL USUARIO ELIJA SI ES POR NIVELES O INORDEN


			//jugará primero el humano. Para guía mirar el gráfico del informe

			//Dado un conjunto de jugadas imprimir todos los posibles resultados.
			//Dada una profundidad imprimir las jugadas a dicha profundidad.

			/*int[] dato = new int[2];
			ArbolGeneral<int []> raiz = new ArbolGeneral<int[]>(dato);*/
			
