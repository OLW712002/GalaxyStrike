using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;

    private void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 3f);
        Destroy(gameObject);
    }
}
