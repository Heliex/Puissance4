using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.Game_Engine
{
    class Game
    {
        private static int NB_CASE_WIDTH = 7;
        private static int NB_CASE_HEIGHT = 6;
        private Board plateau;
        private bool isYourTurn;
        private bool canPlay;
        private bool isLocalGame=true;
        public event EventHandler<GameOverEvent> gameOverEvent;

        public Game(int width=7, int height=6)
        {
            NB_CASE_WIDTH = width;
            NB_CASE_HEIGHT = height;
        }

        public void init()
        {
            plateau = new Board(NB_CASE_WIDTH, NB_CASE_HEIGHT);
            
            if (isLocalGame)
            {
                isYourTurn = true;
                canPlay = true;
            }
            else
            {
                
            }
        }

        public void newPlay(bool? local=null)
        {
            if (local != null) isLocalGame = (bool)local;
            init();
        }

        public void gameOver()
        {

        }
    }
}
