using System;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject HeroGameObject { get; }
        GameObject Props { get; }

        event Action HeroCreated;
        
        GameObject CreateHero(GameObject at);
        void CreateHud();
        GameObject CreateProps(GameObject at);
    }
}