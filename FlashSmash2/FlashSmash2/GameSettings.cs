using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework;

namespace ChangeMe
{

    public static class GameSettings
    {
        public static object EmptySetting = null;
        public static string CurrentProgress = "CurrentProgress";
        public static string File = "currentprogress.dat";

        public static void SetCurrentProgress(GameProgress gameProgress)
        {
            SetSetting(CurrentProgress, gameProgress);
        }

        //public static void SetCurrentProgress(GameProgress gameProgress)
        //{
        //    var iss = IsolatedStorageSync.GetInstance();
        //    iss.SaveGame(File, gameProgress);
        //}

        //public static GameProgress GetCurrentProgress()
        //{
        //    GameProgress gp;
        //    var iss = IsolatedStorageSync.GetInstance();
        //    if(iss!=null) return iss.LoadGame(File);
        //    var defaultItems = new[]
        //    {
        //        new GameItem(0,1),
        //        new GameItem(1,1),
        //        new GameItem(2,1),
        //        new GameItem(3,1),
        //        new GameItem(4,1)
        //    };

        //    var defaultStartGameProgress = new GameProgress
        //    {
        //        CurrentLevel = 1,
        //        CurrentWorld = 1,
        //        TotalMoves = 0,
        //        LevelsPuntuations = new Dictionary<int, int>
        //                {
        //                   { 1, 0 }
        //                },
        //        GameItems = defaultItems
        //    };

        //    SetCurrentProgress(defaultStartGameProgress);

        //    return defaultStartGameProgress;
        //}

        public static GameProgress GetCurrentProgress()
        {
            GameProgress gp;
            IsolatedStorageSettings.ApplicationSettings.TryGetValue(CurrentProgress, out gp);
            if (gp != null) return gp;

            var defaultItems = new[]
            {
                new GameItem(0,Int32.MaxValue),
                new GameItem(1,1),
                new GameItem(2,1),
                new GameItem(3,1),
                new GameItem(4,1)
            };

            var defaultStartGameProgress = new GameProgress
            {
                CurrentLevel = 1,
                CurrentWorld = 1,
                TotalMoves = 0,
                LevelsPuntuations = new Dictionary<int, int>
                        {
                           { 1, 0 }
                        },
                GameItems = defaultItems
            };

            SetSetting(CurrentProgress, defaultStartGameProgress);

            return defaultStartGameProgress;
        }

        public static void SetSetting(string setting, GameProgress value)
        {
            IsolatedStorageSettings.ApplicationSettings[setting] = value;
        }
        public static void Save(GameProgress value)
        {
            Save(CurrentProgress, value);
        }
        public static void Save(string setting, GameProgress value)
        {
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        public static void AddSetting(string setting, GameProgress value)
        {
            IsolatedStorageSettings.ApplicationSettings.Add(setting, value);
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        public static GameProgress GetSetting(string setting)
        {
            return (GameProgress)(IsolatedStorageSettings.ApplicationSettings[setting]);
        }
    }
}
