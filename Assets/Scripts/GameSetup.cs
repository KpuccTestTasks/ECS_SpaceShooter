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

        _systems = new Feature()
            .Add(new AddGameViewSystem(contexts, _views))
            .Add(new RenderSpriteSystem(contexts))
            .Add(new KeyboardInputSystem(contexts))
            .Add(new PlayerMoveSystem(contexts, new UnityTimeService()))
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
