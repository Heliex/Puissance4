using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.Game_Engine
{
    public class IA
    {
        private Game game;
        private int level;

        public IA(Game game, int level)
        {
            this.game = game;
            this.level = level;
        }

        public int[] makeAMove()
        {
            Random r = new Random();
            int[] xy = { r.Next(Game.NB_CASE_WIDTH), r.Next(Game.NB_CASE_HEIGHT)};

            //xy = game.gravity(xy[0], xy[0]);
            
            xy = game.makeAMove(xy[0], xy[1]);
            while (xy[0] == -1)
            {
                xy = game.makeAMove(r.Next(Game.NB_CASE_WIDTH), r.Next(Game.NB_CASE_HEIGHT));
            }

            return xy;
        }

        public int[] gravity(int x, int y)
        {
            while (game.plateau.isInArray(new Case(x, y + 1)))
            {
                if (!game.plateau.recupererCase(x,y+1).isEmpty())
                    break;
                y++;
            }
            //Console.WriteLine("IA - X: " + x + " Y: " + y);
            if (game.plateau.estPlacable(game.plateau.recupererCase(x, y), game.turn)[0] == -1)
            {
                //Console.WriteLine("Jeton non plaçable, nouvel essai de l'IA");
                makeAMove();
            }

            return new int[] { x, y };
        }
    }
}
