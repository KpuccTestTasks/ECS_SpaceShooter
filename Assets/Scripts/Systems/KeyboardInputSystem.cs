using Entitas;
using UnityEngine;

public class KeyboardInputSystem : IInitializeSystem, IExecuteSystem
{
    private InputEntity _moveRightButton;
    private InputEntity _moveLeftButton;
    private InputEntity _shootButton;
    private InputContext _inputContexts;

    public KeyboardInputSystem(Contexts contexts)
    {
        _inputContexts = contexts.input;
    }

    public void Initialize()
    {
        _inputContexts.isMoveLeftButton = true;
        _moveLeftButton = _inputContexts.moveLeftButtonEntity;

        _inputContexts.isMoveRightButton = true;
        _moveRightButton = _inputContexts.moveRightButtonEntity;
    }

    public void Execute()
    {
        UpdateInputEntityState(_moveRightButton, "d");
        UpdateInputEntityState(_moveLeftButton, "a");

        if (Input.GetKeyDown("space"))
        {
            var inputShootEntity = _inputContexts.CreateEntity();
            inputShootEntity.isButtonDown = true;
            inputShootEntity.isShootButton = true;
        }
    }

    private void UpdateInputEntityState(InputEntity entity, string keyName)
    {
        if (Input.GetKeyDown(keyName))
            entity.isButtonDown = true;

        if (Input.GetKeyUp(keyName))
            entity.isButtonDown = false;
    }
}
