using UnityEngine;
using UnityEngine.Playables;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerDestroyedVFX;
    [SerializeField] PlayableDirector masterTimeline;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        masterTimeline.playableGraph.Stop();
        GameObject vfx = Instantiate(playerDestroyedVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 2f);
        Destroy(gameObject);
    }
}
