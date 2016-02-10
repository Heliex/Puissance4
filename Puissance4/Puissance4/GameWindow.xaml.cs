using Puissance4.Game_Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Puissance4
{
    /// <summary>
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public Game game;
        public static bool rafraichir = false;
        public IA GameAI;
        public int _column;
        public int _row;

        public GameWindow()
        {
            InitializeComponent();
            newGame();
        }

        public void newGame()
        {
            game = new Game();
            game.init();
            game.gameOverEvent += GameOver;
            game.refreshEvent += refresh;
            reglerIA(0);
        }

        public void reglerIA(int lvl)
        {
            GameAI = new IA(game, lvl);
        }

        private void GameClick(object sender, RoutedEventArgs e)
        {
            Ellipse _elp = sender as Ellipse;
            _column = (int)_elp.GetValue(Grid.ColumnProperty); //x
            _row = (int)_elp.GetValue(Grid.RowProperty); //y
            //MessageBox.Show(string.Format("Button clicked at column {0}, row {1}", _column, _row));

            if (game != null)
            {
                int[] coordonnees = game.makeAMove(_column, _row);
                //MessageBox.Show(string.Format(coordonnees[0] + " " + coordonnees[1]));
                if (coordonnees[0] == -1)
                {
                    MessageBox.Show(string.Format("Coup interdit!"));
                    return;
                }
                else
                {
                    //Afficher une pièce dans la grille
                    _column = coordonnees[0];
                    _row = coordonnees[1];
                    dessiner();
                }
                
                coordonnees = jouerIA();
                if (coordonnees[0] == -1)
                {
                    MessageBox.Show(string.Format("Coup interdit!"));
                    return;
                }
                else
                {   
                    _column = coordonnees[0];
                    _row = coordonnees[1];
                    dessiner();
                }
                
            }
        }

        private int[] jouerIA()
        {
            int[] xy = GameAI.makeAMove();
            //MessageBox.Show(string.Format("IA :" + xy[0] + " " + xy[1]));
            if (xy[0] == -1)
                jouerIA();

            return xy;
            
        }

        public void dessiner()
        {
            Ellipse elipse = new Ellipse();
            elipse.Height = 100;
            elipse.Width = 100;
            
            if (game.turn % 2 == 1) elipse.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4374FF"));//Joueur1
            else elipse.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF4823")); //IA ou Joueur2

            Grid.SetRow(elipse, _row);
            Grid.SetColumn(elipse, _column);
            GridGame.Children.Add(elipse);
        }

        public void rafraichirTableau()
        {
            game.refresh();
        }

        static void GameOver(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Gagné!"));
        }

        static void refresh(object sender, EventArgs e)
        {
            rafraichir = true;
        }
    }
}
