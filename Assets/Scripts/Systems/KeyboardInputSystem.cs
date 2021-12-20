using Entitas;
using UnityEngine;

public class KeyboardInputSystem : IInitializeSystem, IExecuteSystem
{
    private InputEntity _moveRightButton;
    private InputEntity _moveLeftButton;
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
        if (Input.GetKeyDown("d"))
            _moveRightButton.isButtonDown = true;
        
        if (Input.GetKeyUp("d"))
            _moveRightButton.isButtonDown = false;
        
        if (Input.GetKeyDown("a"))
            _moveLeftButton.isButtonDown = true;
        
        if (Input.GetKeyUp("a"))
            _moveLeftButton.isButtonDown = false;
    }
}
