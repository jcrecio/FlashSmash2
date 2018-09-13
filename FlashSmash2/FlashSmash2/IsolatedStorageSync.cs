using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ChangeMe
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Linq;
    using System.Xml.Serialization;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;

    public class IsolatedStorageSync
    {
        protected static IsolatedStorageSync Instance = null;

        public static IsolatedStorageSync GetInstance()
        {
            return Instance ?? new IsolatedStorageSync();
        }

        private IsolatedStorageSync(){}

        public void SaveGame(string filePath, GameProgress gameProgress)
        {
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            if (store.FileExists(filePath))
            {
                store.DeleteFile(filePath);
            }
            store.CreateFile(filePath);

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(GameProgress));

            using (var stream = new IsolatedStorageFileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, store))
            {
                serializer.Serialize(stream, gameProgress);
            }
        }

        public GameProgress LoadGame(string filePath)
        {
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            GameProgress gp = null;

            if (store.FileExists(filePath))
            {
                using (var stream = new IsolatedStorageFileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, store))
                {
                    var serializer = new XmlSerializer(typeof(GameProgress));
                    gp = (GameProgress)serializer.Deserialize(stream);

                }
            }
            return gp;
        }
    }
}
