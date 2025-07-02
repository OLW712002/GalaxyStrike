using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] ParticleSystem laser;

    bool isFiring = false;
    ParticleSystem.EmissionModule laserControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        laserControl = laser.emission;
        laserControl.enabled = false;
    }

    // Update is called once per frame
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
        laserControl.enabled = isFiring;
    }
}
