using System.Collections.Generic;
using Entitas;

public class DestroyEntitySystem : ICleanupSystem
{
    private IGroup<GameEntity> _destroyedGroup;
    private List<GameEntity> _destroyedCache = new List<GameEntity>();
    
    public DestroyEntitySystem(Contexts contexts)
    {
        _destroyedGroup = contexts.game.GetGroup(GameMatcher.Destroyed);
    }

    public void Cleanup()
    {
        _destroyedCache = _destroyedGroup.GetEntities(_destroyedCache);
        
        foreach (var entity in _destroyedCache)
        {
            entity.Destroy();
        }
    }
}
