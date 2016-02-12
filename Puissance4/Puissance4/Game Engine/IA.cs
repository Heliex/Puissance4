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
            int[] xy = new int[2];
            if(level == 0)
            {
                xy[0] = r.Next(Game.NB_CASE_WIDTH);
                xy[1] = r.Next(Game.NB_CASE_HEIGHT);
                //xy = { r.Next(Game.NB_CASE_WIDTH), r.Next(Game.NB_CASE_HEIGHT) };

                //xy = game.gravity(xy[0], xy[0]);

                xy = game.makeAMove(xy[0], xy[1]);
                while (xy[0] == -1)
                {
                    xy = game.makeAMove(r.Next(Game.NB_CASE_WIDTH), r.Next(Game.NB_CASE_HEIGHT));
                }
                Console.WriteLine("Je rentre dans le niveau facile");
            }
            else if(level == 1)
            {
                // Scoré les cases.
                for(int i = 0; i < Game.NB_CASE_HEIGHT ; i++)
                {
                    for(int j = 0; j < Game.NB_CASE_WIDTH; j++)
                    {
                        // Case du joueur
                   
                        Case c = game.plateau.recupererCase(j, i);
                        if(c.color == false)
                        {
                            Console.WriteLine("Case jouée par le joueur 1; " + " x : " + j + " y : " + i);
                        
                            if(game.plateau.recupererCase(j-1,i) != null && game.plateau.recupererCase(j-1,i).color == null)
                            {
                                game.plateau.recupererCase(j-1, i).poids += 5;
                            }
                            if(game.plateau.recupererCase(j,i-1) != null && game.plateau.recupererCase(j, i-1).color == null)
                            {
                                game.plateau.recupererCase(j, i-1).poids += 5;
                            }
                            if(game.plateau.recupererCase(j+1,i) != null && game.plateau.recupererCase(j + 1, i).color == null)
                            {
                                game.plateau.recupererCase(j + 1, i).poids += 5;
                            }
                        }

                    }
                }

                // Determiner le score max.
                Case determinee = null;
                int poidsMax = 0;
                for(int i = 0; i < Game.NB_CASE_HEIGHT; i++)
                {
                    for(int j = 0; j < Game.NB_CASE_WIDTH; j++)
                    {
                        if(game.plateau.recupererCase(j,i).poids > poidsMax && game.plateau.recupererCase(j,i).isEmpty())
                        {
                            poidsMax = game.plateau.recupererCase(j, i).poids;
                            determinee = game.plateau.recupererCase(j, i);
                            i = 0;
                            j = 0;
                        }
                    }
                }
                if(determinee != null)
                {
                    game.makeAMove(determinee.x,determinee.y);
                    xy[0] = determinee.x;
                    xy[1] = determinee.y;
                }
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
