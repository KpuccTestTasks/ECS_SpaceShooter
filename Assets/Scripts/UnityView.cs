using System.Collections;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;

public class UnityView : MonoBehaviour, IDestroyListener
{
    public void Setup(GameEntity entity)
    {
        entity.AddDestroyListener(this);
    }
    
    void IDestroyListener.OnDestroy(GameEntity entity)
    {
        gameObject.Unlink();
        entity.RemoveDestroyListener(this);
        Destroy(gameObject);
    }
}
