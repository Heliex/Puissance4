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
            if (color == null)
                return false;
            return true;
        }

        public bool placePiece(bool color)
        {
            this.color = color;
            if (this.color == null) return false;
            
            return true;
        }

        public bool isSameColor(Case c)
        {
            if (c.color == null || this.color != c.color) return false;
            return true;
        }
    }
}
