using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private const string InitialPointTag = "InitialPoint";
        private const string PropsPositionTag = "PropsPoint";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IPlayerProgressService _playerProgressService;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine,
            SceneLoader sceneLoader,
            IGameFactory gameFactory,
            IPlayerProgressService playerProgressService)
        {
            _gameFactory = gameFactory;
            _playerProgressService = playerProgressService;
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(_playerProgressService.Level, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitGameWorld();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            GameObject hero = _gameFactory.CreateHero(GameObject.FindGameObjectWithTag(InitialPointTag));
            
            _gameFactory.CreateProps(GameObject.FindGameObjectWithTag(PropsPositionTag));
            
            _gameFactory.CreateHud();
            
            CameraFollow(hero);
        }

        private void CameraFollow(GameObject gameObject) => 
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(gameObject);
    }
}