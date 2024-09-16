using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class PlayerProgressService : IPlayerProgressService
    {
        private const string ProgressKey = "Progress";
        private const string FirstLevel = "Level1";

        public int Money { get; private set; }
        public string Level { get; private set; }

        public PlayerProgressService()
        {
            Load();
        }

        public void Save(string levelName, int money)
        {
            Level = levelName;
            Money = money;
            
            PlayerPrefs.SetString(ProgressKey, Level);
            PlayerPrefs.SetInt(ProgressKey, Money);
        }

        public void Load()
        {
            if (PlayerPrefs.GetString(ProgressKey) == String.Empty)
                Level = FirstLevel;
            else
                Level = PlayerPrefs.GetString(ProgressKey);
            
            Money = PlayerPrefs.GetInt(ProgressKey);
        }
    }
}