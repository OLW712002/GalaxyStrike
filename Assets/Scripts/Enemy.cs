using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDestroyedVFX;
    [SerializeField] int enemyHealth = 3;
    [SerializeField] int scoreValue = 10;

    Scoreboard scoreboard;

    private void Awake()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        enemyHealth--;
        if (enemyHealth <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            GameObject vfx = Instantiate(enemyDestroyedVFX, transform.position, Quaternion.identity);
            Destroy(vfx, 3f);
            Destroy(gameObject);
        }
    }
}
