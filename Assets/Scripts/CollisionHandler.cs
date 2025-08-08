using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using URPGlitch;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerDestroyedVFX;
    [SerializeField] PlayableDirector masterTimeline;
    [SerializeField] Volume portraitVolume;
    [SerializeField] GameObject portraitWindow;

    DigitalGlitchVolume portraitGlitch;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ProcessPortraitGlitch();
        ProcessStopTimeline();
        ProcessPlayerExplosion();
    }

    private void ProcessPortraitGlitch()
    {
        portraitWindow.SetActive(true);
        if (portraitVolume.profile.TryGet(out portraitGlitch))
        {
            portraitGlitch.intensity.value = 0.9f;
        }
        else Debug.Log("CantFindGlitchVolume");
    }

    private void ProcessStopTimeline()
    {
        FindFirstObjectByType<GameSceneManager>().ReloadScene();
        masterTimeline.playableGraph.Stop();
    }

    private void ProcessPlayerExplosion()
    {
        GameObject vfx = Instantiate(playerDestroyedVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 2f);
        Destroy(gameObject);
    }
}
