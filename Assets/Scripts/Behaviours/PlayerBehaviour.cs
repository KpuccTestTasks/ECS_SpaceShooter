using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private RectTransform _bulletSpawner;

    public Vector2 GetBulletSpawnerPosition()
    {
        return _bulletSpawner.anchoredPosition;
    }

    public Vector2 GetStartPosition()
    {
        return ((RectTransform)transform).anchoredPosition;
    }
}
