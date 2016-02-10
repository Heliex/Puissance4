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
        public event EventHandler gameOverEvent;
        public event EventHandler refreshEvent;
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

        public int[] makeAMove(int x, int y)
        {
            int[] coordonnees = gravity(x, y);
            if (coordonnees[0] == -1)
                return coordonnees;
            turn++;

            if (checkLine(coordonnees[0], coordonnees[1]))
                onRaiseGameOverEvent();

            //isYourTurn = false;
            //canPlay = false;
            return coordonnees;
        }

        public int[] gravity(int x,int y)
        {
            while (plateau.isInArray(plateau.recupererCase(x, y + 1)))
            {
                if (!plateau.recupererCase(x, y+1).isEmpty())
                    break;
                y++;
            }
            //Console.WriteLine("P1 - X: " + x + " Y: " + y);
            return plateau.estPlacable(plateau.recupererCase(x, y), turn % 2);
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

        public void refresh()
        {

        }

        protected virtual void onRaiseGameOverEvent ()
        {
            if (gameOverEvent != null) gameOverEvent(this,EventArgs.Empty);
            Console.WriteLine("Partie terminée !");
        }

        protected virtual void onRaiseRefreshEvent(RefreshEvent e)
        {
            if (refreshEvent != null) refreshEvent(this, EventArgs.Empty);
        }
    }
}
