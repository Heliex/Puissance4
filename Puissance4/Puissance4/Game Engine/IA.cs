﻿using System;
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

            gravity(x, y);
            
        }

        public bool gravity(int x, int y)
        {
            while (game.plateau.isInArray(new Case(x, y + 1)))
            {
                if (!game.plateau.recupererCase(x,y+1).isEmpty())
                    break;
                y++;
            }
            Console.WriteLine("IA - X: " + x + " Y: " + y);
            if (!game.plateau.estPlacable(game.plateau.recupererCase(x, y), game.turn))
            {
                //Console.WriteLine("Jeton non plaçable, nouvel essai de l'IA");
                makeAMove();
            }
            return true;
        }
    }
}
