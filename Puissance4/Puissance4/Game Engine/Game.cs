using System;

namespace Puissance4.Game_Engine
{
    public class Game
    {
        public static int NB_CASE_WIDTH = 7;
        public static int NB_CASE_HEIGHT = 6;
        private IA IA;
        public Board plateau
        {
            get; set;
        }
        private bool isYourTurn;
        private bool canPlay;
        private bool isLocalGame=true;
        public event EventHandler<GameOverEvent> gameOverEvent;
        public event EventHandler<RefreshEvent> refreshEvent;
        public int turn { get; set; }

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
                IA = new IA(this, 0);
            }
            else
            {
                Random r = new Random(100);
                if (r.Next() % 2 > 0)
                    canPlay = false;
                else canPlay = true;
            }
        }

        public bool makeAMove(int x, int y)
        {
            gravity(x, y);
            if (!plateau.estPlacable(plateau.recupererCase(x, y), turn%2))
                return false;

            turn++;
            if (checkLine(x, y))
                onRaiseGameOverEvent(new GameOverEvent());
            IA.makeAMove();
            turn++;
            if (checkLine(x, y))
                onRaiseGameOverEvent(new GameOverEvent());

            //isYourTurn = false;
            //canPlay = false;
            return true;
        }

        public bool gravity(int x,int y)
        {
            while (plateau.isInArray(new Case(x, y + 1)))
            {
                Console.WriteLine("P1 - X: " + x + " Y: " + y);
                if (!plateau.estPlacable(plateau.recupererCase(x,y+1),turn%2))
                    return false;
                //return false;
                plateau.viderCase(x, y);
                y++;
                //return true;
            }
            return true;
        }
 
        public bool checkLine(int x, int y)
        {
            if (plateau.verifierLigne(plateau.recupererCase(x,y)))
                return true;

            return false;
        }

        public void newPlay(bool? local=null)
        {
            if (local != null) isLocalGame = (bool)local;
            init();
        }

        public void gameOver()
        {
            
        }

        protected virtual void onRaiseGameOverEvent (GameOverEvent e)
        {
            EventHandler<GameOverEvent> handler = gameOverEvent;

            if (handler != null) handler(this,e);
        }

        protected virtual void onRaiseRefreshEvent(RefreshEvent e)
        {
            EventHandler<RefreshEvent> handler = refreshEvent;
            if (handler != null) handler(this, e);
        }
    }
}
