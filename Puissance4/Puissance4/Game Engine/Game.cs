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
        private bool isLocalGame;
        public event EventHandler<GameOverEvent> gameOverEvent;

        public Game(int width=7, int height=6)
        {
            
        }

        public void init()
        {

        }

        public void newPlay()
        {

        }

        public void gameOver()
        {

        }
    }
}
