using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDestroyedVFX;

    private void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(enemyDestroyedVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 3f);
        Destroy(gameObject);
    }
}
