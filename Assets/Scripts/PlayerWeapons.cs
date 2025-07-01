using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] ParticleSystem laser;

    float firingTime = 1f;
    float counter = 0f;
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
        counter += Time.deltaTime;
        if (counter > firingTime)
        {
            laserControl.enabled = false;
        }
    }

    void OnFire(InputValue value)
    {
        Debug.Log(value.isPressed);
        laserControl.enabled = true;
        counter = 0;
    }
}
