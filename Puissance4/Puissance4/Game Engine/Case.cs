using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.Game_Engine
{
    class Case
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool? color { get; set; }

        public Case(int x, int y)
        {
            this.x = x;
            this.y = y;
            color = null;
        }

        public bool isEmpty()
        {
            if (color != null)
                return false;
            return true;
        }

        public bool placePiece(bool color)
        {
            if (this.color == null) this.color = color; //Si la case est vide, on met un pion
            else return false;                          //Sinon, elle est déjà occupée
            if (this.color == null) return false;       //Si après avoir placé notre pion, la case est toujours vide, il y a une erreur
            
            return true;                                //Sinon le coup s'est bien passé
        }

        public bool isSameColor(Case c)
        {
            if (color == c.color) return true;
            return false;
        }
    }
}
