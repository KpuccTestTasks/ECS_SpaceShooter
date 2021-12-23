using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public class CreateBulletSystem : ReactiveSystem<InputEntity>
{
    private GameContext _gameContext;
    private MetaContext _metaContext;
    private object _views;

    public CreateBulletSystem(Contexts contexts, object views) : base(contexts.input)
    {
        _gameContext = contexts.game;
        _metaContext = contexts.meta;
        _views = views;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.ShootButton);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isButtonDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var playerEntity = _gameContext.playerEntity;

        if (playerEntity == null)
            return;
        
        foreach (var entity in entities)
        {
            var bulletEntity = _gameContext.CreateEntity();
            bulletEntity.isBullet = true;
            bulletEntity.AddMoveSpeed(1000);

            var bulletSpawnerPosition = playerEntity.view.View.GetComponent<PlayerBehaviour>().GetBulletSpawnerPosition();
            var bulletView = _metaContext.instantiateService.InstantiateService.InstantiateGameObject("Bullet",
                _views);
            bulletEntity.AddView(bulletView);
            bulletEntity.AddPosition(bulletSpawnerPosition.x + playerEntity.position.PositionX, bulletSpawnerPosition.y + playerEntity.position.PositionY);
            bulletView.gameObject.Link(bulletEntity);
            bulletView.GetComponent<BulletBehaviour>().SetupBehaviour(bulletEntity);
            
            entity.Destroy();
        }
    }
}
