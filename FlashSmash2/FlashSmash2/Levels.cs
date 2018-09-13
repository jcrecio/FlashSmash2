using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangeMe
{
    public class MatrixLevel
    {
        public int level;
        public int[] squaresContent;
        public int x;
        public int y;
        public int SquaresToLevelCompleted;
        public int onestar;
        public int twostar;
        public int threestar;
        public int fase;
        public int mode;
    }

    public static class Levels //CONTENT OF EACH LEVEL
    {
        // X DOWN, Y RIGHT
        public static Dictionary<int, MatrixLevel> Level = new Dictionary<int, MatrixLevel>
        {
            {   
                1,
                new MatrixLevel {
                    level = 1,
                    squaresContent = new int[]  //Casillas
                    { 
                        3,3,3,0,3,3,3,3,3,3,3,0,3,3,3,3,3,3,0,1,1,0,3,3,3,0,1,1,1,1,0,3,1,0,3,3,0,0,1,3,3,3,3,3,3,3,1,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 19,
                    onestar = 24, twostar = 48, threestar = 72,
                    mode = 0,
                    fase = 1
                }
  
            },
            {   
                2, //Level
                new MatrixLevel {
                    level = 2,
                    squaresContent = new int[]  //Casillas
                    { 
                        0,1,0,0,1,1,1,0,0,0,3,3,0,0,3,3,1,3,3,3,1,3,3,3,0,3,3,3,1,3,3,3,0,0,0,0,0,1,1,0,1,1,3,3,3,3,0,1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3                  
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 28,
                    onestar = 30, twostar = 60, threestar = 90,
                    fase = 1
                }
             },
             {   
                3,
                new MatrixLevel {
                    level = 3,
                    squaresContent = new int[]  //Casillas
                    { 
                        3,3,3,1,1,3,3,3,3,3,3,0,0,3,3,3,3,3,3,0,0,3,3,3,3,3,0,1,1,0,1,1,0,1,1,0,0,3,3,3,1,3,3,1,3,3,3,3,1,3,3,0,3,3,3,3,0,1,0,1,1,3,3,3
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 26,
                    onestar = 24, twostar = 48, threestar = 72,
                    fase = 1
                }
  
            },
             {   
                4, //Level
                new MatrixLevel {
                    level = 4,
                    squaresContent = new int[]  //Casillas
                    { 
                        3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,1,3,3,3,3,3,1,0,0,3,3,3,1,0,0,0,0,0,1,0,0,0,0,0,0,1,0,1,0,0,0,0,0,1,0,3,3,0,1,0,0,0,3,3,3,3,1,0,1
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 36,
                    onestar = 33, twostar = 66, threestar = 99,
                    fase = 1
                }
             },
             {   
                5, //Level
                new MatrixLevel {
                    level = 5,
                    squaresContent = new int[]  //Casillas
                    { 
                        1,1,0,1,0,0,0,0,0,1,3,3,0,0,0,1,0,0,3,3,0,0,0,0,0,0,3,3,1,3,3,3,1,0,0,0,1,3,3,3,3,3,0,1,0,3,3,0,3,3,1,0,0,0,1,0,3,3,3,1,0,1,1,0
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 43,
                    onestar = 45, twostar = 90, threestar = 135,
                    fase = 1
                }
             },
             {   
                6, //Level
                new MatrixLevel {
                    level = 6,
                    squaresContent = new int[]  //Casillas
                    { 
                        3,3,3,0,0,1,3,3,3,3,3,1,0,1,3,3,3,3,3,3,0,1,3,3,3,3,3,3,0,3,3,3,3,3,3,0,1,3,3,3,3,3,3,1,0,1,3,3,3,3,3,1,1,0,3,3,3,3,3,0,0,0,3,3
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 20,
                    onestar = 30, twostar = 60, threestar = 90,
                    fase = 1
                }
             },
              {   
                7, //Level
                new MatrixLevel {
                    level = 7,
                    squaresContent = new int[]  //Casillas
                    { 
                        3,3,3,1,1,1,1,1,3,3,3,0,3,3,0,0,3,3,3,3,3,3,3,0,0,1,3,3,3,3,3,0,1,0,3,3,3,3,3,0,0,0,3,3,3,0,0,0,0,0,3,3,0,0,0,0,1,0,0,0,0,0,0,1
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 34,
                    onestar = 42, twostar = 84, threestar = 126,
                    fase = 1
                }
             },
             {   
                8, //Level
                new MatrixLevel {
                    level = 8,
                    squaresContent = new int[]  //Casillas
                    { 
                        3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,3,3,3,3,3,3,1,0,0,3,3,3,0,0,0,0,0,0,1,0,1,0,0,0,1,0,3,3,3,0,0,1,0,3,3,3,3,3,0,0,3,3,3,3
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 24,
                    onestar = 18, twostar = 36, threestar = 54,
                    fase = 1
                }
             },
             {   
                9, //Level
                new MatrixLevel {
                    level = 9,
                    squaresContent = new int[]  //Casillas
                    { 
                        3,3,3,3,3,3,3,3,3,3,3,3,0,0,1,0,3,3,1,1,0,3,3,3,0,1,1,0,3,3,3,3,0,1,1,1,3,3,3,3,3,0,0,1,3,3,3,3,3,3,3,0,0,1,1,0,3,3,3,3,3,3,3,3
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 23,
                    onestar = 30, twostar = 60, threestar = 90,
                    fase = 2
                }
  
            },
             {   
                10, //Level
                new MatrixLevel {
                    level = 10,
                    squaresContent = new int[]  //Casillas
                    { 
                        0,0,1,0,1,3,3,3,3,3,3,3,1,3,3,3,3,3,3,3,1,3,3,3,0,3,3,3,1,0,3,3,0,0,1,0,1,1,1,3,0,0,1,1,0,0,1,0,0,0,0,0,1,1,0,0,0,0,3,3,3,3,0,0
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 37,
                    onestar = 42, twostar = 84, threestar = 126,
                    fase = 2
                }
  
            },
             {   
                11, //Level
                new MatrixLevel {
                    level = 11,
                    squaresContent = new int[]  //Casillas
                    { 
                        0,1,0,0,3,3,3,3,
                        3,0,0,0,3,3,3,3,
                        3,3,3,0,0,3,3,3,
                        3,3,3,0,0,1,3,3,
                        3,3,1,0,1,0,0,1,
                        3,0,0,0,1,1,0,0,
                        3,3,3,3,3,3,1,1,
                        3,3,3,3,3,3,3,1
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 28,
                    onestar = 39, twostar = 78, threestar = 117,
                    fase = 2
                }
            },
            {   
                12, //Level
                new MatrixLevel {
                    level = 12,
                    squaresContent = new int[]  //Casillas
                    { 
                        3,3,0,3,3,3,3,3,3,3,0,0,3,3,3,3,3,3,3,0,0,3,3,3,3,3,3,3,0,0,0,1,3,3,3,3,1,0,1,1,3,3,3,3,0,3,3,3,3,3,1,0,1,3,3,3,3,3,1,1,3,3,3,3
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 19,
                    onestar = 18, twostar = 36, threestar = 54,
                    fase = 2
                }
            },
            {   
                13, //Level
                new MatrixLevel {
                    level = 13,
                    squaresContent = new int[]  //Casillas
                    { 
                        0,3,1,1,1,0,1,1,1,3,3,1,1,1,1,1,1,3,3,0,1,3,3,1,1,3,3,1,3,3,3,1,1,3,3,0,3,3,3,1,1,1,1,0,3,3,3,1,1,1,0,1,3,3,3,0,1,1,1,1,0,3,0,1
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 40,
                    onestar = 69, twostar = 138, threestar = 207,
                    fase = 2
                }
            },
            {   
                14, //Level
                new MatrixLevel {
                    level = 14,
                    squaresContent = new int[]  //Casillas
                    { 
                        0,1,1,0,0,0,0,0,3,3,3,0,0,1,0,0,3,3,3,0,1,0,1,1,3,3,3,0,0,3,3,1,3,3,3,0,3,3,3,3,3,3,3,1,3,3,3,3,3,1,1,0,3,3,3,0,1,0,0,0,0,1,0,1
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 35,
                    onestar = 39, twostar = 78, threestar = 117,
                    fase = 2
                }
            },
 {   
                15, //Level
                new MatrixLevel {
                    level = 15,
                    squaresContent = new int[]  //Casillas
                    { 
                        1,1,1,1,1,3,3,3,1,3,3,3,3,3,3,3,1,3,3,3,3,0,3,3,1,3,3,3,3,1,1,3,1,3,3,1,1,1,1,0,1,1,1,1,1,1,1,1,3,3,3,1,1,1,1,1,3,3,3,3,1,1,0,1
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 34,
                    onestar = 57, twostar = 114, threestar = 171,
                    fase = 2
                }
            },
             {   
                16, //Level
                new MatrixLevel {
                    level = 16,
                    squaresContent = new int[]  //Casillas
                    { 
                       3,3,3,1,1,3,3,3,3,3,3,1,3,3,3,3,3,3,1,1,3,3,3,3,3,3,3,0,3,3,1,1,3,3,3,1,0,1,1,0,3,3,3,1,3,1,3,3,3,0,0,1,1,3,3,3,3,3,1,1,1,3,3,3
                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 22,
                    onestar = 18, twostar = 36, threestar = 54,
                    fase = 2
                }
            },
                         {   
                17, //Level
                new MatrixLevel {
                    level = 17,
                    squaresContent = new int[]  //Casillas
                    { 
3,3,3,0,0,3,3,3,3,3,0,3,3,0,3,3,0,0,3,3,3,0,3,3,0,3,3,3,3,0,3,3,0,3,3,3,3,0,0,3,3,3,0,3,0,0,0,3,3,0,3,3,0,0,0,3,0,0,3,0,0,0,0,0                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 27,
                    onestar = 42, twostar = 84, threestar = 126,
                    fase = 3
                }
            },
                         {   
                18, //Level
                new MatrixLevel {
                    level = 18,
                    squaresContent = new int[]  //Casillas
                    { 
3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,3,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,0,3,3,3,3,3,3,0,0,0,0,0,0,0,3,3,3,3,3,0,0,0,0                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 26,
                    onestar = 36, twostar = 72, threestar = 108,
                    fase = 3
                }
            },
                                     {   
                19, //Level
                new MatrixLevel {
                    level = 19,
                    squaresContent = new int[]  //Casillas
                    { 
3,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,3,3,3,3,3,3,0,0,3,3                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 26,
                    onestar = 42, twostar = 84, threestar = 126,
                    fase = 3
                }
            },
                                     {   
                20, //Level
                new MatrixLevel {
                    level = 20,
                    squaresContent = new int[]  //Casillas
                    { 
3,3,3,3,3,3,0,0,3,3,0,3,3,0,0,3,0,0,3,3,0,0,3,3,0,0,3,0,0,3,3,3,0,3,3,0,3,3,3,3,3,3,3,0,3,3,3,0,3,3,0,0,3,3,3,0,3,3,0,3,3,3,0,0                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 23,
                    onestar = 57, twostar = 114, threestar = 171,
                    fase = 3
                }
            },
                                     {   
                21, //Level
                new MatrixLevel {
                    level = 21,
                    squaresContent = new int[]  //Casillas
                    { 
3,0,3,3,0,3,0,0,3,0,0,0,0,3,3,0,3,0,0,0,0,3,3,0,0,0,0,0,0,0,3,3,0,0,0,0,0,0,0,3,0,0,3,0,0,0,0,3,0,3,3,0,0,0,0,3,3,3,3,0,0,0,0,0                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 43,
                    onestar = 18, twostar = 36, threestar = 54,
                    fase = 3
                }
            },
            {   
                22, //Level
                new MatrixLevel {
                    level = 22,
                    squaresContent = new int[]  //Casillas
                    { 
3,3,3,3,3,0,0,0,3,0,3,3,3,0,0,0,0,0,3,3,3,0,0,3,0,0,3,3,3,0,3,3,0,3,0,3,3,3,3,3,0,3,3,0,3,3,3,3,0,3,3,0,0,0,3,3,0,0,3,3,0,0,0,0                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 28,
                    onestar = 48, twostar = 96, threestar = 142,
                    fase = 3
                }
            },
            {   
                23, //Level
                new MatrixLevel {
                    level = 23,
                    squaresContent = new int[]  //Casillas
                    { 
0,0,0,3,3,0,0,3,0,0,3,3,3,3,0,3,0,3,3,3,3,3,0,3,3,3,3,3,3,3,0,3,3,3,3,0,3,3,0,0,3,0,0,3,3,3,0,0,0,0,0,3,3,0,0,3,0,0,3,3,0,0,0,3                    },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 28,
                    onestar = 60, twostar = 120, threestar = 180,
                    fase = 3
                }
            },
            {   
                24, //Level
                new MatrixLevel {
                    level = 24,
                    squaresContent = new int[]  //Casillas
                    {
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0                   },
                    x = 8, y = 8,
                    SquaresToLevelCompleted = 64,
                    onestar = 51, twostar = 102, threestar = 153,
                    fase = 3
                }
            },
            {   
                25, //Level
                new MatrixLevel {
                    level = 25,
                    squaresContent = new int[20]  //Casillas
                    { 
                        1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,0
                    },
                    x = 4, y = 5,
                    SquaresToLevelCompleted = 20,
                    onestar = 39, twostar = 78, threestar = 117,
                    fase = 4
                }
            },
            {   
                26, //Level
                new MatrixLevel {
                    level = 26,
                    squaresContent = new int[20]  //Casillas
                    { 
                        0,0,0,0,1,1,1,0,0,0,0,0,0,1,1,1,0,0,0,0
                    },
                    x = 4, y = 5,
                    SquaresToLevelCompleted = 20,
                    onestar = 24, twostar = 48, threestar = 72,
                    fase = 4
                }
            },
            {   
                27, //Level
                new MatrixLevel {
                    level = 27,
                    squaresContent = new int[20]  //Casillas
                    { 
                        0,0,0,0,1,1,1,0,1,0,0,0,1,1,1,0,0,0,0,0
                    },
                    x = 4, y =5,
                    SquaresToLevelCompleted = 20,
                    onestar = 21, twostar = 42, threestar = 63,
                    fase = 4
                }
            },
            {   
                28, //Level
                new MatrixLevel {
                    level = 28,
                    squaresContent = new int[20]  //Casillas
                    { 
                        0,1,1,0,0,1,1,0,0,0,0,0,1,1,1,0,1,1,1,0
                    },
                    x = 4, y = 5,
                    SquaresToLevelCompleted = 20,
                    onestar = 27, twostar = 54, threestar = 81,
                    fase = 4
                }
            },
            {   
                29, //Level
                new MatrixLevel {
                    level = 29,
                    squaresContent = new int[20]  //Casillas
                    { 
                        0,0,0,0,0,1,1,1,0,0,0,0,1,1,1,0,0,0,0,0
                    },
                    x = 4, y = 5,
                    SquaresToLevelCompleted = 20,
                    onestar = 24, twostar = 48, threestar = 72,
                    fase = 4
                }
            },
            {   
                30, //Level
                new MatrixLevel {
                    level = 30,
                    squaresContent = new int[20]  //Casillas
                    { 
                        0,0,0,0,0,1,1,1,0,0,0,0,0,1,1,0,0,0,0,0
                    },
                    x = 4, y = 5,
                    SquaresToLevelCompleted = 20,
                    onestar = 33, twostar = 66, threestar = 99,
                    fase = 4
                }
            },
            {   
                31, //Level
                new MatrixLevel {
                    level = 31,
                    squaresContent = new int[20]  //Casillas
                    { 
                        0,0,0,0,1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,0
                    },
                    x = 4, y = 5,
                    SquaresToLevelCompleted = 20,
                    onestar = 21, twostar = 42, threestar = 63,
                    fase = 4
                }
            },
            {   
                32, //Level
                new MatrixLevel {
                    level = 32,
                    squaresContent = new int[20]  //Casillas
                    { 
                        0,0,0,0,0,1,1,0,0,0,0,0,0,1,1,0,0,0,0,0
                    },
                    x = 4, y = 5,
                    SquaresToLevelCompleted = 20,
                    onestar = 42, twostar = 84, threestar = 126,
                    fase = 4
                }
            },
        };
    }
}
