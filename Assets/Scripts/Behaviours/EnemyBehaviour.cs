using Entitas.Unity;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameEntity _enemyEntity;
    
    public void SetupBehaviour(GameEntity enemyEntity)
    {
        _enemyEntity = enemyEntity;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerBehaviour playerBehaviour = col.GetComponent<PlayerBehaviour>();
            
        if (playerBehaviour != null)
        {
            Debug.Log("Collided player");
            return;
        }

        BulletBehaviour bulletBehaviour = col.GetComponent<BulletBehaviour>();
        
        if (bulletBehaviour != null)
        {
            _enemyEntity.isDestroyed = true;
            gameObject.Unlink();
            Destroy(gameObject);
            return;
        }
    }
}
