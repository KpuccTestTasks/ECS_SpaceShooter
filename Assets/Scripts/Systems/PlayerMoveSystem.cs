using System.Collections.Generic;
using Entitas;

public class PlayerMoveSystem : IExecuteSystem
{
    private GameContext _gameContext;
    private InputContext _inputContext;
    private IGroup<GameEntity> _playerGroup;
    private List<GameEntity> _playerCache = new List<GameEntity>();
    private ITimeService _timeService;
    
    public PlayerMoveSystem(Contexts contexts, ITimeService timeService)
    {
        _gameContext = contexts.game;
        _inputContext = contexts.input;
        _timeService = timeService;
    }
    
    public void Execute()
    {
        _playerGroup = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.MoveSpeed, GameMatcher.Position));
        
        if (_playerGroup == null)
            return;

        float deltaTime = _timeService.GetFrameTime();

        _playerCache = _playerGroup.GetEntities(_playerCache);

        foreach (var player in _playerCache)
        {
            float positionDelta = deltaTime * player.moveSpeed.Value;
            float resultPositionDelta = 0f;

            if (_inputContext.moveLeftButtonEntity.isButtonDown)
                resultPositionDelta -= positionDelta;
            
            if (_inputContext.moveRightButtonEntity.isButtonDown)
                resultPositionDelta += positionDelta;

            if (resultPositionDelta == 0)
                continue;
            
            player.ReplacePosition(resultPositionDelta + player.position.PositionX, player.position.PositionY);
        }
    }
}
