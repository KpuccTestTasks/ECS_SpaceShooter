//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Bullet = 0;
    public const int Destroyed = 1;
    public const int DestroyedListener = 2;
    public const int Enemy = 3;
    public const int MoveSpeed = 4;
    public const int Player = 5;
    public const int Position = 6;
    public const int View = 7;

    public const int TotalComponents = 8;

    public static readonly string[] componentNames = {
        "Bullet",
        "Destroyed",
        "DestroyedListener",
        "Enemy",
        "MoveSpeed",
        "Player",
        "Position",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(BulletComponent),
        typeof(DestroyedComponent),
        typeof(DestroyedListenerComponent),
        typeof(EnemyComponent),
        typeof(MoveSpeedComponent),
        typeof(PlayerComponent),
        typeof(PositionComponent),
        typeof(ViewComponent)
    };
}
