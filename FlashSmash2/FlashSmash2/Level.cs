using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangeMe
{
    // LEVEL IS AIMED TO PROVIDE FUNCTIONALITY, NOT DRAWING OVER THE MAP!! FOR THAT, WORLD IS FOCUSED ON
    public class Level
    {
        public int LevelNumber { get; set; }

        public Square[,] squares { get; set; }
        public int numSquares { get; set; }

        public int SizeSquare { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int moves { get; set; }
        public int STARS_OBTAINED { get; set; }

        public int SquaresToLevelCompleted { get; set; }

        public int ONE_STAR { get; set; }
        public int TWO_STAR { get; set; }
        public int THREE_STAR { get; set; }

        public int fase { get; set; } //fase of the level

        public bool ModeStars { get; set; } //0 for movements, 1 for time

        public int DEFAULT_SIZE_SQUARE = 58;
        #region LEVEL WITH VARIABLE SIZE DEPENDING ON HOW MANY THERE ARE
        //public Level(int LevelNumber, int numXSquares, int numYSquares, int lenght, int squaresToLevelCompleted, int screenDistanceX, int screenDistanceY, int onestar, int twostar, int _fase)
        //{
        //    this.LevelNumber = LevelNumber;

        //    X = numXSquares;
        //    Y = numYSquares;

        //    squares = new Square[numXSquares, numYSquares];

        //    SquaresToLevelCompleted = squaresToLevelCompleted;

        //    SizeSquare = (lenght - 2 * screenDistanceX) / numXSquares;
        //    int pos = 0;
        //    for (int i = 0; i < numYSquares; i++)
        //    {
        //        for (int j = 0; j < numXSquares; j++)
        //        {
        //            int content = Levels.Level[LevelNumber].squaresContent[pos];
        //            squares[j, i] = new Square
        //            {
        //                Position = new Vector2(i, j),
        //                rectangle = new Rectangle(screenDistanceX + j * SizeSquare,
        //                                            screenDistanceY + i * SizeSquare, SizeSquare, SizeSquare),
        //                Content = content
        //            };
        //            pos++;
        //        }
        //    }
        //    moves = 0;

        //    ONE_STAR = onestar;
        //    TWO_STAR = twostar;

        //    fase = _fase;
        //    STARS_OBTAINED = 0;
        //    //Locked = true;
        //}
        #endregion
        public Level(
            int LevelNumber, 
            int numXSquares, 
            int numYSquares, 
            int lenght, 
            int squaresToLevelCompleted, 
            int screenDistanceX, 
            int screenDistanceY, 
            int onestar, 
            int twostar, 
            int threestar, 
            int _fase,
            int forceKeyboardScreen)
        {
            this.LevelNumber = LevelNumber;

            X = numXSquares;
            Y = numYSquares;

            squares = new Square[numXSquares, numYSquares];

            SquaresToLevelCompleted = squaresToLevelCompleted;

            if ((numXSquares == 8) && (numYSquares == 8)) SizeSquare = DEFAULT_SIZE_SQUARE;
            else
            {
                if (forceKeyboardScreen == -1)
                {
                    SizeSquare = 400 / numXSquares;
                }
                else SizeSquare = forceKeyboardScreen;
            }
            int pos = 0;
            for (int i = 0; i < numYSquares; i++)
            {
                for (int j = 0; j < numXSquares; j++)
                {
                    int content = Levels.Level[LevelNumber].squaresContent[pos];
                    squares[j, i] = new Square
                    {
                        Position = new Vector2(j, i),
                        rectangle = new Rectangle(screenDistanceX + j * SizeSquare,
                                                    screenDistanceY + i * SizeSquare, SizeSquare, SizeSquare),
                        Content = content
                    };
                    pos++;
                }
            }
            moves = 0;

            ONE_STAR = onestar;
            TWO_STAR = twostar;
            THREE_STAR = threestar;

            fase = _fase;
            STARS_OBTAINED = 0;
            //Locked = true;
        }

        public List<Square> GetSquareAndAdjacent(int x, int y)
        {
            int EMPTY = Square.EMPTY;

            List<Square> list = new List<Square>();
            if (squares[x, y].Content != EMPTY)
            {
                list.Add(squares[x, y]);

                Square sq = null;
                if (y - 1 >= 0)
                {
                    sq = squares[x, y - 1];
                    if (!sq.Content.Equals(EMPTY))
                    {
                        list.Add(sq);
                    }
                }
                if (x + 1 < X)
                {
                    sq = squares[x + 1, y];
                    if (!sq.Content.Equals(EMPTY))
                    {
                        list.Add(sq);
                    }
                }
                if (y + 1 < Y)
                {
                    sq = squares[x, y + 1];
                    if (!sq.Content.Equals(EMPTY))
                    {
                        list.Add(sq);
                    }
                }
                if (x - 1 >= 0)
                {
                    sq = squares[x - 1, y];
                    if (!sq.Content.Equals(EMPTY))
                    {
                        list.Add(sq);
                    }
                }
            }
            return list;
        }
        public bool IsLevelCompleted(int type)
        {
            int i = 0;

            foreach (var s in squares)
            {
                if (s.Content == type) i++;
                if (i == SquaresToLevelCompleted) return true;
            }
            return false;
        }

        public List<Square> Get5X5AreaSquares(int x, int y)
        {
            var empty = Square.EMPTY;

            var list = new List<Square>();

            var startX = x - 2;
            var endX = x + 2;

            var startY = y - 2;
            var endY = y + 2;

            for (var i = startX; i < endX; i++)
            {
                if ((i >= 0) && (i < X))
                {
                    for (int j = startY; j < endY; j++)
                    {
                        if ((j >= 0) && (j < Y))
                        {
                            var sq = squares[i, j];
                            if (!sq.Content.Equals(empty))
                            {
                                list.Add(sq);
                            }
                        }
                    }
                }
            }

            return list;
        }
    }
    public class Square
    {
        public static int EMPTY = 2;

        public Vector2 Position { get; set; }

        public Rectangle rectangle { get; set; }

        public int Content { get; set; }

        public bool RecentChanged { get; set; }

        public void Switch()
        {
            if (Content < EMPTY) Content = (Content + 1) % 2;
        }
    }
}

