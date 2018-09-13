using System.Collections.Generic;
using System.IO.IsolatedStorage;

namespace ChangeMe
{
    public static class IGameSettings
    {
        public static object EmptySetting = null;
        public static string CurrentProgress = "CURRENT_PROGRESS";

        public static void SetCurrentProgress(GameProgress gameProgress)
        {
            SetSetting(CurrentProgress, gameProgress);
        }

        public static GameProgress GetCurrentProgress()
        {
            var defaultItems = new GameItem[]
            {
                new GameItem(0,1),
                new GameItem(1,0),
                new GameItem(2,0),
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

            if (!IsolatedStorageSettings.ApplicationSettings.Contains(CurrentProgress))
            {
                SetSetting(CurrentProgress, defaultStartGameProgress);
            }
            else
            {
                var gp = (GameProgress)IsolatedStorageSettings.ApplicationSettings[CurrentProgress];
                if (gp != null) defaultStartGameProgress = gp;
            }
            if (defaultStartGameProgress.GameItems == null)
            {
                defaultStartGameProgress.GameItems = defaultItems;
            }
            return defaultStartGameProgress;
        }

        public static void SetSetting(string setting, object value)
        {
            IsolatedStorageSettings.ApplicationSettings[setting] = value;
        }

        public static object GetSetting(string setting)
        {
            return IsolatedStorageSettings.ApplicationSettings[setting];
        }
    }
}