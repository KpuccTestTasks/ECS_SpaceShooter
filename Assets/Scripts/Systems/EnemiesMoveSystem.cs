using System.Collections.Generic;
using Entitas;

public class EnemiesMoveSystem : IExecuteSystem
{
    private IGroup<GameEntity> _enemies;
    private List<GameEntity> _enemiesCache = new List<GameEntity>();
    private ITimeService _timeService;

    public EnemiesMoveSystem(Contexts contexts)
    {
        _enemies = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.View, GameMatcher.MoveSpeed, GameMatcher.Position));
        _timeService = contexts.meta.timeService.TimeService;
    }
    
    public void Execute()
    {
        if (_enemies == null)
            return;
        
        _enemiesCache = _enemies.GetEntities(_enemiesCache);
        float timeDelta = _timeService.GetFrameTime();

        foreach (var entity in _enemiesCache)
        {
            var newPositionY = entity.position.PositionY - entity.moveSpeed.Value * timeDelta;

            if (newPositionY < -500)
            {
                entity.isDestroyed = true;
                continue;
            }
            
            entity.ReplacePosition(entity.position.PositionX, newPositionY);
        }
    }
}
