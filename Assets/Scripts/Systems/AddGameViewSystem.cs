using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class AddGameViewSystem : ReactiveSystem<GameEntity>
{
    private Transform _viewsParent;

    public AddGameViewSystem(Contexts contexts, Transform viewsParent) : base(contexts.game)
    {
        _viewsParent = viewsParent;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var go = new GameObject("View");
            var unityView = go.AddComponent<UnityView>();
            unityView.Setup(entity);
            go.transform.SetParent(_viewsParent);
            entity.AddView(go);
            go.Link(entity);
        }
    }
}
