using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChangeMe
{
    public class World
    {
        public int WorldNumber { get; set; }
        public Dictionary<Int32, OptimizerLevelPosition> PositionLevels { get; set; }
    }
    public class OptimizerLevelPosition
    {
        public Texture2D Texture { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
    }
    public static class Worlds
    {

        public static Dictionary<int, World> SelectWorld = new Dictionary<int, World>
        {
            {
                1,
                new World
                {
                    WorldNumber = 1,
                    PositionLevels = new Dictionary<int, OptimizerLevelPosition> {
                        {
                            1, 
                            new OptimizerLevelPosition {
                                X = 381,
                                Y = 2002,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            2,
                            new OptimizerLevelPosition {
                                X = 255,
                                Y = 1958,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            3, 
                            new OptimizerLevelPosition {
                                X = 111,
                                Y = 1970,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            4, 
                            new OptimizerLevelPosition {
                                X = 18,
                                Y = 1860,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            5, 
                            new OptimizerLevelPosition {
                                X = 40,
                                Y = 1737,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            6, 
                            new OptimizerLevelPosition {
                                X = 188,
                                Y = 1750,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            7, 
                            new OptimizerLevelPosition {
                                X = 313,
                                Y = 1815,
                                W = 46,
                                H = 40
                            }
                        }
                        ,{
                            8, 
                            new OptimizerLevelPosition {
                                X = 400,
                                Y = 1646,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            9, 
                            new OptimizerLevelPosition {
                                X = 320,
                                Y = 1553,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            10, 
                            new OptimizerLevelPosition {
                                X = 276,
                                Y = 1480,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            11, 
                            new OptimizerLevelPosition {
                                X = 141,
                                Y = 1458,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            12, 
                            new OptimizerLevelPosition {
                                X = 79,
                                Y = 1339,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            13, 
                            new OptimizerLevelPosition {
                                X = 230,
                                Y = 1306,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            14, 
                            new OptimizerLevelPosition {
                                X = 348,
                                Y = 1279,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            15, 
                            new OptimizerLevelPosition {
                                X = 340,
                                Y = 1145,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                            16, 
                            new OptimizerLevelPosition {
                                X = 155,
                                Y = 1238,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                            17, 
                            new OptimizerLevelPosition {
                                 X = 66,
                                Y = 1076,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                            18, 
                            new OptimizerLevelPosition {
                                X = 149,
                                Y = 1018,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                            19, 
                            new OptimizerLevelPosition {
                                X = 306,
                                Y = 1015,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                            20, 
                            new OptimizerLevelPosition {
                                X = 404,
                                Y = 877,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                           21, 
                            new OptimizerLevelPosition {
                                X = 243,
                                Y = 883,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                            22, 
                            new OptimizerLevelPosition {
                                X = 107,
                                Y = 876,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                            23, 
                            new OptimizerLevelPosition {
                                X = 157,
                                Y = 741,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                            24, 
                            new OptimizerLevelPosition {
                                X = 305,
                                Y = 625,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                            25, 
                            new OptimizerLevelPosition {
                                X = 236,
                                Y = 492,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                            26, 
                            new OptimizerLevelPosition {
                                X = 33,
                                Y = 481,
                                W = 46,
                                H = 40
                            }
                        },
                         {
                            27, 
                            new OptimizerLevelPosition {
                                X = 245,
                                Y = 429,
                                W = 46,
                                H = 40
                            }
                        },
                                                 {
                            28, 
                            new OptimizerLevelPosition {
                                X = 69,
                                Y = 354,
                                W = 46,
                                H = 40
                            }
                        },
                                                 {
                            29, 
                            new OptimizerLevelPosition {
                                X = 390,
                                Y = 437,
                                W = 46,
                                H = 40
                            }
                        },
                                                 {
                            30, 
                            new OptimizerLevelPosition {
                                X = 361,
                                Y = 251,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            31, 
                            new OptimizerLevelPosition {
                                X = 180,
                                Y = 176,
                                W = 46,
                                H = 40
                            }
                        },
                        {
                            32, 
                            new OptimizerLevelPosition {
                                X = 228,
                                Y = 23,
                                W = 46,
                                H = 40
                            }
                        },
                    }
                }
                }
        };
    }
}
