using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;
        
        private readonly IPlayerProgressService _playerProgressService;

        public LoadProgressState(GameStateMachine stateMachine, IPlayerProgressService playerProgressService)
        {
            _stateMachine = stateMachine;
            _playerProgressService = playerProgressService;
        }

        public void Enter()
        {
            LoadProgress();
            
            _stateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {

        }

        private void LoadProgress() => 
            _playerProgressService.Load();
    }
}