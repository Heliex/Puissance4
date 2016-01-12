﻿using Puissance4.Game_Engine;
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

        public GameWindow()
        {
            InitializeComponent();
            newGame();
        }

        public void newGame()
        {
            game = new Game();
            game.init();
        }


        private void GameClick(object sender, RoutedEventArgs e)
        {
            Button _btn = sender as Button;

            int _column = (int)_btn.GetValue(Grid.ColumnProperty); //x
            int _row = (int)_btn.GetValue(Grid.RowProperty); //y
            //MessageBox.Show(string.Format("Button clicked at column {0}, row {1}", _column, _row));

            if (game != null)
                if (!game.makeAMove(_column, _row))
                {
                    MessageBox.Show(string.Format("Coup interdit!"));
                    return;
                }
                else
                {
                    //Afficher une pièce dans la grille
                    

                }
            if(game.checkLine(_column, _row))
                MessageBox.Show(string.Format("Gagné!"));

        }
    }
}
