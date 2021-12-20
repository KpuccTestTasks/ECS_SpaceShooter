using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class RenderSpriteSystem : ReactiveSystem<GameEntity>
{
    public RenderSpriteSystem(Contexts contexts) : base(contexts.game)
    { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.View);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasSprite;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.View.transform.localScale = Vector3.one;
            var image = entity.view.View.AddComponent<Image>();
            image.sprite = Resources.Load<Sprite>(entity.sprite.Name);
        }
    }
}
