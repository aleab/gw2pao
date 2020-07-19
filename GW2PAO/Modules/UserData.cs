using Microsoft.Practices.Prism.Mvvm;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace GW2PAO.Data.UserData
{
    /// <summary>
    /// Base class for user data classes
    /// </summary>
    /// <typeparam name="T">Type of user data class, used when loading/saving the data</typeparam>
    public class UserData<T> : BindableBase
    {
        /// <summary>
        /// Default logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The default settings directory
        /// </summary>
        public static string DataDirectory => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? Path.GetFullPath("."), "UserData");

        /// <summary>
        /// Enables auto-save of settings. If called, whenever a setting is changed, this settings object will be saved to disk
        /// </summary>
        public virtual void EnableAutoSave()
        {
        }

        /// <summary>
        /// Loads the user settings
        /// </summary>
        /// <returns>The loaded settings, or null if the load fails</returns>
        public static T LoadData(string fileName)
        {
            logger.Debug("Loading user settings");

            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            object loadedSettings = null;

            string fullPath = Path.Combine(DataDirectory, fileName);
            try
            {
                lock (fullPath)
                {
                    if (File.Exists(fullPath))
                    {
                        using (TextReader reader = new StreamReader(fullPath))
                        {
                            loadedSettings = deserializer.Deserialize(reader);
                        }
                    }
                }

                if (loadedSettings == null)
                    return default(T);

                logger.Info("Settings successfully loaded");
                return (T)loadedSettings;
            }
            catch (Exception ex)
            {
                logger.Warn(ex, "Unable to load user settings! Exception: ");
                return default(T);
            }
        }

        /// <summary>
        /// Saves the user settings
        /// </summary>
        /// <param name="settings">The user settings to save</param>
        public static void SaveData(T settings, string fileName)
        {
            logger.Debug("Saving user data");
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            if (!Directory.Exists(DataDirectory))
                Directory.CreateDirectory(DataDirectory);

            string fullPath = Path.Combine(DataDirectory, fileName);
            try
            {
                lock (UserData.GetLock(fullPath))
                {
                    using (TextWriter writer = new StreamWriter(fullPath))
                    {
                        serializer.Serialize(writer, settings);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex, "Unable to save user settings! Exception: ");
            }
        }
    }

    public static class UserData
    {

        private static readonly Dictionary<string, object> FileLocks = new Dictionary<string, object>();

        public static object GetLock(string filepath)
        {
            if (!FileLocks.ContainsKey(filepath))
                FileLocks[filepath] = new object();
            return FileLocks[filepath];
        }
    }
}
