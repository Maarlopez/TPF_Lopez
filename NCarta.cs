using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrabajoFinal_Cartas
{
    class NCarta
    {
        private int carta;
        private int nuevoLimite;
        private int victorias;
        private bool flag;

        public NCarta() { }
        public NCarta(int carta, bool flag)

        {
            this.carta = carta;
            this.flag = flag;
        }

        public NCarta(int carta, int nuevoLimite, int victorias)

        {
            this.carta = carta;
            this.nuevoLimite = nuevoLimite;
            this.victorias = victorias;
        }

        public int GetCarta()
        {
            get{
                return carta; //No funciona "El nombre get no existe en el contexto actual"
            }
            
        }

    }
}
