using System;
using UnityEngine;
using Entitas;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private Transform _views;
    private Systems _systems;
    
    private void Start()
    {
        Contexts contexts = Contexts.sharedInstance;
        UnityTimeService timeService = new UnityTimeService();

        _systems = new Feature()
            .Add(new KeyboardInputSystem(contexts))
            .Add(new CreateEnemiesSystem(contexts, timeService))
            .Add(new AddGameViewSystem(contexts, _views))
            .Add(new PlayerMoveSystem(contexts, timeService))
            .Add(new EnemiesMoveSystem(contexts, timeService))
            .Add(new RenderSpriteSystem(contexts))
            .Add(new RenderMoveSystem(contexts));

        contexts.game.isPlayer = true;
        
        var playerEntity = contexts.game.playerEntity;
        playerEntity.isPlayer = true;
        playerEntity.AddMoveSpeed(500);
        playerEntity.AddPosition(0,-490);
        playerEntity.AddSprite("rectangle");
        
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
