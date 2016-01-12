using System;
using System.Text;

namespace Puissance4.Game_Engine
{
    public class Board
    {
        private Case[,] gameboard;
        private static readonly bool DiagonaleHGVersBD              = false;
        private static readonly bool DiagonaleBDVersHG              = true;
        private static readonly bool DiagonaleBGVersHD              = false;
        private static readonly bool DiagonaleHDVersBG              = true;
        private static readonly bool DroiteVerticaleVersHaut        = false;
        private static readonly bool DroiteVerticaleVersBas         = true;
        private static readonly bool DroiteHorizontaleVersDroite    = false;
        private static readonly bool DroiteHorizontaleVersGauche    = true;

        private int noPlaceLeft;

        private int countDiagonaleLine = 0;
        private int countStraightLine = 0;

        public Board(int x, int y)
        {
            gameboard = new Case[x, y];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    gameboard[i, j] = new Case(i, j);
            noPlaceLeft = x * y;
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
                Case[] neightbours = new Case[8];
                neightbours[0] = recupererCase(c.x - 1, c.y - 1);   // 1[x][ ][ ]
                neightbours[1] = recupererCase(c.x    , c.y - 1);   // 1[ ][x][ ]
                neightbours[2] = recupererCase(c.x + 1, c.y - 1);   // 1[ ][ ][x]

                neightbours[3] = recupererCase(c.x - 1, c.y);       // 2[x][o][ ]
                neightbours[4] = recupererCase(c.x + 1, c.y);       // 2[ ][o][x]

                neightbours[5] = recupererCase(c.x - 1, c.y + 1);   // 3[x][ ][ ]
                neightbours[6] = recupererCase(c.x    , c.y + 1);   // 3[ ][x][ ]
                neightbours[7] = recupererCase(c.x + 1, c.y + 1);   // 3[ ][ ][x]

                //Contrôle Lignes
                //Lignes Diagonales
                //Diagonale haut gauche vers bas droite
                if (neightbours[0].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[0]))
                {
                    if (ligneDiagonale(neightbours[0], c))
                        return true;
                }

                if (neightbours[7].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[7]))
                {
                    if (ligneDiagonale(neightbours[7], c))
                        return true;
                }
                countDiagonaleLine = 1;

