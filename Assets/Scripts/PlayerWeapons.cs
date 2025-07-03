using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] ParticleSystem[] lasers;

    bool isFiring = false;
    ParticleSystem.EmissionModule laserControl;

    void Start()
    {
        //laserControl = laser.emission;
    }

    void Update()
    {
        ProcessFiring();
    }

    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach (ParticleSystem laser in lasers)
        {
            laserControl = laser.emission;
            laserControl.enabled = isFiring;
        }
    }
}
