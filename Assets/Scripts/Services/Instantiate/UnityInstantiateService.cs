using UnityEngine;

public class UnityInstantiate : IInstantiateService
{
    private Transform _instantiatetransform;

    public UnityInstantiate(Transform instantiatePlace)
    {
        _instantiatetransform = instantiatePlace;
    }
    
    public GameObject InstantiateGameObject(string path)
    {
        return GameObject.Instantiate(Resources.Load<GameObject>(path), _instantiatetransform);
    }
}
