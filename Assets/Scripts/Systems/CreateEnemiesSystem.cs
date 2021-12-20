using UnityEngine;
using Entitas;

public class CreateEnemiesSystem : IExecuteSystem
{
    private GameContext _gameContext;
    private ITimeService _timeService;
    private float _timePassedAfterSpawn;

    private const int SpawnEnemyDelay = 3;
    
    public CreateEnemiesSystem(Contexts contexts, ITimeService timeService)
    {
        _gameContext = contexts.game;
        _timeService = timeService;
    }
    
    public void Execute()
    {
        _timePassedAfterSpawn += _timeService.GetFrameTime();

        if (_timePassedAfterSpawn < SpawnEnemyDelay)
            return;

        var enemyEntity = _gameContext.CreateEntity();
        enemyEntity.isEnemy = true;
        enemyEntity.AddMoveSpeed(300);
        enemyEntity.AddSprite("round");
        enemyEntity.AddPosition(Random.Range(-700, 700), 600);

        _timePassedAfterSpawn = 0;
    }
}
