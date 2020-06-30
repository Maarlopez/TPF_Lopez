using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrabajoFinal_Cartas
{
    class NCarta
    {
        private int nuevoLimite;
        
        /** implementacion de las propiedades */
        public int victorias
	    { get; set; }
        
        
        public bool flag
	     { get; set; }
        
        public int carta
	     { get; set; }
	    
     /** fin de las propiedades*/ 
        public NCarta() { }
        public NCarta(int c, bool f)

        {
            this.carta = c;
            this.flag = f;
        }

        public NCarta(int carta, int nuevoLimite, int victorias)

        {
            this.carta = carta;
            this.nuevoLimite = nuevoLimite;
            this.victorias = victorias;
        }


    }
}
