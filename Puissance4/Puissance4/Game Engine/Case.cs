using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.Game_Engine
{
    class Case
    {
        private int x { get; set; }
        private int y { get; set; }
        private bool? color;

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
    }
}
