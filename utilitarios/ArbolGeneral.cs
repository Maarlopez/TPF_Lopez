using System;
using System.Collections.Generic;

namespace TrabajoFinal_Cartas
{
	public class ArbolGeneral<T>
	{
	
		private NodoGeneral<T> raiz;

		public ArbolGeneral(T dato)
		{
			this.raiz = new NodoGeneral<T>(dato);
		}

		private ArbolGeneral(NodoGeneral<T> nodo)
		{
			this.raiz = nodo;
		}

		private NodoGeneral<T> getRaiz()
		{
			return raiz;
		}

		public T getDatoRaiz()
		{
			return this.getRaiz().getDato();
		}

		public List<ArbolGeneral<T>> getHijos()
		{
			List<ArbolGeneral<T>> temp = new List<ArbolGeneral<T>>();
			foreach (var element in this.raiz.getHijos()) 
			{
				temp.Add(new ArbolGeneral<T>(element));
			}
			return temp;
		}
		
		public int altura()
		{
			if (this.esHoja()) {
				return 0;
			}
			int h = 0;

			foreach (var hijo in this.getHijos()) {
				h = Math.Max(h, hijo.altura());
				Console.WriteLine(h + 1);
			}
			return h + 1;
		}

		public void agregarHijo(ArbolGeneral<T> hijo)
		{
			this.raiz.getHijos().Add(hijo.getRaiz());
		}

		public void eliminarHijo(ArbolGeneral<T> hijo)
		{
			this.raiz.getHijos().Remove(hijo.getRaiz());
		}

		public bool esVacio()
		{
			return this.raiz == null;
		}

		public bool esHoja()
		{
			return this.raiz != null && this.getHijos().Count == 0;
		}

	}

}
