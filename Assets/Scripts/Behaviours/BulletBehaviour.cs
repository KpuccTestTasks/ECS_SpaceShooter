using System;
using Entitas.Unity;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private GameEntity _bulletEntity;

    public void SetupBehaviour(GameEntity bulletEntity)
    {
        _bulletEntity = bulletEntity;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        EnemyBehaviour enemyBehaviour = col.GetComponent<EnemyBehaviour>();
        
        if (enemyBehaviour != null)
        {
            DestroyBullet();
            return;
        }

        if (col.CompareTag("BulletDestroyer"))
        {
            DestroyBullet();
            return;
        }
    }

    private void DestroyBullet()
    {
        _bulletEntity.isDestroyed = true;
        gameObject.Unlink();
        Destroy(gameObject);
    }
}
