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

        var metaContext = contexts.meta;
        metaContext.ReplaceInstantiateService(new UnityInstantiate());
        metaContext.ReplaceTimeService(new UnityTimeService());
        
        _systems = new Feature()
            .Add(new SetupPlayerSystem(contexts, _views))
            .Add(new CreateEnemiesSystem(contexts, _views))
            .Add(new KeyboardInputSystem(contexts))
            .Add(new CreateBulletSystem(contexts, _views))
            .Add(new PlayerMoveSystem(contexts))
            .Add(new EnemiesMoveSystem(contexts))
            .Add(new BulletMoveSystem(contexts))
            .Add(new RenderMoveSystem(contexts))
            .Add(new DestroyedEventSystem(contexts))
            .Add(new DestroyEntitySystem(contexts));

        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
