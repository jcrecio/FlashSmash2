using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace ChangeMe
{

    /// <summary>
    /// Tipo principal del juego
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        public GameProgress CurrentProgress { get; set; }
        public int TotalMoves { get; set; }

        public bool LockExchangeScreens = true;

        public Square[] EmptySquares = { };
        public const int LevelsPerFase = 8;
        public const int EMPTY = 2;
        public const int SQUARE_LENGTH_FOR_8X8 = 58;
        public const int LAST_LEVEL = 32;
        public const int SIZE_SQUARE_FOR_3X4 = 92;
        public const int SCREEN_X_FOR_3X4 = 56;

        private int _STATE; // When we change the state we directly apply a fading
        public int STATE
        {
            get
            {
                return _STATE;
            }
            set
            {
                _STATE = value;
                fadingScreen = 0;
            }
        }

        public bool ScreenChange = true;

        //int mAlphaValue = 1;
        //int mFadeIncrement = 3;
        //double mFadeDelay = .035;

        public int fadingScreen { get; set; }
        public int rateFade { get; set; }

        public int MAX_POS_START_WORLD_MAP_Y = 1248;

        readonly GraphicsDeviceManager _graphics;
        public SpriteBatch spriteBatch { get; set; }

        SpriteFont myfont, myfont2, ItemsFont;

        Texture2D Background;
        Texture2D BackgroundBoard;

        // Level
        Texture2D SquareTextureOne; // normal square
        Texture2D SquareTextureZero; // normal square
        Texture2D SquareTextureTwo; // normal square

        Texture2D ReadyLevelSprite;
        Texture2D LockedLevelSprite;

        Texture2D OutliningStars; //texture to draw the time of the stars
        Texture2D OutliningStarsDisabled; //texture to draw the time of the stars

        private Texture2D Frame;

        Square SquareExploding;

        //Transition 0->1 and 1->0
        Texture2D[] TransitionsSpriteZeroToOne;
        Texture2D[] TransitionsSpriteOneToZero;
        //Transition settings
        int transitionStatus = 0;

        // Items texture
        Texture2D BombTexture, BombTextureEmpty;
        Texture2D FireTexture, FireTextureEmpty;
        Texture2D StarTexture, StarTextureEmpty;
        Texture2D StarTextureDark, StarTextureDarkEmpty;
        Texture2D RocketTexture, RocketTextureEmpty;
        Texture2D ThunderTexture, ThunderTextureEmpty;

        private Rectangle RecItemsContainer;

        //Endlevel
        Texture2D OrangeMessageTexture;
        Texture2D ResetTexture;

        Texture2D PathTexture;

        //Sounds
        SoundEffect soundEffect;
        SoundEffect soundOnestar;

        SoundEffect soundBackground;

        Rectangle backgroundRectangle;
        Rectangle backgroundBoardRectangle;

        Rectangle recOrangeMessage;
        Rectangle recReset;

        // stars
        Rectangle StarRectangle1;
        Rectangle StarRectangle2;
        Rectangle StarRectangle3;
        Texture2D StarTexture1, StarTextureGrey;
        Texture2D SideBarTexture;
        //Texture2D StarTexture2;
        //Texture2D StarTexture3;

        //World's stuff
        public World CurrentWorld { get; set; }
        Texture2D WorldTexture;
        Rectangle WorldRectangle;
        float touchLocation;
        TouchLocation touchWorld; //This is used in order to calculate the world position player
        Rectangle[] cacheLevelsPositions; //Array is used to get the touchable detection of each level faster

        int ScreenDistanceX, ScreenDistanceY;
        int LenghtScreen;
        bool dragging, onDrag, tooDragNoClick;

        private bool dragginItemThunder;

        // Level
        public Level CurrentLevel { get; set; }

        // Items
        public GameItem[] CurrentItems { get; set; }

        Texture2D OptionPlay;
        Texture2D OptionSettings;
        Texture2D OptionAbout;

        // Menu options
        Rectangle recPlay;
        Rectangle recSettings;
        Rectangle recAbout;

        private Rectangle StarsRectangle;

        // Decrement for current levels stars
        public int STARS_DECREMENT;

        public bool drawEnd = false; // Draw the info of the end level onto the level

        Square[] SquaresAdjacent;

        private int ItemPushed = -1;

        private int startXItems = 40;
        private int startYItems = 600;

        private Texture2D ItemTexturePushed;

        private bool gameOver = false;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // La velocidad de fotogramas predeterminada para Windows Phone es de 30 fps.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Amplía la duración de la batería con bloqueo.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Permite que el juego realice la inicialización que necesite para empezar a ejecutarse.
        /// Aquí es donde puede solicitar cualquier servicio que se requiera y cargar todo tipo de contenido
        /// no relacionado con los gráficos. Si se llama a base.Initialize, todos los componentes se enumerarán
        /// e inicializarán.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent se llama una vez por juego y permite cargar
        /// todo el contenido.
        /// </summary>
        protected override void LoadContent()
        {
            TouchPanel.EnabledGestures = GestureType.VerticalDrag | GestureType.HorizontalDrag;
            rateFade = 40;
            CurrentProgress = GameSettings.GetCurrentProgress();

            CurrentWorld = Worlds.SelectWorld[CurrentProgress.CurrentWorld];
            CurrentProgress.CurrentLevel = 33;
            LoadLevel(CurrentProgress.CurrentLevel);

            PathTexture = Content.Load<Texture2D>(string.Concat("Path/Camino", CurrentProgress.CurrentLevel));

            // Stars progress
            OutliningStars = Content.Load<Texture2D>("Stars/StarsBackground1");
            OutliningStarsDisabled = Content.Load<Texture2D>("Stars/StarsBackgroundDisabled");
            //OutliningStars.SetData(new Color[] { Color.Yellow });
            //OutliningImage = Content.Load<Texture2D>("starImage");
            ItemTexturePushed = new Texture2D(_graphics.GraphicsDevice, 67, 67);
            var data = new Color[67 * 67];
            for (var i = 0; i < data.Length; ++i) data[i] = Color.Red;
            ItemTexturePushed.SetData(data);
            //ItemTexturePushed.SetData(new Color[] { Color.Red });

            _graphics.PreferredBackBufferWidth = 480;
            _graphics.PreferredBackBufferHeight = 800;

            //worlds stuff
            LoadContentCurrentWorld(CurrentWorld);

            dragging = false;
            tooDragNoClick = false;
            touchLocation = MAX_POS_START_WORLD_MAP_Y;
            WorldRectangle = new Rectangle(0, (int)touchLocation, 480, 2048);

            _graphics.IsFullScreen = true;
            _graphics.SupportedOrientations = DisplayOrientation.Portrait;
            _graphics.ApplyChanges();

            // Crea un SpriteBatch nuevo para dibujar texturas.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            myfont = Content.Load<SpriteFont>("Myfont");
            myfont2 = Content.Load<SpriteFont>("Myfont2");
            ItemsFont = Content.Load<SpriteFont>("ItemsFont");
            // Cambiar sitios donde cargar, donde cargar estos por ej en cada lvl

            OrangeMessageTexture = Content.Load<Texture2D>("OrangeSign");
            ResetTexture = Content.Load<Texture2D>("reset");

            SideBarTexture = Content.Load<Texture2D>("SideBar");

            BombTexture = Content.Load<Texture2D>("Sprites/Items/ItemBomb");
            RocketTexture = Content.Load<Texture2D>("Sprites/Items/ItemRocket");
            FireTexture = Content.Load<Texture2D>("Sprites/Items/ItemFire");
            StarTexture = Content.Load<Texture2D>("Sprites/Items/ItemStar");
            StarTextureDark = Content.Load<Texture2D>("Sprites/Items/ItemStarDark");
            ThunderTexture = Content.Load<Texture2D>("Sprites/Items/ItemThunder");

            BombTextureEmpty = Content.Load<Texture2D>("Sprites/Items/ItemBombEmpty");
            RocketTextureEmpty = Content.Load<Texture2D>("Sprites/Items/ItemRocketEmpty");
            //FireTextureEmpty = Content.Load<Texture2D>("Sprites/Items/ItemFireEmpty");
            StarTextureEmpty = Content.Load<Texture2D>("Sprites/Items/ItemStarEmpty");
            StarTextureDarkEmpty = Content.Load<Texture2D>("Sprites/Items/ItemStarDarkEmpty");
            ThunderTextureEmpty = Content.Load<Texture2D>("Sprites/Items/ItemThunderEmpty");

            dragginItemThunder = false;

            RecItemsContainer = new Rectangle(startXItems, startYItems, 350, 70);

            StarTexture1 = Content.Load<Texture2D>("star");
            StarTextureGrey = Content.Load<Texture2D>("greystar");

            ReadyLevelSprite = Content.Load<Texture2D>("Sprites/Buttons/ReadyLevelSprite");
            LockedLevelSprite = Content.Load<Texture2D>("Sprites/Buttons/LockedLevelSprite");

            //jcrecio OutliningStars = Content.Load<Texture2D>("Sprites/OutliningStars");
            //UpperBar = Content.Load<Texture2D>("Sprites/Bar/TopBar");
            //BottomBar = Content.Load<Texture2D>("/Bar/BottomBar");
            Frame = Content.Load<Texture2D>("Frame");

            //ScreenDistanceX = GraphicsDevice.Viewport.Width / 17;
            //ScreenDistanceY = 60;
            ScreenDistanceX = 8;
            ScreenDistanceY = 100;

            LenghtScreen = GraphicsDevice.Viewport.Width - ScreenDistanceX * 2;
            
            int h = LenghtScreen / 2;

            backgroundRectangle = new Rectangle(0, 0, 480, 800);
            backgroundBoardRectangle = new Rectangle(8, ScreenDistanceY +0, 464, 464);

            OptionPlay = Content.Load<Texture2D>("Play");
            OptionSettings = Content.Load<Texture2D>("Settings");
            OptionAbout = Content.Load<Texture2D>("Credits");

            recPlay = new Rectangle(ScreenDistanceX, 10, LenghtScreen, h);
            recSettings = new Rectangle(ScreenDistanceX, 10 + h, LenghtScreen, h);
            recAbout = new Rectangle(ScreenDistanceX, 20 + 2 * h, LenghtScreen, h);

            recOrangeMessage = new Rectangle(ScreenDistanceX, GraphicsDevice.Viewport.Height / 2, LenghtScreen, h);
            recReset = new Rectangle(GraphicsDevice.Viewport.Width - 65, 2, 60, 60);

            int sx = recOrangeMessage.X + 25, sy = recOrangeMessage.Y + 120;

            StarRectangle1 = new Rectangle(sx, sy, 90, 90);
            StarRectangle2 = new Rectangle(sx + 120, sy, 90, 90);
            StarRectangle3 = new Rectangle(sx + 240, sy, 90, 90);

            StarsRectangle = new Rectangle(10, 10, 350, 90);

            soundEffect = Content.Load<SoundEffect>("pulsation");
            soundOnestar = Content.Load<SoundEffect>("onestar");

            // Loop main theme music
            soundBackground = Content.Load<SoundEffect>("maintheme");
            SoundEffectInstance instance = soundBackground.CreateInstance();
            instance.IsLooped = true;
            soundBackground.Play(0.7f, 0.0f, 0.0f);

            STATE = GameState.MENU;
            TotalMoves = 0;
        }

        /// <summary>
        /// UnloadContent se llama una vez por juego y permite descargar
        /// todo el contenido.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Permite al juego ejecutar lógica para, por ejemplo, actualizar el mundo,
        /// buscar colisiones, recopilar entradas y reproducir audio.
        /// </summary>
        /// <param name="gameTime">Proporciona una instantánea de los valores de tiempo.</param>
        protected override void Update(GameTime gameTime)
        {
            ButtonState bs = GamePad.GetState(PlayerIndex.One).Buttons.Back;

            var touch = TouchPanel.GetState().FirstOrDefault();
            
            bool pressed = touch.State == TouchLocationState.Pressed;
            bool released = touch.State == TouchLocationState.Released;

            // About transitions ---------------------------->
            if (fadingScreen < 255) fadingScreen += rateFade;
            
            switch (STATE)
            {
                #region MENU
                case GameState.MENU:
                    {
                        if (bs == ButtonState.Pressed)
                        {
                            GameSettings.Save(CurrentProgress);
                            Exit();
                        }
                        else if (touch.State == TouchLocationState.Pressed)
                        {
                            if (recPlay.Contains((int)touch.Position.X, (int)touch.Position.Y))
                            {
                                STATE = GameState.WORLD;
                                LockExchangeScreens = true;
                            }
                            else if (recSettings.Contains((int)touch.Position.X, (int)touch.Position.Y))
                            {
                                CurrentProgress.LevelsPuntuations = new Dictionary<int, int>();
                                CurrentProgress.CurrentLevel = 1;
                                GameSettings.SetCurrentProgress(CurrentProgress);
                                STATE = GameState.WORLD;
                                PathTexture = Content.Load<Texture2D>("Path/Camino1");
                            }
                            else if (recAbout.Contains((int)touch.Position.X, (int)touch.Position.Y))
                            {

                            }
                        }
                        DrawMenu(gameTime);
                        break;
                    }
                #endregion
                #region WORLD
                case GameState.WORLD:
                    {
                        if (bs == ButtonState.Pressed)
                        {
                            STATE = GameState.MENU;
                            break;
                        }
                        else
                        {
                            if (released)
                            {
                                if (!LockExchangeScreens)
                                {
                                    dragging = false;
                                    if (!tooDragNoClick)
                                    {
                                        int l = cacheLevelsPositions.Count();

                                        for (int i = 0; i < CurrentProgress.CurrentLevel; i++)
                                        {
                                            if (i < LAST_LEVEL)
                                            {
                                                if (cacheLevelsPositions[i].Contains((int)touch.Position.X,
                                                    (int)(touch.Position.Y + touchLocation)))
                                                {
                                                    STATE = GameState.LEVEL;
                                                    LoadLevel(i + 1);
                                                }
                                            }
                                        }
                                    }
                                    tooDragNoClick = false;
                                }
                                LockExchangeScreens = false;
                            }
                            else if (pressed)
                            {
                                onDrag = true;
                                dragging = true;
                            }

                            if (onDrag)
                            {
                                touchWorld = touch;
                                onDrag = false;
                            }
                            if (dragging)
                            {
                                float difference = (touch.Position.Y - touchWorld.Position.Y);
                                touchLocation -= difference;
                                if (touchLocation > MAX_POS_START_WORLD_MAP_Y) touchLocation = MAX_POS_START_WORLD_MAP_Y;
                                else if (touchLocation < 0) touchLocation = 0;
                                touchWorld = touch;
                                if (Math.Abs(difference) > 1) tooDragNoClick = true;
                            }

                            DrawWorld(gameTime);
                            break;
                        }
                    }
                #endregion
                #region LEVEL
                case GameState.LEVEL:
                    {
                        if (bs == ButtonState.Pressed)
                        {
                            STATE = GameState.WORLD;
                        }
                        else if (touch.State == TouchLocationState.Pressed)
                        {
                            int pushX = ((int)touch.Position.X - ScreenDistanceX) / CurrentLevel.SizeSquare,
                                pushY = ((int)touch.Position.Y - ScreenDistanceY) / CurrentLevel.SizeSquare;

                            var tappedPoint = new Point
                            {
                                X = (int) touch.Position.X,
                                Y = (int) touch.Position.Y
                            };

                            if ((pushX >= 0) && (pushX < CurrentLevel.X) && (pushY >= 0) && (pushY < CurrentLevel.Y))
                            {
                                SquareExploding = CurrentLevel.squares[pushX, pushY];
                                if (ItemPushed != -1)
                                {
                                    if ((ItemPushed == 0) && (SquareExploding.Content < 2))
                                    {
                                        transitionStatus = 4;
                                        soundEffect.Play();
                                        SquareExploding.RecentChanged = true;
                                        SquareExploding.Switch();
                                        CurrentLevel.moves++;
                                        CurrentProgress.GameItems[ItemPushed].Substract();
                                        ItemPushed = -1;

                                        if (CurrentLevel.IsLevelCompleted(1))
                                        {
                                            ActionsWhenLevelCompleted();
                                        }
                                    }
                                    else if (ItemPushed == 1)
                                    {
                                        transitionStatus = 4;
                                        soundEffect.Play();
                                        var squareList = CurrentLevel.Get5X5AreaSquares(pushX, pushY);
                                        ExplodeSquareList(squareList, false);
                                        CurrentProgress.GameItems[ItemPushed].Substract();
                                        ItemPushed = -1;

                                        if (CurrentLevel.IsLevelCompleted(1))
                                        {
                                            ActionsWhenLevelCompleted();
                                        }
                                    }
                                    else if (ItemPushed == 5)
                                    {
                                        dragginItemThunder = true;
                                    }
                                }
                                else
                                {
                                    if (SquareExploding.Content < 2)
                                    {
                                        transitionStatus = 4;

                                        var squareList = CurrentLevel.GetSquareAndAdjacent(pushX, pushY);

                                        ExplodeSquareList(squareList, true);
                                    }
                                }
                            }
                            if (RecItemsContainer.Contains(tappedPoint))
                            {
                                var relativePushed = (tappedPoint.X - startXItems) / 80;
                                ItemPushed = (ItemPushed != relativePushed) &&
                                             (CurrentProgress.GameItems[relativePushed].Amount > 0)
                                    ? relativePushed
                                    : -1;
                            }
                            else if (recReset.Contains(tappedPoint))
                            {
                                CurrentLevel = SetCurrentLevel(Levels.Level[CurrentLevel.LevelNumber]);
                            }
                            else if (StarsRectangle.Contains(tappedPoint))
                            {
                                if (ItemPushed == 2)
                                {
                                    if (CurrentLevel.ONE_STAR > CurrentLevel.moves)
                                    {
                                        CurrentLevel.moves = 0;
                                    }
                                    else if (CurrentLevel.TWO_STAR > CurrentLevel.moves)
                                    {
                                        CurrentLevel.moves = CurrentLevel.ONE_STAR / 2;
                                    }
                                    else if (CurrentLevel.TWO_STAR == CurrentLevel.moves)
                                    {
                                        CurrentLevel.moves = 0;
                                    }
                                    else if (CurrentLevel.THREE_STAR > CurrentLevel.moves)
                                    {
                                        CurrentLevel.moves = CurrentLevel.TWO_STAR / 2;
                                    }
                                    else if (CurrentLevel.THREE_STAR == CurrentLevel.moves)
                                    {
                                        CurrentLevel.moves = CurrentLevel.ONE_STAR;
                                    }
                                    CurrentProgress.GameItems[ItemPushed].Substract();
                                    ItemPushed = -1;
                                }
                                else if (ItemPushed == 3)
                                {
                                    if (CurrentLevel.ONE_STAR > CurrentLevel.moves)
                                    {
                                        CurrentLevel.moves = 0;
                                    }
                                    else if (CurrentLevel.TWO_STAR > CurrentLevel.moves)
                                    {
                                        CurrentLevel.moves = CurrentLevel.ONE_STAR;
                                    }
                                    else if (CurrentLevel.TWO_STAR == CurrentLevel.moves)
                                    {
                                        CurrentLevel.moves = 0;
                                    }
                                    else if (CurrentLevel.THREE_STAR > CurrentLevel.moves)
                                    {
                                        CurrentLevel.moves = CurrentLevel.TWO_STAR;
                                    }
                                    else if (CurrentLevel.THREE_STAR == CurrentLevel.moves)
                                    {
                                        CurrentLevel.moves = CurrentLevel.ONE_STAR;
                                    }
                                    CurrentProgress.GameItems[ItemPushed].Substract();
                                    ItemPushed = -1;
                                }
                            }
                        }
                        if (transitionStatus > 0) transitionStatus--;
                        else
                        {
                            SquareExploding = null;
                            SquaresAdjacent = EmptySquares;
                        }
                        DrawLevel(gameTime);
                        break;
                    }
                #endregion
                #region ENDLEVEL
                case GameState.ENDLEVEL:
                    {
                        if (bs == ButtonState.Pressed || touch.State == TouchLocationState.Released)
                        {
                            if (ScreenChange)
                            {
                                ScreenChange = false;
                            }
                            else
                            {
                                if (!gameOver)
                                {
                                    if (CurrentProgress.CurrentLevel < CurrentLevel.LevelNumber)
                                    {
                                        TotalMoves += CurrentLevel.moves;
                                        var next = CurrentLevel.LevelNumber + 1;
                                        SetCurrentLevel(Levels.Level[next]);
                                    }
                                }
                                STATE = GameState.WORLD;
                                gameOver = false;
                                drawEnd = false;
                            }
                        }
                        else
                        {

                        }
                        DrawLevel(gameTime);
                        break;
                    }
            }
            #endregion
            base.Update(gameTime);
        }

        private Level SetCurrentLevel(MatrixLevel ml)
        {
            if (ml.level < 25)
            {
                return new Level(
                    ml.level, ml.x, ml.y,
                    GraphicsDevice.Viewport.Width, ml.SquaresToLevelCompleted,
                    ScreenDistanceX, ScreenDistanceY,
                    ml.onestar, ml.twostar, ml.threestar,
                    ml.fase, -1);
            }
            return new Level(
                ml.level, ml.x, ml.y,
                GraphicsDevice.Viewport.Width, ml.SquaresToLevelCompleted,
                SCREEN_X_FOR_3X4, ScreenDistanceY + 2,
                ml.onestar, ml.twostar, ml.threestar,
                ml.fase, 92);
        }

        private void ExplodeSquareList(List<Square> squareList, bool revert)
        {
            if (squareList.Count > 0)
            {
                SquaresAdjacent = squareList.ToArray();
                foreach (var square in SquaresAdjacent)
                {
                    square.RecentChanged = true;
                    if (revert) square.Switch();
                    else if (square.Content.Equals(0)) square.Switch();
                }
                soundEffect.Play();
                CurrentLevel.moves++;

                if (CurrentLevel.IsLevelCompleted(1))
                {
                    ActionsWhenLevelCompleted();
                }
                else if (CurrentLevel.moves > CurrentLevel.THREE_STAR)
                {
                    STATE = GameState.ENDLEVEL;
                    ScreenChange = true;
                    drawEnd = true;
                    gameOver = true;
                }
            }
        }

        protected void ActionsWhenLevelCompleted()
        {
            soundOnestar.Play();

            STATE = GameState.ENDLEVEL;
            ScreenChange = true;

            if (CurrentLevel.moves > CurrentLevel.TWO_STAR)
            {
                CurrentLevel.STARS_OBTAINED = 1;
                CurrentProgress.LevelsPuntuations[CurrentLevel.LevelNumber] = 1;
            }
            else if (CurrentLevel.moves <= CurrentLevel.ONE_STAR)
            {
                CurrentLevel.STARS_OBTAINED = 3;
                CurrentProgress.LevelsPuntuations[CurrentLevel.LevelNumber] = 3;
            }
            else
            {
                CurrentLevel.STARS_OBTAINED = 2;
                CurrentProgress.LevelsPuntuations[CurrentLevel.LevelNumber] = 2;
            }

            // Save the progress
            if (CurrentProgress.CurrentLevel <= CurrentLevel.LevelNumber)
            {
                CurrentProgress.CurrentLevel++;
            }

            GameSettings.Save(CurrentProgress);
            PathTexture = Content.Load<Texture2D>(string.Concat("Path/Camino", CurrentProgress.CurrentLevel));
            drawEnd = true;
        }

        protected void DrawMenu(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(OptionPlay, recPlay, new Color(255, 255, 255, fadingScreen));
            //spriteBatchForEnd.Draw(OptionSettings, recSettings, new Color(255, 255, 255, fadingScreen));
            spriteBatch.Draw(OptionAbout, recAbout, new Color(255, 255, 255, fadingScreen));
            spriteBatch.DrawString(myfont, "REINICIAR PARTIDACA",
                   new Vector2(100,300), new Color(255, 0, 0, fadingScreen));
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawWorld(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            int startYscreen = (int)touchLocation;

            spriteBatch.Draw(WorldTexture, new Rectangle(0, -startYscreen, 480, 2048)
                , new Color(255, 255, 255, fadingScreen));
            spriteBatch.Draw(PathTexture, new Rectangle(0, -startYscreen, 480, 2048)
                , new Color(255, 255, 255, fadingScreen));
            //spriteBatchForEnd.Draw(WorldTexture, new Rectangle(0, -startYscreen, 480, 2048)
            //    , new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255)));

            int xItems = 10, yItems = 10;
            foreach (var item in CurrentProgress.GameItems)
            {
                if (item.Amount > 0)
                {
                    spriteBatch.Draw(GetGraphicItem(item.ItemType, 1), new Rectangle(xItems, yItems, 30, 30), Color.White);
                    xItems += 35;
                }
            }

            var positionsInRange = CurrentWorld.PositionLevels
                .Where(rd => rd.Value.Y >= (startYscreen - 100) && rd.Value.Y <= (startYscreen + 900));

            foreach (var worldLevel in positionsInRange)
            {
                int x1 = worldLevel.Value.X;
                int x2;
                if (worldLevel.Key < 10) x2 = worldLevel.Value.X + 15;
                else x2 = worldLevel.Value.X + 10;
                int y = (worldLevel.Value.Y - startYscreen), key = worldLevel.Key;
                bool locked = CurrentProgress.CurrentLevel < key;
                //Level completed, enable to play or disable should have different sprites
                Rectangle r = new Rectangle((int)x1, (int)y, 46, 40);
                
                Color textLevelColor;

                if (locked)
                {
                    //spriteBatchForEnd.Draw(LockedLevelSprite, r, null, new Color(255, 255, 255, fadingScreen), 0, Vector2.Zero, SpriteEffects.None, 0.9f);
                    textLevelColor = new Color(255, 255, 255, fadingScreen);
                }
                else
                {
                    textLevelColor = new Color(255, 0, 0, fadingScreen);
                }

                spriteBatch.DrawString(myfont, key.ToString(),
                    new Vector2(worldLevel.Key > 9 ? x2 - 5: x2, y - 2), textLevelColor);
                x1 -= 5;
                if (CurrentProgress.LevelsPuntuations.ContainsKey(worldLevel.Key))
                {
                    int stars = CurrentProgress.LevelsPuntuations[worldLevel.Key];
                    int y_;
                    Texture2D starRef;
                    for (int i = 0; i < 3; i++)
                    {
                        if (i < stars) starRef = StarTexture1;
                        else starRef = StarTextureGrey;
                        if (i == 1)
                        {
                            y_ = y + 5;
                        }
                        else y_ = y;
                        spriteBatch.Draw(starRef, new Rectangle(x1 + i * 20, y_ + 20, 15, 15), new Color(255, 255, 255, fadingScreen));
                    }
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawLevel(GameTime gameTime) // crear sobrecarga guachi para evitar begins ends
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var colorForNow = new Color(255, 255, 255, fadingScreen);

            spriteBatch.Begin();


            spriteBatch.Draw(Background, backgroundRectangle, colorForNow);


            if((CurrentLevel.LevelNumber==1)||(CurrentLevel.LevelNumber >= 9)&&(CurrentLevel.LevelNumber <= 23))
            {
                spriteBatch.Draw(BackgroundBoard, backgroundBoardRectangle, colorForNow);
            }

            // Drawing star progress
            if (CurrentLevel.moves < 100)
            {
                double totalMovs = CurrentLevel.THREE_STAR;
                double qForOneMov = 100 / totalMovs;

                double qForOnePixel = 2.8 * qForOneMov;
                double qToSubstract = qForOnePixel*(CurrentLevel.moves + 1);

                spriteBatch.Draw(OutliningStarsDisabled,

                    new Rectangle(15, 7, 280, 92),
                    colorForNow);

                spriteBatch.Draw(OutliningStars,

                    new Rectangle(15, 7, (int)(280 - qToSubstract), 92),
                    colorForNow);
            }

            spriteBatch.Draw(Frame, new Vector2(0,0), Color.White);

            // Items
            var posXItem = startXItems;
            var items = CurrentProgress.GameItems;
            foreach (var item in items)
            {
                if (ItemPushed.Equals(item.ItemType) && (item.Amount > 0))
                {
                    spriteBatch.Draw(ItemTexturePushed, new Rectangle(posXItem - 2, startYItems - 2, 69, 69), Color.White);
                }
                spriteBatch.DrawString(ItemsFont, item.Amount.ToString(CultureInfo.InvariantCulture), new Vector2(posXItem + 55, startYItems + 60), Color.Red);

                spriteBatch.Draw(GetGraphicItem(item.GetItemType, item.Amount),
                    new Rectangle(posXItem, startYItems, 65, 65), colorForNow);
                posXItem += 80;
            }

            // Drawing the squares
            if (!drawEnd)
            {
                foreach (var square in CurrentLevel.squares)
                {
                    if (square.Content < 3)
                    {
                        if (square.Content == 2)
                        {
                            spriteBatch.Draw(SquareTextureTwo, square.rectangle, colorForNow);
                        }
                        if (transitionStatus > 0)
                        {
                            if (square.Content == 0)
                            {
                                spriteBatch.Draw(
                                    !SquaresAdjacent.Contains(square)
                                        ? SquareTextureZero
                                        : TransitionsSpriteOneToZero[transitionStatus], square.rectangle, colorForNow);
                            }
                            else
                            {
                                if (SquareExploding == square)
                                {
                                    spriteBatch.Draw(TransitionsSpriteZeroToOne[transitionStatus], square.rectangle,
                                        colorForNow);
                                }
                                else
                                {
                                    spriteBatch.Draw(
                                        !SquaresAdjacent.Contains(square)
                                            ? SquareTextureOne
                                            : TransitionsSpriteZeroToOne[transitionStatus], square.rectangle,
                                        colorForNow);
                                }
                            }
                        }
                        else
                        {
                            spriteBatch.Draw(square.Content == 0 ? SquareTextureZero : SquareTextureOne,
                                square.rectangle, colorForNow);
                        }
                    }
                }
            }
            else
            {
                DrawEndGame(spriteBatch, gameOver);
            }

            spriteBatch.Draw(ResetTexture, recReset, Color.White);
           
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private Texture2D GetGraphicItem(int getItemType, int status)
        {
            switch (getItemType)
            {
                case 0:
                {
                    return status != 0 ? BombTexture: BombTextureEmpty;
                }
                case 1:
                {
                    return status != 0 ? RocketTexture: RocketTextureEmpty;
                }
                case 2:
                {
                    return status != 0 ? StarTexture: StarTextureEmpty;
                }
                case 3:
                {
                    return status != 0 ? StarTextureDark: StarTextureDarkEmpty;
                }
                case 4:
                {
                    return status != 0 ? ThunderTexture: StarTextureDarkEmpty;
                }
                default:
                    return status != 0 ? ThunderTexture : ThunderTextureEmpty;
            }
        }

        public void DrawEndGame(SpriteBatch spriteBatchForEnd, bool isGameOver)
        {
            if (isGameOver)
            {
                spriteBatchForEnd.Draw(OrangeMessageTexture, recOrangeMessage, new Color(255, 255, 255, fadingScreen));
                spriteBatchForEnd.DrawString(myfont2, "You've failed!", new Vector2(recOrangeMessage.X + 15, recOrangeMessage.Y + 10),
                   new Color(0, 255, 0, fadingScreen)); 
                return;
            }
            spriteBatchForEnd.Draw(OrangeMessageTexture, recOrangeMessage, new Color(255, 255, 255, fadingScreen));
            spriteBatchForEnd.DrawString(myfont2, "Level " + CurrentLevel.LevelNumber + "\ncompleted! ", new Vector2(recOrangeMessage.X + 15, recOrangeMessage.Y + 10),
               new Color(0, 255, 0, fadingScreen));
            spriteBatchForEnd.Draw(StarTexture1, StarRectangle1, new Color(255, 255, 255, fadingScreen));
            if (CurrentLevel.STARS_OBTAINED > 1)
            {
                spriteBatchForEnd.Draw(StarTexture1, StarRectangle2, new Color(255, 255, 255, fadingScreen));
                if (CurrentLevel.STARS_OBTAINED == 3)
                {
                    spriteBatchForEnd.Draw(StarTexture1, StarRectangle3, new Color(255, 255, 255, fadingScreen));
                }
            }
        }

        #region Functions

        public void LoadLevel(int numberLevel)
        {
            if (numberLevel <= LAST_LEVEL)
            {
                MatrixLevel ml = Levels.Level[numberLevel];
                CurrentLevel = SetCurrentLevel(ml);
                STARS_DECREMENT = 270 / ml.threestar;
                LoadContentCurrentLevel(CurrentLevel);
            }
        }

        public void LoadContentCurrentWorld(World world)
        {
            cacheLevelsPositions = new Rectangle[world.PositionLevels.Count];

            int i = 0;

            WorldTexture = Content.Load<Texture2D>(string.Concat(@"Worlds/World", CurrentWorld.WorldNumber));
            foreach (var recTexture in world.PositionLevels)
            {
                //recTexture.Value.Texture = Content.Load<Texture2D>(string.Concat("Level", recTexture.Key.ToString()));
                cacheLevelsPositions[i] = new Rectangle(recTexture.Value.X, recTexture.Value.Y, recTexture.Value.W, recTexture.Value.H);
                i++;
            }
        }

        public void LoadContentCurrentLevel(Level level)
        {
            int fase = level.fase;
            string fasePath = string.Concat("Fase", fase, "/");

            Background = Content.Load<Texture2D>(string.Concat(fasePath, "background"));

            backgroundRectangle = level.fase < 4 ? new Rectangle(0, 0, 480, 800) : new Rectangle(8, 100, 464, 464);

            if ((level.LevelNumber==1)||((level.LevelNumber >= 9) && level.LevelNumber <= 23))
            {
                BackgroundBoard = Content.Load<Texture2D>(string.Concat("LevelBackgrounds/Level", level.LevelNumber));
            }
            CurrentItems = CurrentProgress.GameItems;

            SetTransitions(fase, fasePath, 5, 5);
        }

        private void SetTransitions(int fase, string fasePath, int lenghtToOne, int lengthToZero)
        {
            TransitionsSpriteZeroToOne = new Texture2D[lenghtToOne];
            TransitionsSpriteOneToZero = new Texture2D[lengthToZero];
            SquareTextureZero = Content.Load<Texture2D>(string.Concat("Fase", fase, "/Zero"));
            SquareTextureOne = Content.Load<Texture2D>(string.Concat("Fase", fase, "/One"));
            SquareTextureTwo = Content.Load<Texture2D>(string.Concat("Fase", fase, "/Two"));

            for (var i = 1; i < lenghtToOne; i++)
            {
                TransitionsSpriteZeroToOne[i] =
                    Content.Load<Texture2D>(string.Concat(fasePath, "TransitionToOne/acerouno", lenghtToOne - i));
            }

            for (var i = 1; i < lengthToZero; i++)
            {
                TransitionsSpriteOneToZero[i] =
                    Content.Load<Texture2D>(string.Concat(fasePath, "TransitionToZero/aunocero", lengthToZero - i));
            }
        }

        #endregion
    }
}