                //Diagonale haut droite vers bas gauche
                if (neightbours[2].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[2]))
                {
                    if (ligneDiagonale(neightbours[2], c))
                        return true;
                }
                if (neightbours[5].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[0]))
                {
                    if (ligneDiagonale(neightbours[0], c))
                        return true;
                }
                countDiagonaleLine = 1;

                //Lignes Horizontales et Verticales
                //Verticale
                if (neightbours[1].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[1]))
                {
                    if (ligneDroite(neightbours[1], c))
                        return true;
                }

                if (neightbours[6].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[6]))
                {
                    if (ligneDroite(neightbours[6], c))
                        return true;
                }
                countStraightLine = 1;

                //Horizontale
                if (neightbours[3].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[3]))
                {
                    if (ligneDroite(neightbours[3], c))
                        return true;
                }

                if (neightbours[4].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[4]))
                {
                    if (ligneDroite(neightbours[4], c))
                        return true;
                }
                countStraightLine = 1;
                
                
                //if (neightbours[0].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[0]))
                //{
                //    if (ligneDiagonaleHGBD(neightbours[0], DiagonaleHGVersBD))
                //        return true;
                //}

                //if (neightbours[1].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[1]))
                //{
                //    if (ligneDroiteVerticale(neightbours[1], DroiteVerticaleVersHaut))
                //        return true;
                //}

                //if (neightbours[2].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[2]))
                //{
                //    if (ligneDiagonale(neightbours[2], DiagonaleBGVersHD))
                //        return true;
                //}
                //if (neightbours[3].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[3]))
                //{
                //    if (ligneDroite(neightbours[3], DroiteHorizontale))
                //        return true;
                //}
                //if (neightbours[4].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[4]))
                //{
                //    if (ligneDroite(neightbours[4], DroiteHorizontale))
                //        return true;
                //}
                //if (neightbours[5].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[5]))
                //{
                //    if (ligneDiagonale(neightbours[5], DiagonaleBGVersHD))
                //        return true;
                //}
                //if (neightbours[6].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[6]))
                //{
                //    if (ligneDroite(neightbours[6], DroiteVerticale))
                //        return true;
                //}
                //if (neightbours[7].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[7]))
                //{
                //    if (ligneDiagonale(neightbours[7], DiagonaleHGVersBD))
                //        return true;
                //}

                
            }

            return false;
        }

        public Case recupererCase(int x, int y)
        {
            try
            {
                return gameboard[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return new Case(-1, -1);
            }
        }

        //public bool ligneDroiteVerticale(Case c, bool sens)
        //{
        //    Case[] neightbours = new Case[2];
        //    neightbours[0] = recupererCase(c.x - 1, c.y);
        //    neightbours[1] = recupererCase(c.x + 1, c.y);
        //    neightbours[2] = recupererCase(c.x, c.y - 1);
        //    neightbours[3] = recupererCase(c.x, c.y + 1);
            
        //    if (countStraightLine < 0 || countStraightLine > 4) return false;

        //    if (sens = DroiteHorizontaleVersDroite)
        //    {
        //        if (neightbours[0].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[0]))
        //            if (ligneDroiteVerticale(neightbours[0], DroiteHorizontale))
        //                return true;

        //        if (neightbours[1].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[1]))
        //            if (ligneDroiteVerticale(neightbours[1], DroiteHorizontale))
        //                return true;
        //    }
        //    else
        //    {
        //        if (neightbours[2].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[2]))
        //            if (ligneDroiteVerticale(neightbours[2], DroiteVerticale))
        //                return true;

        //        if (neightbours[3].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[3]))
        //            if (ligneDroiteVerticale(neightbours[3], DroiteVerticale))
        //                return true;
        //    }

        //    return false;
        //}


        public bool ligneDiagonale(Case c, Case caseOriginale)
        {
            if (!c.isEmpty() && c.isSameColor(caseOriginale))
            {
                countDiagonaleLine++;
                Case newCase;
                try
                {
                    newCase = gameboard[c.x - (caseOriginale.x - c.x), c.y - (caseOriginale.y - c.y)];
                } catch (IndexOutOfRangeException) {
                    return false;
                }
                Console.WriteLine(c.x + " " + caseOriginale.x + " " + (c.x - (caseOriginale.x - c.x)) + " " + c.y + " " + caseOriginale.y + " " + (c.y - (caseOriginale.y - c.y))+"   "+countDiagonaleLine);
                ligneDiagonale(newCase, c);
            }

            if (countDiagonaleLine == 4)
            {
                return true;
            }   
            return false;
        }

        public bool ligneDroite(Case c, Case caseOriginale)
        {
            if (!c.isEmpty() && c.isSameColor(caseOriginale))
            {
                countStraightLine++;
                Case newCase;
                try
                {
                    newCase = gameboard[c.x - (caseOriginale.x - c.x), c.y - (caseOriginale.y - c.y)];
                }
                catch (IndexOutOfRangeException)
                {
                    return false;
                }
                ligneDroite(newCase, c);
            }

            if (countStraightLine == 4)
            {
                return true;
            }
            return false;
        }

        //public bool ligneDroiteHorizontale(Case c, bool sens)
        //{
        //    Case[] neightbours = new Case[2];
        //    neightbours[0] = recupererCase(c.x - 1, c.y);
        //    neightbours[1] = recupererCase(c.x + 1, c.y);
        //    neightbours[2] = recupererCase(c.x, c.y - 1);
        //    neightbours[3] = recupererCase(c.x, c.y + 1);

        //    if (countStraightLine < 0 || countStraightLine > 4) return false;

        //    if (sens = DroiteHorizontale)
        //    {
        //        if (neightbours[0].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[0]))
        //            if (ligneDroiteHorizontale(neightbours[0], DroiteHorizontale))
        //                return true;

        //        if (neightbours[1].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[1]))
        //            if (ligneDroiteHorizontale(neightbours[1], DroiteHorizontale))
        //                return true;
        //    }
        //    else
        //    {
        //        if (neightbours[2].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[2]))
        //            if (ligneDroiteHorizontale(neightbours[2], DroiteVerticale))
        //                return true;

        //        if (neightbours[3].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[3]))
        //            if (ligneDroiteHorizontale(neightbours[3], DroiteVerticale))
        //                return true;
        //    }

        //    return false;
        //}

        //public bool ligneDiagonaleHGBD(Case c, bool sens)
        //{
        //    Case[] neightbours = new Case[2];
        //    neightbours[0] = recupererCase(c.x - 1, c.y - 1);
        //    neightbours[1] = recupererCase(c.x + 1, c.y + 1);
        //    neightbours[2] = recupererCase(c.x + 1, c.y - 1);
        //    neightbours[3] = recupererCase(c.x - 1, c.y + 1);
            
        //    if (countDiagonaleLine > 4 || countDiagonaleLine < 0) return false;

        //    if (sens = DiagonaleBGVersHD)
        //    {
        //        if (neightbours[0].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[0]))
        //            if (ligneDiagonale(neightbours[0], DiagonaleBGVersHD))
        //                countDiagonaleLine++;

        //        if (neightbours[1].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[1]))
        //            if (ligneDiagonale(neightbours[1], DiagonaleBGVersHD))
        //                countDiagonaleLine++;
        //    }
        //    else
        //    {
        //        if (neightbours[2].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[2]))
        //            if (ligneDiagonale(neightbours[2], DiagonaleHGVersBD))
        //                countDiagonaleLine++;

        //        if (neightbours[3].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[3]))
        //            if (ligneDiagonale(neightbours[3], DiagonaleHGVersBD))
        //                countDiagonaleLine++;
        //    }

        //    if (countDiagonaleLine == 4)
        //    {
        //        countDiagonaleLine = 0;
        //        return true;
        //    }
        //    return false;
        //}

        //public bool ligneDiagonaleBGHD(Case c, bool sens)
        //{
        //    Case[] neightbours = new Case[2];
        //    neightbours[0] = recupererCase(c.x - 1, c.y - 1);
        //    neightbours[1] = recupererCase(c.x + 1, c.y + 1);
        //    neightbours[2] = recupererCase(c.x + 1, c.y - 1);
        //    neightbours[3] = recupererCase(c.x - 1, c.y + 1);

        //    if (countDiagonaleLine > 4 || countDiagonaleLine < 0) return false;

        //    if (sens = DiagonaleBGVersHD)
        //    {
        //        if (neightbours[0].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[0]))
        //            if (ligneDiagonale(neightbours[0], DiagonaleBGVersHD))
        //                countDiagonaleLine++;

        //        if (neightbours[1].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[1]))
        //            if (ligneDiagonale(neightbours[1], DiagonaleBGVersHD))
        //                countDiagonaleLine++;
        //    }
        //    else
        //    {
        //        if (neightbours[2].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[2]))
        //            if (ligneDiagonale(neightbours[2], DiagonaleHGVersBD))
        //                countDiagonaleLine++;

        //        if (neightbours[3].x != -1 && gameboard[c.x, c.y].isSameColor(neightbours[3]))
        //            if (ligneDiagonale(neightbours[3], DiagonaleHGVersBD))
        //                countDiagonaleLine++;
        //    }

        //    if (countDiagonaleLine == 4)
        //    {
        //        countDiagonaleLine = 0;
        //        return true;
        //    }
        //    return false;
        //}

        public bool isInArray(Case c)
        {
            if (c.x >= gameboard.GetLength(0) && c.x < 0) return false;
            if (c.y >= gameboard.GetLength(1) && c.y < 0) return false;

            return true;
        }

        public bool estPlacable(Case c, int isPlayerTurn)
        {
            if (!isInArray(c)) return false;
            if (!c.isEmpty() || !gameboard[c.x, c.y].isEmpty()) return false;

            if (noPlaceLeft-- <= 0) return false;
            if (!c.placePiece(isPlayerTurn == 0 ? false : true))
            {
                noPlaceLeft++;  //En cas de problème, on annule le coup précédent
                return false;
            }

            return true;
        }

        public void viderCase(int x, int y)
        {
            gameboard[x, y] = new Case(x, y);
        }

        public String toString()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                    s.Append(gameboard[i, j].isEmpty() ? "0" : "1");
                s.AppendLine();
            }
            s.AppendLine();
            return s.ToString();
        }
    }
}
