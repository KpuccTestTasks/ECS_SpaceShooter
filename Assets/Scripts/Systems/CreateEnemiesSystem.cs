using UnityEngine;
using Entitas;
using Entitas.Unity;

public class CreateEnemiesSystem : IExecuteSystem
{
    private GameContext _gameContext;
    private ITimeService _timeService;
    private IInstantiateService _instantiateService;
    private float _timePassedAfterSpawn;

    private const int SpawnEnemyDelay = 3;
    
    public CreateEnemiesSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
        _timeService = contexts.meta.timeService.TimeService;
        _instantiateService = contexts.meta.instantiateService.InstantiateService;
    }
    
    public void Execute()
    {
        _timePassedAfterSpawn += _timeService.GetFrameTime();

        if (_timePassedAfterSpawn < SpawnEnemyDelay)
            return;

        var enemyEntity = _gameContext.CreateEntity();
        enemyEntity.isEnemy = true;
        enemyEntity.AddMoveSpeed(300);
        
        // убрать рандом в сервис юнити
        enemyEntity.AddPosition(Random.Range(-700, 700), 600);

        var enemyBehaviour = _instantiateService.InstantiateGameObject("Enemy").GetComponent<EnemyBehaviour>();
        enemyBehaviour.gameObject.Link(enemyEntity);
        enemyBehaviour.SetupBehaviour(enemyEntity);
        enemyEntity.AddView(enemyBehaviour.gameObject);

        _timePassedAfterSpawn = 0;
    }
}
