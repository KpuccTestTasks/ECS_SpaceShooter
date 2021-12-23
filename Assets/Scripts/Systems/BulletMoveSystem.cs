using System.Collections.Generic;
using Entitas;

public class BulletMoveSystem : IExecuteSystem
{
    private MetaContext _metaContext;
    private IGroup<GameEntity> _bulletEntities;
    private List<GameEntity> _bulletsCache = new List<GameEntity>();

    public BulletMoveSystem(Contexts contexts)
    {
        _bulletEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Bullet, GameMatcher.MoveSpeed, GameMatcher.View, GameMatcher.Position).NoneOf(GameMatcher.Destroyed));
        _metaContext = contexts.meta;
    }
    
    public void Execute()
    {
        _bulletsCache = _bulletEntities.GetEntities(_bulletsCache);
        float frameTime = _metaContext.timeService.TimeService.GetFrameTime();

        foreach (var bulletEntity in _bulletsCache)
        {
            float moveSpeed = bulletEntity.moveSpeed.Value;
            float positionDelta = frameTime * moveSpeed;
            
            bulletEntity.ReplacePosition(bulletEntity.position.PositionX, bulletEntity.position.PositionY + positionDelta);
        }
    }
}
