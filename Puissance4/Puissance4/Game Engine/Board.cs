using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.Game_Engine
{
    class Board
    {
        private Case[,] gameboard;

        public Board(int x, int y)
        {
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; y++)
                    gameboard[i, j] = new Case(i, j);
        }

        public void init()
        {

        }

        public bool verifierLigne(Case c)
        {

            return true;
        }

       public Case recupererCase(int x,int y)
       {
           int i=0; int j=0;
           for ( i=0; i < Puissance4.GameWindow ; i++ )
               for ( j=0; j <  ; j++ );

           return gameboard[i,j];
       }
       
        public bool ligneDroite(Case c, bool sens)
        {

            return true;
        }

        public bool ligneDiagonale(Case c, bool sens)
        {

            return true;
        }
            
        public bool estPlacable(Case c)
        {

            return true;
        }
    }
}
