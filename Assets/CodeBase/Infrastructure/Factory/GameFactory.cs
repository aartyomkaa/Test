using System;
using CodeBase.Infrastructure.AssetManagment;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        
        public GameObject HeroGameObject { get; private set; }
        public GameObject Props { get; private set; }

        public event Action HeroCreated;
        
        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at)
        {
            HeroGameObject = Instantiate(AssetPath.Hero, at.transform.position);
            HeroCreated?.Invoke();
            return HeroGameObject;
        }

        public GameObject CreateProps(GameObject at)
        {
            Props = Instantiate(AssetPath.Props, at.transform.position);
            return Props;
        }

        public void CreateHud() =>
            Instantiate(AssetPath.Hud);

        private GameObject Instantiate(string assetPath, Vector3 at)
        {
            GameObject hero = _assets.InstantiateAt(assetPath, at);
            return hero;
        }
        private GameObject Instantiate(string assetPath)
        {
            GameObject hud = _assets.Instantiate(assetPath);
            return hud;
        }
    }
}