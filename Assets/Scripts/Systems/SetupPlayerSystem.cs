using Entitas;
using Entitas.Unity;

public class SetupPlayerSystem : IInitializeSystem
{
    private GameContext _gameContext;
    private IInstantiateService _instantiateService;

    public SetupPlayerSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
        _instantiateService = contexts.meta.instantiateService.InstantiateService;
    }
    
    public void Initialize()
    {
        _gameContext.isPlayer = true;
        
        var playerEntity = _gameContext.playerEntity;
        playerEntity.isPlayer = true;
        playerEntity.AddMoveSpeed(500);
        playerEntity.AddView(_instantiateService.InstantiateGameObject("Player"));

        var playerBehaviour = playerEntity.view.View.GetComponent<PlayerBehaviour>();
        var startPosition = playerBehaviour.GetStartPosition();
        playerEntity.AddPosition(startPosition.x,startPosition.y);
        playerBehaviour.gameObject.Link(playerEntity);
    }
}
