using UnityEngine;

namespace CodeBase.Data.LevelProgress
{
    public interface ILevel
    {
        Transform PlayerSpawnPoint { get; }
        string Name { get; }

        void SetLevel(string name);
    }
}