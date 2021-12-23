using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderMoveSystem : ReactiveSystem<GameEntity>
{
    public RenderMoveSystem(Contexts contexts) : base(contexts.game)
    { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.View, GameMatcher.Position));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasPosition && !entity.isDestroyed;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            RectTransform entityTransform = entity.view.View.GetComponent<RectTransform>();
            entityTransform.anchoredPosition = new Vector2(entity.position.PositionX, entity.position.PositionY);
        }
    }
}
