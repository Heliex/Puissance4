using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.Game_Engine
{
    class Board
    {
        private Case[,] gameboard;
        private static sealed bool DiagonaleHGVersBD = false;
        private static sealed bool DiagonaleBGVersHD = true;
        private static sealed bool DroiteVerticale = false;
        private static sealed bool DroiteHorizontale = true;

        private int countDiagonaleLine = 0;
        private int countStraightLine = 0;

        public Board(int x, int y)
        {
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    gameboard[i, j] = new Case(i, j);
        }

        public void init()
        {
            for (int i = 0; i < gameboard.GetLength(0); i++)
                for (int j = 0; j < gameboard.GetLength(1); j++)
                    gameboard[i, j] = new Case(i, j);
        }

        public bool verifierLigne(Case c)
        {
            if (!gameboard[c.x, c.y].isEmpty())
            {
                if (isInArray(gameboard[c.x - 1, c.y - 1]) && gameboard[c.x, c.y].isSameColor(gameboard[c.x - 1, c.y - 1]))
                    if (ligneDiagonale(gameboard[c.x - 1, c.y - 1], DiagonaleHGVersBD))
                        return true;

                if (isInArray(gameboard[c.x, c.y - 1]) && gameboard[c.x, c.y].isSameColor(gameboard[c.x, c.y - 1]))
                    if (ligneDroite(gameboard[c.x, c.y - 1], DroiteVerticale))
                        return true;

                if (isInArray(gameboard[c.x + 1, c.y - 1]) && gameboard[c.x, c.y].isSameColor(gameboard[c.x + 1, c.y - 1]))
                    if (ligneDiagonale(gameboard[c.x - 1, c.y - 1], DiagonaleBGVersHD))
                        return true;

                if (isInArray(gameboard[c.x - 1, c.y]) && gameboard[c.x, c.y].isSameColor(gameboard[c.x - 1, c.y]))
                    if (ligneDroite(gameboard[c.x - 1, c.y], DroiteHorizontale))
                        return true;

                if (isInArray(gameboard[c.x + 1, c.y]) && gameboard[c.x, c.y].isSameColor(gameboard[c.x + 1, c.y]))
                    if (ligneDroite(gameboard[c.x + 1, c.y], DroiteHorizontale))
                        return true;

                if (isInArray(gameboard[c.x - 1, c.y + 1]) && gameboard[c.x, c.y].isSameColor(gameboard[c.x - 1, c.y + 1]))
                    if (ligneDiagonale(gameboard[c.x - 1, c.y + 1], DiagonaleBGVersHD))
                        return true;

                if (isInArray(gameboard[c.x, c.y + 1]) && gameboard[c.x, c.y].isSameColor(gameboard[c.x, c.y + 1]))
                    if (ligneDroite(gameboard[c.x, c.y + 1], DroiteVerticale))
                        return true;

                if (!isInArray(gameboard[c.x + 1, c.y + 1]) && gameboard[c.x, c.y].isSameColor(gameboard[c.x + 1, c.y + 1]))
                    if (ligneDiagonale(gameboard[c.x + 1, c.y + 1], DiagonaleHGVersBD))
                        return true;
            }

            return false;
        }

        public Case recupererCase(int x, int y)
        {
            return gameboard[x, y];
        }

        public bool ligneDroite(Case c, bool sens)
        {
            if (countStraightLine < 0 || countStraightLine > 4) return false;

            if (sens = DroiteHorizontale)
            {
                if (isInArray(gameboard[c.x - 1, c.y - 1]) && gameboard[c.x - 1, c.y - 1].isEmpty())
                    if (ligneDroite(gameboard[c.x - 1, c.y], DroiteHorizontale))
                        return true;

                if (isInArray(gameboard[c.x + 1, c.y]) && gameboard[c.x + 1, c.y].isEmpty())
                    if (ligneDroite(gameboard[c.x + 1, c.y], DroiteHorizontale))
                        return true;
            }
            else
            {
                if (isInArray(gameboard[c.x, c.y - 1]) && gameboard[c.x, c.y - 1].isEmpty())
                    if (ligneDroite(gameboard[c.x, c.y - 1], DroiteVerticale))
                        return true;

                if (isInArray(gameboard[c.x, c.y + 1]) && gameboard[c.x, c.y + 1].isEmpty())
                    if (ligneDroite(gameboard[c.x, c.y + 1], DroiteVerticale))
                        return true;
            }

            return false;
        }

        public bool ligneDiagonale(Case c, bool sens)
        {
            if (countDiagonaleLine > 4 || countDiagonaleLine < 0) return false;

            if (sens = DiagonaleBGVersHD)
            {
                if (isInArray(gameboard[c.x - 1, c.y]) && gameboard[c.x - 1, c.y].isEmpty())
                    if (ligneDiagonale(gameboard[c.x - 1, c.y], DiagonaleBGVersHD))
                        countDiagonaleLine++;

                if (isInArray(gameboard[c.x + 1, c.y]) && gameboard[c.x + 1, c.y].isEmpty())
                    if (ligneDiagonale(gameboard[c.x + 1, c.y], DiagonaleBGVersHD))
                        countDiagonaleLine++;
            }
            else
            {
                if (isInArray(gameboard[c.x, c.y - 1]) && gameboard[c.x, c.y - 1].isEmpty())
                    if (ligneDiagonale(gameboard[c.x, c.y - 1], DiagonaleHGVersBD))
                        countDiagonaleLine++;

                if (isInArray(gameboard[c.x, c.y + 1]) && gameboard[c.x, c.y + 1].isEmpty())
                    if (ligneDiagonale(gameboard[c.x, c.y + 1], DiagonaleHGVersBD))
                        countDiagonaleLine++;
            }

            if (countDiagonaleLine == 4)
            {
                countDiagonaleLine = 0;
                return true;
            }
            return false;
        }

        public bool isInArray(Case c)
        {
            if (c.x >= gameboard.GetLength(0) && c.x < 0) return false;
            if (c.y >= gameboard.GetLength(1) && c.y < 0) return false;

            return true;
        }

        public bool estPlacable(Case c)
        {
            if (!isInArray(c)) return false;
            if (!c.isEmpty() || !gameboard[c.x, c.y].isEmpty()) return false;

            return true;
        }
    }
}
