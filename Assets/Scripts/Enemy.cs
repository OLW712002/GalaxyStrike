using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDestroyedVFX;
    [SerializeField] int enemyHealth = 3;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        enemyHealth--;
        if (enemyHealth <= 0)
        {
            GameObject vfx = Instantiate(enemyDestroyedVFX, transform.position, Quaternion.identity);
            Destroy(vfx, 3f);
            Destroy(gameObject);
        }
    }
}
