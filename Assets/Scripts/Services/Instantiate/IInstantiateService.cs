using UnityEngine;

public interface IInstantiateService
{
    GameObject InstantiateGameObject(string prefabPath, object transform);
}
