using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.Game_Engine
{
    class IA
    {
        private Game game;
        private int level;

        public IA(Game game, int level)
        {
            this.game = game;
            this.level = level;
        }

        public void makeAMove()
        {
 
            Random r = new Random();
            int x = r.Next(Game.NB_CASE_WIDTH);
            int y = r.Next(Game.NB_CASE_HEIGHT);
            Case c = game.plateau.recupererCase(x, y);
            if(!game.plateau.estPlacable(c, game.turn))
            {
                Console.WriteLine("Jeton non plaçable, nouvel essai de l'IA");
                makeAMove();
            }
        }
    }
}
