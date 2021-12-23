using UnityEngine;

public class UnityInstantiate : IInstantiateService
{
    public GameObject InstantiateGameObject(string path, object transform)
    {
        return GameObject.Instantiate(Resources.Load<GameObject>(path), (Transform)transform);
    }
}
